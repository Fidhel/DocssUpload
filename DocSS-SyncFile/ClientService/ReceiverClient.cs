using DocSS_SyncFile.Controller;
using DocSS_SyncFile.Dao;
using DocSS_SyncFile.Model;
using DocSS_SyncFile.Utilities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;


namespace DocSS_SyncFile.ClientService
{
    class ReceiverClient
    {

        private static String PRD = "http://login.docss.com.br:8006/DOCS-Receiver/service/";
        private static String HML = "http://suportediversa.ddns.net:8006/DOCS-Receiver/service/";
        private static String DSV = "http://localhost:8080/DOCS-Receiver/service/";
        protected static String URL_VIGENTE = PRD;
        private static String METODO_ENVIO = "rest/send/arquivo";
        private static String METODO_PART = "rest/send/part";
        private static String METODO_ENVIO_TESTE = "rest/send/upload";
        protected static String checkUpdate = "rest/send/autoupdate/";
        protected static String TIPO_ENVIO = "application/xml";




        protected static async Task restTemplateAsync(HttpContent content, String servico)
        {

            using (var client = new HttpClient())
            {

                client.BaseAddress = new Uri(URL_VIGENTE);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(TIPO_ENVIO));

                HttpResponseMessage messageResponsePost = await client.PostAsync(servico, content);
            }
        }

        public static void swithServer(String environment){

            switch (environment) {
                case "PRD":
                    URL_VIGENTE = PRD;
                    break;

                case "HML":
                    URL_VIGENTE = HML;
                    break;

            }
        }

        public static Boolean checarServidor(Profile prf)
        {
            Boolean resultado = true;


            try
            {

                using (var client = new HttpClient())
                {

                    client.BaseAddress = new Uri(URL_VIGENTE);


                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/xml"));


                    HttpResponseMessage messageResponseGet = client.GetAsync("rest/send/" + prf.instalacao).Result;

                    if (messageResponseGet.IsSuccessStatusCode)
                    {
                        String ultimoRelease = messageResponseGet.Content.ReadAsStringAsync().Result;
                        UpdateClient.checarVersao(ultimoRelease);
                        resultado = true;
                    }

                }
            }
            catch (AggregateException e)
            {
                DaoTxtImpl.regException(e);
            }


            return resultado;
        }


        
        public static String checarEnvioArquivo(DocsFileVo docsFileVo)
        {
            ArquivosController gerenciador = new ArquivosController();

            using (var client = new HttpClient())
            {
                String key = null;
                client.BaseAddress = new Uri(URL_VIGENTE);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(TIPO_ENVIO));

                HttpContent content = new ObjectContent<DocsFileVo>(docsFileVo, new CustomNamespaceXmlFormatter());
                HttpResponseMessage messageResponsePost = client.PostAsync(METODO_ENVIO, content).Result;

                if (messageResponsePost.IsSuccessStatusCode)
                {
                    key = messageResponsePost.Content.ReadAsStringAsync().Result;
                }
                return key;
            }
        }

        public static async Task SincronizarArquivos(DocsFileVo docsFileVo, Profile prf)
        {
            ArquivosController gerenciador = new ArquivosController();

            using (var client = new HttpClient())
            {

                client.BaseAddress = new Uri(URL_VIGENTE);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(TIPO_ENVIO));

                /*CONTROLE DO POOL DE ENVIO DE ARQUIVOS*/
                PoolControle.permissaoEnvioReceiver();

                HttpContent content = new ObjectContent<DocsFileVo>(docsFileVo, new CustomNamespaceXmlFormatter());
                HttpResponseMessage messageResponsePost = await client.PostAsync(METODO_ENVIO, content);
                PoolControle.liberarRecurso();

                if (messageResponsePost.IsSuccessStatusCode)
                {
                    Debug.WriteLine(messageResponsePost.Content);
                    String key = await messageResponsePost.Content.ReadAsStringAsync();
                    if (new ArquivosController().validaKey(key))
                    {
                        ArquivosController.registrarArquivoEnviadoSucesso(key, docsFileVo);
                    }
                }
            }
        }


        public static Boolean SincronizarArquivosSerial(DocsFileVo docsFileVo, Profile prf)
        {

            ArquivosController gerenciador = new ArquivosController();

            Boolean sucessoEnvio = false;
            using (var client = new HttpClient())
            {

                client.BaseAddress = new Uri(URL_VIGENTE);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(TIPO_ENVIO));



                HttpContent content = new ObjectContent<DocsFileVo>(docsFileVo, new CustomNamespaceXmlFormatter());
                HttpResponseMessage messageResponsePost = client.PostAsync(METODO_PART, content).Result;

                if (messageResponsePost.IsSuccessStatusCode)
                {

                    String key = messageResponsePost.Content.ReadAsStringAsync().Result;
                    if (key.Equals("OK", StringComparison.InvariantCultureIgnoreCase))
                    {
                        sucessoEnvio = true;
                    }
                }
            }
            return sucessoEnvio;
        }

        public static async Task enviarArquivo(DocsFileVo docsFileVo, Profile prf)
        {
            ArquivosController gerenciador = new ArquivosController();

            if (!PoolControle.poolGrandesArquivos(docsFileVo)) return;

            using (var client = new HttpClient())
            {
                try{
                    client.BaseAddress = new Uri(URL_VIGENTE);
                client.DefaultRequestHeaders.Accept.Clear();
                //client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("multipart/form-data"));


                var multContent = new MultipartFormDataContent();

                docsFileVo.arquivo = null;
                multContent.Add(new ObjectContent<DocsFileVo>(docsFileVo, new CustomNamespaceXmlFormatter()), "docsvo");
                multContent.Add(new StreamContent(File.OpenRead(docsFileVo.caminhoAbsoluto)), "filedata");

                /*CONTROLE DO POOL DE ENVIO DE ARQUIVOS*/
                PoolControle.permissaoEnvioReceiver();

                

                    HttpContent content = new StreamContent(File.OpenRead(docsFileVo.caminhoAbsoluto));
                    HttpResponseMessage messageResponsePost = client.PostAsync(METODO_ENVIO_TESTE, multContent).Result;
                    PoolControle.liberarRecurso();

                    if (messageResponsePost.IsSuccessStatusCode)
                    {
                        String key = messageResponsePost.Content.ReadAsStringAsync().Result;
                        DaoTxtImpl.regMsg("Arquivo: " + docsFileVo.nomeArquivo + " Env.Sucesso KEY:" + key);
                        if (new ArquivosController().validaKey(key))
                        {
                            DaoAcess dao = new DaoAcess();
                            dao.insertSendFileAndClearMonitor(key, docsFileVo);

                        }
                    }
                    else {
                        DaoTxtImpl.regMsg("Arquivo: " + docsFileVo.nomeArquivo + " Falha");
                    }
                }
                
                catch (Exception e){
                    DaoTxtImpl.regException(e);
                }
            }
        }

    }
}

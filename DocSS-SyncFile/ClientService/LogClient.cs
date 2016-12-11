using DocSS_SyncFile.Controller;
using DocSS_SyncFile.Model;
using DocSS_SyncFile.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DocSS_SyncFile.ClientService
{
    class LogClient : ReceiverClient
    {


        private LogSend l;
        private static LogSend log;
        private static readonly String URL_REST_LOG = "rest/send/logupload";



        private static void popularLogSend(Profile prf)
        {
            log = new LogSend();
            log.codigoInstalacao = prf.instalacao;
            log.usuario = prf.usuario;
        }

        public LogClient(Profile prf)
        {
            l = new LogSend();
            l.codigoInstalacao = prf.instalacao;
            l.usuario = prf.usuario;
        }


        private static void enviarLogUpload()
        {
            LogClient.restTemplateAsync(new ObjectContent<LogSend>(log, new CustomNamespaceXmlFormatter()), URL_REST_LOG);
        }



        public static bool logServicoIniciado(Profile prf,DocssDirectory d)
        {
            LogClient.popularLogSend(prf);
            log.codStatus = "0";
            log.descricaoStatus = "UPLOAD_APP_INICIADO";
            log.arquivosEnviados = prf.usuario;
            /*log.cnpjEnvio = d.cnpj;*/
            LogClient.enviarLogUpload();
            return true;
        }

        public static bool logServicoEmExecucao(Profile prf)
        {

            LogClient.popularLogSend(prf);
            log.codStatus = "1";
            log.descricaoStatus = "UPLOAD_APP_ATIVO";
            log.arquivosEnviados = prf.usuario;
            log.cnpjEnvio = "";/*TODO ANALISAR*/
            LogClient.enviarLogUpload();

            return true;
        }

        public static bool logServicoProcessandoArquivos(Profile prf, int qtd, StringBuilder str, DocssDirectory d)
        {

            LogClient.popularLogSend(prf);
            log.codStatus = "2";
            log.descricaoStatus = "UPLOAD_APP_ENVIANDO " + qtd + " ARQUIVOS";
            log.arquivosEnviados = str.ToString();
            log.cnpjEnvio = d.cnpj;
            LogClient.enviarLogUpload();
            return true;
        }

        public static bool logServicoProcessandoArquivosSucesso(Profile prf, int qtd, StringBuilder str, DocssDirectory d)
        {

            LogClient.popularLogSend(prf);
            log.codStatus = "3";
            log.descricaoStatus = "UPLOAD_APP_ENVIADO_COM_SUCESSO " + qtd + " ARQUIVOS";
            log.arquivosEnviados = str.ToString();
            log.cnpjEnvio = d.cnpj;
            LogClient.enviarLogUpload();
            return true;
        }



        public static bool logServicoEncerrado(Profile prf)
        {

            LogClient.popularLogSend(prf);
            log.codStatus = "5";
            log.descricaoStatus = "UPLOAD_APP_ENCERRADO";
            log.arquivosEnviados = prf.usuario;
            log.cnpjEnvio = "";/*TODO ANALISAR*/
            LogClient.enviarLogUpload();
            System.Threading.Thread.Sleep(2000);
            return true;
        }

    }
}

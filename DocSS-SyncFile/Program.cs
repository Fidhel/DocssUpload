using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Xml.Linq;
using System.Text;
using System.Xml.Serialization;
using System.Net.Http.Formatting;
using DocSS_SyncFile.Model;
using DocSS_SyncFile.Controller;
using DocSS_SyncFile.Dao;
using System.Threading;
using DocSS_SyncFile.Utilities;
using DocSS_SyncFile.ClientService;

namespace DocSS_SyncFile
{


    
    

public static class Program
    {

        static Label labelStatus;
        static int maxPool = 0;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {


            try
            {



                String statusExecucao = Process.GetCurrentProcess().ProcessName;
                Process[] l = Process.GetProcessesByName(statusExecucao);


                if (l.Length <= 1)
                {



                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    
                    Application.Run(new Form1());


                    
                }
                else {
                    MessageBox.Show("Aplicação já está em execução.", "DocSS-Upload");
                    Application.Exit();
                }

            }
            catch (Exception ex) {
                DaoTxtImpl.regException(ex);
            }



        }



        


        public static int enviarArquivos(String diretorioUpload) {

            ArquivosController gerenciador = new ArquivosController();

            

            // List<DocsFileInfo> ListDocsFileInfo = gerenciador.listarArquivosDiretorio(diretorioUpload);
            List<DocsFileVo> ListDocsFileInfo = gerenciador.carregarArquivos(diretorioUpload);

            
            int x = 0;
            int total = 0;
           foreach (DocsFileVo docsFileVo in ListDocsFileInfo) {

                total = x + 1;
                labelStatus.Text = "Enviando... "+total+" de "+ListDocsFileInfo.Count;
                DocsFileVo doc = gerenciador.popularEnvioDocsFileVo(docsFileVo,null,null);
               Program.SincronizarArquivos(doc);
                
                x++;
           }
            return x;
        }


        public static void poolControl() {
            maxPool++;
            if (maxPool == 1000) {
                //20 000 -  20 seconds
                System.Threading.Thread.Sleep(5000);
            }
            maxPool = 0;
            return;
        }

        public static async Task SincronizarArquivos(DocsFileVo docsFileVo)
        {

            using (var client = new HttpClient())
            {

                 client.BaseAddress = new Uri("http://suportediversa.ddns.net:8006/DOCS-Receiver/service/");
            
                //client.BaseAddress = new Uri("http://localhost:8080/DOCS-Receiver/service/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/xml"));

                
                HttpResponseMessage messageResponseGet = await client.GetAsync("rest/send/69");
               
                if (messageResponseGet.IsSuccessStatusCode) {
                    
                    Debug.WriteLine(await messageResponseGet.Content.ReadAsStringAsync());
                }
                


                //HTTP POST
                //var docsFileVo = new DocsFileVo() { nome = "LIGHT.pdf", arquivo = File.ReadAllBytes("C:\\temp\\LIGHT.pdf") };

                poolControl();

                HttpContent content = new ObjectContent<DocsFileVo>(docsFileVo, new CustomNamespaceXmlFormatter());
                HttpResponseMessage messageResponsePost = await client.PostAsync("rest/send/arquivo", content);
                //HttpResponseMessage messageResponsePost = client.PostAsync("rest/send/arquivo", content).Result;

                if (messageResponsePost.IsSuccessStatusCode)
                {
                    DaoAcess dao = new DaoAcess();
                    //dao.salvarEnvio(docsFileVo);
                    Debug.WriteLine(await messageResponsePost.Content.ReadAsStringAsync());
                }
               
            }

        }
    }
}

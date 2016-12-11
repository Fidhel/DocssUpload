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
    class UpdateClient : ReceiverClient
    {
        private static String nomeVersao = "DocssUpload.exe";
        public static String releaseServer;

        private static String pastaAtualizacaoApp = VariaveisGlobais.appData() + "\\DocSSync\\update\\";

        private static String recuperarNomeVersao(String release)
        {
            return nomeVersao.Replace(".exe", "." + release + ".exe");
        }

        private static void downloadUltimoVersao(String ultimoRelease)
        {
            WebClient client = new WebClient();
            client.DownloadFileAsync(new Uri(URL_VIGENTE + checkUpdate), pastaAtualizacaoApp + recuperarNomeVersao(ultimoRelease));
        }

        public static bool checarVersao(String ultimoRelease)
        {
            releaseServer = ultimoRelease;
            return checarVersao();
        }


        public static bool checarVersao()
        {


            float floatUltimoRelease = float.Parse(releaseServer);
            float floatVersaoInstalada = float.Parse(VariaveisGlobais.productVersion);
            bool isUpdate = false;

            if (floatUltimoRelease > floatVersaoInstalada)
            {
                isUpdate = true;
                if (!File.Exists(pastaAtualizacaoApp + recuperarNomeVersao(releaseServer)))
                {
                    UpdateClient.downloadUltimoVersao(releaseServer);
                }
            }
            return isUpdate;
        }

        private static String getDirArquivoUpdate()
        {
            return pastaAtualizacaoApp + recuperarNomeVersao(releaseServer);
        }

        public static int atualizarApp()
        {

            if (releaseServer == null)
            {
                return (int)VariaveisGlobais.UpdateApp.AGUARDANDO_DOWNLOAD;
            }

            if (checarVersao(releaseServer))
            {
                if (!DocssUtil.arquivoBloqueado(new FileInfo(UpdateClient.getDirArquivoUpdate())))
                {
                    System.Diagnostics.Process.Start(UpdateClient.getDirArquivoUpdate());
                }
                else {
                    return (int)VariaveisGlobais.UpdateApp.AGUARDANDO_DOWNLOAD;
                }
            }
            else {
                return (int)VariaveisGlobais.UpdateApp.ULITMA_VERSAO_INSTALADA;
            };
            return 3;
        }

    }
}

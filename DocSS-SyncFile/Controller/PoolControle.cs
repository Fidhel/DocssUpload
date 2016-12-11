using DocSS_SyncFile.ClientService;
using DocSS_SyncFile.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocSS_SyncFile.Controller
{
    class PoolControle
    {

        private static int qtdPool = 0;
        private static DocsFileVo docs;


        public static void liberarPoolGrandesArquivos()
        {
            if (docs != null)
            {
                String key = ReceiverClient.checarEnvioArquivo(docs);
                if (new ArquivosController().validaKey(key))
                {
                    docs = null;
                }
            }
        }
        public static Boolean poolGrandesArquivos(DocsFileVo send)
        {
            Boolean b = true;
            if (send.tamanhoArquivo > 10000000)
            {
                if (docs == null)
                {
                    docs = send;
                    docs.arquivo = null;
                }
                else {
                    b = false;
                }
            }
            return b;
        }

        public static void permissaoEnvioReceiver()
        {
            while (true)
            {
                if (qtdPool <= 50)
                {
                    qtdPool++;
                    return;
                }
            }
        }

        public static void liberarRecurso()
        {
            qtdPool--;
        }
        public static void poolControl()
        {
            qtdPool++;
            if (qtdPool == 300)
            {
                //20 000 -  20 seconds
                System.Threading.Thread.Sleep(1000);
            }
            qtdPool = 0;
            return;
        }

    }
}

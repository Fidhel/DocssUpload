using DocSS_SyncFile.Model;
using DocSS_SyncFile.Utilities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocSS_SyncFile.Dao
{
    class DaoTxtImpl
    {

        private static String DOCS_DATA_FOLDER = null;
        private static string DESTINO_DATA_SEND = null;
        private static string FILE_DEBUG = null;

        private static void checarDestinoLog()
        {
            if (DOCS_DATA_FOLDER == null || DESTINO_DATA_SEND == null)
            {
                DOCS_DATA_FOLDER = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\DocSSync\\";
                DESTINO_DATA_SEND = DOCS_DATA_FOLDER + "docssLog.log";
            }
        }


        private static void checarDestinoDebug()
        {
            if (DOCS_DATA_FOLDER == null || DESTINO_DATA_SEND == null)
            {
                DOCS_DATA_FOLDER = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\DocSSync\\";
                FILE_DEBUG = DOCS_DATA_FOLDER + "docssDebug.log";
            }
        }






        private static void registrarEnvio(String key, DocsFileVo docsFile)
        {
            DaoTxtImpl.checarDestinoLog();
            StreamWriter file = DaoTxtImpl.recuperarArquivo(DESTINO_DATA_SEND);
            file.WriteLine(docsFile.caminhoAbsoluto + "#" + docsFile.ultimaModificacao + "#" + key);
            file.Close();
        }

        public static void regException(Exception e)
        {
            DaoTxtImpl.checarDestinoLog();
            StreamWriter file = DaoTxtImpl.recuperarArquivo(DESTINO_DATA_SEND);

            file.WriteLine(DateTime.Now.ToString()+" - "+e.Message+":"+e.StackTrace);
            file.Close();
        }

        public static void regMsg(String msg)
        {
            if (DocssUtil.debugMode){
                DaoTxtImpl.checarDestinoDebug();
                StreamWriter file = DaoTxtImpl.recuperarArquivo(FILE_DEBUG);
                file.WriteLine(DateTime.Now.ToString() + " - " + msg);
                file.Close();
            }
        }

        private static StreamWriter recuperarArquivo(String destino)
        {
            StreamWriter sw;
            if (!File.Exists(destino))
            {
                sw = File.CreateText(destino);
            }
            else {
                sw = File.AppendText(destino);
            }
            return sw;
        }
    }
}

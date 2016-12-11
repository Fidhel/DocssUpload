using DocSS_SyncFile;
using DocSS_SyncFile.Controller;
using DocSS_SyncFile.Model;
using DocSS_SyncFile.Utilities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocSS_SyncFile.Dao
{

    

    


   

        class DaoAcess
    {
        private Profile profile;
        private static DaoSqLiteImpl daoSqLite;
        public  static String DOCS_DATA_FOLDER = "\\DocSSync\\";
        


      
       
       static DaoAcess(){
            DOCS_DATA_FOLDER = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + DOCS_DATA_FOLDER;
            AppDomain.CurrentDomain.SetData("DataDirectory", DOCS_DATA_FOLDER);
            daoSqLite = new DaoSqLiteImpl();
       }


        public List<DocssDirectory> listDocssDirectory()
        {
            return daoSqLite.listDocssDirectory();
        }

        public void atualizarStatusLogEnvioSucesso(String cnpj, List<DocsFileVo> listDocs) {
            daoSqLite.atualizarStatusLogEnvioSucesso(cnpj, listDocs);
        }

       public Profile getProfile() {
            profile = daoSqLite.getProfile();
            verificarProfile(profile);
            return profile;
        }

        public int qtdPendencia() {
            return daoSqLite.qtdPendenteImpl();
        }

        public List<DocsFileVo> listarArquivosPendentesLogEnvio(String cnpj) {
            return daoSqLite.listarArquivosPendentesLogEnvioImpl(cnpj);
        }


        public void insertSendFileAndClearMonitor(String key,DocsFileVo d) {
            daoSqLite.registrarEnvio(key,d);
            daoSqLite.deleteWaitingSendFile(d);
        }

        private void verificarProfile(Profile profile) {
            int s = 0;

            if (profile.listDocssDirectory.Count <= 0) {

                DocssDirectory cnpjDiretorio = new DocssDirectory();
                cnpjDiretorio.cnpj = "0000000000000";
                cnpjDiretorio.path = Environment.GetFolderPath(Environment.SpecialFolder.Personal) + "\\DocSS";
                cnpjDiretorio.subfolder = true;
                DaoSqLiteImpl.incluirCnpjDiretorio(cnpjDiretorio);
                cnpjDiretorio.path = cnpjDiretorio.path + "\\";
                List<DocssDirectory>  list = new List<DocssDirectory>();
                list.Add(cnpjDiretorio);
                profile.listDocssDirectory = list;
                s++;
            }
           

            if (string.IsNullOrEmpty(profile.instalacao))
            {
                
                profile.instalacao = DocssUtil.installationName(profile);
                s++;
            }
            if(s>0)daoSqLite.atualizarProfile(profile);
        }

        public void atualizarProfile(Profile prf) {
            //this.atualizarProfileTxt(prf);
            daoSqLite.atualizarProfile(prf);

            /*
            DaoAcess.DIRETORIO_ENVIO = prf.diretorio;
            using (var context = new Database1Entities())
            {
                Profile update = context.Profile.First<Profile>();
                update.usuario = prf.usuario;
                update.cnpj = prf.cnpj;
                update.diretorio = prf.diretorio;
                context.SaveChanges();
            }
            */
        }

        public void insertWaitingSend(DocsFileVo d) {
            DaoSqLiteImpl daoSQL = new DaoSqLiteImpl();
            daoSQL.insertWaitingSendImpl(d);
        }

        public void insertWaitingSend(List<DocsFileVo> l)
        {
            DaoSqLiteImpl daoSQL = new DaoSqLiteImpl();
            List<DocsFileVo> listSend = new List<DocsFileVo>();
            int count = 0;
            foreach (DocsFileVo d in l)
            {
                count++;
                if (!daoSQL.existWaitingSendImpl(d)) {
                    listSend.Add(d);
                }
            }
            foreach (DocsFileVo d in listSend) { 
                daoSQL.insertWaitingSendImpl(d);
            }
        }

        public List<String> listNameFilesWaitingDirectory(DocssDirectory d) {
               return  daoSqLite.listFilesWaitingDirectoryImpl(d);
        }





        public Boolean salvarEnvio(String key ,DocsFileVo docs,Profile prf) {
            /*
            using (var context = new DatabaseEntitiesRegEnv()) {
                REG_ARQ_ENV reg = context.REG_ARQ_ENV.Create();
                reg.NOME_ARQ = docs.nomeArquivo;
                reg.EXTENSAO_ARQ = docs.extensaoArquivo;
                reg.TAMANHO_ARQ = (int)docs.tamanhoArquivo;
                reg.LOCAL_ORIG_ARQ = docs.caminhoAbsoluto;
                reg.DATA_ENV_ARQ = docs.dateTimeEnvio;


                reg.USUARIO = prf.usuario;
                reg.CNPJ_ENV = Convert.ToInt64(prf.cnpj);
                reg.COD_INSTALACAO = prf.cnpj;
                reg.STATUS_ENV = "ENVIADO";

                context.REG_ARQ_ENV.Add(reg);
                context.SaveChanges();
            }
            */
            new DaoSqLiteImpl().registrarEnvio(key, docs);
            return true;
        }
    }
}

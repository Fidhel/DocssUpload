using DocSS_SyncFile.Model;
using DocSS_SyncFile.Utilities;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocSS_SyncFile.Dao
{
    class DaoSqLiteImpl
    {

        public static SQLiteConnection sqlite_conn;
        protected static SQLiteCommand sqlite_cmd;
        protected static SQLiteDataReader sqlite_datareader;
        protected static String DOCS_DATA_FOLDER = "\\DocSSync\\";
        private   static String CONNECTION_STRING;

        public DaoSqLiteImpl()
        {
            DaoSqLiteImpl.conectarBanco();
        }

        public SQLiteConnection getConnection() {
            return sqlite_conn;
        }

        protected static void conectarBanco()
        {
            if (sqlite_conn == null){
                DOCS_DATA_FOLDER = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + DOCS_DATA_FOLDER;
                CONNECTION_STRING = "Data Source=" + DOCS_DATA_FOLDER + "dcs.dt;Version=3;New=True;Compress=True;";
                sqlite_conn = new SQLiteConnection(CONNECTION_STRING);
                sqlite_conn.Open();
            }
        }






        public Profile getProfile()
        {
            Profile prf = null;

            sqlite_cmd = sqlite_conn.CreateCommand();
            sqlite_cmd.CommandText = "SELECT * FROM PROFILE;";
            sqlite_datareader = sqlite_cmd.ExecuteReader();

            while (sqlite_datareader.Read())
            {
                prf = new Profile();
                prf.Id = Int32.Parse(sqlite_datareader["ID"].ToString());
                prf.usuario = sqlite_datareader["USUARIO"].ToString();
                prf.senha = sqlite_datareader["SENHA"].ToString();
                prf.instalacao = sqlite_datareader["INSTALACAO"].ToString();
                prf.versaoApp = sqlite_datareader["APP_VER"].ToString();
                prf.startSO = (bool)sqlite_datareader["INICIALIZACAO_SO"];
                prf.maxArqMin = Int32.Parse(sqlite_datareader["ARQ_MINUTO"].ToString());
                prf.server = sqlite_datareader["SERVER"].ToString();
            }

            prf.listDocssDirectory = this.listDocssDirectory();

            return prf;
        }

        public Boolean consultaArquivoEnviado(String caminhoAbsoluto, DateTime dataModificacao)
        {
            DaoSqLiteImpl.conectarBanco();
            SQLiteDataReader r;
            Boolean b = false;

            sqlite_cmd = sqlite_conn.CreateCommand();
            sqlite_cmd.CommandText = "SELECT COUNT(*) AS QTD FROM HIST_SEND_FILE WHERE DATA_MODIFICACAO = @DATA_MODIFICACAO AND CAMINHO_ABSOLUTO = @CAMINHO_ABSOLUTO;";
            sqlite_cmd.Parameters.AddWithValue("@DATA_MODIFICACAO", dataModificacao);
            sqlite_cmd.Parameters.AddWithValue("@CAMINHO_ABSOLUTO", caminhoAbsoluto);
            r = sqlite_cmd.ExecuteReader();

            if (r.Read())
            {
                b = Int32.Parse(r["QTD"].ToString()) > 0;
            }
            return b;
        }

        public int qtdPendenteImpl()
        {
            DaoSqLiteImpl.conectarBanco();
            SQLiteDataReader r;
            int qtd = 0;

            sqlite_cmd = sqlite_conn.CreateCommand();
            sqlite_cmd.CommandText = "SELECT COUNT(*) AS QTD FROM WAIT_SEND_FILE";
            r = sqlite_cmd.ExecuteReader();
            if (r.Read())
            {
                qtd = Int32.Parse(r["QTD"].ToString());
            }
            return qtd;
        }

        public static List<DocsFileVo> listarArquivosEnviados()
        {
            DaoSqLiteImpl.conectarBanco();
            sqlite_cmd = sqlite_conn.CreateCommand();
            sqlite_cmd.CommandText = "SELECT * FROM HIST_SEND_FILE LIMIT 300;";
            SQLiteDataReader reader = sqlite_cmd.ExecuteReader();
            List<DocsFileVo> list = new List<DocsFileVo>();
            while (reader.Read())
            {
                DocsFileVo docs = new DocsFileVo();
                docs.nomeArquivo = reader["NOME"].ToString();
                docs.ultimaModificacao = Convert.ToDateTime(reader["DATA_MODIFICACAO"].ToString().Trim());
                docs.dateTimeEnvio = Convert.ToDateTime(reader["DATA_ENVIO"].ToString().Trim());
                list.Add(docs);
            }
            return list;
        }

        public List<DocsFileVo> listarArquivosEnviados(String atributo, String pesquisa)
        {
            DaoSqLiteImpl.conectarBanco();
            sqlite_cmd = sqlite_conn.CreateCommand();
            sqlite_cmd.CommandText = "SELECT* FROM  HIST_SEND_FILE where " + atributo.Replace("ENVIO", "DATA_ENVIO") + " like('%" + pesquisa + "%');";
            SQLiteDataReader reader = sqlite_cmd.ExecuteReader();
            List<DocsFileVo> list = new List<DocsFileVo>();
            while (reader.Read())
            {
                DocsFileVo docs = new DocsFileVo();
                docs.nomeArquivo = reader["NOME"].ToString();
                docs.ultimaModificacao = Convert.ToDateTime(reader["DATA_MODIFICACAO"].ToString().Trim());
                docs.dateTimeEnvio = Convert.ToDateTime(reader["DATA_ENVIO"].ToString().Trim());
                list.Add(docs);
            }
            return list;
        }

        public List<DocsFileVo> listarArquivosPendentesLogEnvioImpl(String cnpj)
        {
            DaoSqLiteImpl.conectarBanco();
            sqlite_cmd = sqlite_conn.CreateCommand();
            sqlite_cmd.CommandText = "SELECT* FROM  HIST_SEND_FILE WHERE SEND_LOG='N' AND CNPJ=@CNPJ;";
            sqlite_cmd.Parameters.AddWithValue("@CNPJ", Decimal.Parse(cnpj));
            SQLiteDataReader reader = sqlite_cmd.ExecuteReader();
            List<DocsFileVo> list = new List<DocsFileVo>();
            while (reader.Read())
            {
                DocsFileVo docs = new DocsFileVo();
                docs.nomeArquivo = reader["NOME"].ToString();
                docs.ultimaModificacao = DateTime.Parse(reader["DATA_MODIFICACAO"].ToString());
                list.Add(docs);
            }
            return list;
        }

        public void atualizarProfile(Profile profile)
        {
            sqlite_cmd = sqlite_conn.CreateCommand();

            /*sqlite_cmd.CommandText = "UPDATE PROFILE SET USUARIO=@USUARIO,SENHA=@SENHA,CNPJ=@CNPJ,DIRETORIO=@DIRETORIO,INICIALIZACAO_SO=@INICIALIZACAO_SO,INSTALACAO=@INSTALACAO WHERE ID=@ID";*/
            sqlite_cmd.CommandText = "UPDATE PROFILE SET USUARIO=@USUARIO,SENHA=@SENHA,INICIALIZACAO_SO=@INICIALIZACAO_SO,INSTALACAO=@INSTALACAO,ARQ_MINUTO=@ARQ_MINUTO WHERE ID=@ID";

            sqlite_cmd.Parameters.AddWithValue("@ID", profile.Id);
            sqlite_cmd.Parameters.AddWithValue("@USUARIO", profile.usuario);
            sqlite_cmd.Parameters.AddWithValue("@SENHA", profile.senha);
            /*
            sqlite_cmd.Parameters.AddWithValue("@CNPJ", profile.cnpj);
            sqlite_cmd.Parameters.AddWithValue("@DIRETORIO", profile.diretorio);
            */
            sqlite_cmd.Parameters.AddWithValue("@INICIALIZACAO_SO", profile.startSO);
            sqlite_cmd.Parameters.AddWithValue("@INSTALACAO", DocssUtil.installationName(profile));
            sqlite_cmd.Parameters.AddWithValue("@ARQ_MINUTO", profile.maxArqMin);
            sqlite_cmd.ExecuteNonQuery();
        }

        public void registrarEnvio(String key, DocsFileVo docs)
        {
            DaoSqLiteImpl.conectarBanco();
            sqlite_cmd = sqlite_conn.CreateCommand();
            sqlite_cmd.CommandText = "INSERT INTO HIST_SEND_FILE VALUES(@KEY,@NOME,@TAMANHO,@DATA_MODIFICACAO,@CAMINHO_ABSOLUTO,@DATA_ENVIO,@USUARIO,@CNPJ,@INSTALACAO,@SEND_LOG);";

            sqlite_cmd.Parameters.AddWithValue("@KEY", key);
            sqlite_cmd.Parameters.AddWithValue("@NOME", docs.nomeArquivo);
            sqlite_cmd.Parameters.AddWithValue("@TAMANHO", docs.tamanhoArquivo);
            sqlite_cmd.Parameters.AddWithValue("@DATA_MODIFICACAO", docs.ultimaModificacao);
            sqlite_cmd.Parameters.AddWithValue("@CAMINHO_ABSOLUTO", docs.caminhoAbsoluto);
            sqlite_cmd.Parameters.AddWithValue("@DATA_ENVIO", docs.dateTimeEnvio);
            sqlite_cmd.Parameters.AddWithValue("@USUARIO", docs.usuario);
            sqlite_cmd.Parameters.AddWithValue("@CNPJ", docs.cnpjEnvio);
            sqlite_cmd.Parameters.AddWithValue("@INSTALACAO", docs.codigoInstalacao);
            sqlite_cmd.Parameters.AddWithValue("@SEND_LOG", "N");

            sqlite_cmd.ExecuteNonQuery();
        }

        public void deleteWaitingSendFile(DocsFileVo docs)
        {
            DaoSqLiteImpl.conectarBanco();
            sqlite_cmd = sqlite_conn.CreateCommand();
            sqlite_cmd.CommandText = "DELETE FROM WAIT_SEND_FILE WHERE PATH = @PATH AND NAME = @NAME AND CNPJ = @CNPJ AND STATUS = @STATUS";

            sqlite_cmd.Parameters.AddWithValue("@PATH", docs.caminhoAbsoluto.Replace(docs.nomeArquivo, ""));
            sqlite_cmd.Parameters.AddWithValue("@NAME", docs.nomeArquivo);
            sqlite_cmd.Parameters.AddWithValue("@CNPJ", docs.cnpjEnvio);
            sqlite_cmd.Parameters.AddWithValue("@STATUS", "PENDENTE");
            sqlite_cmd.ExecuteNonQuery();
        }

        public void insertWaitingSendImpl(DocsFileVo docs)
        {
            int cincoMegabytes = 5242880;


            if (!existWaitingSendImpl(docs)) { 
                DaoSqLiteImpl.conectarBanco();
                sqlite_cmd = sqlite_conn.CreateCommand();
                sqlite_cmd.CommandText = "INSERT INTO WAIT_SEND_FILE(PATH,NAME,CNPJ,DATE_RECEIVER,DATE_MODIFICATION,SIZE_FILE,STATUS) VALUES(@PATH,@NAME,@CNPJ,@DATE_RECEIVER,@DATE_MODIFICATION,@SIZE_FILE,@STATUS);";

                sqlite_cmd.Parameters.AddWithValue("@PATH", docs.caminhoAbsoluto.Replace(docs.nomeArquivo, ""));
                sqlite_cmd.Parameters.AddWithValue("@NAME", docs.nomeArquivo);
                sqlite_cmd.Parameters.AddWithValue("@CNPJ", docs.cnpjEnvio);
                sqlite_cmd.Parameters.AddWithValue("@DATE_RECEIVER", DateTime.Now);
                sqlite_cmd.Parameters.AddWithValue("@DATE_MODIFICATION", docs.ultimaModificacao);
                if (docs.tamanhoArquivo < cincoMegabytes){
                    sqlite_cmd.Parameters.AddWithValue("@SIZE_FILE", "P");
                }
                else {
                    sqlite_cmd.Parameters.AddWithValue("@SIZE_FILE", "G");
                }
                
                sqlite_cmd.Parameters.AddWithValue("@STATUS", "PENDENTE");

                sqlite_cmd.ExecuteNonQuery();
            }

        }

        public bool existWaitingSendImpl(DocsFileVo docs)
        {
            DaoSqLiteImpl.conectarBanco();
            SQLiteDataReader r;
            Boolean b = false;

            sqlite_cmd = sqlite_conn.CreateCommand();
            sqlite_cmd.CommandText = "SELECT COUNT(*) AS QTD FROM WAIT_SEND_FILE WHERE PATH = @PATH AND NAME = @NAME AND @CNPJ = CNPJ;";
            sqlite_cmd.Parameters.AddWithValue("@PATH", docs.caminhoAbsoluto.Replace(docs.nomeArquivo, ""));
            sqlite_cmd.Parameters.AddWithValue("@NAME", docs.nomeArquivo);
            sqlite_cmd.Parameters.AddWithValue("@CNPJ", docs.cnpjEnvio);
            r = sqlite_cmd.ExecuteReader();

            if (r.Read())
            {
                if (Int32.Parse(r["QTD"].ToString()) > 0) {
                    b = true;
                }
            }
            return b;
        }


        public List<String> listFilesWaitingDirectoryImpl(DocssDirectory d) {
            DaoSqLiteImpl.conectarBanco();
            sqlite_cmd = sqlite_conn.CreateCommand();
            sqlite_cmd.CommandText = "SELECT NAME FROM  WAIT_SEND_FILE WHERE STATUS='PENDENTE' AND PATH = @PATH AND CNPJ=@CNPJ;";

            sqlite_cmd.Parameters.AddWithValue("@PATH", d.path);
            sqlite_cmd.Parameters.AddWithValue("@CNPJ", Decimal.Parse(d.cnpj));


            SQLiteDataReader reader = sqlite_cmd.ExecuteReader();
            List<String> list = new List<String>();

            while (reader.Read()){
                list.Add(d.path+reader["NAME"].ToString());
            }
            return list;
        }

        public  List<DocssDirectory> listDocssDirectory()
        {
            DaoSqLiteImpl.conectarBanco();
            sqlite_cmd = sqlite_conn.CreateCommand();
            sqlite_cmd.CommandText = "SELECT CNPJ,DIRETORIO,SUBPASTA,SMXML FROM  CNPJ_DIRETORIO;";
            SQLiteDataReader reader = sqlite_cmd.ExecuteReader();
            List<DocssDirectory> list = new List<DocssDirectory>();
            while (reader.Read())
            {
                DocssDirectory d = new DocssDirectory();
                d.cnpj = reader["CNPJ"].ToString();
                d.path = reader["DIRETORIO"].ToString();
                d.subfolder = reader["SUBPASTA"] as bool? ?? false;
                d.onlyxml = reader["SMXML"] as bool? ?? false;
                list.Add(d);
            }
            this.countPathFilesData(list);
            return list;
        }

        public void countPathFilesData(List<DocssDirectory> input)
        {

            DaoSqLiteImpl.conectarBanco();
                sqlite_cmd = sqlite_conn.CreateCommand();
                sqlite_cmd.CommandText = "SELECT COUNT(*) AS QTD, CNPJ FROM HIST_SEND_FILE  GROUP BY CNPJ;";
                SQLiteDataReader r = sqlite_cmd.ExecuteReader();

                while (r.Read())
                {
                       DocssDirectory d  = input.Find(x => Int64.Parse(x.cnpj) == Int64.Parse(r["CNPJ"].ToString()));
                       if (d != null) d.dbCount = Int32.Parse(r["QTD"].ToString());
                }
        }
        
            


        public static void incluirCnpjDiretorio(DocssDirectory cnpjDiretorio)
        {
            DaoSqLiteImpl.conectarBanco();
            sqlite_cmd = sqlite_conn.CreateCommand();
            sqlite_cmd.CommandText = "INSERT INTO CNPJ_DIRETORIO VALUES(@CNPJ,@DIRETORIO,@SUBPASTA);";

            sqlite_cmd.Parameters.AddWithValue("@CNPJ", cnpjDiretorio.cnpj);
            sqlite_cmd.Parameters.AddWithValue("@DIRETORIO", cnpjDiretorio.path + "\\");
            sqlite_cmd.Parameters.AddWithValue("@SUBPASTA", cnpjDiretorio.subfolder);

            sqlite_cmd.ExecuteNonQuery();
        }

        public void atualizarStatusLogEnvioSucesso(String cnpj, List<DocsFileVo> listDocs)
        {
            DaoSqLiteImpl.conectarBanco();

            foreach (DocsFileVo docs in listDocs)
            {
                sqlite_cmd = sqlite_conn.CreateCommand();
                sqlite_cmd.CommandText = "UPDATE HIST_SEND_FILE SET SEND_LOG='S' WHERE CNPJ=@CNPJ AND NOME=@NOME AND DATA_MODIFICACAO>@DATA_MODIFICACAO"; ;

                sqlite_cmd.Parameters.AddWithValue("@CNPJ", Decimal.Parse(cnpj));
                sqlite_cmd.Parameters.AddWithValue("@NOME", docs.nomeArquivo);
                sqlite_cmd.Parameters.AddWithValue("@DATA_MODIFICACAO", docs.ultimaModificacao);

                sqlite_cmd.ExecuteNonQuery();
            }

        }


        public static void atualizarCnpjDiretorio(List<DocssDirectory> list)
        {
            DaoSqLiteImpl.conectarBanco();

            foreach (DocssDirectory dir in list)
            {
                sqlite_cmd = sqlite_conn.CreateCommand();
                sqlite_cmd.CommandText = "UPDATE CNPJ_DIRETORIO SET DIRETORIO=@DIRETORIO,SUBPASTA=@SUBPASTA,SMXML=@SMXML WHERE CNPJ=@CNPJ"; ;

                sqlite_cmd.Parameters.AddWithValue("@CNPJ", dir.cnpj);
                sqlite_cmd.Parameters.AddWithValue("@DIRETORIO", dir.path);
                sqlite_cmd.Parameters.AddWithValue("@SUBPASTA", dir.subfolder);
                sqlite_cmd.Parameters.AddWithValue("@SMXML", dir.onlyxml);

                sqlite_cmd.ExecuteNonQuery();
            }

        }


        public static void excluirCnpjDiretorio(DocssDirectory cnpjDiretorio)
        {
            DaoSqLiteImpl.conectarBanco();
            sqlite_cmd = sqlite_conn.CreateCommand();
            sqlite_cmd.CommandText = "DELETE FROM CNPJ_DIRETORIO WHERE CNPJ = @CNPJ AND DIRETORIO = @DIRETORIO;";

            sqlite_cmd.Parameters.AddWithValue("@CNPJ", cnpjDiretorio.cnpj);
            sqlite_cmd.Parameters.AddWithValue("@DIRETORIO", cnpjDiretorio.path);
            sqlite_cmd.ExecuteNonQuery();
        }


        public static Boolean diretorioValido(DocssDirectory d)
        {
            DaoSqLiteImpl.conectarBanco();
            SQLiteDataReader r;
            Boolean b = false;

            sqlite_cmd = sqlite_conn.CreateCommand();
            sqlite_cmd.CommandText = "SELECT COUNT(*) AS QTD FROM  CNPJ_DIRETORIO WHERE CNPJ = @CNPJ AND DIRETORIO = @DIRETORIO;";
            sqlite_cmd.Parameters.AddWithValue("@CNPJ", d.cnpj);
            sqlite_cmd.Parameters.AddWithValue("@DIRETORIO", d.path);
            r = sqlite_cmd.ExecuteReader();

            if (r.Read())
            {
                b = Int32.Parse(r["QTD"].ToString()) > 0;
            }
            return b;
        }
        

    }
}

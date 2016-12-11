using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocSS_SyncFile.Dao
{
    class DaoCheckDatabaseUpdate
    {

        protected static SQLiteConnection sqlite_conn;
        protected static SQLiteCommand sqlite_cmd;
        protected static SQLiteDataReader sqlite_datareader;
        protected static String DOCS_DATA_FOLDER = "\\DocSSync\\";

        public DaoCheckDatabaseUpdate()
        {
        }

        public static void verificarEstruturaBancoLocal()
        {

            sqlite_conn = new DaoSqLiteImpl().getConnection();
            DaoCheckDatabaseUpdate.estruturaRecursividade();
            /*26-04-2016*/
            DaoCheckDatabaseUpdate.estruturaLogEVersaoApp();

            /*06-08-2016*/
            DaoCheckDatabaseUpdate.createTableWaitingSend();

            /*21-08-2016
              Indexes create.
            */
            DaoCheckDatabaseUpdate.createIndexLog();
            DaoCheckDatabaseUpdate.createIndexConsulHist();
            DaoCheckDatabaseUpdate.createIndexWaitSend();

            /*22-08-2016
              Create server options of profile.
            */
            DaoCheckDatabaseUpdate.createColumnProfileServer();
        }


        private static void estruturaLogEVersaoApp()
        {

            /*ALTERAÇÂO PARA CRIAÇÂO DE CONTROLE DE VERSÂO DA APLICAÇÂO*/

            if (!verificarTabelaEColuna("PROFILE", "APP_VER"))
            {
                DaoCheckDatabaseUpdate.criarColunaDefaultVal("PROFILE", "APP_VER", "VARCHAR", "'1.0.0'");
            }

            /*ALTERAÇÂO PARA CRIAÇÂO DE CONTROLE DE ARQUIVOS ENVIADOS*/
            if (!verificarTabelaEColuna("HIST_SEND_FILE", "SEND_LOG"))
            {
                DaoCheckDatabaseUpdate.criarColunaDefaultVal("HIST_SEND_FILE", "SEND_LOG", "CHAR", "S");
            }

        }

        private static void estruturaRecursividade()
        {
            /*ALTERAÇÂO PARA CRIAÇÂO DE OPÇÂO DE RECURSIDADE TABELA:CNPJ_DIRETORIO COLUNA:SUBPASTA TIPO:BOOLEAN*/
            if (!verificarTabelaEColuna("CNPJ_DIRETORIO", "SUBPASTA"))
            {
                DaoCheckDatabaseUpdate.criarColunaDefaultVal("CNPJ_DIRETORIO", "SUBPASTA", "BOOLEAN", "1");
            }
            /*ALTERAÇÂO PARA CRIAÇÂO DE OPÇÂO DE RECURSIDADE TABELA:CNPJ_DIRETORIO COLUNA:SUBPASTA TIPO:BOOLEAN*/
            if (!verificarTabelaEColuna("PROFILE", "ARQ_MINUTO"))
            {
                DaoCheckDatabaseUpdate.criarColunaDefaultVal("PROFILE", "ARQ_MINUTO", "INT", "60");
            }
        }
            

        private static Boolean verificarTabelaEColuna(String tabela, String coluna)
        {
            sqlite_cmd = sqlite_conn.CreateCommand();
            sqlite_cmd.CommandText = "SELECT sql FROM sqlite_master WHERE type = 'table' AND name = @TABELA ;";
            sqlite_cmd.Parameters.AddWithValue("@TABELA", tabela);
            var reader = sqlite_cmd.ExecuteReader();

            if (reader.Read())
            {
                bool hascol = reader.GetString(0).Contains(coluna);
                reader.Close();
                return hascol;
            }
            reader.Close();
            return false;
        }

        private static void criarColunaDefaultVal(String tabela, String coluna, String tipo, String defaultValue)
        {
            sqlite_cmd = sqlite_conn.CreateCommand();
            sqlite_cmd.CommandText = string.Format("ALTER TABLE {0} ADD COLUMN {1} {2} DEFAULT {3};", tabela, coluna, tipo, defaultValue);
            sqlite_cmd.ExecuteNonQuery();
        }


        private static void createColumnProfileServer()
        {
            if (!verificarTabelaEColuna("PROFILE", "SERVER")) { 
                criarColunaDefaultVal("PROFILE", "SERVER", "VARCHAR(3)", "HML");
            }
        }

        private static void criarColuna(String tabela, String coluna, String tipo)
        {
            sqlite_cmd = sqlite_conn.CreateCommand();
            sqlite_cmd.CommandText = string.Format("ALTER TABLE {0} ADD COLUMN {1} {2};", tabela, coluna, tipo);
            sqlite_cmd.ExecuteNonQuery();
        }

        private static void createTableWaitingSend()
        {
             if (!checkTable("WAIT_SEND_FILE")){
                String create = "CREATE TABLE WAIT_SEND_FILE(" +
                            "id            INTEGER       PRIMARY KEY AUTOINCREMENT," +
                            "path          VARCHAR(300)," +
                            "name          VARCHAR(300)," +
                            "cnpj          VARCHAR(25)," +
                            "date_receiver DATETIME," +
                            "date_modification DATETIME,"+
                            "size_file     CHAR(1)," +
                            "status        VARCHAR(20));";
                sqlite_cmd = sqlite_conn.CreateCommand();
                sqlite_cmd.CommandText = create;
                sqlite_cmd.ExecuteNonQuery();
            }
        }

        private static void createIndexLog()
        {
            
            if (!checkIndex("hist_send_file", "index_consult_log"))
            {
                String create = "CREATE INDEX index_consult_log on hist_send_file(send_log,cnpj);";
                sqlite_cmd = sqlite_conn.CreateCommand();
                sqlite_cmd.CommandText = create;
                sqlite_cmd.ExecuteNonQuery();
            }
        }

        private static void createIndexConsulHist()
        {

            if (!checkIndex("hist_send_file", "index_consult_hist"))
            {
                String create = "CREATE INDEX index_consult_hist on hist_send_file(data_modificacao,caminho_absoluto);";
                sqlite_cmd = sqlite_conn.CreateCommand();
                sqlite_cmd.CommandText = create;
                sqlite_cmd.ExecuteNonQuery();
            }
        }

        private static void createIndexWaitSend()
        {

            if (!checkIndex("wait_send_file", "index_wait_send"))
            {
                String create = "CREATE INDEX index_wait_send on wait_send_file(path,name,cnpj);";
                sqlite_cmd = sqlite_conn.CreateCommand();
                sqlite_cmd.CommandText = create;
                sqlite_cmd.ExecuteNonQuery();
            }
        }

        private static Boolean checkTable(String tabela)
        {
            bool b = false;
            sqlite_cmd = sqlite_conn.CreateCommand();
            sqlite_cmd.CommandText = "SELECT sql FROM sqlite_master WHERE type = 'table' AND name = @TABELA ;";
            sqlite_cmd.Parameters.AddWithValue("@TABELA", tabela);
            var reader = sqlite_cmd.ExecuteReader();

            if (reader.Read())
            {
                b = true;
            }
            reader.Close();
            return b;
        }





        private static Boolean checkIndex(String table,String index)
        {
            bool b = false;
            sqlite_cmd = sqlite_conn.CreateCommand();
            sqlite_cmd.CommandText = string.Format("PRAGMA INDEX_LIST({0})",table);
            sqlite_cmd.Parameters.AddWithValue("@TABELA", table);
            
            var reader = sqlite_cmd.ExecuteReader();

            while(reader.Read())
            {

                if (reader["NAME"].ToString() == index) {
                    b = true;
                    break;
                }
                
            }
            reader.Close();
            return b;
        }
    }
}

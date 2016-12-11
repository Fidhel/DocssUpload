using DocSS_SyncFile.ClientService;
using DocSS_SyncFile.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocSS_SyncFile.Utilities
{
    class VariaveisGlobais
    {

        public static readonly String nomeAppSuporteRemoto = "TeamViewerQS_pt.exe";

        public static readonly String productVersion = "1.0.5";

        public static readonly String productName = "Docss Upload";

        public static readonly String msgConfirmUpdateApp = "Será necessario encerrar o Docss Upload para iniciar o processo de atualização Ok!?";

        public static readonly String MSG_AGUARDANDO_DOWNLOAD = "Download da nova atualização em andamento. Por favor, tente novamente mais tarde.";

        public static readonly String MSG_ULITMA_VERSAO_INSTALADA = "A ultima versão já está instalada.";

        public enum UpdateApp { ULITMA_VERSAO_INSTALADA, AGUARDANDO_DOWNLOAD };

        public static String appData()
        {
            return Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

        }

        public static String msgUpdateApp()
        {
            return "Nova versão(" + UpdateClient.releaseServer + ") disponivel, deseja atualizar agora? Clique Aqui!";
        }
    }
}

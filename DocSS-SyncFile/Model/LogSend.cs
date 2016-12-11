using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocSS_SyncFile.Model
{
    [Serializable]
    public class LogSend
    {
        public String cnpjEnvio { get; set; }
        public String usuario { get; set; }
        public String codigoInstalacao { get; set; }
        public String codStatus { get; set; }
        public String descricaoStatus { get; set; }
        public String arquivosEnviados { get; set; }
    }
}

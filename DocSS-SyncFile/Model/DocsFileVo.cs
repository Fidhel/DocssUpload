using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocSS_SyncFile.Model
{
    [Serializable]
    public class DocsFileVo
    {
        public String nomeArquivo { get; set; }

        public String extensaoArquivo { get; set; }

        public long tamanhoArquivo { get; set; }

        public DateTime ultimaModificacao { get; set; }

        public String caminhoAbsoluto { get; set; }

        public byte[] arquivo { get; set; }

        public DateTime dateTimeEnvio { get; set; }


        public String usuario { get; set; }

        public long cnpjEnvio { get; set; }

        public String codigoInstalacao { get; set; }

        /*01-03-2016 ADMINISTRAR DIRETORIO DESTINO*/
        public String diretorioColeta { get; set; }

    }
}

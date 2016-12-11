using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocSS_SyncFile.Model
{
    [Serializable]
    public class Profile
    {
        public int Id { get; set; }
        public string usuario { get; set; }
        public string senha { get; set; }

        public string cnpj { get; set; }
        public string diretorio { get; set; }

        public Boolean startSO { get; set; }
        public string instalacao { get; set; }

        public string versaoApp { get; set; }

        public List<DocssDirectory> listDocssDirectory { get; set; }
        public int maxArqMin { get; set; }
    }
}

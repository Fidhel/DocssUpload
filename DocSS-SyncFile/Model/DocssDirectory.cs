﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocSS_SyncFile.Model
{
    [Serializable]
    public class DocssDirectory
    {
        public string cnpj { get; set; }
        public string path { get; set; }
        public bool subfolder { get; set; }

        public bool onlyxml { get; set; }

        public long dbCount { get; set; }
    }
}

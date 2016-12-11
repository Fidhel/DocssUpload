using DocSS_SyncFile.Controller;
using DocSS_SyncFile.Dao;
using DocSS_SyncFile.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocSS_SyncFile.Utilities
{
    class FileMonitor
    {

        private Profile p;
        private String path = null;
        private String cnpj = null;

        public FileMonitor(Profile p) {
            this.p = p;
            this.watch();
        }

        private void watch()
        {
            foreach (DocssDirectory d in p.listDocssDirectory)
            {
                if (Directory.Exists(d.path)) { 
                    FileSystemWatcher watcher = new FileSystemWatcher();

                    watcher.Path = d.path;
                    watcher.NotifyFilter = NotifyFilters.LastWrite |
                                           NotifyFilters.FileName;
                    //NotifyFilters.DirectoryName;
                    //NotifyFilters.FileName |

                    watcher.Filter = "*.*";
                    watcher.Changed += new FileSystemEventHandler(OnChanged);
                    watcher.Created += new FileSystemEventHandler(OnChanged);
                    watcher.Error += new ErrorEventHandler(OnError);
                    watcher.EnableRaisingEvents = true;
                }
            }
        }

        

        private void OnChanged(object sender, FileSystemEventArgs e)
        {
            DaoTxtImpl.regMsg("Arquivo Capturado:" + e.Name + " - " + DateTime.Now);
            this.getInfoDirectory(e);
            this.insertWaitingFile(e.FullPath);
        }

        private void OnError(object source, ErrorEventArgs e)
        {
            DaoTxtImpl.regException(e.GetException());
            DocssDirectory d = new DocssDirectory();
            d.path = this.path;
            List<String> list = new DocssFileUtils().getFilesFolder(d,null);

            foreach (String filePath in list) {
                DaoTxtImpl.regMsg("Arquivo Capturado:" + filePath + " - " + DateTime.Now);
                this.insertWaitingFile(filePath);
            }
        }

        private void insertWaitingFile(String fullPathFile) {
            DocsFileVo f = new ArquivosController().popularDocsFileVo(new FileInfo(fullPathFile));
            f.cnpjEnvio = Int64.Parse(this.cnpj);
            new DaoAcess().insertWaitingSend(f);
        }

        private void getInfoDirectory(FileSystemEventArgs f) {
            foreach (DocssDirectory d in p.listDocssDirectory)
            {
                String s = f.FullPath.Replace(f.Name, "");
                if (d.path == s)
                {
                    this.cnpj = d.cnpj;
                    this.path = s;
                }

            }
        }

    }
}

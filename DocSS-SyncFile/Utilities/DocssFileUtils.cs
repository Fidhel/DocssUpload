using DocSS_SyncFile.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocSS_SyncFile.Utilities
{
    class DocssFileUtils
    {



        private DateTime? lastChange;
        private long totalWaitingFiles = 0;
        private readonly long UMMEGA = 1048576;

        
        /*
            If parameter bigThenMB is equals 0, list all files small 5mb.
            If parameter exceptExtension is null list all files to folder.

        */
        public DocssFileUtils(String path, bool subfolder, String limitDate, int bigThenMB, String[] exceptExtension) {
            

            if (limitDate != null) {
                lastChange = new DateTime(Int32.Parse(limitDate.Substring(0, 4)), Int32.Parse(limitDate.Substring(4, 2)), Int32.Parse(limitDate.Substring(6, 2)));
            }
        }

        public DocssFileUtils() {
            
        }


        public List<String> getFilesFolder(DocssDirectory d, String[] strExceptExtension)
        {
            IEnumerable<String> listFilesFolder;
            if (d.subfolder)
            {
                if (strExceptExtension != null)
                    listFilesFolder = Directory.EnumerateFiles(d.path, "*.*", SearchOption.AllDirectories).Where(f => !strExceptExtension.Contains(Path.GetExtension(f))).OrderByDescending(f => new FileInfo(f).LastWriteTime);
                else
                    listFilesFolder = Directory.EnumerateFiles(d.path, "*.*", SearchOption.AllDirectories).OrderByDescending(f => new FileInfo(f).LastWriteTime);
            }
            else {
                if (strExceptExtension != null)
                    listFilesFolder = Directory.EnumerateFiles(d.path, "*.*", SearchOption.TopDirectoryOnly).Where(f => !strExceptExtension.Contains(Path.GetExtension(f))).OrderByDescending(f => new FileInfo(f).LastWriteTime);
                else
                    listFilesFolder = Directory.EnumerateFiles(d.path, "*.*", SearchOption.AllDirectories).OrderByDescending(f => new FileInfo(f).LastWriteTime);
            }
            return listFilesFolder.ToList();
        }


        /*
       private List<FileInfo> getFiles(List<DocssDirectory> list) {


           foreach (DocssDirectory d in list)
           {

               foreach (string f in this.getFilesFolder(d.path,null))
               {
                   fileInfo = new FileInfo(f);
                   //checkLastChange();
                   //checkSizeFile();


                   addFileInfo();
                   resetAddFile();
               }

           }


           return listFileInfo;
       }

       private void checkLastChange() {
           isAddFile = false;
           //Check file large "lastChange"
           if (lastChange != null)
           {
               if (fileInfo.LastWriteTime > lastChange)
               {
                   isAddFile = true;
               }
           }
           else {
                   isAddFile = true;
           }
       }

       private void checkSizeFile() {
           if (isAddFile) { 
               if (nuBigThenMB != 0) {
                   long size = nuBigThenMB * UMMEGA;
                   if (fileInfo.Length < size) {
                       isAddFile = false;
                   }
               }
               else
               {
                   long size = 5 * UMMEGA;
                   if (fileInfo.Length > size)
                   {
                       isAddFile = false;
                   }
               }
           }
       }
       */







    }
}

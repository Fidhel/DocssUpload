using DocSS_SyncFile.Dao;
using DocSS_SyncFile.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DocSS_SyncFile.Controller
{
    
    public class ArquivosController
    {
        private static string DESTINO_DATA_SEND = DaoAcess.DOCS_DATA_FOLDER + "DTTSD.dcs";
       
 
        public List<DocsFileVo> listWaitingFilesDirectory(DocssDirectory d) {
            
            /*CARREGAR ARQUIVOS PENDENTES DE ENVIO*/
            List<DocsFileVo> listDocs = listarPequenosArquivosPendentesEnvio(d);
            
            return listDocs;
        }

        
        [MethodImpl(MethodImplOptions.Synchronized)]
        public static void registrarArquivoEnviadoSucesso(String key,DocsFileVo docsFile)
        {
            new DaoSqLiteImpl().registrarEnvio(key, docsFile);
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        public static void insertSucessSendFile(String key, DocsFileVo docsFile)
        {
            DaoSqLiteImpl d = new DaoSqLiteImpl();
            d.registrarEnvio(key, docsFile);
        }


        public List<DocsFileVo> listarPequenosArquivosPendentesEnvio(DocssDirectory d)
        {
            List<DocsFileVo> listDocs = new List<DocsFileVo>();
            IEnumerable<String> listaDiretorio = null;
            String fileType =  "*.*";
            if (d.onlyxml) {
                fileType = "*.xml";
            }
            if (d.subfolder) {
                listaDiretorio = Directory.EnumerateFiles(d.path, fileType, SearchOption.AllDirectories);
            }
            else {
                listaDiretorio = Directory.EnumerateFiles(d.path, fileType, SearchOption.TopDirectoryOnly);
            }

            listDocs = this.getParseToListDocssFileVo(listaDiretorio.ToList(),d.cnpj, false);

            return listDocs;
        }


        public List<DocsFileVo> listarGrandesArquivosPendentesEnvio(DocssDirectory d)
        {
            int cincoMegabytes = 5242880;
            List<DocsFileVo> listDocs = new List<DocsFileVo>();

            IEnumerable<String> listaDiretorio = null;
            if (d.subfolder)
            {
                listaDiretorio = Directory.EnumerateFiles(d.path, "*.*", SearchOption.AllDirectories);
            }
            else {
                listaDiretorio = Directory.EnumerateFiles(d.path, "*.*", SearchOption.TopDirectoryOnly);
            }

            listDocs = this.getParseToListDocssFileVo(listaDiretorio.ToList(),d.cnpj, true);
            
            return listDocs;
        }

        public List<DocsFileVo> getParseToListDocssFileVo(List<String> listPath, String cnpj,bool bigFile) {
            int cincoMegabytes = 5242880;

            List<DocsFileVo> list = new List<DocsFileVo>();
            foreach (String pathFile in listPath) {
                bool isBig = false;
                FileInfo fileInfo = new FileInfo(pathFile);

                if (fileInfo.Length > cincoMegabytes) isBig = true;

                if (isBig == bigFile && !new DaoSqLiteImpl().consultaArquivoEnviado(fileInfo.FullName, fileInfo.LastWriteTime))
                {
                    
                        /*Preenche arquivo Docs*/
                        DocsFileVo docsFile = popularDocsFileVo(fileInfo);
                        docsFile.cnpjEnvio  = Int64.Parse(cnpj);
                        /*Popula Lista*/
                        list.Add(docsFile);
                    
                }
            }
            return list;
        }

        public List<DocsFileVo> spliSendFile(DocsFileVo docsFileVo) {
            
            String inputFile = docsFileVo.caminhoAbsoluto;
            String nome = docsFileVo.nomeArquivo + "_PART";
            String path = DaoAcess.DOCS_DATA_FOLDER + "\\tmp\\"+nome;
            int umMegabyte = 1048576;

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
                this.filePart(inputFile, umMegabyte, path);
            }
            
            List<DocsFileVo> listParts = new List<DocsFileVo>();
            foreach (string arquivo in Directory.EnumerateFiles(path, "*.*", SearchOption.AllDirectories))
            {
                FileInfo fileInfo = new FileInfo(arquivo);

                /*Preenche arquivo Docs*/
                DocsFileVo part = popularDocsFileVo(fileInfo);
                part.tamanhoArquivo = Convert.ToInt64(part.nomeArquivo);
                part.nomeArquivo = nome;
                
                /*Popula Lista*/
                listParts.Add(part);
                
            }
            return listParts;
        }

        public void deletePastaTmpEnvio(String nome)
        {
            String path = DaoAcess.DOCS_DATA_FOLDER + "\\tmp\\" + nome + "_PART";
            Directory.Delete(path);
        }

    public List<DocsFileVo> listarArquivosPendentesEnvioTxt(String diretorioUpload)
        {
            String docssFile;
            List<DocsFileVo> listDocs = new List<DocsFileVo>();


            StreamReader str = new StreamReader(DESTINO_DATA_SEND);
            Boolean eArquivoNovo = true;
            foreach (string arquivo in Directory.EnumerateFiles(diretorioUpload, "*.*", SearchOption.AllDirectories))
            {   
                FileInfo fileInfo = new FileInfo(arquivo);
                docssFile = fileInfo.FullName + "#" + fileInfo.LastWriteTime;
                
                Debug.WriteLine(docssFile);
                while (str.Peek() >= 0) {
                    string[] dat = str.ReadLine().Split('#');
                    String line = (dat[0]+dat[1]).Trim();
                    if (line == docssFile.Trim().Replace("#","") && validaKey(dat[2])) {
                        
                        eArquivoNovo = false;
                        
                    }
                }

                if (eArquivoNovo)
                {

                    /*Preenche arquivo Docs*/
                    DocsFileVo docsFile = popularDocsFileVo(fileInfo);
                    /*Popula Lista*/
                    listDocs.Add(docsFile);
                    eArquivoNovo = true;
                }
                eArquivoNovo = true;
                str.DiscardBufferedData();
                str.BaseStream.Position = 0;
            }
            
            str.Close();
            return listDocs;
        }

        public List<DocsFileVo> listarArquivosDiretorio(String diretorioUpload)
        {

            string[] subdirectoryEntries = Directory.GetDirectories(diretorioUpload);
            List<DocsFileVo> listDocs = new List<DocsFileVo>();


            foreach (string arquivo in Directory.EnumerateFiles(diretorioUpload, "*.*", SearchOption.AllDirectories))
            {
                FileInfo fileInfo = new FileInfo(arquivo);

                Debug.WriteLine("nome:" + fileInfo.Name);
                Debug.WriteLine("diretorio:" + fileInfo.FullName);

                /*Preenche arquivo Docs*/
                DocsFileVo docsFile = new DocsFileVo();
                docsFile.nomeArquivo = fileInfo.Name;
                docsFile.tamanhoArquivo = fileInfo.Length;
                docsFile.extensaoArquivo = fileInfo.Extension;
                docsFile.caminhoAbsoluto = fileInfo.FullName;


                /*Popula Lista*/
                listDocs.Add(docsFile);
            }

            /*RETORNO*/
            return listDocs;
        }


        public List<DocsFileVo> carregarArquivos(String diretorioUpload)
        {

            //string[] subdirectoryEntries = Directory.GetDirectories(diretorioUpload);
            List<DocsFileVo> listDocs = new List<DocsFileVo>();
            
             

            foreach (string arquivo in Directory.EnumerateFiles(diretorioUpload, "*.*", SearchOption.AllDirectories))
            {
                FileInfo fileInfo = new FileInfo(arquivo);

                Debug.WriteLine("nome:" + fileInfo.Name);
                Debug.WriteLine("diretorio:" + fileInfo.FullName);

                DocsFileVo docs =  this.popularDocsFileVo(fileInfo);

                /*Popula Lista*/
                listDocs.Add(docs);
            }

            /*RETORNO*/
            return listDocs;
        }

        public DocsFileVo popularDocsFileVo(FileInfo fileInfo)
        {
            try {
                DocsFileVo docs = new DocsFileVo();
                docs.nomeArquivo = fileInfo.Name;
                docs.extensaoArquivo = fileInfo.Extension;
                docs.tamanhoArquivo = fileInfo.Length;
                docs.caminhoAbsoluto = fileInfo.FullName;
                docs.ultimaModificacao = fileInfo.LastWriteTime;
                return docs;
            }
            catch (FileNotFoundException fe) {
                DaoTxtImpl.regMsg("Arquivo nao encontrado:"+fileInfo.Name);
                return null;
            }
        }

        public DocsFileVo popularEnvioDocsFileVo(DocsFileVo docs,Profile prf,DocssDirectory d) {
            docs.arquivo = File.ReadAllBytes(docs.caminhoAbsoluto);
            docs.usuario = prf.usuario;
            docs.cnpjEnvio = Convert.ToInt64(d.cnpj);
            docs.codigoInstalacao = prf.instalacao;
            docs.dateTimeEnvio = DateTime.Now;
            docs.diretorioColeta = d.path;
            return docs;
        }

        public DocsFileVo popularEnvioDocsFileVoSemByteArrray(DocsFileVo docs, Profile prf, DocssDirectory d)
        {
            docs.usuario = prf.usuario;
            docs.cnpjEnvio = Convert.ToInt64(d.cnpj);
            docs.codigoInstalacao = prf.instalacao;
            docs.dateTimeEnvio = DateTime.Now;
            docs.diretorioColeta = d.path;
            return docs;
        }

        public Boolean validaKey(String key) {
            if (!String.IsNullOrEmpty(key)) { 
            String[] keyPart;

            keyPart = key.Split('-');
                if (keyPart.Length == 5) {
                    if (keyPart[0].Length == 8 && keyPart[4].Length == 12) {
                        return true;
                    }
                }
            }
            return false;
        }


        public DocsFileVo prepararDiretorioEnvio(DocsFileVo completo, DocsFileVo part) {
            String caminhoAbsoluto = completo.caminhoAbsoluto;
            caminhoAbsoluto = caminhoAbsoluto.Replace(completo.nomeArquivo, "");
            caminhoAbsoluto = caminhoAbsoluto+part.nomeArquivo + "\\" + part.tamanhoArquivo;
            part.caminhoAbsoluto = caminhoAbsoluto;
            return part;
        }

        public void deletarArquivoEnviado(String caminhoAbsoluto) { 
            File.Delete(caminhoAbsoluto);
        }

        public void filePart(string inputFile, int chunkSize, string path)
        {

            const int BUFFER_SIZE = 20 * 1024;
            byte[] buffer = new byte[BUFFER_SIZE];

            using (Stream input = File.OpenRead(inputFile))
            {
                int index = 0;
                while (input.Position < input.Length)
                {
                    using (Stream output = File.Create(path + "\\" + index))
                    {
                        int remaining = chunkSize, bytesRead;
                        while (remaining > 0 && (bytesRead = input.Read(buffer, 0,
                                Math.Min(remaining, BUFFER_SIZE))) > 0)
                        {
                            output.Write(buffer, 0, bytesRead);
                            remaining -= bytesRead;
                        }
                    }
                    index++;
                    Thread.Sleep(500); // experimental; perhaps try it
                }
            }
        }
    }
}

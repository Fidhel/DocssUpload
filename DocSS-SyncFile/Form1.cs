﻿using DocSS_SyncFile.Dao;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using DocSS_SyncFile.Controller;
using System.Threading;
using Microsoft.Win32;
using System.IO;
using DocSS_SyncFile.Utilities;
using DocSS_SyncFile.ClientService;
using DocSS_SyncFile.Model;

namespace DocSS_SyncFile
{
    public partial class Form1 : Form
    {

        
        private AppController ctrlApp;
        private Boolean admSync = false;
        private static String registroWindows = "SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run";
        private Boolean exitMenu = false;
        private int countUpdate = 0;
        public Form1()
        {
            

            AppController.verificarBancoLocal();
            DaoCheckDatabaseUpdate.verificarEstruturaBancoLocal();

            DaoAcess dao = new DaoAcess();
            Profile prf = dao.getProfile();
            dao.atualizarProfile(prf);
            ReceiverClient.swithServer(prf.server);
            LogClient.logServicoIniciado(prf, null);

            InitializeComponent();
        }

        


        public Boolean autenticaAdministrador(String senha) {
            if (senha.Equals("d1versa")) {
                admSync = true;
            } 
            return admSync;
        }
        private void popularInterface() {

            
            this.labelPendEnvio.Text = "Pendencia:";



            labelAppVersion.Text = VariaveisGlobais.productVersion;

            textUser.Text = ctrlApp.getProfile().usuario;
            

            checkStartSO.Checked = ctrlApp.getProfile().startSO;

            exitMenu = false;
            startOSAplicacaoWindows(ctrlApp.getProfile().startSO);
            inputArqMin.Text = ctrlApp.getProfile().maxArqMin.ToString();
            trackArqMin.Value = ctrlApp.getProfile().maxArqMin;

            dataGridDiretorio.Rows.Clear();
            foreach (DocssDirectory cnpjDiretorio in ctrlApp.getProfile().listDocssDirectory)
            {
                if (Directory.Exists(cnpjDiretorio.path))
                {
                    dataGridDiretorio.Rows.Add(cnpjDiretorio.cnpj, cnpjDiretorio.path,cnpjDiretorio.subfolder);
                }
                else {
                    dataGridDiretorio.Rows.Add(cnpjDiretorio.cnpj, "(NÂO ENCONTRADO)" + cnpjDiretorio.path, cnpjDiretorio.subfolder);
                    int l = dataGridDiretorio.Rows.Count - 1;
                    dataGridDiretorio.Rows[l].Cells[1].Style = new DataGridViewCellStyle { ForeColor = Color.Red };

                }
            }
            dataGridDiretorio.Refresh();
        }


        private void loadGridDir() {
            dataGridDiretorio.Rows.Clear();
            ctrlApp.refresh();
            foreach (DocssDirectory cnpjDiretorio in ctrlApp.getProfile().listDocssDirectory)
            {
                if (Directory.Exists(cnpjDiretorio.path))
                {
                    dataGridDiretorio.Rows.Add(cnpjDiretorio.cnpj, cnpjDiretorio.path, cnpjDiretorio.subfolder);
                }
                else {
                    dataGridDiretorio.Rows.Add(cnpjDiretorio.cnpj, "(NÂO ENCONTRADO)" + cnpjDiretorio.path, cnpjDiretorio.subfolder);
                    int l = dataGridDiretorio.Rows.Count - 1;
                    dataGridDiretorio.Rows[l].Cells[1].Style = new DataGridViewCellStyle { ForeColor = Color.Red };

                }
            }
            dataGridDiretorio.Refresh();
        }


        private void atualizarProfile() {
            ctrlApp.getProfile().usuario = textUser.Text;
            ctrlApp.getProfile().startSO = checkStartSO.Checked;
            ctrlApp.getProfile().maxArqMin = Int32.Parse(inputArqMin.Text);
            ctrlApp.updateProfile();
            editarFormulario(false);
        }

        /*
            Habilita e Desabilita campos do Formuladrio
        */
        private void editarFormulario(Boolean b) {
            if (b)
            {
                textUser.ReadOnly = false;
                textBox1.ReadOnly = false;
            }
            else {
                textUser.ReadOnly = true;
                textBox1.ReadOnly = true;
            }
        }
        
        private Icon ico;

        private void Form1_Load(object sender, EventArgs e)
        {
            
            
               
            ico = notifyicon.Icon;
            ctrlApp = new AppController();
            popularInterface();


            this.startMonitor();
            
            
            
        }

        private void startMonitor() {
            ThreadPool.QueueUserWorkItem((dumby) => monitorar());
        }


        public static void startOSAplicacaoWindows(Boolean status)
        {
            RegistryKey reg = Registry.CurrentUser.OpenSubKey(registroWindows, true);
            if (status == true)
            {
                reg.SetValue("DocSS-Upload", Application.ExecutablePath.ToString());
            }
            else {
                if (reg.GetValue("DocSS-Upload") != null) {
                    reg.DeleteValue("DocSS-Upload");
                }
            }
                
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {

           
                this.notificarEnvio(Program.enviarArquivos(folderBrowserDialog1.SelectedPath));

                //labelStatus.Text = "Enviando... 1 de 10 nf001.xml"; 
        }

        private async Task monitorar() {

            
            
            
            DaoSqLiteImpl dao = new DaoSqLiteImpl();
            
            while (true)
            {
                try
                {
                    this.Invoke((MethodInvoker)delegate ()
                    {
                        this.popularInterface();
                    });

                    ctrlApp.processarArquivos();
                    if (AppController.qtdEnvio > 0 || !AppController.serverStatus)
                    {
                        this.notificarEnvio(AppController.qtdEnvio);
                    }
                    if (AppController.listNotificacoes.Count > 0)
                    {
                        foreach (String str in AppController.listNotificacoes)
                        {
                            this.notificar(str);
                        }
                        AppController.listNotificacoes = new List<String>();
                    }
                    this.Invoke((MethodInvoker)delegate ()
                    {
                        this.atualizarPendencia();
                    });
                    this.notificarAtualizacaoApp();
                    Thread.Sleep(60000);
                }
                catch (Exception ex) {
                    
                    Thread.Sleep(60000);
                    DaoTxtImpl.regException(ex);
                }
            }
        }

        private void btn_minimizar(object sender, EventArgs e)
        {
            this.editarFormulario(false);
            this.Hide();
        }


        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LogClient.logServicoEncerrado(ctrlApp.getProfile());
            this.exitMenu = true;
            this.Close();
        }

        private void optionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Show();
        }

        private void sincronizarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.notificarEnvio(Program.enviarArquivos(folderBrowserDialog1.SelectedPath));
        }

        private void monitoramentoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Em construção.");
        }

        

        private void notificarEnvio(int qtdEnviado) {
            if (!AppController.serverStatus) { 
                notifyicon.ShowBalloonTip(3000, VariaveisGlobais.productName, "ERRO: DocSS-Receiver fora do ar!", ToolTipIcon.Info);
            }else { 
                notifyicon.ShowBalloonTip(3000, VariaveisGlobais.productName, qtdEnviado+" arquivos sincronizados com sucesso.",ToolTipIcon.Info);
                AppController.qtdEnvio = 0;
        }
         }

        private void notificar(String mensagem)
        {
            notifyicon.ShowBalloonTip(3000, VariaveisGlobais.productName, mensagem, ToolTipIcon.Info);
        }

        

        private void button1_Click_2(object sender, EventArgs e)
        {
            folderBrowserDialog1.ShowDialog();
            _textDiretorio.Text = folderBrowserDialog1.SelectedPath;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        

        private void button2_Click(object sender, EventArgs e)
        {
            atualizarProfile();
        }

        

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textUser_TextChanged(object sender, EventArgs e)
        {

        }

        

        private void _textDiretorio_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            SenhaAdminMsgBox formSenhaAdmin = new SenhaAdminMsgBox();
            formSenhaAdmin.ShowDialog(this);
            if (admSync)
            {
                editarFormulario(true);
                admSync = false;
            }
            
        }

        private void folderBrowserDialog1_HelpRequest(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            MonitorFiles monitor = new MonitorFiles();
            monitor.ShowDialog(this); 
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged_1(object sender, EventArgs e)
        {

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!exitMenu) {
                e.Cancel = true;
                this.Hide();
                this.editarFormulario(false);
                notifyicon.ShowBalloonTip(500, "DocSS", "Continua em execução minimizado.", ToolTipIcon.Info);

            }
        }

        private void notifyicon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Show();
        }

        private void dataGridDiretorio_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;
            
            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {

                DataGridViewRow linhaSelecionada = dataGridDiretorio.Rows[e.RowIndex];
                DocssDirectory cnpjDiretorio = new DocssDirectory();
                cnpjDiretorio.cnpj = linhaSelecionada.Cells["cnpj"].Value.ToString();
                cnpjDiretorio.path = linhaSelecionada.Cells["diretorio"].Value.ToString().Replace("(NÂO ENCONTRADO)","");

                DialogResult dialogResult = MessageBox.Show("Tem certeza que deseja excluir o diretorio de captura " + cnpjDiretorio.path+" CNPJ:"+cnpjDiretorio.cnpj, "Excluir",MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    DaoSqLiteImpl.excluirCnpjDiretorio(cnpjDiretorio);
                    this.loadGridDir();
                    //this.clearCnpjDiretorioDataGrid();
                }
                
             }
            /*
            switch (senderGrid.Columns[e.ColumnIndex].Name) {

                case "diretorio":
                    folderBrowserDialog1.ShowDialog();
                    _textDiretorio.Text = folderBrowserDialog1.SelectedPath;
                    break;
                default:
                    break;
            }
            */
            
        }

        private void clearCnpjDiretorioDataGrid() {
             dataGridDiretorio.Rows.Clear();
            //this.popularInterface();
            //dataGridDiretorio.Refresh();
        }

        private void btnAdicionarDiretorio_Click(object sender, EventArgs e)
        {

            SenhaAdminMsgBox formSenhaAdmin = new SenhaAdminMsgBox();
            formSenhaAdmin.ShowDialog(this);
            if (admSync)
            {
                String cnpj = textBox1.Text;
                String diretorio = _textDiretorio.Text;

                if (String.IsNullOrEmpty(cnpj))
                {
                    DialogResult dialogResult = MessageBox.Show("Favor preencher CNPJ corretamente.");
                    return;
                }


                if (String.IsNullOrEmpty(diretorio))
                {
                    DialogResult dialogResult = MessageBox.Show("Favor selecionar um diretorio valido.");
                    return;
                }

                DocssDirectory cnpjDiretorio = new DocssDirectory();
                cnpjDiretorio.cnpj = cnpj;
                cnpjDiretorio.path = diretorio;
                cnpjDiretorio.subfolder = true;

                DaoSqLiteImpl.incluirCnpjDiretorio(cnpjDiretorio);
                this.loadGridDir(); 
                //this.clearCnpjDiretorioDataGrid();
            }
        }

        private void recarregarGridDiretorios_Click(object sender, EventArgs e)
        {
            this.popularInterface();
        }
        
        private void trackArqMin_ValueChanged(object sender, EventArgs e)
        {
            inputArqMin.Text = trackArqMin.Value.ToString();
        }

        private void aplicarDiretorios_Click(object sender, EventArgs e)
        {
            List<DocssDirectory> list = new List<DocssDirectory>();
            foreach (DataGridViewRow linha in this.dataGridDiretorio.Rows) {
                DocssDirectory dir = new DocssDirectory();
                dir.cnpj = linha.Cells[0].Value.ToString();
                dir.path = linha.Cells[1].Value.ToString();
                dir.subfolder = Convert.ToBoolean(linha.Cells[2].Value.ToString());
                list.Add(dir);
            }
            DaoSqLiteImpl.atualizarCnpjDiretorio(list);
            this.popularInterface();
        }

        private void label3_Click_1(object sender, EventArgs e)
        {

        }

        private void linkSuprtRemoto_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(DaoAcess.DOCS_DATA_FOLDER+VariaveisGlobais.nomeAppSuporteRemoto);
        }

        private void labelPendEnvio_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.atualizarPendencia();
        }

        public void atualizarPendencia() {
            this.labelPendEnvio.Text = "Pendencia:" + new DaoAcess().qtdPendencia();
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void linkatualizarapp_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            switch (UpdateClient.atualizarApp()) {

                case (int)VariaveisGlobais.UpdateApp.AGUARDANDO_DOWNLOAD:
                    MessageBox.Show(VariaveisGlobais.MSG_AGUARDANDO_DOWNLOAD);
                    break;

                case (int)VariaveisGlobais.UpdateApp.ULITMA_VERSAO_INSTALADA:
                    MessageBox.Show(VariaveisGlobais.MSG_ULITMA_VERSAO_INSTALADA);
                    break;

                default:
                    break;
            }
        }


        /** AUTO UPDATE **/
        private void notificarAtualizacaoApp()
        {
            if ((countUpdate == 1 | countUpdate == 60) && UpdateClient.checarVersao())
            {
                notifyUpdate.ShowBalloonTip(3000, VariaveisGlobais.productName, VariaveisGlobais.msgUpdateApp(), ToolTipIcon.Info);
            }
            countUpdate++;
            if (countUpdate == 60) countUpdate = 2;
        }

        

        private void notifyUpdate_BalloonTipClicked(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show(VariaveisGlobais.msgConfirmUpdateApp,VariaveisGlobais.productName+" Atualização", MessageBoxButtons.YesNo);
            if (r == DialogResult.Yes) {
                UpdateClient.atualizarApp();
                this.exitMenu = true;
                this.Close();
            }
        }
        /** AUTO UPDATE **/

        private void encerrarAplicacao() {
            LogClient.logServicoEncerrado(ctrlApp.getProfile());
            this.exitMenu = true;
            this.Close();
        }
       
    }
}

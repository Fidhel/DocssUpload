using DocSS_SyncFile.Controller;
using DocSS_SyncFile.Dao;
using DocSS_SyncFile.Model;
using DocSS_SyncFile.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DocSS_SyncFile
{
    public partial class MonitorFiles : Form
    {
        private static int qtd = 0;
        private DaoSqLiteImpl daoMonitor;


        public MonitorFiles()
        {
            daoMonitor = new DaoSqLiteImpl();
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void MonitorFiles_Load(object sender, EventArgs e)
        {
            
            carregarTabOperacional();
            comboFiltro.SelectedIndex = 1;


        }

        public void carregarGrid() {
            dataGridSend.Rows.Clear();
            int count = 0;
            foreach (DocsFileVo docs in daoMonitor.listarArquivosEnviados(comboFiltro.SelectedItem.ToString(), inputPesquisa.Text))
            {
                dataGridSend.Rows.Add("ENVIADO", docs.dateTimeEnvio, docs.nomeArquivo, docs.ultimaModificacao);
                count++;
            }
            labelQtdSend.Text = count.ToString();
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {
            carregarTabOperacional();
        }

        public static  void atualizarQtdArquivosPendentesEnvio(int i) {
            qtd = i;
        }

        public static void atualizarQtdArquivosPendentesEnvio()
        {
            qtd--;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            carregarTabOperacional();
        }

        private void carregarTabOperacional() {
            //qtdPendente.Text = qtd.ToString();
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            DocssUtil.debugModeManager(inputPesquisa.Text);
            this.carregarGrid();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void qtdPendente_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
           // qtdPendente.Text = qtd.ToString();
        }
    }
}

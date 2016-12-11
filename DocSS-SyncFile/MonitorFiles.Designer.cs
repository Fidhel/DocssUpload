namespace DocSS_SyncFile
{
    partial class MonitorFiles
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MonitorFiles));
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.labelQtdSend = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.comboFiltro = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnPesquisar = new System.Windows.Forms.Button();
            this.inputPesquisa = new System.Windows.Forms.TextBox();
            this.dataGridSend = new System.Windows.Forms.DataGridView();
            this.status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.envio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.arquivo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtModificacao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridSend)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage2.Controls.Add(this.labelQtdSend);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.comboFiltro);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Controls.Add(this.btnPesquisar);
            this.tabPage2.Controls.Add(this.inputPesquisa);
            this.tabPage2.Controls.Add(this.dataGridSend);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(2);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(2);
            this.tabPage2.Size = new System.Drawing.Size(737, 402);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Arquivos";
            // 
            // labelQtdSend
            // 
            this.labelQtdSend.AutoSize = true;
            this.labelQtdSend.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.labelQtdSend.Location = new System.Drawing.Point(37, 35);
            this.labelQtdSend.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelQtdSend.Name = "labelQtdSend";
            this.labelQtdSend.Size = new System.Drawing.Size(13, 13);
            this.labelQtdSend.TabIndex = 15;
            this.labelQtdSend.Text = "0";
            this.labelQtdSend.Click += new System.EventHandler(this.label4_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(4, 35);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(31, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "Total";
            // 
            // comboFiltro
            // 
            this.comboFiltro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboFiltro.FormattingEnabled = true;
            this.comboFiltro.Items.AddRange(new object[] {
            "NOME",
            "ENVIO"});
            this.comboFiltro.Location = new System.Drawing.Point(40, 6);
            this.comboFiltro.Margin = new System.Windows.Forms.Padding(2);
            this.comboFiltro.Name = "comboFiltro";
            this.comboFiltro.Size = new System.Drawing.Size(82, 21);
            this.comboFiltro.TabIndex = 12;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 13);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Filtro";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(149, 12);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Valor";
            // 
            // btnPesquisar
            // 
            this.btnPesquisar.Location = new System.Drawing.Point(296, 4);
            this.btnPesquisar.Margin = new System.Windows.Forms.Padding(2);
            this.btnPesquisar.Name = "btnPesquisar";
            this.btnPesquisar.Size = new System.Drawing.Size(96, 22);
            this.btnPesquisar.TabIndex = 9;
            this.btnPesquisar.Text = "Pesquisar";
            this.btnPesquisar.UseVisualStyleBackColor = true;
            this.btnPesquisar.Click += new System.EventHandler(this.btnPesquisar_Click);
            // 
            // inputPesquisa
            // 
            this.inputPesquisa.Location = new System.Drawing.Point(184, 6);
            this.inputPesquisa.Margin = new System.Windows.Forms.Padding(2);
            this.inputPesquisa.Name = "inputPesquisa";
            this.inputPesquisa.Size = new System.Drawing.Size(98, 20);
            this.inputPesquisa.TabIndex = 8;
            // 
            // dataGridSend
            // 
            this.dataGridSend.AllowUserToAddRows = false;
            this.dataGridSend.AllowUserToOrderColumns = true;
            this.dataGridSend.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dataGridSend.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridSend.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.status,
            this.envio,
            this.arquivo,
            this.dtModificacao});
            this.dataGridSend.Location = new System.Drawing.Point(4, 61);
            this.dataGridSend.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridSend.Name = "dataGridSend";
            this.dataGridSend.RowHeadersVisible = false;
            this.dataGridSend.RowTemplate.Height = 28;
            this.dataGridSend.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGridSend.Size = new System.Drawing.Size(730, 339);
            this.dataGridSend.TabIndex = 2;
            // 
            // status
            // 
            this.status.HeaderText = "Status";
            this.status.Name = "status";
            this.status.Width = 70;
            // 
            // envio
            // 
            this.envio.HeaderText = "Envio";
            this.envio.Name = "envio";
            this.envio.Width = 120;
            // 
            // arquivo
            // 
            this.arquivo.HeaderText = "Arquivo";
            this.arquivo.Name = "arquivo";
            this.arquivo.Width = 400;
            // 
            // dtModificacao
            // 
            this.dtModificacao.HeaderText = "Data Modificacao";
            this.dtModificacao.Name = "dtModificacao";
            this.dtModificacao.Width = 120;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(1, 0);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(745, 428);
            this.tabControl1.TabIndex = 1;
            // 
            // MonitorFiles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(746, 427);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "MonitorFiles";
            this.Text = "Monitor";
            this.Load += new System.EventHandler(this.MonitorFiles_Load);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridSend)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.DataGridView dataGridSend;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TextBox inputPesquisa;
        private System.Windows.Forms.Button btnPesquisar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboFiltro;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label labelQtdSend;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtModificacao;
        private System.Windows.Forms.DataGridViewTextBoxColumn arquivo;
        private System.Windows.Forms.DataGridViewTextBoxColumn envio;
        private System.Windows.Forms.DataGridViewTextBoxColumn status;
    }
}
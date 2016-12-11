namespace DocSS_SyncFile
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.notifyicon = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.button1 = new System.Windows.Forms.Button();
            this._textDiretorio = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textUser = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.linkatualizarapp = new System.Windows.Forms.LinkLabel();
            this.labelPendEnvio = new System.Windows.Forms.LinkLabel();
            this.linkSuprtRemoto = new System.Windows.Forms.LinkLabel();
            this.labelAppVersion = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textArqMinConfig = new System.Windows.Forms.Label();
            this.trackArqMin = new System.Windows.Forms.TrackBar();
            this.inputArqMin = new System.Windows.Forms.TextBox();
            this.checkStartSO = new System.Windows.Forms.CheckBox();
            this.button5 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.aplicarDiretorios = new System.Windows.Forms.Button();
            this.recarregarGridDiretorios = new System.Windows.Forms.Button();
            this.btnAdicionarDiretorio = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.dataGridDiretorio = new System.Windows.Forms.DataGridView();
            this.CNPJ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.diretorio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnRecursividade = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dataGridBtnExcluir = new System.Windows.Forms.DataGridViewButtonColumn();
            this.notifyUpdate = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackArqMin)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridDiretorio)).BeginInit();
            this.SuspendLayout();
            // 
            // notifyicon
            // 
            this.notifyicon.ContextMenuStrip = this.contextMenuStrip1;
            this.notifyicon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyicon.Icon")));
            this.notifyicon.Text = "Docss Upload";
            this.notifyicon.Visible = true;
            this.notifyicon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyicon_MouseDoubleClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.optionsToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(97, 48);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(96, 22);
            this.optionsToolStripMenuItem.Text = "App";
            this.optionsToolStripMenuItem.Click += new System.EventHandler(this.optionsToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(96, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // folderBrowserDialog1
            // 
            this.folderBrowserDialog1.HelpRequest += new System.EventHandler(this.folderBrowserDialog1_HelpRequest);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(390, 91);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(97, 28);
            this.button1.TabIndex = 2;
            this.button1.Text = "Buscar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_2);
            // 
            // _textDiretorio
            // 
            this._textDiretorio.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._textDiretorio.Location = new System.Drawing.Point(9, 91);
            this._textDiretorio.Margin = new System.Windows.Forms.Padding(2);
            this._textDiretorio.Name = "_textDiretorio";
            this._textDiretorio.Size = new System.Drawing.Size(345, 26);
            this._textDiretorio.TabIndex = 3;
            this._textDiretorio.TextChanged += new System.EventHandler(this._textDiretorio_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(7, 70);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "Diretorio - NF";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(2, 12);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 20);
            this.label4.TabIndex = 9;
            this.label4.Text = "Usuario";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // textUser
            // 
            this.textUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textUser.Location = new System.Drawing.Point(6, 35);
            this.textUser.Name = "textUser";
            this.textUser.ReadOnly = true;
            this.textUser.Size = new System.Drawing.Size(324, 26);
            this.textUser.TabIndex = 10;
            this.textUser.TextChanged += new System.EventHandler(this.textUser_TextChanged);
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.button3.Location = new System.Drawing.Point(13, 289);
            this.button3.Margin = new System.Windows.Forms.Padding(2);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(81, 35);
            this.button3.TabIndex = 14;
            this.button3.Text = "Editar";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.button4.Location = new System.Drawing.Point(9, 435);
            this.button4.Margin = new System.Windows.Forms.Padding(2);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(90, 35);
            this.button4.TabIndex = 15;
            this.button4.Text = "Monitor";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(5, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(751, 539);
            this.tabControl1.TabIndex = 17;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.linkatualizarapp);
            this.tabPage1.Controls.Add(this.labelPendEnvio);
            this.tabPage1.Controls.Add(this.linkSuprtRemoto);
            this.tabPage1.Controls.Add(this.labelAppVersion);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Controls.Add(this.checkStartSO);
            this.tabPage1.Controls.Add(this.button5);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.textBox2);
            this.tabPage1.Controls.Add(this.textUser);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.button3);
            this.tabPage1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPage1.Location = new System.Drawing.Point(4, 29);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(743, 506);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Inicialização";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // linkatualizarapp
            // 
            this.linkatualizarapp.AutoSize = true;
            this.linkatualizarapp.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.linkatualizarapp.Location = new System.Drawing.Point(324, 481);
            this.linkatualizarapp.Name = "linkatualizarapp";
            this.linkatualizarapp.Size = new System.Drawing.Size(71, 20);
            this.linkatualizarapp.TabIndex = 27;
            this.linkatualizarapp.TabStop = true;
            this.linkatualizarapp.Text = "Atualizar";
            this.linkatualizarapp.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkatualizarapp_LinkClicked);
            // 
            // labelPendEnvio
            // 
            this.labelPendEnvio.AutoSize = true;
            this.labelPendEnvio.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.labelPendEnvio.Location = new System.Drawing.Point(3, 481);
            this.labelPendEnvio.Name = "labelPendEnvio";
            this.labelPendEnvio.Size = new System.Drawing.Size(88, 20);
            this.labelPendEnvio.TabIndex = 26;
            this.labelPendEnvio.TabStop = true;
            this.labelPendEnvio.Text = "Pendencia:";
            this.labelPendEnvio.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.labelPendEnvio_LinkClicked);
            // 
            // linkSuprtRemoto
            // 
            this.linkSuprtRemoto.AutoSize = true;
            this.linkSuprtRemoto.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.linkSuprtRemoto.Location = new System.Drawing.Point(612, 481);
            this.linkSuprtRemoto.Name = "linkSuprtRemoto";
            this.linkSuprtRemoto.Size = new System.Drawing.Size(127, 20);
            this.linkSuprtRemoto.TabIndex = 25;
            this.linkSuprtRemoto.TabStop = true;
            this.linkSuprtRemoto.Text = "Suporte Remoto";
            this.linkSuprtRemoto.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkSuprtRemoto_LinkClicked);
            // 
            // labelAppVersion
            // 
            this.labelAppVersion.AutoSize = true;
            this.labelAppVersion.Location = new System.Drawing.Point(337, 449);
            this.labelAppVersion.Name = "labelAppVersion";
            this.labelAppVersion.Size = new System.Drawing.Size(44, 20);
            this.labelAppVersion.TabIndex = 24;
            this.labelAppVersion.Text = "0.0.0";
            this.labelAppVersion.Click += new System.EventHandler(this.label3_Click_1);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textArqMinConfig);
            this.groupBox1.Controls.Add(this.trackArqMin);
            this.groupBox1.Controls.Add(this.inputArqMin);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(7, 172);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(333, 99);
            this.groupBox1.TabIndex = 23;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Arquivos por minuto";
            // 
            // textArqMinConfig
            // 
            this.textArqMinConfig.AutoSize = true;
            this.textArqMinConfig.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textArqMinConfig.Location = new System.Drawing.Point(88, 26);
            this.textArqMinConfig.Name = "textArqMinConfig";
            this.textArqMinConfig.Size = new System.Drawing.Size(118, 13);
            this.textArqMinConfig.TabIndex = 24;
            this.textArqMinConfig.Text = "Zero(0) igual a ilimitado.";
            // 
            // trackArqMin
            // 
            this.trackArqMin.BackColor = System.Drawing.SystemColors.Window;
            this.trackArqMin.Location = new System.Drawing.Point(6, 45);
            this.trackArqMin.Maximum = 1000;
            this.trackArqMin.Name = "trackArqMin";
            this.trackArqMin.Size = new System.Drawing.Size(324, 45);
            this.trackArqMin.TabIndex = 22;
            this.trackArqMin.TickFrequency = 50;
            this.trackArqMin.ValueChanged += new System.EventHandler(this.trackArqMin_ValueChanged);
            // 
            // inputArqMin
            // 
            this.inputArqMin.Enabled = false;
            this.inputArqMin.Location = new System.Drawing.Point(6, 19);
            this.inputArqMin.MaxLength = 10;
            this.inputArqMin.Name = "inputArqMin";
            this.inputArqMin.ReadOnly = true;
            this.inputArqMin.Size = new System.Drawing.Size(77, 20);
            this.inputArqMin.TabIndex = 21;
            // 
            // checkStartSO
            // 
            this.checkStartSO.AutoSize = true;
            this.checkStartSO.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.checkStartSO.Location = new System.Drawing.Point(7, 131);
            this.checkStartSO.Name = "checkStartSO";
            this.checkStartSO.Size = new System.Drawing.Size(285, 24);
            this.checkStartSO.TabIndex = 20;
            this.checkStartSO.Text = "Carregar na inicialização do sistema.";
            this.checkStartSO.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            this.button5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.button5.Location = new System.Drawing.Point(98, 289);
            this.button5.Margin = new System.Windows.Forms.Padding(2);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(90, 35);
            this.button5.TabIndex = 19;
            this.button5.Text = "aplicar";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button2_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(2, 64);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 20);
            this.label2.TabIndex = 18;
            this.label2.Text = "Senha";
            // 
            // textBox2
            // 
            this.textBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox2.Location = new System.Drawing.Point(6, 86);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(324, 26);
            this.textBox2.TabIndex = 17;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.aplicarDiretorios);
            this.tabPage2.Controls.Add(this.recarregarGridDiretorios);
            this.tabPage2.Controls.Add(this.btnAdicionarDiretorio);
            this.tabPage2.Controls.Add(this.textBox1);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.dataGridDiretorio);
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Controls.Add(this._textDiretorio);
            this.tabPage2.Controls.Add(this.button4);
            this.tabPage2.Controls.Add(this.button1);
            this.tabPage2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPage2.Location = new System.Drawing.Point(4, 29);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(743, 506);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Captura";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // aplicarDiretorios
            // 
            this.aplicarDiretorios.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.aplicarDiretorios.Location = new System.Drawing.Point(182, 352);
            this.aplicarDiretorios.Margin = new System.Windows.Forms.Padding(2);
            this.aplicarDiretorios.Name = "aplicarDiretorios";
            this.aplicarDiretorios.Size = new System.Drawing.Size(81, 28);
            this.aplicarDiretorios.TabIndex = 23;
            this.aplicarDiretorios.Text = "Aplicar";
            this.aplicarDiretorios.UseVisualStyleBackColor = true;
            this.aplicarDiretorios.Click += new System.EventHandler(this.aplicarDiretorios_Click);
            // 
            // recarregarGridDiretorios
            // 
            this.recarregarGridDiretorios.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.recarregarGridDiretorios.Location = new System.Drawing.Point(9, 352);
            this.recarregarGridDiretorios.Margin = new System.Windows.Forms.Padding(2);
            this.recarregarGridDiretorios.Name = "recarregarGridDiretorios";
            this.recarregarGridDiretorios.Size = new System.Drawing.Size(159, 28);
            this.recarregarGridDiretorios.TabIndex = 22;
            this.recarregarGridDiretorios.Text = "Recarregar Diretorios";
            this.recarregarGridDiretorios.UseVisualStyleBackColor = true;
            this.recarregarGridDiretorios.Click += new System.EventHandler(this.recarregarGridDiretorios_Click);
            // 
            // btnAdicionarDiretorio
            // 
            this.btnAdicionarDiretorio.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdicionarDiretorio.Location = new System.Drawing.Point(9, 135);
            this.btnAdicionarDiretorio.Margin = new System.Windows.Forms.Padding(2);
            this.btnAdicionarDiretorio.Name = "btnAdicionarDiretorio";
            this.btnAdicionarDiretorio.Size = new System.Drawing.Size(97, 28);
            this.btnAdicionarDiretorio.TabIndex = 21;
            this.btnAdicionarDiretorio.Text = "Adicionar";
            this.btnAdicionarDiretorio.UseVisualStyleBackColor = true;
            this.btnAdicionarDiretorio.Click += new System.EventHandler(this.btnAdicionarDiretorio_Click);
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(9, 25);
            this.textBox1.MaxLength = 17;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(345, 26);
            this.textBox1.TabIndex = 20;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(7, 3);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 20);
            this.label5.TabIndex = 19;
            this.label5.Text = "CNPJ";
            // 
            // dataGridDiretorio
            // 
            this.dataGridDiretorio.AllowUserToAddRows = false;
            this.dataGridDiretorio.AllowUserToResizeColumns = false;
            this.dataGridDiretorio.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridDiretorio.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridDiretorio.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dataGridDiretorio.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridDiretorio.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridDiretorio.ColumnHeadersHeight = 30;
            this.dataGridDiretorio.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridDiretorio.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CNPJ,
            this.diretorio,
            this.columnRecursividade,
            this.dataGridBtnExcluir});
            this.dataGridDiretorio.Location = new System.Drawing.Point(9, 177);
            this.dataGridDiretorio.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridDiretorio.Name = "dataGridDiretorio";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlDark;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridDiretorio.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridDiretorio.RowHeadersVisible = false;
            this.dataGridDiretorio.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridDiretorio.RowTemplate.Height = 28;
            this.dataGridDiretorio.Size = new System.Drawing.Size(729, 171);
            this.dataGridDiretorio.TabIndex = 18;
            this.dataGridDiretorio.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridDiretorio_CellClick);
            // 
            // CNPJ
            // 
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CNPJ.DefaultCellStyle = dataGridViewCellStyle3;
            this.CNPJ.HeaderText = "CNPJ";
            this.CNPJ.MaxInputLength = 17;
            this.CNPJ.Name = "CNPJ";
            this.CNPJ.ReadOnly = true;
            this.CNPJ.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.CNPJ.Width = 140;
            // 
            // diretorio
            // 
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.diretorio.DefaultCellStyle = dataGridViewCellStyle4;
            this.diretorio.HeaderText = "Diretorio";
            this.diretorio.MaxInputLength = 500;
            this.diretorio.Name = "diretorio";
            this.diretorio.ReadOnly = true;
            this.diretorio.Width = 415;
            // 
            // columnRecursividade
            // 
            this.columnRecursividade.HeaderText = "Subpastas";
            this.columnRecursividade.Name = "columnRecursividade";
            this.columnRecursividade.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.columnRecursividade.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // dataGridBtnExcluir
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridBtnExcluir.DefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridBtnExcluir.HeaderText = "Ação";
            this.dataGridBtnExcluir.Name = "dataGridBtnExcluir";
            this.dataGridBtnExcluir.Text = "Excluir";
            this.dataGridBtnExcluir.UseColumnTextForButtonValue = true;
            this.dataGridBtnExcluir.Width = 70;
            // 
            // notifyUpdate
            // 
            this.notifyUpdate.ContextMenuStrip = this.contextMenuStrip1;
            this.notifyUpdate.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyUpdate.Icon")));
            this.notifyUpdate.Text = "Docss Upload";
            this.notifyUpdate.BalloonTipClicked += new System.EventHandler(this.notifyUpdate_BalloonTipClicked);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(760, 551);
            this.Controls.Add(this.tabControl1);
            this.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DocSS Upload";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackArqMin)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridDiretorio)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.NotifyIcon notifyicon;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox _textDiretorio;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textUser;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.DataGridView dataGridDiretorio;
        private System.Windows.Forms.CheckBox checkStartSO;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btnAdicionarDiretorio;
        private System.Windows.Forms.Button recarregarGridDiretorios;
        private System.Windows.Forms.DataGridViewButtonColumn dataGridBtnExcluir;
        private System.Windows.Forms.DataGridViewCheckBoxColumn columnRecursividade;
        private System.Windows.Forms.DataGridViewTextBoxColumn diretorio;
        private System.Windows.Forms.DataGridViewTextBoxColumn CNPJ;
        private System.Windows.Forms.TextBox inputArqMin;
        private System.Windows.Forms.TrackBar trackArqMin;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label textArqMinConfig;
        private System.Windows.Forms.Button aplicarDiretorios;
        private System.Windows.Forms.Label labelAppVersion;
        private System.Windows.Forms.LinkLabel linkSuprtRemoto;
        private System.Windows.Forms.LinkLabel labelPendEnvio;
        private System.Windows.Forms.LinkLabel linkatualizarapp;
        private System.Windows.Forms.NotifyIcon notifyUpdate;
    }
}


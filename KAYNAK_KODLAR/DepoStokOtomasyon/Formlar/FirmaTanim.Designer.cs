namespace DepoStokOtomasyon
{
    partial class FirmaTanim
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FirmaTanim));
            this.panel1 = new System.Windows.Forms.Panel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.tILBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txthesap = new System.Windows.Forms.MaskedTextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbil = new System.Windows.Forms.ComboBox();
            this.tILBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.iLDS = new DepoStokOtomasyon.ILDS();
            this.mtxttel = new System.Windows.Forms.MaskedTextBox();
            this.txtvergi = new System.Windows.Forms.TextBox();
            this.txtadres = new System.Windows.Forms.TextBox();
            this.txtad = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton4 = new System.Windows.Forms.ToolStripButton();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.tcmbara = new System.Windows.Forms.ToolStripComboBox();
            this.ttxtara = new System.Windows.Forms.ToolStripTextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.panel4 = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.t_ILTableAdapter = new DepoStokOtomasyon.ILDSTableAdapters.T_ILTableAdapter();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.panel2 = new System.Windows.Forms.Panel();
            this.linkLabel2 = new System.Windows.Forms.LinkLabel();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.pnlfirma = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tILBindingSource)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tILBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iLDS)).BeginInit();
            this.panel3.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel4.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.panel2.SuspendLayout();
            this.pnlfirma.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.toolStrip1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 19);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1003, 39);
            this.panel1.TabIndex = 49;
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.toolStrip1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(30, 30);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.toolStripSeparator1,
            this.toolStripButton2,
            this.toolStripSeparator2,
            this.toolStripButton3});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1003, 37);
            this.toolStrip1.TabIndex = 33;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(64, 34);
            this.toolStripButton1.Text = "Yeni";
            this.toolStripButton1.Click += new System.EventHandler(this.ToolStripButton1_Click_1);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 37);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(81, 34);
            this.toolStripButton2.Text = "Kaydet";
            this.toolStripButton2.Click += new System.EventHandler(this.ToolStripButton2_Click_1);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 37);
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton3.Image")));
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(77, 34);
            this.toolStripButton3.Text = "Listele";
            this.toolStripButton3.Click += new System.EventHandler(this.ToolStripButton3_Click_1);
            // 
            // tILBindingSource
            // 
            this.tILBindingSource.DataMember = "T_IL";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txthesap);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.cmbil);
            this.groupBox1.Controls.Add(this.mtxttel);
            this.groupBox1.Controls.Add(this.txtvergi);
            this.groupBox1.Controls.Add(this.txtadres);
            this.groupBox1.Controls.Add(this.txtad);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.groupBox1.Location = new System.Drawing.Point(29, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(860, 247);
            this.groupBox1.TabIndex = 55;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Firma Kartı Ekle";
            // 
            // txthesap
            // 
            this.txthesap.Location = new System.Drawing.Point(147, 198);
            this.txthesap.Mask = "TR00-0000-0000-0000-0000-0000-00";
            this.txthesap.Name = "txthesap";
            this.txthesap.Size = new System.Drawing.Size(226, 21);
            this.txthesap.TabIndex = 58;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label10.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label10.Location = new System.Drawing.Point(400, 51);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(15, 13);
            this.label10.TabIndex = 57;
            this.label10.Text = "İl";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(38, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 54;
            this.label2.Text = "Firma Adı";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label4.Location = new System.Drawing.Point(38, 103);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 13);
            this.label4.TabIndex = 56;
            this.label4.Text = "Telefon";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label3.Location = new System.Drawing.Point(400, 99);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 13);
            this.label3.TabIndex = 55;
            this.label3.Text = "Adres";
            // 
            // cmbil
            // 
            this.cmbil.DataSource = this.tILBindingSource1;
            this.cmbil.DisplayMember = "IL_AD";
            this.cmbil.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbil.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbil.FormattingEnabled = true;
            this.cmbil.Location = new System.Drawing.Point(465, 48);
            this.cmbil.Name = "cmbil";
            this.cmbil.Size = new System.Drawing.Size(242, 21);
            this.cmbil.TabIndex = 47;
            this.cmbil.ValueMember = "IL_ID";
            // 
            // tILBindingSource1
            // 
            this.tILBindingSource1.DataMember = "T_IL";
            this.tILBindingSource1.DataSource = this.iLDS;
            // 
            // iLDS
            // 
            this.iLDS.DataSetName = "ILDS";
            this.iLDS.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // mtxttel
            // 
            this.mtxttel.Location = new System.Drawing.Point(147, 98);
            this.mtxttel.Mask = "(999) 000-0000";
            this.mtxttel.Name = "mtxttel";
            this.mtxttel.Size = new System.Drawing.Size(226, 21);
            this.mtxttel.TabIndex = 46;
            // 
            // txtvergi
            // 
            this.txtvergi.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtvergi.Location = new System.Drawing.Point(147, 148);
            this.txtvergi.Name = "txtvergi";
            this.txtvergi.Size = new System.Drawing.Size(226, 21);
            this.txtvergi.TabIndex = 28;
            // 
            // txtadres
            // 
            this.txtadres.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtadres.Location = new System.Drawing.Point(465, 96);
            this.txtadres.Multiline = true;
            this.txtadres.Name = "txtadres";
            this.txtadres.Size = new System.Drawing.Size(242, 125);
            this.txtadres.TabIndex = 25;
            // 
            // txtad
            // 
            this.txtad.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtad.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtad.Location = new System.Drawing.Point(147, 48);
            this.txtad.Name = "txtad";
            this.txtad.Size = new System.Drawing.Size(226, 21);
            this.txtad.TabIndex = 24;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label6.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label6.Location = new System.Drawing.Point(38, 150);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(80, 13);
            this.label6.TabIndex = 36;
            this.label6.Text = "Vergi Dairesi";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label7.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label7.Location = new System.Drawing.Point(38, 197);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(55, 13);
            this.label7.TabIndex = 37;
            this.label7.Text = "IBAN No";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.dataGridView1);
            this.panel3.Controls.Add(this.toolStrip2);
            this.panel3.Controls.Add(this.panel4);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(29, 256);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(860, 206);
            this.panel3.TabIndex = 56;
            this.panel3.Visible = false;
            // 
            // toolStrip2
            // 
            this.toolStrip2.ImageScalingSize = new System.Drawing.Size(30, 30);
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton4,
            this.toolStripLabel1,
            this.tcmbara,
            this.ttxtara});
            this.toolStrip2.Location = new System.Drawing.Point(0, 22);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(860, 37);
            this.toolStrip2.TabIndex = 46;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // toolStripButton4
            // 
            this.toolStripButton4.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripButton4.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton4.Image")));
            this.toolStripButton4.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.toolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton4.Name = "toolStripButton4";
            this.toolStripButton4.Size = new System.Drawing.Size(80, 34);
            this.toolStripButton4.Text = "   Sil      ";
            this.toolStripButton4.Click += new System.EventHandler(this.ToolStripButton4_Click);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripLabel1.Image")));
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(84, 34);
            this.toolStripLabel1.Text = "Kayıt Ara";
            // 
            // tcmbara
            // 
            this.tcmbara.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tcmbara.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.tcmbara.Items.AddRange(new object[] {
            "Firma Adı",
            "Telefon"});
            this.tcmbara.Name = "tcmbara";
            this.tcmbara.Size = new System.Drawing.Size(121, 37);
            // 
            // ttxtara
            // 
            this.ttxtara.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.ttxtara.Name = "ttxtara";
            this.ttxtara.Size = new System.Drawing.Size(100, 37);
            this.ttxtara.TextChanged += new System.EventHandler(this.Ttxtara_TextChanged);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 59);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(860, 147);
            this.dataGridView1.TabIndex = 47;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridView1_CellContentClick);
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridView1_CellContentClick);
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(21)))), ((int)(((byte)(110)))));
            this.panel4.Controls.Add(this.button2);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(860, 22);
            this.panel4.TabIndex = 48;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(44)))), ((int)(((byte)(52)))));
            this.button2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button2.BackgroundImage")));
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button2.Dock = System.Windows.Forms.DockStyle.Right;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button2.ForeColor = System.Drawing.Color.LightGray;
            this.button2.Location = new System.Drawing.Point(837, 0);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(23, 22);
            this.button2.TabIndex = 1;
            this.button2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.Button2_Click);
            // 
            // t_ILTableAdapter
            // 
            this.t_ILTableAdapter.ClearBeforeFill = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 2.691924F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 86.44068F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10.9671F));
            this.tableLayoutPanel1.Controls.Add(this.panel3, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.groupBox1, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 58);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 54.54546F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 45.45454F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1003, 465);
            this.tableLayoutPanel1.TabIndex = 51;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.panel2.Controls.Add(this.linkLabel2);
            this.panel2.Controls.Add(this.linkLabel1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1003, 19);
            this.panel2.TabIndex = 52;
            // 
            // linkLabel2
            // 
            this.linkLabel2.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(21)))), ((int)(((byte)(110)))));
            this.linkLabel2.AutoSize = true;
            this.linkLabel2.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.linkLabel2.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(80)))), ((int)(((byte)(200)))));
            this.linkLabel2.Location = new System.Drawing.Point(12, 3);
            this.linkLabel2.Name = "linkLabel2";
            this.linkLabel2.Size = new System.Drawing.Size(60, 13);
            this.linkLabel2.TabIndex = 1;
            this.linkLabel2.TabStop = true;
            this.linkLabel2.Text = "Anasayfa >";
            this.linkLabel2.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkLabel2_LinkClicked);
            // 
            // linkLabel1
            // 
            this.linkLabel1.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(21)))), ((int)(((byte)(110)))));
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.linkLabel1.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(80)))), ((int)(((byte)(200)))));
            this.linkLabel1.Location = new System.Drawing.Point(70, 3);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(77, 13);
            this.linkLabel1.TabIndex = 0;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Firma Tanımları";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkLabel1_LinkClicked);
            // 
            // pnlfirma
            // 
            this.pnlfirma.Controls.Add(this.tableLayoutPanel1);
            this.pnlfirma.Controls.Add(this.panel1);
            this.pnlfirma.Controls.Add(this.panel2);
            this.pnlfirma.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlfirma.Location = new System.Drawing.Point(0, 0);
            this.pnlfirma.Name = "pnlfirma";
            this.pnlfirma.Size = new System.Drawing.Size(1003, 523);
            this.pnlfirma.TabIndex = 59;
            // 
            // FirmaTanim
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1003, 523);
            this.Controls.Add(this.pnlfirma);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FirmaTanim";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FirmaTanim";
            this.Load += new System.EventHandler(this.FirmaTanim_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tILBindingSource)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tILBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iLDS)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel4.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.pnlfirma.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
       
        private System.Windows.Forms.BindingSource tILBindingSource;

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbil;
        private System.Windows.Forms.MaskedTextBox mtxttel;
        private System.Windows.Forms.TextBox txtvergi;
        private System.Windows.Forms.TextBox txtadres;
        private System.Windows.Forms.TextBox txtad;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton toolStripButton4;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripTextBox ttxtara;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ToolStripComboBox tcmbara;
        private ILDS iLDS;
        private System.Windows.Forms.BindingSource tILBindingSource1;
        private ILDSTableAdapters.T_ILTableAdapter t_ILTableAdapter;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.LinkLabel linkLabel2;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Panel pnlfirma;
        private System.Windows.Forms.MaskedTextBox txthesap;
    }
}
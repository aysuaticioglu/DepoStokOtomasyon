namespace DepoStokOtomasyon.Formlar
{
    partial class StokHareket
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StokHareket));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.tcmbara = new System.Windows.Forms.ToolStripComboBox();
            this.btnraporla = new System.Windows.Forms.ToolStripButton();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.dtgstok = new Bunifu.Framework.UI.BunifuCustomDataGrid();
            this.panel6 = new System.Windows.Forms.Panel();
            this.linkLabel2 = new System.Windows.Forms.LinkLabel();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.pnlstokh = new System.Windows.Forms.Panel();
            this.toolStrip2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgstok)).BeginInit();
            this.panel6.SuspendLayout();
            this.pnlstokh.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip2
            // 
            this.toolStrip2.ImageScalingSize = new System.Drawing.Size(30, 30);
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.tcmbara,
            this.btnraporla});
            this.toolStrip2.Location = new System.Drawing.Point(0, 19);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(926, 37);
            this.toolStrip2.TabIndex = 48;
            this.toolStrip2.Text = "toolStrip2";
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
            this.tcmbara.AutoCompleteCustomSource.AddRange(new string[] {
            "Stok Kodu",
            "Stok Adı",
            "Kategori",
            "Miktar"});
            this.tcmbara.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tcmbara.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.tcmbara.Items.AddRange(new object[] {
            "Stok Giriş",
            "Stok Çıkış"});
            this.tcmbara.Name = "tcmbara";
            this.tcmbara.Size = new System.Drawing.Size(121, 37);
            this.tcmbara.SelectedIndexChanged += new System.EventHandler(this.Tcmbara_SelectedIndexChanged);
            // 
            // btnraporla
            // 
            this.btnraporla.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnraporla.Image = ((System.Drawing.Image)(resources.GetObject("btnraporla.Image")));
            this.btnraporla.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnraporla.Name = "btnraporla";
            this.btnraporla.Size = new System.Drawing.Size(81, 34);
            this.btnraporla.Text = "Raporla";
            this.btnraporla.Click += new System.EventHandler(this.Btnraporla_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.dtgstok, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 56);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 426F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(926, 426);
            this.tableLayoutPanel1.TabIndex = 51;
            // 
            // dtgstok
            // 
            this.dtgstok.AllowUserToAddRows = false;
            this.dtgstok.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dtgstok.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dtgstok.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dtgstok.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dtgstok.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dtgstok.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(21)))), ((int)(((byte)(110)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgstok.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dtgstok.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgstok.DefaultCellStyle = dataGridViewCellStyle3;
            this.dtgstok.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgstok.DoubleBuffered = true;
            this.dtgstok.EnableHeadersVisualStyles = false;
            this.dtgstok.HeaderBgColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(21)))), ((int)(((byte)(110)))));
            this.dtgstok.HeaderForeColor = System.Drawing.SystemColors.Control;
            this.dtgstok.Location = new System.Drawing.Point(3, 3);
            this.dtgstok.Name = "dtgstok";
            this.dtgstok.ReadOnly = true;
            this.dtgstok.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgstok.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dtgstok.RowHeadersVisible = false;
            this.dtgstok.RowHeadersWidth = 90;
            this.dtgstok.Size = new System.Drawing.Size(920, 420);
            this.dtgstok.TabIndex = 51;
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.panel6.Controls.Add(this.linkLabel2);
            this.panel6.Controls.Add(this.linkLabel1);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel6.Location = new System.Drawing.Point(0, 0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(926, 19);
            this.panel6.TabIndex = 54;
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
            this.linkLabel1.Size = new System.Drawing.Size(81, 13);
            this.linkLabel1.TabIndex = 0;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Stok Hareketler";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkLabel1_LinkClicked);
            // 
            // pnlstokh
            // 
            this.pnlstokh.Controls.Add(this.tableLayoutPanel1);
            this.pnlstokh.Controls.Add(this.toolStrip2);
            this.pnlstokh.Controls.Add(this.panel6);
            this.pnlstokh.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlstokh.Location = new System.Drawing.Point(0, 0);
            this.pnlstokh.Name = "pnlstokh";
            this.pnlstokh.Size = new System.Drawing.Size(926, 482);
            this.pnlstokh.TabIndex = 55;
            // 
            // StokHareket
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(926, 482);
            this.Controls.Add(this.pnlstokh);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "StokHareket";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "StokHareket";
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgstok)).EndInit();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.pnlstokh.ResumeLayout(false);
            this.pnlstokh.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripComboBox tcmbara;
        private System.Windows.Forms.ToolStripButton btnraporla;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private Bunifu.Framework.UI.BunifuCustomDataGrid dtgstok;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.LinkLabel linkLabel2;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Panel pnlstokh;
    }
}
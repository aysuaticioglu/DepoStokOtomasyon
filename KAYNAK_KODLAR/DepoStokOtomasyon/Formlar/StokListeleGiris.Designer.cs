namespace DepoStokOtomasyon
{
    partial class StokListeleGiris
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StokListeleGiris));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Sec = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.tcmbara = new System.Windows.Forms.ToolStripComboBox();
            this.ttxtara = new System.Windows.Forms.ToolStripTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Sec});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dataGridView1.Location = new System.Drawing.Point(0, 36);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(810, 246);
            this.dataGridView1.TabIndex = 47;
            // 
            // Sec
            // 
            this.Sec.HeaderText = "Seç";
            this.Sec.Name = "Sec";
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(30, 30);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.tcmbara,
            this.ttxtara});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(810, 33);
            this.toolStrip1.TabIndex = 46;
            this.toolStrip1.Text = "toolStrip1";
            this.toolStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.ToolStrip1_ItemClicked);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripLabel1.Image")));
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(84, 30);
            this.toolStripLabel1.Text = "Kayıt Ara";
            // 
            // tcmbara
            // 
            this.tcmbara.Items.AddRange(new object[] {
            "Stok Kodu",
            "Stok Adı",
            "Barkod"});
            this.tcmbara.Name = "tcmbara";
            this.tcmbara.Size = new System.Drawing.Size(121, 33);
            // 
            // ttxtara
            // 
            this.ttxtara.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.ttxtara.Name = "ttxtara";
            this.ttxtara.Size = new System.Drawing.Size(100, 33);
            // 
            // StokListeleGiris
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(810, 282);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "StokListeleGiris";
            this.Text = "StokListeleGiris";
            this.Load += new System.EventHandler(this.StokListeleGiris_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripComboBox tcmbara;
        private System.Windows.Forms.ToolStripTextBox ttxtara;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Sec;
    }
}
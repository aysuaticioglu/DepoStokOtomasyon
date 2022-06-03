namespace DepoStokOtomasyon.Formlar
{
    partial class Islemler
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.t_BIRIMTableAdapter1 = new DepoStokOtomasyon.BirimDSTableAdapters.T_BIRIMTableAdapter();
            this.panel9 = new System.Windows.Forms.Panel();
            this.livechart1 = new LiveCharts.WinForms.CartesianChart();
            this.islemlerdatagrid = new Bunifu.Framework.UI.BunifuCustomDataGrid();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.pieChart1 = new LiveCharts.WinForms.PieChart();
            this.pastagrafik = new LiveCharts.WinForms.PieChart();
            ((System.ComponentModel.ISupportInitialize)(this.islemlerdatagrid)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // t_BIRIMTableAdapter1
            // 
            this.t_BIRIMTableAdapter1.ClearBeforeFill = true;
            // 
            // panel9
            // 
            this.panel9.AutoSize = true;
            this.panel9.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel9.Location = new System.Drawing.Point(0, 0);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(1052, 0);
            this.panel9.TabIndex = 53;
            // 
            // livechart1
            // 
            this.livechart1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.livechart1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.livechart1.Location = new System.Drawing.Point(10, 3);
            this.livechart1.Name = "livechart1";
            this.livechart1.Size = new System.Drawing.Size(835, 272);
            this.livechart1.TabIndex = 56;
            this.livechart1.Text = "cartesianChart1";
            // 
            // islemlerdatagrid
            // 
            this.islemlerdatagrid.AllowUserToAddRows = false;
            this.islemlerdatagrid.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            this.islemlerdatagrid.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.islemlerdatagrid.BackgroundColor = System.Drawing.SystemColors.Control;
            this.islemlerdatagrid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.islemlerdatagrid.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.DarkSlateBlue;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Verdana", 7.75F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.islemlerdatagrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.islemlerdatagrid.ColumnHeadersHeight = 15;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.ButtonFace;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.ButtonFace;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.islemlerdatagrid.DefaultCellStyle = dataGridViewCellStyle3;
            this.islemlerdatagrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.islemlerdatagrid.DoubleBuffered = true;
            this.islemlerdatagrid.EnableHeadersVisualStyles = false;
            this.islemlerdatagrid.GridColor = System.Drawing.SystemColors.Control;
            this.islemlerdatagrid.HeaderBgColor = System.Drawing.Color.DarkSlateBlue;
            this.islemlerdatagrid.HeaderForeColor = System.Drawing.SystemColors.Control;
            this.islemlerdatagrid.Location = new System.Drawing.Point(10, 281);
            this.islemlerdatagrid.MultiSelect = false;
            this.islemlerdatagrid.Name = "islemlerdatagrid";
            this.islemlerdatagrid.ReadOnly = true;
            this.islemlerdatagrid.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.ButtonFace;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.islemlerdatagrid.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.islemlerdatagrid.RowHeadersVisible = false;
            this.islemlerdatagrid.RowHeadersWidth = 100;
            this.islemlerdatagrid.Size = new System.Drawing.Size(835, 246);
            this.islemlerdatagrid.TabIndex = 54;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 0.7604563F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 80.03802F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 19.29658F));
            this.tableLayoutPanel1.Controls.Add(this.islemlerdatagrid, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.livechart1, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.pieChart1, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.pastagrafik, 2, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 52.45283F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 47.54717F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1052, 530);
            this.tableLayoutPanel1.TabIndex = 55;
            // 
            // pieChart1
            // 
            this.pieChart1.Location = new System.Drawing.Point(851, 3);
            this.pieChart1.Name = "pieChart1";
            this.pieChart1.Size = new System.Drawing.Size(198, 272);
            this.pieChart1.TabIndex = 57;
            this.pieChart1.Text = "pieChart1";
            // 
            // pastagrafik
            // 
            this.pastagrafik.Location = new System.Drawing.Point(851, 281);
            this.pastagrafik.Name = "pastagrafik";
            this.pastagrafik.Size = new System.Drawing.Size(198, 246);
            this.pastagrafik.TabIndex = 58;
            this.pastagrafik.Text = "pieChart2";
            // 
            // Islemler
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1052, 530);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.panel9);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Islemler";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Islemler";
            this.Load += new System.EventHandler(this.Islemler_Load_1);
            ((System.ComponentModel.ISupportInitialize)(this.islemlerdatagrid)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private BirimDSTableAdapters.T_BIRIMTableAdapter t_BIRIMTableAdapter1;
        private System.Windows.Forms.Panel panel9;
        private LiveCharts.WinForms.CartesianChart livechart1;
        private Bunifu.Framework.UI.BunifuCustomDataGrid islemlerdatagrid;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private LiveCharts.WinForms.PieChart pieChart1;
        private LiveCharts.WinForms.PieChart pastagrafik;
    }
}
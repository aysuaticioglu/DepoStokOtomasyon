using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DepoStokOtomasyon
{
    public partial class FirmaListele : Form
    {
        public string firmaID;
        public FirmaListele()
        {
            InitializeComponent();
        }
        SqlConnection baglan = new SqlConnection(ConfigurationManager.ConnectionStrings["Baglanti"].ToString());
        DataSet daset = new DataSet();
        private void ToolStripButton1_Click(object sender, EventArgs e)
        {
            baglan.Open();
            SqlCommand komut = new SqlCommand("Delete From T_FIRMA Where FIRMA_AD='" + dataGridView1.CurrentRow.Cells["FIRMA_AD"].Value.ToString() + "'", baglan);
            komut.ExecuteNonQuery();
            baglan.Close();
            daset.Tables["T_FIRMA"].Clear();
            KayitGoster();
            MessageBox.Show("Firma Kaydı Silindi.");
            foreach (Control item in this.Controls)
            {
                if (item is TextBox)
                {
                    item.Text = "";
                }

            }
        }
        private void KayitGoster()
        {
            baglan.Open();
            SqlDataAdapter adptr = new SqlDataAdapter("Select F.FIRMA_ID,F.FIRMA_AD,I.IL_AD AS IL,F.ADRES,F.TEL,F.VDAIRE,F.HESAP_NO,F.YETKILI_AD,F.YETKILI_SOYAD,YETKILI_EPOSTA From " +
                "T_FIRMA AS F , T_IL AS I " +
                "WHERE I.IL_ID=F.IL_ID", baglan);
            adptr.Fill(daset, "T_FIRMA");
            dataGridView1.DataSource = daset.Tables["T_FIRMA"];
            baglan.Close();
        }

        private void FirmaListele_Load(object sender, EventArgs e)
        {
            KayitGoster();
            
        }

        private void ToolStripTextBox1_TextChanged(object sender, EventArgs e)
        {
            if (toolStripComboBox1.Text == "Firma Adı")
            {
                DataTable tablo = new DataTable();
                baglan.Open();
                SqlDataAdapter adtr = new SqlDataAdapter("Select F.FIRMA_ID, F.FIRMA_AD, I.IL_AD AS IL, F.ADRES, F.TEL, F.VDAIRE, F.HESAP_NO, F.YETKILI_AD, F.YETKILI_SOYAD, YETKILI_EPOSTA From " +
                "T_FIRMA AS F , T_IL AS I " +
                "WHERE I.IL_ID=F.IL_ID AND  F.FIRMA_AD Like'%" + toolStripTextBox1.Text + "%'", baglan);
                adtr.Fill(tablo);
                dataGridView1.DataSource = tablo;
                baglan.Close();

            }
            if (toolStripComboBox1.Text == "Telefon")
            {
                DataTable tablo = new DataTable();
                baglan.Open();
                SqlDataAdapter adtr = new SqlDataAdapter("Select F.FIRMA_ID, F.FIRMA_AD, I.IL_AD AS IL, F.ADRES, F.TEL, F.VDAIRE, F.HESAP_NO, F.YETKILI_AD, F.YETKILI_SOYAD, YETKILI_EPOSTA From " +
                "T_FIRMA AS F , T_IL AS I " +
                "WHERE I.IL_ID=F.IL_ID AND  F.TEL Like'%" + toolStripTextBox1.Text + "%'", baglan);

                adtr.Fill(tablo);

                dataGridView1.DataSource = tablo;

                baglan.Close();
            }
        }

        private void ToolStripComboBox1_Click(object sender, EventArgs e)
        {

        }

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            FirmaTanim frm2 = new FirmaTanim();
            frm2.Name = "FIRMA";
            if (Application.OpenForms["FIRMA"] == null)
            {
                
                frm2.firmaID = dataGridView1.CurrentRow.Cells["FIRMA_ID"].Value.ToString();
                
                frm2.Show();
               
            }
            else
            {
                Application.OpenForms["FIRMA"].BringToFront();
               

            }
        }
    }
}
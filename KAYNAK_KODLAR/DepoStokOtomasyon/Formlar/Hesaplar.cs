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
    public partial class Hesaplar : Form
    {
        SqlConnection baglan = new SqlConnection(ConfigurationManager.ConnectionStrings["Baglanti"].ToString());
        SqlCommand komut;  DataSet daset = new DataSet();
        public string HesapID = "";
        public Hesaplar()
        {
            InitializeComponent();
        }
        private void KayitGoster()//DATAGRIDVIEW DOLDURMA
        {
            daset.Clear();
            baglan.Open();
            SqlDataAdapter adptr = new SqlDataAdapter("SELECT * FROM T_HESAP", baglan);
            adptr.Fill(daset, "T_HESAP");
            dataGridView1.DataSource = daset.Tables["T_HESAP"];
            baglan.Close();
            dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }
        private void ToolStripButton2_Click(object sender, EventArgs e)//KAYDET BUTONUNA BASILDIĞINDA
        {
            if (HesapID == "" && txthad.Text!="")
            {
                baglan.Open();
                komut = new SqlCommand("INSERT INTO T_HESAP VALUES( @HESAP_AD,@IBAN,@BANKA,@BAKIYE) ", baglan);
                komut.Parameters.AddWithValue("@HESAP_AD", txthad.Text);
                komut.Parameters.AddWithValue("@IBAN", txtIban.Text);
                komut.Parameters.AddWithValue("@BANKA",txtbanka.Text);
                komut.Parameters.AddWithValue("@BAKIYE", 0);
          
                komut.ExecuteNonQuery();
                baglan.Close();
                MessageBox.Show("Hesap Kaydı Eklendi");
                daset.Clear();
                KayitGoster();
            }
            else if (HesapID != "" && txthad.Text != "")
            {
                baglan.Open();
                komut = new SqlCommand("UPDATE T_HESAP SET  HESAP_AD=@HESAP_AD,IBAN=@IBAN,BANKA=@BANKA WHERE HESAP_ID=" + HesapID, baglan);
                komut.Parameters.AddWithValue("@HESAP_AD", txthad.Text);
                komut.Parameters.AddWithValue("@IBAN", txtIban.Text);
                komut.Parameters.AddWithValue("@BANKA", txtbanka.Text);
                komut.ExecuteNonQuery();
                baglan.Close();
                MessageBox.Show("Hesap Kaydı Güncellendi");
                daset.Clear();
                KayitGoster();
            }
            else
            {
                txthad.Focus();
                errorProvider1.SetError(txthad, "Boş Geçilmez");
            }
        }
        private void ToolStripButton1_Click(object sender, EventArgs e)//YENİ BUTONUNA BASILDIĞINDA
        {
            HesapID = "";
            txtbanka.Text = "";
            txthad.Text = "";
            txtIban.Text = "";
        }
        private void ToolStripButton4_Click(object sender, EventArgs e)//SİL BUTONUNA BASILDIĞINDA
        {
            string message = "Kaydı Silmek İstiyor Musunuz?";
            string title = "Sil";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;

            DialogResult result = MessageBox.Show(message, title, buttons, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
            if (result == DialogResult.Yes)
            {
                baglan.Open();
                SqlCommand komut = new SqlCommand("Delete From T_HESAP Where HESAP_AD='" + dataGridView1.CurrentRow.Cells["HESAP_AD"].Value.ToString() + "'", baglan);
                komut.ExecuteNonQuery();
                baglan.Close();
                daset.Tables["T_HESAP"].Clear();
                KayitGoster();
                MessageBox.Show("Hesap Kaydı Silindi.");
                foreach (Control item in this.Controls)
                {
                    if (item is TextBox)
                    {
                        item.Text = "";
                    }

                }
            }
        }
        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)//DATAGRIDVIEWDEN VERİ SEÇİLDİĞİNDE
        {
            HesapID = dataGridView1.CurrentRow.Cells["HESAP_ID"].Value.ToString();
            if (HesapID != "")
            {

                baglan.Open();
                SqlCommand komut = new SqlCommand("Select * From T_HESAP where HESAP_ID='" + HesapID + "'", baglan);
                SqlDataReader data;
                data = komut.ExecuteReader();
                while (data.Read())
                {
                    txthad.Text = data[1].ToString();
                 
                    txtIban.Text = data[2].ToString();
                    txtbanka.Text = data[3].ToString();

                }
                baglan.Close();
            }

        }
        private void Hesaplar_Load(object sender, EventArgs e)
        {
            KayitGoster();
        }
        private void Ttxtara_TextChanged(object sender, EventArgs e)//DATAGRIDVIEWDE ARAMA YAPILDIĞINDA
        {
            DataTable tablo = new DataTable();
            baglan.Open();
            SqlDataAdapter adtr = new SqlDataAdapter("Select * From T_HESAP WHERE HESAP_AD Like'%" + ttxtara.Text + "%'", baglan);
            adtr.Fill(tablo);
            dataGridView1.DataSource = tablo;
            baglan.Close();
        }
        private void LinkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)//UST LINK
        {
            pnlhesaplar.Controls.Clear();
            Formlar.Islemler fe2 = new Formlar.Islemler();
            fe2.TopLevel = false;
            pnlhesaplar.Controls.Add(fe2);
            fe2.Show();
            fe2.Dock = DockStyle.Fill;
            fe2.BringToFront();
        }
        private void LinkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)//UST LINK
        {
            pnlhesaplar.Controls.Clear();
            Hesaplar fe2 = new Hesaplar();
            fe2.TopLevel = false;
            pnlhesaplar.Controls.Add(fe2);
            fe2.Show();
            fe2.Dock = DockStyle.Fill;
            fe2.BringToFront();
        }
    }
}

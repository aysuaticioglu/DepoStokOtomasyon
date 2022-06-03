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
    public partial class KullaniciHesap : Form
    {
        public string kad="";
        public KullaniciHesap()
        {
            InitializeComponent();
        }
        SqlConnection baglan = new SqlConnection(ConfigurationManager.ConnectionStrings["Baglanti"].ToString());
        SqlCommand komut;
        public string ad;
      
        private void KullaniciHesap_Load(object sender, EventArgs e)//KULLANICI BİLGİLER
        {
            if (kad!="")
            {
                baglan.Open();
                SqlCommand komut = new SqlCommand("Select * From T_KULLANICI where KULLANICI_ID='" + kad + "'", baglan);
                SqlDataReader data;
                data = komut.ExecuteReader();
                while (data.Read())
                {
                    textBox1.Text = data[1].ToString();
                    textBox2.Text = data[2].ToString();
                    textBox3.Text = data[3].ToString();
                    textBox4.Text = data[4].ToString();
                    textBox5.Text = data[5].ToString();

                }
                baglan.Close();
            }
        }
        private void ToolStripButton2_Click(object sender, EventArgs e)//KAYDET BUTONUNA BASILDIĞINDA
        {
          
            baglan.Open();
            komut = new SqlCommand("UPDATE T_KULLANICI  SET  AD=@AD,SOYAD=@SOYAD,K_AD=@K_AD,K_SIFRE=@K_SIFRE,EPOSTA=@EPOSTA WHERE KULLANICI_ID='"+kad+"'", baglan);
            komut.Parameters.AddWithValue("@AD", textBox1.Text);
            komut.Parameters.AddWithValue("@SOYAD", textBox2.Text);
            komut.Parameters.AddWithValue("@K_AD", textBox3.Text);
            komut.Parameters.AddWithValue("@K_SIFRE", textBox4.Text);
            komut.Parameters.AddWithValue("@EPOSTA", textBox5.Text);
            komut.ExecuteNonQuery();
            baglan.Close();
            MessageBox.Show("Değişikler Güncellendi");
     

          

        }
        private void LinkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)//UST LINK
        {
            pnlkul.Controls.Clear();
            Formlar.Islemler fe2 = new Formlar.Islemler();
            fe2.TopLevel = false;
            pnlkul.Controls.Add(fe2);
            fe2.Show();
            fe2.Dock = DockStyle.Fill;
            fe2.BringToFront();
        }
        private void LinkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)//UST LINK
        {
            pnlkul.Controls.Clear();
            KullaniciHesap fe2 = new KullaniciHesap();
            fe2.TopLevel = false;
            pnlkul.Controls.Add(fe2);
            fe2.Show();
            fe2.Dock = DockStyle.Fill;
            fe2.BringToFront();
        }
    }
}

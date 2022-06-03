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
    public partial class Giris : Form
    {
        public Giris()
        {
            InitializeComponent();
        }
        SqlConnection baglan = new SqlConnection(ConfigurationManager.ConnectionStrings["Baglanti"].ToString());
        public string kad;

        SqlDataReader data;
        SqlCommand komut;
        private void Button1_Click(object sender, EventArgs e)//GİRİŞ YAP BUTONU
        {
            GirisYap();
        }
        private void GirisYap()//KULLANICI ADI ve ŞİFRE KONTROL
        {
            baglan.Open();
            if (textBox1.Text == "" || textBox3.Text == "")
            {
                MessageBox.Show("Kullanıcı Adı ve Şifre Girmeniz Gerekiyor.");
            }
            else
            {

                komut = new SqlCommand("Select * From T_KULLANICI Where K_AD=@Ad And K_SIFRE=@Sifre", baglan);
                komut.Parameters.AddWithValue("@Ad", textBox1.Text);
                komut.Parameters.AddWithValue("@Sifre", textBox3.Text);
                data = komut.ExecuteReader();

                if (data.Read())
                {
                    Anasayfa frm = new Anasayfa();
                    frm.kad = data[0].ToString();
                    frm.Show();
                    this.Hide();

                }

                else
                {

                    MessageBox.Show("Kullanıcı Adı ve Şifre Yanlış.");

                }



            }
        }
        private void Button7_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void Giris_Load(object sender, EventArgs e)//OTURUMU KONTROL ETME
        {
            baglan.Open();
            komut = new SqlCommand("Select * From T_KULLANICI ", baglan);


            data = komut.ExecuteReader();

            if (data.Read())
            {
                if (Convert.ToBoolean(data[6]) == true)
                {
                    textBox1.Text = data[3].ToString();
                    textBox3.Text = data[4].ToString();

                }
            }
            baglan.Close();
        }
    }
}




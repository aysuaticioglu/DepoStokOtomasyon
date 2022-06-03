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
    public partial class Anasayfa : Form
    {
        SqlConnection baglan = new SqlConnection(ConfigurationManager.ConnectionStrings["Baglanti"].ToString());
        SqlCommand komut;
        public string kad = "";
        SqlDataReader data;
        public Anasayfa()
        {
            InitializeComponent();
            Design();
        }
        private void Design()//PANEL
        {
            pnlfirma.Visible = false;
            pnlstok.Visible = false;
            pnldepo.Visible = false;
            pnlanaliz.Visible = false;
            pnlhesap.Visible = false;

        }

        private void Anasayfa_Load(object sender, EventArgs e)//KULLANICI ADI KULLANMA
        {
            panel1.Visible = false;

            if (kad != "")
            {
                baglan.Open();
                komut = new SqlCommand("Select * From T_KULLANICI Where KULLANICI_ID=" + kad, baglan);


                data = komut.ExecuteReader();
                if (data.Read())
                {
                    bunifuThinButton21.ButtonText = data[3].ToString();

                }
                baglan.Close();


            }
            panel2.Controls.Clear();
            Formlar.Islemler fe2 = new Formlar.Islemler();
            fe2.TopLevel = false;
            panel2.Controls.Add(fe2);
            fe2.Show();
            fe2.Dock = DockStyle.Fill;
            fe2.BringToFront();

        }
        private void hideMenu()//MENU AYARLARI
        {

            if (pnldepo.Visible == true) pnldepo.Visible = false;
            if (pnlstok.Visible == true) pnlstok.Visible = false;
            if (pnlfirma.Visible == true) pnlfirma.Visible = false;
            if (pnlanaliz.Visible == true) pnlanaliz.Visible = false;
            if (pnlhesap.Visible == true) pnlhesap.Visible = false;
            if (panel10.Visible == true) panel10.Visible = false;

        }
        private void showMenu(Panel subMenu)//MENU AYARLARI
        {

            if (subMenu.Visible == false)
            {
                hideMenu();
                subMenu.Visible = true;
            }
            else
            {
                subMenu.Visible = false;

            }
        }

        private void Btndepotanim_Click(object sender, EventArgs e)
        {

            panel2.Controls.Clear();
            DepoTanim fe2 = new DepoTanim();
            fe2.TopLevel = false;
            panel2.Controls.Add(fe2);
            fe2.Show();
            fe2.Dock = DockStyle.Fill;
            fe2.BringToFront();

        }
        private void Btnsgiris_Click(object sender, EventArgs e)
        {
            panel2.Controls.Clear();
            StokGiris fe2 = new StokGiris();
            fe2.TopLevel = false;
            panel2.Controls.Add(fe2);
            fe2.Show();
            fe2.Dock = DockStyle.Fill;
            fe2.BringToFront();

        }
        private void Btnscikis_Click(object sender, EventArgs e)
        {
            panel2.Controls.Clear();
            StokCikis fe2 = new StokCikis();
            fe2.TopLevel = false;
            panel2.Controls.Add(fe2);
            fe2.Show();
            fe2.Dock = DockStyle.Fill;
            fe2.BringToFront();

        }
        private void Btnstanim_Click(object sender, EventArgs e)
        {
            panel2.Controls.Clear();
            StokTanim fe2 = new StokTanim();
            fe2.TopLevel = false;
            panel2.Controls.Add(fe2);
            fe2.Show();
            fe2.Dock = DockStyle.Fill;
            fe2.BringToFront();
        }
        private void Btnfirmatanim_Click(object sender, EventArgs e)
        {
            panel2.Controls.Clear();
            FirmaTanim fe2 = new FirmaTanim();
            fe2.TopLevel = false;
            panel2.Controls.Add(fe2);
            fe2.Show();
            fe2.Dock = DockStyle.Fill;
            fe2.BringToFront();
        }
        private void Btndeposayim_Click(object sender, EventArgs e)
        {

            panel2.Controls.Clear();
            DepoSayim fe2 = new DepoSayim();
            fe2.TopLevel = false;
            panel2.Controls.Add(fe2);
            fe2.Show();
            fe2.Dock = DockStyle.Fill;
            fe2.BringToFront();
        }
        private void BunifuThinButton21_Click(object sender, EventArgs e)//KULLANICI HESAP BUTONU
        {
            panel1.Visible = true;
            showMenu(panel10);
            panel2.Controls.Clear();
            KullaniciHesap fe2 = new KullaniciHesap();
            fe2.kad = kad;
            fe2.TopLevel = false;
            panel2.Controls.Add(fe2);
            fe2.Show();
            fe2.Dock = DockStyle.Fill;
            fe2.BringToFront();
        }
        private void Bfbstok_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
            panel11.BackColor = Color.Transparent;
            panel6.BackColor = Color.Transparent;
            panel5.BackColor = Color.Transparent;
            panel8.BackColor = Color.Transparent;
            panel4.BackColor = Color.White;
            showMenu(pnlstok);

        }
        private void Bfbdepo_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
            panel11.BackColor = Color.Transparent;
            panel6.BackColor = Color.White;
            panel5.BackColor = Color.Transparent;
            panel4.BackColor = Color.Transparent;
            panel8.BackColor = Color.Transparent;
            showMenu(pnldepo);
        }
        private void BunifuFlatButton1_Click(object sender, EventArgs e)//ANASAYFA BUTONU
        {
            panel1.Visible = false;
            panel2.Controls.Clear();
            Formlar.Islemler fe2 = new Formlar.Islemler();
            fe2.TopLevel = false;
            panel2.Controls.Add(fe2);
            fe2.Show();
            fe2.Dock = DockStyle.Fill;
            fe2.BringToFront();
            hideMenu();

        }
        private void Bfbfirma_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
            panel11.BackColor = Color.Transparent;
            panel6.BackColor = Color.Transparent;
            panel5.BackColor = Color.White;
            panel4.BackColor = Color.Transparent;
            panel8.BackColor = Color.Transparent;
            showMenu(pnlfirma);
        }
        private void Bfbanaliz_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
            panel11.BackColor = Color.Transparent;
            panel6.BackColor = Color.Transparent;
            panel5.BackColor = Color.Transparent;
            panel4.BackColor = Color.Transparent;
            panel8.BackColor = Color.White;
            showMenu(pnlanaliz);
        }
        private void Bfbhesap_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
            panel11.BackColor = Color.White;
            panel6.BackColor = Color.Transparent;
            panel5.BackColor = Color.Transparent;
            panel5.BackColor = Color.Transparent;
            panel8.BackColor = Color.Transparent;
            showMenu(pnlhesap);

        }
        private void Btnmevcut_Click(object sender, EventArgs e)
        {

            panel2.Controls.Clear();
            MevcutStok fe2 = new MevcutStok();
            fe2.TopLevel = false;
            panel2.Controls.Add(fe2);
            fe2.Show();
            fe2.Dock = DockStyle.Fill;
            fe2.BringToFront();
        }
        private void Depotransfer_Click(object sender, EventArgs e)
        {
            panel2.Controls.Clear();
            DepoTransfer fe2 = new DepoTransfer();
            fe2.TopLevel = false;
            panel2.Controls.Add(fe2);
            fe2.Show();
            fe2.Dock = DockStyle.Fill;
            fe2.BringToFront();
        }
        private void Btnhesap_Click(object sender, EventArgs e)
        {
            panel2.Controls.Clear();
            Hesaplar fe2 = new Hesaplar();
            fe2.TopLevel = false;
            panel2.Controls.Add(fe2);
            fe2.Show();
            fe2.Dock = DockStyle.Fill;
            fe2.BringToFront();
        }
        private void Btnkasa_Click(object sender, EventArgs e)
        {
            panel2.Controls.Clear();
            Kasa fe2 = new Kasa();
            fe2.TopLevel = false;
            panel2.Controls.Add(fe2);
            fe2.Show();
            fe2.Dock = DockStyle.Fill;
            fe2.BringToFront();
        }
        private void Btnhesaphareket_Click(object sender, EventArgs e)
        {
            panel2.Controls.Clear();
            Formlar.HesapHareket fe2 = new Formlar.HesapHareket();
            fe2.TopLevel = false;
            panel2.Controls.Add(fe2);
            fe2.Show();
            fe2.Dock = DockStyle.Fill;
            fe2.BringToFront();
        }
        private void Btndepotransfer_Click(object sender, EventArgs e)
        {
            panel2.Controls.Clear();
            Formlar.AnalizDepoTransferleri fe2 = new Formlar.AnalizDepoTransferleri();
            fe2.TopLevel = false;
            panel2.Controls.Add(fe2);
            fe2.Show();
            fe2.Dock = DockStyle.Fill;
            fe2.BringToFront();
        }
        private void Btnshareket_Click(object sender, EventArgs e)
        {
            panel2.Controls.Clear();
            Formlar.StokHareket fe2 = new Formlar.StokHareket();
            fe2.TopLevel = false;
            panel2.Controls.Add(fe2);
            fe2.Show();
            fe2.Dock = DockStyle.Fill;
            fe2.BringToFront();
        }
        private void Btncikis_Click(object sender, EventArgs e)//KULLANICI ÇIKIŞ YAP
        {

            baglan.Open();
            komut = new SqlCommand("UPDATE T_KULLANICI  SET OTURUM=@OTURUM WHERE KULLANICI_ID='" + kad + "'", baglan);
            komut.Parameters.AddWithValue("@OTURUM", true);
            komut.ExecuteNonQuery();
            baglan.Close();
            Application.Exit();
        }
        private void Btnoturum_Click(object sender, EventArgs e)//KULLANICI OTURUM KAPAT
        {
            baglan.Open();
            komut = new SqlCommand("UPDATE T_KULLANICI  SET OTURUM=@OTURUM WHERE KULLANICI_ID='" + kad + "'", baglan);
            komut.Parameters.AddWithValue("@OTURUM", false);
            komut.ExecuteNonQuery();
            baglan.Close();

            Application.Exit();

        }
    }
}


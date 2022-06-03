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
    public partial class Kasa : Form
    {
        SqlConnection baglan = new SqlConnection(ConfigurationManager.ConnectionStrings["Baglanti"].ToString());
        SqlDataReader data2; SqlCommand komut3, komut2, komut;
        Panel[] pnl = new Panel[10]; LinkLabel[] lbl = new LinkLabel[10]; Label[] lbl2 = new Label[10];
        int top = 60, left = 10, sayac = 0;
        string[] hesapad = new string[10]; string[] hesapid = new string[10]; decimal[] bakiye = new decimal[10];
        public Kasa()
        {
            InitializeComponent();
        }
        private void Kasa_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'hesapFirma.T_FIRMA' table. You can move, or remove it, as needed.
            this.t_FIRMATableAdapter.Fill(this.hesapFirma.T_FIRMA);
            // TODO: This line of code loads data into the 'hesapT2DS.T_HESAP' table. You can move, or remove it, as needed.
            this.t_HESAPTableAdapter1.Fill(this.hesapT2DS.T_HESAP);
            // TODO: This line of code loads data into the 'hesapT1DS.T_HESAP' table. You can move, or remove it, as needed.
            this.t_HESAPTableAdapter.Fill(this.hesapT1DS.T_HESAP);
            KayitSayi();
            Hesaplar();
        }
        private void Hesaplar()//DİNAMİK HESAP KISMI YAPMA
        {

            for (int i = 1; i <= sayac; i++)
            {
                baglan.Open();
                komut2 = new SqlCommand("Select top " + i + "* From T_HESAP ", baglan);

                data2 = komut2.ExecuteReader();

                while (data2.Read())
                {
                    hesapid[i] = data2[0].ToString();
                    hesapad[i] = data2[1].ToString();
                    bakiye[i] = Convert.ToDecimal(data2[4]);

                }
                baglan.Close();

            }
            for (int i = 1; i <= sayac; i++)
            {
                lbl[i] = new LinkLabel();
                lbl[i].Location = new Point(left + 5, top * (i) + 5);
                lbl[i].Text = hesapad[i];
                lbl[i].Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
                lbl[i].ForeColor = Color.Black;
                lbl[i].LinkColor = Color.FromArgb(7, 0, 72);
                lbl[i].BackColor = Color.Gainsboro;
                lbl[i].LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
                lbl[i].Name = "lbl";
                lbl[i].AutoSize = true;
                lbl[i].TabIndex = 0;



                lbl2[i] = new Label();
                lbl2[i].Location = new Point(left + 5, top * (i) + 25);
                lbl2[i].Text = bakiye[i].ToString("C");
                lbl2[i].Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
                lbl2[i].ForeColor = Color.Black;
                lbl2[i].BackColor = Color.Gainsboro;
                lbl2[i].Name = bakiye[i].ToString();
                lbl2[i].AutoSize = true;
                lbl2[i].TabIndex = 0;


                pnl[i] = new Panel();
                pnl[i].Width = 200;
                pnl[i].Height = 50;
                pnl[i].Location = new Point(left, top * (i));
                pnl[i].BackColor = Color.Gainsboro;
                panel1.Controls.Add(lbl[i]);
                panel1.Controls.Add(lbl2[i]);
                panel1.Controls.Add(pnl[i]);





            }
            if (sayac >= 2)
            {
                lbl[1].LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.Lbl1_LinkClicked);
                lbl[2].LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.Lbl2_LinkClicked);
         
            }
            if (sayac >= 3)
            {
  
                lbl[3].LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.Lbl3_LinkClicked);
            }

            if (sayac >= 4)
            {


                lbl[4].LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.Lbl4_LinkClicked);
            }

            if (sayac >= 5)
            {

                lbl[5].LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.Lbl5_LinkClicked);
            }

        }
        private void KayitSayi()//HESAPLARIN SAYISINI BULMA
        {
            komut = new SqlCommand("SELECT COUNT(*) FROM T_HESAP;", baglan);
            baglan.Open();
            sayac = Convert.ToInt32(komut.ExecuteScalar());
            baglan.Close();
        }
        private void Lbl1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)//HESAPLARIN TIKLANMASI
        {

            lblhesap.Text = hesapad[1];
            lblid.Text = hesapid[1];
            pnlicerik.Visible = true;
            cmbt1.SelectedValue = lblid.Text;
        }
        private void Lbl2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)//HESAPLARIN TIKLANMASI
        {
            lblhesap.Text = hesapad[2];
            lblid.Text = hesapid[2];
            pnlicerik.Visible = true;
            cmbt1.SelectedValue = lblid.Text;
        }
        private void Lbl3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)//HESAPLARIN TIKLANMASI
        {
            lblhesap.Text = hesapad[3];
            lblid.Text = hesapid[3];
            pnlicerik.Visible = true;
            cmbt1.SelectedValue = lblid.Text;
        }
        private void Lbl4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)//HESAPLARIN TIKLANMASI
        {
            lblhesap.Text = hesapad[4];
            lblid.Text = hesapid[4];
            pnlicerik.Visible = true;
            cmbt1.SelectedValue = lblid.Text;
        }
        private void Lbl5_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)//HESAPLARIN TIKLANMASI
        {
            lblhesap.Text = hesapad[5];
            lblid.Text = hesapid[5];
            pnlicerik.Visible = true;
            cmbt1.SelectedValue = lblid.Text;
        }
        private void Btngiris_Click(object sender, EventArgs e)//HESAP GİRİŞE TIKLANDIĞINDA
        {
            p1.BackColor = Color.FromArgb(0, 192, 0);
            p2.BackColor = Color.Transparent;
            p3.BackColor = Color.Transparent;
            p4.BackColor = Color.Transparent;
            p5.BackColor = Color.Transparent;
            groupBox1.Visible = true;
            groupBox2.Visible = false;
            groupBox3.Visible = false;
            groupBox4.Visible = false;
            groupBox5.Visible = false;
        }
        private void Btncikis_Click(object sender, EventArgs e)//HESAP ÇIKIŞA BASILDĞINDA
        {
            p1.BackColor = Color.Transparent;
            p2.BackColor = Color.FromArgb(192, 0, 0);
            p3.BackColor = Color.Transparent;
            p4.BackColor = Color.Transparent;
            p5.BackColor = Color.Transparent;
            groupBox1.Visible = false;
            groupBox2.Visible = true;
            groupBox3.Visible = false;
            groupBox4.Visible = false;
            groupBox5.Visible = false;
        }
        private void LinkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)//ÜST LINKLER(ANASAYFA)
        {
            pnlkasa.Controls.Clear();
            Formlar.Islemler fe2 = new Formlar.Islemler();
            fe2.TopLevel = false;
            pnlkasa.Controls.Add(fe2);
            fe2.Show();
            fe2.Dock = DockStyle.Fill;
            fe2.BringToFront();
        }
        private void LinkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)//ÜST LINKLER(KASA)
        {
            pnlkasa.Controls.Clear();
            Kasa fe2 = new Kasa();
            fe2.TopLevel = false;
            pnlkasa.Controls.Add(fe2);
            fe2.Show();
            fe2.Dock = DockStyle.Fill;
            fe2.BringToFront();
        }
        private void Btnfirmao_Click(object sender, EventArgs e)//FİRMA ÖDEMEYE TIKLANDIĞINDA
        {
            p1.BackColor = Color.Transparent;
            p2.BackColor = Color.Transparent;
            p3.BackColor = Color.Transparent;
            p4.BackColor = Color.FromArgb(192, 0, 0);
            p5.BackColor = Color.Transparent;
            groupBox1.Visible = false;
            groupBox2.Visible = false;
            groupBox3.Visible = false;
            groupBox4.Visible = true;
            groupBox5.Visible = false;
        }
        private void Btnfirmat_Click(object sender, EventArgs e)//FİRMA TAHSİLATA TIKLANDIĞINDA
        {

            p1.BackColor = Color.Transparent;
            p2.BackColor = Color.Transparent;
            p3.BackColor = Color.Transparent;
            p4.BackColor = Color.Transparent;
            p5.BackColor = Color.FromArgb(0, 192, 0);
            groupBox1.Visible = false;
            groupBox2.Visible = false;
            groupBox3.Visible = false;
            groupBox4.Visible = false;
            groupBox5.Visible = true;
        }
        private void Btnfirmaodeme_Click(object sender, EventArgs e)//FİRMA ÖDEME İŞLEMİ KABUL ETME 
        {
            if (txtfaciklama.Text != "" && txtftutar.Text != "" && cmbfirma.Text != "")
            {
                string message = cmbfirma.Text + " Firmasına "  + txtftutar.Text + " TL  Ödeme Yapılsın mı?";
                string title = "Firma Ödeme";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;

                DialogResult result = MessageBox.Show(message, title, buttons, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (result == DialogResult.Yes)
                {
                    baglan.Open();
                    komut3 = new SqlCommand("INSERT INTO T_FIRMAODEME VALUES(@HESAP_ID,@FIRMA_ID,@TUTAR,@ACIKLAMA,@TARIH);UPDATE T_HESAP SET BAKIYE-=@TUTAR WHERE HESAP_ID=" + lblid.Text +";UPDATE T_GIDER SET TUTAR=+@TUTAR WHERE AY=@AY", baglan);
                    komut3.Parameters.AddWithValue("@HESAP_ID",lblid.Text);
                    komut3.Parameters.AddWithValue("@FIRMA_ID", cmbfirma.SelectedValue);
                    komut3.Parameters.AddWithValue("@TUTAR", Convert.ToDecimal(txtftutar.Text));
                    komut3.Parameters.AddWithValue("@ACIKLAMA", txtfaciklama.Text);
                    komut3.Parameters.AddWithValue("@TARIH", dtpfirma.Value);
                    komut3.Parameters.AddWithValue("@AY", dtpfirma.Value.Month);
            
                    komut3.ExecuteNonQuery();
                    baglan.Close();
                    MessageBox.Show(cmbfirma.Text + " Firmasına " + txtftutar.Text + " TL  Ödeme Yapıldı.");

                }
            }
            else
            {
                txtftutar.Focus(); txtfaciklama.Focus(); cmbfirma.Focus(); 
                errorProvider1.SetError(txtftutar, "Boş Geçilmez");
                errorProvider1.SetError(txtfaciklama, "Boş Geçilmez");
                errorProvider1.SetError(cmbfirma, "Boş Geçilmez");
            }

        }
        private void Btnfirmatah_Click(object sender, EventArgs e)//FİRMA TAHSİLAT İŞLEMİ KABUL ETME
        {
            if (txta.Text != "" && txttl.Text != "" && cmbfirmat.Text != "")
            {
                string message = cmbfirmat.Text + " Firmasına " + txttl.Text + " TL  Ödeme Alınsın mı?";
                string title = "Firma Tahsilat";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;

                DialogResult result = MessageBox.Show(message, title, buttons, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (result == DialogResult.Yes)
                {
                    baglan.Open();
                    komut3 = new SqlCommand("INSERT INTO T_FIRMATAHSILAT VALUES(@HESAP_ID,@FIRMA_ID,@TUTAR,@ACIKLAMA,@TARIH);UPDATE T_HESAP SET BAKIYE+=@TUTAR WHERE HESAP_ID=" + lblid.Text + ";UPDATE T_GELIR SET TUTAR=+@TUTAR WHERE AY=@AY", baglan);
                    komut3.Parameters.AddWithValue("@HESAP_ID", lblid.Text);
                    komut3.Parameters.AddWithValue("@FIRMA_ID", cmbfirmat.SelectedValue);
                    komut3.Parameters.AddWithValue("@TUTAR", Convert.ToDecimal(txttl.Text));
                    komut3.Parameters.AddWithValue("@ACIKLAMA", txta.Text);
                    komut3.Parameters.AddWithValue("@TARIH", dtp2.Value);
                    komut3.Parameters.AddWithValue("@AY", dtp2.Value.Month);
                    komut3.ExecuteNonQuery();
                    baglan.Close();
                    MessageBox.Show(cmbfirmat.Text + " Firmasına " + txttl.Text + " TL  Ödeme Alındı.");

                }
            }
            else
            {
                txttl.Focus(); txta.Focus(); cmbfirmat.Focus();
                errorProvider1.SetError(txttl, "Boş Geçilmez");
                errorProvider1.SetError(txta, "Boş Geçilmez");
                errorProvider1.SetError(cmbfirmat, "Boş Geçilmez");
            }
        }
        private void Btntransfer_Click(object sender, EventArgs e)//HESAP TRANSFERE BASILDIĞINDA
        {
            p1.BackColor = Color.Transparent;
            p2.BackColor = Color.Transparent;
            p3.BackColor = Color.FromArgb(0, 192, 192);
            p4.BackColor = Color.Transparent;
            p5.BackColor = Color.Transparent;
            groupBox1.Visible = false;
            groupBox2.Visible = false;
            groupBox3.Visible = true;
        }
        private void Btnhgiris_Click(object sender, EventArgs e)//HESAP GİRİŞTE İŞLEMİ KABUL ETME
        {
            if (txtaciklama.Text != "" && txttutar.Text != "")
            {
                string message = lblhesap.Text + " Hesabına " + txttutar.Text + " TL  Giris Yapılsın mı?";
                string title = "Hesaba Giriş";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;

                DialogResult result = MessageBox.Show(message, title, buttons, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (result == DialogResult.Yes)
                {
                    baglan.Open();
                    komut3 = new SqlCommand("INSERT INTO T_HESAPGIRIS VALUES( @HESAP_ID,@TUTAR,@ACIKLAMA,@TARIH);UPDATE T_HESAP SET BAKIYE+=@TUTAR WHERE HESAP_ID=" + lblid.Text + ";UPDATE T_GELIR SET TUTAR=+@TUTAR WHERE AY=@AY", baglan);
                    komut3.Parameters.AddWithValue("@HESAP_ID", lblid.Text);
                    komut3.Parameters.AddWithValue("@TUTAR", Convert.ToDecimal(txttutar.Text));

                    komut3.Parameters.AddWithValue("@ACIKLAMA", txtaciklama.Text);
                    komut3.Parameters.AddWithValue("@TARIH", girisdtp.Value);
                    komut3.Parameters.AddWithValue("@AY", girisdtp.Value.Month);
                    komut3.ExecuteNonQuery();
                    baglan.Close();
                    MessageBox.Show(lblhesap.Text + " Hesabına " + txttutar.Text + " TL  Giris Yapıldı.");

                }
            }

            else
            {
                txttutar.Focus(); txttutar.Focus();
                errorProvider1.SetError(txtaciklama, "Boş Geçilmez");
                errorProvider1.SetError(txttutar, "Boş Geçilmez");
            }

        }
        private void Cikisbtn_Click(object sender, EventArgs e)//HESAP ÇIKIŞTA İŞLEMİ KABUL ETME
        {
            if (cikisa.Text != "" && cikist.Text != "")
            {
                string message = lblhesap.Text + " Hesabından " + cikist.Text + " TL  Çıkış Yapılsın mı?";
                string title = "Hesaptan Çıkış";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;

                DialogResult result = MessageBox.Show(message, title, buttons, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (result == DialogResult.Yes)
                {
                    baglan.Open();
                    komut3 = new SqlCommand("INSERT INTO T_HESAPCIKIS VALUES( @HESAP_ID,@TUTAR,@ACIKLAMA,@TARIH);UPDATE T_HESAP SET BAKIYE-=@TUTAR WHERE HESAP_ID=" + lblid.Text+ ";UPDATE T_GIDER SET TUTAR=+@TUTAR WHERE AY=@AY", baglan);
                    komut3.Parameters.AddWithValue("@HESAP_ID", lblid.Text);
                    komut3.Parameters.AddWithValue("@TUTAR", Convert.ToDecimal(cikist.Text));
                    komut3.Parameters.AddWithValue("@ACIKLAMA", cikisa.Text);
                    komut3.Parameters.AddWithValue("@TARIH", cikisdtp.Value);
                    komut3.Parameters.AddWithValue("@AY", cikisdtp.Value.Month);
                    
                    komut3.ExecuteNonQuery();
                    baglan.Close();
                    MessageBox.Show(lblhesap.Text + " Hesabından " + cikist.Text + " TL  Çıkış Yapıldı.");


                }
            }

            else
            {
                cikist.Focus(); cikisa.Focus();
                errorProvider1.SetError(cikisa, "Boş Geçilmez");
                errorProvider1.SetError(cikist, "Boş Geçilmez");
            }
        }
        private void Tbtn_Click(object sender, EventArgs e)//HESAP TRANSFERDE İŞLEMİ KABUL ETME
        {

            if (cmbt1.Text == cmbt2.Text)
            {
                MessageBox.Show("Aynı Hesaplar Arası Transfer Yapılmaz");
            }
            else if (taciklama.Text != "" && ttutar.Text != "" && cmbt2.Text != "")
            {
                string message = cmbt1.Text + " Hesabından " + cmbt2.Text + " Hesabına " + ttutar.Text + " TL  Transfer Yapılsın mı?";
                string title = "Hesaba Transfer";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;

                DialogResult result = MessageBox.Show(message, title, buttons, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (result == DialogResult.Yes)
                {
                    baglan.Open();
                    komut3 = new SqlCommand("INSERT INTO T_HESAPTRANSFER VALUES( @GIDEN_HESAP_ID, @GELEN_HESAP_ID,@TUTAR,@ACIKLAMA,@TARIH);UPDATE T_HESAP SET BAKIYE-=@TUTAR WHERE HESAP_ID=" + cmbt1.SelectedValue +
                        ";UPDATE T_HESAP SET BAKIYE+=@TUTAR WHERE HESAP_ID=" + cmbt2.SelectedValue, baglan);
                    komut3.Parameters.AddWithValue("@GIDEN_HESAP_ID", cmbt1.SelectedValue);
                    komut3.Parameters.AddWithValue("@GELEN_HESAP_ID", cmbt2.SelectedValue);
                    komut3.Parameters.AddWithValue("@TUTAR", Convert.ToDecimal(ttutar.Text));
                    komut3.Parameters.AddWithValue("@ACIKLAMA", taciklama.Text);
                    komut3.Parameters.AddWithValue("@TARIH", tdtp.Value);
                    komut3.ExecuteNonQuery();
                    baglan.Close();
                    MessageBox.Show(cmbt1.Text + " Hesabından " + cmbt2.Text + " Hesabına " + ttutar.Text + " TL  Transfer Yapıldı.");

                }
            }
            else
            {
                ttutar.Focus(); taciklama.Focus(); cmbt1.Focus(); cmbt2.Focus();
                errorProvider1.SetError(ttutar, "Boş Geçilmez");
                errorProvider1.SetError(taciklama, "Boş Geçilmez");

                errorProvider1.SetError(cmbt2, "Boş Geçilmez");
            }

        }
    }
}

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
    public partial class DepoTanim : Form
    {
        public DepoTanim()
        {
            InitializeComponent();
        }
        SqlConnection baglan = new SqlConnection(ConfigurationManager.ConnectionStrings["Baglanti"].ToString());
        SqlCommand komut,komut3; SqlDataReader data4,data2;
        DataSet daset = new DataSet();
        public string depoID = "";
        int sayac = 0, i = 0;
        int[] stok = new int[50];
        private void ToolStripButton3_Click(object sender, EventArgs e)//LİSTELE BUTONUNA BASILDIĞINDA
        {
            panel3.Visible = true;
            KayitGoster();
            sayac++;
            if (sayac % 2 == 0)
            {
                daset.Clear();
                panel3.Visible = false;

            }

        }
        private void KayitGoster()//LİSTELEME
        {
            daset.Clear();
            baglan.Open();
            SqlDataAdapter adptr = new SqlDataAdapter("SELECT * FROM T_DEPO ", baglan);
            adptr.Fill(daset, "T_DEPO");
            dataGridView1.DataSource = daset.Tables["T_DEPO"];
            baglan.Close();
            dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }
        private void Depolar_Load(object sender, EventArgs e)
        {
            panel3.Visible = false;
        }
        private void ToolStripButton2_Click(object sender, EventArgs e)//KAYDET BUTONUNA BASILDIĞINDA
        {
            if (depoID == "" && textBox1.Text != "" && textBox2.Text != "")
            {
                baglan.Open();
                komut = new SqlCommand("INSERT INTO T_DEPO VALUES( @DEPO_KODU,@DEPO_AD) ", baglan);

                komut.Parameters.AddWithValue("@DEPO_KODU", textBox1.Text);
                komut.Parameters.AddWithValue("@DEPO_AD", textBox2.Text);

                komut.ExecuteNonQuery();
                baglan.Close();
                MessageBox.Show("Depo Kaydı Eklendi");
                daset.Clear();
                DepoMiktar();
                KayitGoster();
            }

            else if (depoID != "" && textBox1.Text != "" && textBox2.Text != "")
            {
                baglan.Open();
                komut = new SqlCommand("UPDATE T_DEPO SET  DEPO_KODU=@DEPO_KODU,DEPO_AD=@DEPO_AD WHERE DEPO_ID='" + depoID + "'", baglan);
                komut.Parameters.AddWithValue("@DEPO_KODU", textBox1.Text);
                komut.Parameters.AddWithValue("@DEPO_AD", textBox2.Text);
                komut.ExecuteNonQuery();
                baglan.Close();
                MessageBox.Show("Depo Kaydı Güncellendi");
                daset.Clear();
                KayitGoster();
            }
            else
            {
                textBox1.Focus();
                errorProvider1.SetError(textBox1, "Boş Geçilmez");
                errorProvider1.SetError(textBox2, "Boş Geçilmez");
            }
        }
        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)//GÜNCELLEME
        {
            depoID = dataGridView1.CurrentRow.Cells["DEPO_ID"].Value.ToString();
            if (depoID != "")
            {

                baglan.Open();
                SqlCommand komut = new SqlCommand("SELECT * FROM T_DEPO WHERE DEPO_ID='" + depoID + "'", baglan);
                SqlDataReader data;
                data = komut.ExecuteReader();
                while (data.Read())
                {
                    textBox1.Text = data[1].ToString();
                    textBox2.Text = data[2].ToString();

                }
                baglan.Close();
            }
        }
        private void ToolStripButton1_Click(object sender, EventArgs e)//YENİ BUTONUNA BASILDIĞINDA
        {
            textBox1.Text = "";
            textBox2.Text = "";
            depoID = "";
        }
        private void Button2_Click(object sender, EventArgs e)//KAPAT BUTONU
        {
            daset.Clear();
            panel3.Visible = false;
        }
        private void Ttxtara_TextChanged(object sender, EventArgs e)//ARAMA YAPILDIĞINDA
        {
            DataTable tablo = new DataTable();
            baglan.Open();
            SqlDataAdapter adtr = new SqlDataAdapter("SELECT * FROM T_DEPO WHERE DEPO_AD Like'%" + ttxtara.Text + "%'", baglan);
            adtr.Fill(tablo);
            dataGridView1.DataSource = tablo;
            baglan.Close();
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
                SqlCommand komut = new SqlCommand("Delete From T_DEPO Where DEPO_AD='" + dataGridView1.CurrentRow.Cells["DEPO_AD"].Value.ToString() + "'", baglan);
                komut.ExecuteNonQuery();
                baglan.Close();
                daset.Tables["T_DEPO"].Clear();
                KayitGoster();
                MessageBox.Show("Depo Kaydı Silindi.");
                foreach (Control item in this.Controls)
                {
                    if (item is TextBox)
                    {
                        item.Text = "";
                    }

                }
            }
        }
        private void LinkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)//ÜST LINK
        {
            pnldepo.Controls.Clear();
            Formlar.Islemler fe2 = new Formlar.Islemler();
            fe2.TopLevel = false;
            pnldepo.Controls.Add(fe2);
            fe2.Show();
            fe2.Dock = DockStyle.Fill;
            fe2.BringToFront();
        }
        private void LinkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)//ÜST LINK
        {

            pnldepo.Controls.Clear();
            DepoTanim fe2 = new DepoTanim();
            fe2.TopLevel = false;
            pnldepo.Controls.Add(fe2);
            fe2.Show();
            fe2.Dock = DockStyle.Fill;
            fe2.BringToFront();
        }
        private void DepoMiktar()//DEPO ve MİKTAR TABLOSU İLİŞKİSİ
        {
            baglan.Open();
            SqlCommand komut4 = new SqlCommand("SELECT DEPO_ID FROM T_DEPO WHERE DEPO_ID = (select IDENT_CURRENT('T_DEPO'));", baglan);
     
            data4 = komut4.ExecuteReader();
            data4.Read();
            int depoid = Convert.ToInt32(data4[0]);
            baglan.Close();
            baglan.Open();
            SqlCommand komut2 = new SqlCommand("SELECT M.STOK_ID FROM T_MIKTAR M GROUP BY M.STOK_ID", baglan);
          
            data2 = komut2.ExecuteReader();
            while (data2.Read())
            {
                stok[i] = Convert.ToInt32(data2[0]); i++;
            }

            baglan.Close();
            baglan.Open();
            for (int k = 0; k < i; k++)
            {
                komut3 = new SqlCommand("INSERT INTO T_MIKTAR VALUES(@STOK_ID,@DEPO_ID,@KALAN_MIKTAR) ", baglan);
                komut3.Parameters.AddWithValue("@STOK_ID", stok[k]);
                komut3.Parameters.AddWithValue("@DEPO_ID", depoid);
                komut3.Parameters.AddWithValue("@KALAN_MIKTAR", 0);
                komut3.ExecuteNonQuery();
            }


        
            baglan.Close();
        }
    }
}

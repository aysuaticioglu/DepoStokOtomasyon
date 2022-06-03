using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using iTextSharp.text.pdf;
using iTextSharp.text;
using System.IO;
using System.Configuration;

namespace DepoStokOtomasyon
{
    public partial class StokGiris : Form
    {
        public StokGiris()
        {
            InitializeComponent();
        }
        SqlConnection baglan = new SqlConnection(ConfigurationManager.ConnectionStrings["Baglanti"].ToString());
        DataSet daset = new DataSet(); SqlCommand komut, komut2, komut3;
        public string StokID;
        decimal kdv = 0, fiyat = 0, toplam = 0, nettoplam = 0;
        int sayac = 0, tik = 0;
        int[] chk = new int[50]; int[] dmiktar = new int[50]; int[] did = new int[50];
   
        private void StokGiris_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'stokGFDS.T_FIRMA' table. You can move, or remove it, as needed.
            this.t_FIRMATableAdapter.Fill(this.stokGFDS.T_FIRMA);
            // TODO: This line of code loads data into the 'stokGDDS.T_DEPO' table. You can move, or remove it, as needed.
            this.t_DEPOTableAdapter.Fill(this.stokGDDS.T_DEPO);
            panel1.BringToFront();
            baglan.Open();
            komut3 = new SqlCommand("SELECT ISLEM_NO FROM T_STOKGIRIS WHERE GIRIS_ID = (select IDENT_CURRENT('T_STOKGIRIS'));", baglan);
            SqlDataReader data;
            data = komut3.ExecuteReader();
           
            if (data.Read() != false)
            {
                string islemno = data[0].ToString().Substring(3);
                mtxtislem.Text += Convert.ToInt32(islemno) + 1;
            }
            else
            {
                mtxtislem.Text = "SG-1000";
            }

          
            baglan.Close();
       
            dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[8].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
     


        }
        private void MiktarGiris()//GİRİLEN MİKTARLARI DİZİYE AKTARIR.
        {
            for (int i = 0; i < sayac; i++)
            {
                dmiktar[i] = Convert.ToInt32(dataGridView1.Rows[i].Cells[8].Value.ToString());
            }
        }
        private void ToolStripButton2_Click(object sender, EventArgs e)//KAYDETME KISMI
        {

            if (cmbdepo.Text != "" && cmbfirma.Text != "" && dataGridView1.Rows[0].Cells[1].Value != null)
            {
                tik = 0;
                MiktarGiris();
                baglan.Open();
                for (int i = 0; i < sayac; i++)
                {

                    fiyat = Convert.ToDecimal(dataGridView1.Rows[i].Cells[6].Value);

                    kdv = Convert.ToDecimal(dataGridView1.Rows[i].Cells[7].Value);

                    komut = new SqlCommand("INSERT INTO T_STOKGIRIS VALUES(@ISLEM_NO,@FIRMA_ID,@DEPO_ID,@STOK_ID,@MIKTAR,@FIYAT,@TARIH,@TOPLAM_TUTAR);", baglan);
                    komut.Parameters.AddWithValue("@ISLEM_NO", mtxtislem.Text);
                    komut.Parameters.AddWithValue("@FIRMA_ID", Convert.ToInt32(cmbfirma.SelectedValue));
                    komut.Parameters.AddWithValue("@DEPO_ID", cmbdepo.SelectedValue);
                    komut.Parameters.AddWithValue("@STOK_ID", did[i]);
                    komut.Parameters.AddWithValue("@MIKTAR", dmiktar[i]);
                    komut.Parameters.AddWithValue("@FIYAT", fiyat);
                    komut.Parameters.AddWithValue("@TARIH", dateTimePicker1.Value);
                    komut.Parameters.AddWithValue("@TOPLAM_TUTAR", (((fiyat * kdv) / 100) * 100 + fiyat) * dmiktar[i]);
                    komut.ExecuteNonQuery();

                }
                baglan.Close();


                StokGirisCikis();
                MessageBox.Show("Kayıt Eklendi");
                tik++;
            }
            else
            {
                cmbfirma.Focus(); dataGridView1.Focus(); cmbdepo.Focus();
                errorProvider1.SetError(cmbdepo, "Boş Geçilmez");
                errorProvider1.SetError(cmbfirma, "Boş Geçilmez");
                errorProvider1.SetError(dataGridView1, "Boş Geçilmez");
            }

        }
        void total()//GENEL VE NET TOPLAM KISMI
        {
            toplam = 0;
            nettoplam = 0;
            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {

                decimal f = Convert.ToDecimal(dataGridView1.Rows[i].Cells[6].Value);
                decimal k = Convert.ToDecimal(dataGridView1.Rows[i].Cells[7].Value);
                int m = Convert.ToInt32(dataGridView1.Rows[i].Cells[8].Value);
                toplam += m * (((f * k) / 100) * 100 + f);
                nettoplam += m * f;
                txtgeneltop.Text = toplam.ToString();
                txtnettoplam.Text = nettoplam.ToString();

            }
        }
        private void stokliste()//STOKĞUN SECİLDİĞİ YER.
        {
            baglan.Open();
            SqlDataAdapter adptr = new SqlDataAdapter("SELECT S.STOK_ID,S.STOK_KOD,S.STOK_AD,S.BARKOD FROM  T_STOK S", baglan);
            adptr.Fill(daset, "T_STOK");
            dataGridView2.DataSource = daset.Tables["T_STOK"];
            baglan.Close();
            dataGridView2.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView2.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView2.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView2.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
 

        }
        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)//SEÇ BUTONU BASILDIĞINDA
        {
            if (e.ColumnIndex == 0)
            {
                sayac++;
                panel1.Visible = true;
                panel1.Location= new System.Drawing.Point(278, 94);
                daset.Clear();
                stokliste();

            }

        }
        private void DataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)//SECİLEN SATIRI DATAGRIDE DOLDURUYOR.
        {
            StokID = dataGridView2.CurrentRow.Cells["STOK_ID"].Value.ToString();
            if (StokID != "")
            {
                baglan.Open();
                SqlCommand komut = new SqlCommand("SELECT S.STOK_ID,S.STOK_KOD,S.STOK_AD,S.BARKOD,B.BIRIM_AD,S.FIYAT,S.KDV  FROM T_STOK S,T_BIRIM B  WHERE B.BIRIM_ID = S.BIRIM_ID  AND S.STOK_ID = '" + StokID + "'", baglan);
                SqlDataReader data;
                data = komut.ExecuteReader();
                while (data.Read())
                {
                    int row = dataGridView1.Rows.Add();
                    dataGridView1.Rows[sayac - 1].Cells[1].Value = data[0].ToString();
                    dataGridView1.Rows[sayac - 1].Cells[2].Value = data[1].ToString();
                    dataGridView1.Rows[sayac - 1].Cells[3].Value = data[2].ToString();
                    dataGridView1.Rows[sayac - 1].Cells[4].Value = data[3].ToString();
                    dataGridView1.Rows[sayac - 1].Cells[5].Value = data[4].ToString();
                    dataGridView1.Rows[sayac - 1].Cells[6].Value = data[5].ToString();
                    dataGridView1.Rows[sayac - 1].Cells[7].Value = data[6].ToString();
                    did[sayac - 1] = Convert.ToInt32(StokID);
                    panel1.Visible = false;

                }

                baglan.Close();




            }
        }
        private void Ttxtara_TextChanged(object sender, EventArgs e)//STOK ARAMA
        {
            DataTable tablo = new DataTable();
            baglan.Open();
            SqlDataAdapter adtr = new SqlDataAdapter("SELECT S.STOK_ID,S.STOK_KOD,S.STOK_AD,S.BARKOD FROM  T_STOK S WHERE S.STOK_KOD Like'%" + ttxtara.Text + "%'", baglan);
            adtr.Fill(tablo);
            dataGridView2.DataSource = tablo;
            baglan.Close();
        }
        private void LinkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)//UST LINK
        {
            pnlsgiris.Controls.Clear();
            Formlar.Islemler fe2 = new Formlar.Islemler();
            fe2.TopLevel = false;
            pnlsgiris.Controls.Add(fe2);
            fe2.Show();
            fe2.Dock = DockStyle.Fill;
            fe2.BringToFront();
        }
        private void LinkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)//UST LINK
        {
            pnlsgiris.Controls.Clear();
            StokGiris fe2 = new StokGiris();
            fe2.TopLevel = false;
            pnlsgiris.Controls.Add(fe2);
            fe2.Show();
            fe2.Dock = DockStyle.Fill;
            fe2.BringToFront();
        }
        private void ToolStripButton1_Click(object sender, EventArgs e)//RAPORLAMA
        {
            if (tik != 0)
            {
                PdfPTable tablo = new PdfPTable(7);
                iTextSharp.text.Document d = new iTextSharp.text.Document();
                PdfWriter.GetInstance(d, new FileStream(Application.StartupPath.ToString()+ mtxtislem.Text + "_Rapor.pdf", FileMode.Create));
                d.AddAuthor("Admin");
                d.AddSubject("Stok Giriş");
                d.AddCreationDate();
                d.AddCreator("Stok Giriş");
                BaseFont arial = BaseFont.CreateFont("C:\\windows\\fonts\\arial.ttf", BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
                iTextSharp.text.Font font = new iTextSharp.text.Font(arial, 12, iTextSharp.text.Font.NORMAL);
                iTextSharp.text.Font font2 = new iTextSharp.text.Font(arial, 15, iTextSharp.text.Font.NORMAL);
                if (d.IsOpen() == false) d.Open();
                d.Add(new Paragraph("STOK GİRİŞ ", font2));
                d.Add(new Paragraph("İşlem No: " + mtxtislem.Text, font));
                d.Add(new Paragraph("Depo: " + cmbdepo.Text + "   Firma:" + cmbfirma.Text, font));
                d.Add(new Paragraph("Tarih: " + dateTimePicker1.Value, font));
                d.Add(new Paragraph("        ", font));
                d.Add(new Paragraph("        ", font));
                baglan.Open();
                SqlCommand komut = new SqlCommand("SELECT S.STOK_KOD,S.STOK_AD,S.BARKOD,B.BIRIM_AD,G.FIYAT,S.KDV,G.MIKTAR FROM T_STOKGIRIS G, T_STOK S, T_BIRIM B WHERE S.BIRIM_ID = B.BIRIM_ID AND S.STOK_ID = G.STOK_ID  AND G.ISLEM_NO = '" + mtxtislem.Text + "'", baglan);
                SqlDataReader data;
                data = komut.ExecuteReader();
                tablo.AddCell("Stok Kodu");
                tablo.AddCell("Stok Adı");
                tablo.AddCell("Barkod");
                tablo.AddCell("Birim");
                tablo.AddCell("Fiyat");
                tablo.AddCell("KDV");
                tablo.AddCell("Miktar");
                while (data.Read())
                {
                    tablo.AddCell(data[0].ToString());
                    tablo.AddCell(data[1].ToString());
                    tablo.AddCell(data[2].ToString());
                    tablo.AddCell(data[3].ToString());
                    tablo.AddCell(data[4].ToString());
                    tablo.AddCell(data[5].ToString());
                    tablo.AddCell(data[6].ToString());
                }
                PdfPCell cell = new PdfPCell(new Phrase("    "));
                cell.Colspan = 2;
                cell.HorizontalAlignment = 1;
                tablo.AddCell(cell);
                cell = new PdfPCell(new Phrase("Genel Toplam:" + txtgeneltop.Text));
                cell.Colspan = 3;
                cell.HorizontalAlignment = 1;
                tablo.AddCell(cell);
                cell = new PdfPCell(new Phrase("Net Toplam:" + txtnettoplam.Text));
                cell.Colspan = 2;
                cell.HorizontalAlignment = 1;
                tablo.AddCell(cell);
                d.Add(tablo);
                d.Close();
                MessageBox.Show("Raporlandı");
                baglan.Close();
                Formlar.Rapor rpr = new Formlar.Rapor();
                rpr.adres = Application.StartupPath.ToString() + mtxtislem.Text + "_Rapor.pdf";
                rpr.Show();

            }
            else
            {
                MessageBox.Show("Önce Kaydetmeniz Gerekiyor");
            }

        }
        private void Button7_Click(object sender, EventArgs e)
        {
            panel1.Visible = false; sayac--;
        }
    
        private void StokGirisCikis()//STOK GİRİS ÇIKIŞ MİKTARLARI T_MIKTAR ADLI TABLOYA AKTARIYOR
        {
            baglan.Open();

            for (int i = 0; i < sayac; i++)
            {
                komut2 = new SqlCommand("UPDATE  T_MIKTAR SET KALAN_MIKTAR=KALAN_MIKTAR+@KALAN_MIKTAR WHERE STOK_ID=" + did[i] + " AND DEPO_ID=" + cmbdepo.SelectedValue, baglan);

                komut2.Parameters.AddWithValue("@KALAN_MIKTAR", dmiktar[i]);
                komut2.ExecuteNonQuery();
      
            }
            baglan.Close();
        }

        private void DataGridView1_CellStateChanged(object sender, DataGridViewCellStateChangedEventArgs e)//MİKTAR SÜTUNUNA MİKTAR YAZILDIĞINDA
        {
            total();
        }
    }
}
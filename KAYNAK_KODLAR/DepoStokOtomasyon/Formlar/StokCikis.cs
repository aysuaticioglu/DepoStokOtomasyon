using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DepoStokOtomasyon
{
    public partial class StokCikis : Form
    {
        public StokCikis()
        {
            InitializeComponent();
        }
        SqlConnection baglan = new SqlConnection(ConfigurationManager.ConnectionStrings["Baglanti"].ToString());
        DataSet daset = new DataSet(); SqlCommand komut, komut2, komut3;
        public string StokID;
        int tiklanma = 0, sayac = 0, kontrol = 0, tekrar = 0, satir = 0, raportik = 0;
        decimal kdv = 0, fiyat = 0, toplam = 0, nettoplam = 0;
        int[] dmiktar = new int[50]; int[] did = new int[50]; int[] dtekrar = new int[50]; int[] toplam_miktar = new int[50];
        int[] stok_miktar = new int[50]; int[] stok = new int[50]; int[] dizi_id = new int[50]; int[] girismiktar = new int[50];
        int[] olmayan = new int[50];//birden fazla girilmeyen stokğun girilen miktarı
        int[] olmayan_id = new int[50];//birden fazla girilmeyen stokğun  idsi
        int[] olmayan_stok = new int[50];//birden fazla girilmeyen stokğun stoktaki miktarı

        private void MiktarGiris()//MİKTARLARI DİZİYE AKTARIR
        {
            for (int i = 0; i < sayac; i++)
            {
                dmiktar[i] = Convert.ToInt32(dataGridView1.Rows[i].Cells[9].Value.ToString());//Girilen miktar diziye aktarıldı.
                dtekrar[i] = Convert.ToInt32(dataGridView1.Rows[i].Cells[1].Value.ToString());//Stok idsi diziye aktarıldı.
                stok_miktar[i] = Convert.ToInt32(dataGridView1.Rows[i].Cells[8].Value);//Stok koduna ait toplam miktar diziye aktarıldı.
            }


        }
        private void stokliste()//STOĞUN SEÇİLDİĞİ YER
        {

            baglan.Open();
            // SqlDataAdapter adptr = new SqlDataAdapter("SELECT S.STOK_ID,S.STOK_KOD,S.STOK_AD,S.BARKOD,SUM(G.MIKTAR) AS [STOKTAKİ MIKTAR]  FROM T_STOK S,T_BIRIM B,T_STOKGIRIS G WHERE B.BIRIM_ID = S.BIRIM_ID AND G.STOK_ID = S.STOK_ID GROUP BY S.STOK_ID, S.STOK_AD, B.BIRIM_AD, S.BARKOD, S.STOK_KOD, S.STOK_AD", baglan);
            SqlDataAdapter adptr = new SqlDataAdapter("SELECT S.STOK_ID,S.STOK_KOD,S.STOK_AD,S.BARKOD,M.KALAN_MIKTAR AS [STOKTAKİ MIKTAR] FROM T_STOK S, T_BIRIM B, T_STOKGIRIS G, T_MIKTAR M,T_DEPO D  WHERE B.BIRIM_ID = S.BIRIM_ID AND G.STOK_ID = S.STOK_ID AND G.STOK_ID = M.STOK_ID AND M.KALAN_MIKTAR<>0   AND D.DEPO_ID=M.DEPO_ID AND D.DEPO_ID=" + cmbdepo.SelectedValue + " GROUP BY S.STOK_ID, S.STOK_AD, B.BIRIM_AD, S.BARKOD, S.STOK_KOD, S.STOK_AD,M.KALAN_MIKTAR", baglan);

            adptr.Fill(daset, "T_STOK");
            dataGridView2.DataSource = daset.Tables["T_STOK"];
            baglan.Close();
            dataGridView2.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView2.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView2.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView2.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView2.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
          



        }
        private void ToolStripButton1_Click(object sender, EventArgs e)//RAPORLAMA
        {
            if (raportik != 0)
            {
                PdfPTable tablo = new PdfPTable(7);
                iTextSharp.text.Document d = new iTextSharp.text.Document();
                PdfWriter.GetInstance(d, new FileStream(Application.StartupPath.ToString() + txtislem.Text + "_Rapor.pdf", FileMode.Create));
                d.AddAuthor("Admin");
                d.AddSubject("Stok Çıkış");
                d.AddCreationDate();
                d.AddCreator("Stok Çıkış");
                BaseFont arial = BaseFont.CreateFont("C:\\windows\\fonts\\arial.ttf", BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
                iTextSharp.text.Font font = new iTextSharp.text.Font(arial, 12, iTextSharp.text.Font.NORMAL);
                iTextSharp.text.Font font2 = new iTextSharp.text.Font(arial, 15, iTextSharp.text.Font.NORMAL);
                if (d.IsOpen() == false) d.Open();
                d.Add(new Paragraph("STOK ÇIKIŞ ", font2));
                d.Add(new Paragraph("İşlem No: " + txtislem.Text, font));
                d.Add(new Paragraph("Depo: " + cmbdepo.Text + "   Firma:" + cmbfirma.Text, font));
                d.Add(new Paragraph("Tarih: " + dateTimePicker1.Value, font));
                d.Add(new Paragraph("        ", font));
                d.Add(new Paragraph("        ", font));
                baglan.Open();
                SqlCommand komut = new SqlCommand("SELECT S.STOK_KOD,S.STOK_AD,S.BARKOD,B.BIRIM_AD,G.FIYAT,S.KDV,G.MIKTAR FROM T_STOKCIKIS G, T_STOK S, T_BIRIM B WHERE S.BIRIM_ID = B.BIRIM_ID AND S.STOK_ID = G.STOK_ID  AND G.ISLEM_NO = '" + txtislem.Text + "'", baglan);
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
                rpr.adres = Application.StartupPath.ToString() + txtislem.Text + "_Rapor.pdf";
                rpr.Show();
            }
            else
            {
                MessageBox.Show("Önce Kaydetmeniz Gerekiyor");
            }
        }
        private void LinkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)//UST LINK
        {
            pnlscikis.Controls.Clear();
            StokCikis fe2 = new StokCikis();
            fe2.TopLevel = false;
            pnlscikis.Controls.Add(fe2);
            fe2.Show();
            fe2.Dock = DockStyle.Fill;
            fe2.BringToFront();
        }
        private void LinkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)//UST LINK
        {
            pnlscikis.Controls.Clear();
            Formlar.Islemler fe2 = new Formlar.Islemler();
            fe2.TopLevel = false;
            pnlscikis.Controls.Add(fe2);
            fe2.Show();
            fe2.Dock = DockStyle.Fill;
            fe2.BringToFront();
        }
        private void StokCikis_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'stokCDDS.T_DEPO' table. You can move, or remove it, as needed.
            this.t_DEPOTableAdapter.Fill(this.stokCDDS.T_DEPO);

            // TODO: This line of code loads data into the 'firmaDS.T_FIRMA' table. You can move, or remove it, as needed.
            this.t_FIRMATableAdapter.Fill(this.firmaDS.T_FIRMA);
            panel1.BringToFront();
            baglan.Open();
            komut3 = new SqlCommand("SELECT ISLEM_NO FROM T_STOKCIKIS WHERE CIKIS_ID = (select IDENT_CURRENT('T_STOKCIKIS'));", baglan);
            SqlDataReader data;
            data = komut3.ExecuteReader();
            ;
      
            if (data.Read()!=false)
            {
                string islemno = data[0].ToString().Substring(3);
                txtislem.Text += Convert.ToInt32(islemno) + 1;
            }
            else
            {
                txtislem.Text = "SÇ-1000";
            }

            baglan.Close();
           
            dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[8].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[9].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

        }
        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)//SEÇ BUTONUNA BASILDIĞINDA
        {
            if (e.ColumnIndex == 0)
            {


                if (tiklanma == 0)
                {
                    MessageBox.Show("İlk Depoyu Seçiniz");
                }
                if (tiklanma > 0)
                {
                    sayac++;
                    panel1.Visible = true;
                    panel1.Location = new System.Drawing.Point(233, 120);
                    daset.Clear();
                    stokliste();
                    cmbdepo.Enabled = false;
                }


            }

        }
        private void DataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)//STOK SEÇİLDİĞİNDE
        {

            StokID = dataGridView2.CurrentRow.Cells["STOK_ID"].Value.ToString();

            if (StokID != "")
            {
                baglan.Open();
                SqlCommand komut = new SqlCommand("SELECT S.STOK_ID,S.STOK_KOD,S.STOK_AD,S.BARKOD,B.BIRIM_AD,S.FIYAT,S.KDV,M.KALAN_MIKTAR AS [STOKTAKİ MIKTAR]   FROM T_STOK S,T_BIRIM B,T_STOKGIRIS G,T_MIKTAR M,T_DEPO D  WHERE B.BIRIM_ID = S.BIRIM_ID AND  G.STOK_ID = M.STOK_ID AND G.STOK_ID = S.STOK_ID  AND D.DEPO_ID=M.DEPO_ID AND D.DEPO_ID=" + cmbdepo.SelectedValue + " AND S.STOK_ID = '" + StokID + "'" + " GROUP BY S.STOK_ID, S.STOK_AD, B.BIRIM_AD, S.BARKOD, S.STOK_KOD, S.FIYAT, S.KDV ,S.STOK_AD,M.KALAN_MIKTAR", baglan);
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
                    dataGridView1.Rows[sayac - 1].Cells[8].Value = data[7].ToString();
                    did[sayac - 1] = Convert.ToInt32(StokID);
                    panel1.Visible = false;
                }
                baglan.Close();

            }

        }
        private void Ttxtara_TextChanged(object sender, EventArgs e)//AÇILAN FORMDAN DATAGRIDVIEWDE ARAMA YAPMA
        {
            DataTable tablo = new DataTable();
            baglan.Open();
            SqlDataAdapter adtr = new SqlDataAdapter("SELECT S.STOK_ID,S.STOK_KOD,S.STOK_AD,S.BARKOD FROM  T_STOK S WHERE S.STOK_KOD Like'%" + ttxtara.Text + "%'", baglan);
            adtr.Fill(tablo);
            dataGridView2.DataSource = tablo;
            baglan.Close();
        }
        private void Button7_Click(object sender, EventArgs e)
        {
            panel1.Visible = false; sayac--;
        }
        private void ToolStripButton2_Click(object sender, EventArgs e)//KAYDET BUTONU
        {
            MiktarGiris();
            tekrar = 0;
            raportik = 0;
            satir = 0;
            for (int j = 0; j < sayac; j++)
            {
                for (int k = 0; k < sayac; k++)
                {
                    if (dtekrar[j] == dtekrar[k])//Bu kısım iki defa ya da daha fazla aynı stok kodu seçilmişse onları bulup diziye aktarıyor.
                    {
                        if (j != k)
                        {
                            tekrar++;
                            toplam_miktar[j] = dmiktar[j] + dmiktar[k];
                            dizi_id[j] = dtekrar[j];
                            stok[j] = stok_miktar[j];
                        }

                    }

                }
                if (Convert.ToInt32(dataGridView1.Rows[j].Cells[9].Value.ToString()) < Convert.ToInt32(dataGridView1.Rows[j].Cells[8].Value))
                {
                    satir++;
                    //Burada eğer hiç aynı stok kodununda birden fazla girilmemişse girilen satırların miktarlarını stoktaki miktarları ile karşılaştırıyor.
                    //Eğer stoktaki miktardan az ise sayaç olarak kullanılan satir değişkeninde kaç tane satir olduğunu buluyor.
                    //Eğer stoktaki miktardan az değil ise ekleme kısmındaki if else kısmının else kısmına giderek uyarı veriyor.

                }


            }
            for (int j = 0; j < sayac; j++)
            {

                if (dizi_id[j] != dtekrar[j])
                {
                    olmayan[j] = dmiktar[j];
                    olmayan_id[j] = dtekrar[j];
                    olmayan_stok[j] = stok_miktar[j];
                }

            }
            kontrol = 0;
            for (int j = 0; j < sayac; j++)
            {

                if (toplam_miktar[j] <= stok[j])
                {
                    if (toplam_miktar[j] != 0 || stok[j] != 0)
                    {
                        kontrol++;
                    }

                }
                if (olmayan[j] <= olmayan_stok[j])
                {
                    if (olmayan[j] != 0 || olmayan_stok[j] != 0)
                    {
                        kontrol++;
                    }
                }
            }


            baglan.Open();
            if (cmbdepo.Text != "" && cmbfirma.Text != "" && dataGridView1.Rows[0].Cells[1].Value != null)
            {
                if (tekrar == 0)
                {
                    if (sayac == satir)  //Burada eğer üç satırlık bir giriş yapılmışsa 2 tanesi koşula uyup 1 tanesi uymuyorsa else kısmına girdiyor.
                                         //Üç satırlık giriş yapılmışsa üçününde koşula uygun olması gerekir.
                    {
                        for (int i = 0; i < sayac; i++)
                        {

                            fiyat = Convert.ToDecimal(dataGridView1.Rows[i].Cells[6].Value);
                            kdv = Convert.ToDecimal(dataGridView1.Rows[i].Cells[7].Value);
                            komut = new SqlCommand("INSERT INTO T_STOKCIKIS VALUES(@ISLEM_NO,@FIRMA_ID,@DEPO_ID,@STOK_ID,@MIKTAR,@FIYAT,@TARIH,@TOPLAM_TUTAR) ", baglan);
                            komut.Parameters.AddWithValue("@ISLEM_NO", txtislem.Text);
                            komut.Parameters.AddWithValue("@FIRMA_ID", Convert.ToInt32(cmbfirma.SelectedValue));
                            komut.Parameters.AddWithValue("@DEPO_ID", cmbdepo.SelectedValue);
                            komut.Parameters.AddWithValue("@STOK_ID", did[i]);
                            komut.Parameters.AddWithValue("@MIKTAR", dmiktar[i]);
                            komut.Parameters.AddWithValue("@FIYAT", fiyat);
                            komut.Parameters.AddWithValue("@TARIH", dateTimePicker1.Value);
                            komut.Parameters.AddWithValue("@TOPLAM_TUTAR", (((fiyat * kdv) / 100) * 100 + fiyat) * dmiktar[i]);
                            komut.ExecuteNonQuery();

                        }

                        MessageBox.Show("Kayıt Eklendi"); raportik++;
                        StokGirisCikis();

                    }
                    else
                    {
                        MessageBox.Show("Stoktaki Miktardan Fazla Girdiniz");
                        MiktarGiris();
                    }

                }


                else if (tekrar >= 1)
                {
                    if (sayac == kontrol)
                    {
                        for (int i = 0; i < sayac; i++)
                        {
                            fiyat = Convert.ToDecimal(dataGridView1.Rows[i].Cells[6].Value);
                            kdv = Convert.ToDecimal(dataGridView1.Rows[i].Cells[7].Value);
                            komut = new SqlCommand("INSERT INTO T_STOKCIKIS VALUES(@ISLEM_NO,@FIRMA_ID,@DEPO_ID,@STOK_ID,@MIKTAR,@FIYAT,@TARIH,@TOPLAM_TUTAR) ", baglan);
                            komut.Parameters.AddWithValue("@ISLEM_NO", txtislem.Text);
                            komut.Parameters.AddWithValue("@FIRMA_ID", Convert.ToInt32(cmbfirma.SelectedValue));
                            komut.Parameters.AddWithValue("@DEPO_ID", cmbdepo.SelectedValue);
                            komut.Parameters.AddWithValue("@STOK_ID", did[i]);
                            komut.Parameters.AddWithValue("@MIKTAR", dmiktar[i]);
                            komut.Parameters.AddWithValue("@FIYAT", fiyat);
                            komut.Parameters.AddWithValue("@TARIH", dateTimePicker1.Value);
                            komut.Parameters.AddWithValue("@TOPLAM_TUTAR", dmiktar[i] * ((fiyat * kdv) / 100) + fiyat);
                            komut.ExecuteNonQuery();

                        }
                        MessageBox.Show("Kayıt Eklendi"); raportik++;
                        StokGirisCikis();

                    }
                    else
                    {
                        MessageBox.Show("Stoktaki Miktardan Fazla Girdiniz");
                    }
                }
            }
            else
            {

                cmbfirma.Focus(); dataGridView1.Focus(); cmbdepo.Focus();
                errorProvider1.SetError(cmbdepo, "Boş Geçilmez");
                errorProvider1.SetError(cmbfirma, "Boş Geçilmez");
                errorProvider1.SetError(dataGridView1, "Boş Geçilmez");
            }


            baglan.Close();

        }
        private void StokGirisCikis()//MİKTAR TABLOSU GÜNCELLEME
        {

            for (int j = 0; j < sayac; j++)
            {
                komut2 = new SqlCommand("UPDATE  T_MIKTAR SET KALAN_MIKTAR=KALAN_MIKTAR-@KALAN_MIKTAR WHERE STOK_ID=" + did[j] + " AND DEPO_ID=" + cmbdepo.SelectedValue, baglan);
                komut2.Parameters.AddWithValue("@KALAN_MIKTAR", dmiktar[j]);
                komut2.ExecuteNonQuery();
            }

        }
        void total()//GENEL VE NET TOPLAMI HESAPLAMA
        {
            toplam = 0;
            nettoplam = 0;
            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {

                decimal f = Convert.ToDecimal(dataGridView1.Rows[i].Cells[6].Value);
                decimal k = Convert.ToDecimal(dataGridView1.Rows[i].Cells[7].Value);
                int m = Convert.ToInt32(dataGridView1.Rows[i].Cells[9].Value);
                toplam += m * (((f * k) / 100)*100 + f);
                nettoplam += m * f;
                txtgeneltop.Text = toplam.ToString();
                txtnettoplam.Text = nettoplam.ToString();

            }
        }
        private void DataGridView1_CellStateChanged(object sender, DataGridViewCellStateChangedEventArgs e)//MİKTAR SÜTUNUNA MİKTAR YAZILDIĞINDA
        {
            total();
        }
        private void Cmbdepo_SelectedIndexChanged(object sender, EventArgs e)//DEPO SEÇİMİNİ KONTROL ETME
        {
            tiklanma++;
        }
    }

}
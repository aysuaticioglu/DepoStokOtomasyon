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
    public partial class DepoTransfer : Form
    {
        public DepoTransfer()
        {
            InitializeComponent();
        }
        SqlConnection baglan = new SqlConnection(ConfigurationManager.ConnectionStrings["Baglanti"].ToString());
        DataSet daset = new DataSet(); SqlDataReader oku;
        SqlCommand komut, komut2, komut_transfer, komut3;
        public string StokID;
        int tiklanma = 0, sayac = 0, tekrar = 0, kontrol = 0, satir = 0, dongu = 0, tik = 0;
        string stok2, depo, id = "";
        int[] dmiktar = new int[50]; int[] did = new int[50]; int[] dtekrar = new int[50]; int[] toplam_miktar = new int[50];
        int[] stok_miktar = new int[50]; int[] stok = new int[50]; int[] dizi_id = new int[50]; int[] girismiktar = new int[50];
        int[] olmayan = new int[50];//birden fazla girilmeyen stokğun girilen miktarı
        int[] olmayan_id = new int[50];//birden fazla girilmeyen stokğun  idsi
        int[] olmayan_stok = new int[50];//birden fazla girilmeyen stokğun stoktaki miktarı
        private void MiktarGiris()//MİKTARLARI DİZİYE AKTARIR.
        {
            for (int i = 0; i < sayac; i++)
            {
                dmiktar[i] = Convert.ToInt32(dataGridView1.Rows[i].Cells[6].Value.ToString());//Girilen miktar diziye aktarıldı.
                dtekrar[i] = Convert.ToInt32(dataGridView1.Rows[i].Cells[1].Value.ToString());//Stok idsi diziye aktarıldı.
                stok_miktar[i] = Convert.ToInt32(dataGridView1.Rows[i].Cells[5].Value);//Stok koduna ait toplam miktar diziye aktarıldı.
            }


        }
        private void ToolStripButton1_Click(object sender, EventArgs e)
        {

            if (tik != 0)
            {
                PdfPTable tablo = new PdfPTable(4);
                iTextSharp.text.Document d = new iTextSharp.text.Document();
                PdfWriter.GetInstance(d, new FileStream(Application.StartupPath.ToString() + txttransfer.Text + "_Rapor.pdf", FileMode.Create));
                d.AddAuthor("Admin");
                d.AddSubject("Depo Transfer");
                d.AddCreationDate();
                d.AddCreator("Depo Transfer");
                BaseFont arial = BaseFont.CreateFont("C:\\windows\\fonts\\arial.ttf", BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
                iTextSharp.text.Font font = new iTextSharp.text.Font(arial, 12, iTextSharp.text.Font.NORMAL);
                iTextSharp.text.Font font2 = new iTextSharp.text.Font(arial, 15, iTextSharp.text.Font.NORMAL);
                if (d.IsOpen() == false) d.Open();
                d.Add(new Paragraph("DEPO TRANSFER", font2));
                d.Add(new Paragraph("Transfer No: " + txttransfer.Text, font));
                d.Add(new Paragraph("Çıkış Depo: " + cmbdepo.Text + " Giriş Depo:" + cmbdepo2.Text, font));
                d.Add(new Paragraph("Tarih: " + dateTimePicker1.Text, font));
                d.Add(new Paragraph("        ", font));
                d.Add(new Paragraph("        ", font));
                baglan.Open();
                SqlCommand komut = new SqlCommand("SELECT S.STOK_KOD,S.STOK_AD,S.BARKOD,D.MIKTAR FROM T_DEPOTRANSFER D,T_TRANSFER T,T_STOK S" +
                    " WHERE T.TRANSFER_ID=D.TRANSFER_ID AND D.STOK_ID=S.STOK_ID AND T.TRANSFER_NO= '" + txttransfer.Text + "'", baglan);
                SqlDataReader data;
                data = komut.ExecuteReader();
                tablo.AddCell("Stok Kodu");
                tablo.AddCell("Stok Adı");
                tablo.AddCell("Barkod");
                tablo.AddCell("Miktar");
                while (data.Read())
                {
                    tablo.AddCell(data[0].ToString());
                    tablo.AddCell(data[1].ToString());
                    tablo.AddCell(data[2].ToString());
                    tablo.AddCell(data[3].ToString());
                }
                d.Add(tablo);
                d.Close();
                MessageBox.Show("Raporlandı");
                baglan.Close();
                Formlar.Rapor rpr = new Formlar.Rapor();
                rpr.adres = Application.StartupPath.ToString() + txttransfer.Text + "_Rapor.pdf";
                rpr.Show();
            }
            else
            {
                MessageBox.Show("Önce Kaydetmeniz Gerekiyor");
            }

        }//RAPORLAMA
        private void LinkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)//ÜST LINK
        {
            pnltransfer.Controls.Clear();
            Formlar.Islemler fe2 = new Formlar.Islemler();
            fe2.TopLevel = false;
            pnltransfer.Controls.Add(fe2);
            fe2.Show();
            fe2.Dock = DockStyle.Fill;
            fe2.BringToFront();
        }
        private void LinkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)//ÜST LINK
        {
            pnltransfer.Controls.Clear();
            DepoTransfer fe2 = new DepoTransfer();
            fe2.TopLevel = false;
            pnltransfer.Controls.Add(fe2);
            fe2.Show();
            fe2.Dock = DockStyle.Fill;
            fe2.BringToFront();
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
            dataGridView2.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;


        }
        private void DepoTransfer_Load(object sender, EventArgs e)//TRANSFER NO EKLENDİĞİ YER
        {
            // TODO: This line of code loads data into the 'girisDepoDS.T_DEPO' table. You can move, or remove it, as needed.
            this.t_DEPOTableAdapter1.Fill(this.girisDepoDS.T_DEPO);
            // TODO: This line of code loads data into the 'cikisDepoDS.T_DEPO' table. You can move, or remove it, as needed.
            this.t_DEPOTableAdapter.Fill(this.cikisDepoDS.T_DEPO);
            baglan.Open();
            komut3 = new SqlCommand("SELECT TRANSFER_NO FROM T_TRANSFER WHERE TRANSFER_ID = (select IDENT_CURRENT('T_TRANSFER'));", baglan);
            SqlDataReader data;
            data = komut3.ExecuteReader();
            data.Read();
    
            if (data.Read() != false)
            {
                string islemno = data[0].ToString().Substring(3);
                txttransfer.Text += Convert.ToInt32(islemno) + 1;
            }
            else
            {
                txttransfer.Text = "ST-1000";
            }
            baglan.Close();
         
            dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;


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
                    daset.Clear();
                    stokliste();
                    cmbdepo.Enabled = false;
                }


            }

        }
        private void DataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)//SEÇİLENİ SATIRA DOLDURMA
        {

            StokID = dataGridView2.CurrentRow.Cells["STOK_ID"].Value.ToString();

            if (StokID != "")
            {
                baglan.Open();
                SqlCommand komut = new SqlCommand("SELECT S.STOK_ID,S.STOK_KOD,S.STOK_AD,S.BARKOD,M.KALAN_MIKTAR AS[STOKTAKİ MIKTAR] FROM T_STOK S, T_STOKGIRIS G, T_MIKTAR M, T_DEPO D  WHERE G.STOK_ID = M.STOK_ID AND G.STOK_ID = S.STOK_ID  AND D.DEPO_ID = M.DEPO_ID AND D.DEPO_ID =" + cmbdepo.SelectedValue + " AND S.STOK_ID = '" + StokID + "'" + " GROUP BY S.STOK_ID, S.STOK_AD, S.BARKOD, S.STOK_KOD, S.STOK_AD, M.KALAN_MIKTAR", baglan);



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

                    did[sayac - 1] = Convert.ToInt32(StokID);
                    panel1.Visible = false;
                }
                baglan.Close();

            }

        }
        private void Ttxtara_TextChanged(object sender, EventArgs e)//ARAMA BUTONU
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
                if (Convert.ToInt32(dataGridView1.Rows[j].Cells[6].Value.ToString()) < Convert.ToInt32(dataGridView1.Rows[j].Cells[5].Value))
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

            if (cmbdepo.Text != "" && cmbdepo2.Text != "" && dataGridView1.Rows[0].Cells[1].Value != null)
            {
                baglan.Open();
                if (tekrar == 0)
                {
                    if (sayac == satir)  //Burada eğer üç satırlık bir giriş yapılmışsa 2 tanesi koşula uyup 1 tanesi uymuyorsa else kısmına girdiyor.
                                         //Üç satırlık giriş yapılmışsa üçününde koşula uygun olması gerekir.
                    {
                        for (int i = 0; i < sayac; i++)
                        {
                            komut = new SqlCommand("INSERT INTO T_TRANSFER VALUES(@TRANSFER_NO,@CIKIS_DEPO_ID,@GIRIS_DEPO_ID,@TRANSFER_TARIH);select  insert_ID=@@Identity; ", baglan);
                            komut.Parameters.AddWithValue("@TRANSFER_NO", txttransfer.Text);
                            komut.Parameters.AddWithValue("@GIRIS_DEPO_ID", Convert.ToInt32(cmbdepo2.SelectedValue));
                            komut.Parameters.AddWithValue("@CIKIS_DEPO_ID", cmbdepo.SelectedValue);
                            komut.Parameters.AddWithValue("@TRANSFER_TARIH", dateTimePicker1.Value);
                            id = komut.ExecuteScalar().ToString();
                        }

                        MessageBox.Show("Kayıt Eklendi");
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

                            komut = new SqlCommand("INSERT INTO T_TRANSFER VALUES(@TRANSFER_NO,@CIKIS_DEPO_ID,@GIRIS_DEPO_ID,@STOK_ID,@TRANSFER_TARIH) ", baglan);
                            komut.Parameters.AddWithValue("@TRANSFER_NO", txttransfer.Text);
                            komut.Parameters.AddWithValue("@GIRIS_DEPO_ID", Convert.ToInt32(cmbdepo2.SelectedValue));
                            komut.Parameters.AddWithValue("@CIKIS_DEPO_ID", cmbdepo.SelectedValue);
                            komut.Parameters.AddWithValue("@STOK_ID", did[i]);
                            komut.Parameters.AddWithValue("@TRANSFER_TARIH", dateTimePicker1.Value);
                            komut.ExecuteNonQuery();

                        }
                        MessageBox.Show("Kayıt Eklendi");
                        StokGirisCikis();
                    }
                    else
                    {
                        MessageBox.Show("Stoktaki Miktardan Fazla Girdiniz");
                    }
                }
                baglan.Close();
                tik++;
                DepoT();
            }
            else
            {
                cmbdepo2.Focus(); dataGridView1.Focus(); cmbdepo.Focus();
                errorProvider1.SetError(cmbdepo, "Boş Geçilmez");
                errorProvider1.SetError(cmbdepo2, "Boş Geçilmez");
                errorProvider1.SetError(dataGridView1, "Boş Geçilmez");
            }



        }
        private void DepoT()//DEPO TRANSFER TABLOSUNA EKLEME
        {
            baglan.Open();
            for (int i = 0; i < sayac; i++)
            {
                komut_transfer = new SqlCommand("INSERT INTO T_DEPOTRANSFER VALUES(@TRANSFER_ID,@STOK_ID,@MIKTAR)", baglan);
                komut_transfer.Parameters.AddWithValue("@TRANSFER_ID", id);
                komut_transfer.Parameters.AddWithValue("@STOK_ID", did[i]);
                komut_transfer.Parameters.AddWithValue("@MIKTAR", dmiktar[i]);
                komut_transfer.ExecuteNonQuery();
            }
            baglan.Close();
        }
        private void StokGirisCikis()//MİKTARA GÖRE iŞLEM
        {
            komut3 = new SqlCommand("SELECT * FROM T_MIKTAR ", baglan);
            oku = komut3.ExecuteReader();
            while (oku.Read())
            {
                stok2 = oku[0].ToString();
                depo = oku[1].ToString();
                for (int j = 0; j < sayac; j++)
                {
                    if (sayac > dongu)
                    {
                        if (stok2 == did[j].ToString() && depo == cmbdepo2.SelectedValue.ToString())//DEPODA STOK NUMARISINA AİT GİRİŞ VARSA
                        {
                            komut2 = new SqlCommand("UPDATE  T_MIKTAR SET KALAN_MIKTAR=KALAN_MIKTAR-@KALAN_MIKTAR WHERE STOK_ID=" + did[j] + " AND DEPO_ID=" + cmbdepo.SelectedValue + ";"
                                + "UPDATE  T_MIKTAR SET KALAN_MIKTAR=KALAN_MIKTAR+@KALAN_MIKTAR WHERE STOK_ID=" + did[j] + " AND DEPO_ID=" + cmbdepo2.SelectedValue, baglan);
                            komut2.Parameters.AddWithValue("@KALAN_MIKTAR", dmiktar[j]);

                        }
                        else//DEPODA STOK NUMARISINA AİT GİRİŞ YOKSA
                        {

                            komut2 = new SqlCommand("UPDATE  T_MIKTAR SET KALAN_MIKTAR=KALAN_MIKTAR-@KALAN_MIKTAR WHERE STOK_ID=" + did[j] + " AND DEPO_ID=" + cmbdepo.SelectedValue + ";"
                                + "INSERT INTO T_MIKTAR  VALUES( @STOK_ID,@DEPO_ID,@KALAN_MIKTAR) ", baglan);
                            komut2.Parameters.AddWithValue("@STOK_ID", StokID);
                            komut2.Parameters.AddWithValue("@DEPO_ID", cmbdepo2.SelectedValue);
                            komut2.Parameters.AddWithValue("@KALAN_MIKTAR", dmiktar[j]);

                        }
                    }
                }
                dongu++;
            }
            oku.Close();
            komut2.ExecuteNonQuery();
        }
        private void Cmbdepo_SelectedIndexChanged(object sender, EventArgs e)//DEPO SEÇİMİNİ KONTROL ETME
        {
            tiklanma++;
        }
        private void Cmbdepo2_SelectedIndexChanged(object sender, EventArgs e)//İKİ DEPO SEÇİMİ FARKLI OLMASI
        {
            if (cmbdepo.Text == cmbdepo2.Text)
            {
                MessageBox.Show("Çıkış ve Giriş Deposu Aynı Olamaz");
                cmbdepo2.Text = "";
            }
        }

    }
}
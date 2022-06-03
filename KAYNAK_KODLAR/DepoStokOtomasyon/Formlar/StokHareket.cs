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

namespace DepoStokOtomasyon.Formlar
{
    public partial class StokHareket : Form
    {
        public StokHareket()
        {
            InitializeComponent();
        }
        SqlConnection baglan = new SqlConnection(ConfigurationManager.ConnectionStrings["Baglanti"].ToString());
        DataSet daset = new DataSet();
        SqlDataAdapter adtr;
        DataTable tablo = new DataTable();

        private void Tcmbara_SelectedIndexChanged(object sender, EventArgs e)//COMBOBOXTAN SEÇİM YAPILDIĞINDA
        {
            if (tcmbara.Text == "Stok Giriş")
            {

                tablo.Clear();
                adtr = new SqlDataAdapter("SELECT SC.ISLEM_NO AS [Islem No],S.STOK_KOD AS [Stok Kodu], D.DEPO_AD AS[Depo],F.FIRMA_AD AS [Firma],SC.MIKTAR AS [Miktar],SC.FIYAT AS [Fiyat], ((((SC.TOPLAM_TUTAR - SC.FIYAT) * 100) / SC.FIYAT) / SC.MIKTAR) / 100 AS[KDV], SC.TOPLAM_TUTAR AS[Toplam Tutar], SC.TARIH as [Tarih] FROM  T_STOK S, T_KATEGORI K, T_STOKGIRIS SC, T_DEPO D, T_FIRMA F WHERE   SC.STOK_ID = S.STOK_ID AND D.DEPO_ID = SC.DEPO_ID AND F.FIRMA_ID = SC.FIRMA_ID GROUP BY S.STOK_KOD, SC.ISLEM_NO, D.DEPO_AD, SC.TARIH, F.FIRMA_AD, SC.TOPLAM_TUTAR, SC.FIYAT, SC.MIKTAR ORDER BY SC.TARIH DESC; ", baglan);
                adtr.Fill(tablo);
                dtgstok.DataSource = tablo;



            }
            else if (tcmbara.Text == "Stok Çıkış")
            {

                tablo.Clear();
                adtr = new SqlDataAdapter("SELECT SC.ISLEM_NO AS [Islem No],S.STOK_KOD AS [Stok Kodu], D.DEPO_AD AS[Depo],F.FIRMA_AD AS [Firma],SC.MIKTAR AS [Miktar],SC.FIYAT AS [Fiyat], ((((SC.TOPLAM_TUTAR - SC.FIYAT) * 100) / SC.FIYAT) / SC.MIKTAR) / 100 AS[KDV], SC.TOPLAM_TUTAR AS[Toplam Tutar], SC.TARIH as [Tarih] FROM  T_STOK S, T_KATEGORI K, T_STOKCIKIS SC, T_DEPO D, T_FIRMA F WHERE   SC.STOK_ID = S.STOK_ID AND D.DEPO_ID = SC.DEPO_ID AND F.FIRMA_ID = SC.FIRMA_ID GROUP BY S.STOK_KOD, SC.ISLEM_NO, D.DEPO_AD, SC.TARIH, F.FIRMA_AD, SC.TOPLAM_TUTAR, SC.FIYAT, SC.MIKTAR ORDER BY SC.TARIH DESC; ", baglan);
                adtr.Fill(tablo);
                dtgstok.DataSource = tablo;

            }
            dtgstok.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dtgstok.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dtgstok.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dtgstok.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dtgstok.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dtgstok.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dtgstok.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dtgstok.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dtgstok.Columns[8].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

        }
        private void LinkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)//UST LINK
        {
            pnlstokh.Controls.Clear();
            Formlar.Islemler fe2 = new Formlar.Islemler();
            fe2.TopLevel = false;
            pnlstokh.Controls.Add(fe2);
            fe2.Show();
            fe2.Dock = DockStyle.Fill;
            fe2.BringToFront();

        }
        private void Btnraporla_Click(object sender, EventArgs e)//RAPORLAMA
        {
            exportgridtopdf(dtgstok, "StokHareketRapor_" + DateTime.Today.ToShortDateString());
        }
        public void exportgridtopdf(DataGridView dgw, string filename)//RAPORLAMA İŞLEMİ
        {
            BaseFont bf = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1250, BaseFont.EMBEDDED);
            PdfPTable pdftable = new PdfPTable(dgw.Columns.Count);
            iTextSharp.text.Paragraph d = new iTextSharp.text.Paragraph();
            pdftable.DefaultCell.Padding = 3;
            pdftable.WidthPercentage = 100;
            pdftable.HorizontalAlignment = Element.ALIGN_LEFT;
            pdftable.DefaultCell.BorderWidth = 1;


            iTextSharp.text.Font text = new iTextSharp.text.Font(bf, 10, iTextSharp.text.Font.NORMAL);
    
       
   
        
            foreach (DataGridViewColumn column in dgw.Columns)
            {

                PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText, text));
                cell.BackgroundColor = new iTextSharp.text.BaseColor(240, 240, 240);
                pdftable.AddCell(cell);
            }
            foreach (DataGridViewRow row in dgw.Rows)
            {
                foreach (DataGridViewCell cell in row.Cells)
                {

                    pdftable.AddCell(new Phrase(cell.Value.ToString(), text));
                }
            }
            var savefiledialoge = new SaveFileDialog();
            savefiledialoge.FileName = filename;
            savefiledialoge.DefaultExt = ".pdf";
            if (savefiledialoge.ShowDialog() == DialogResult.OK)
            {
                using (FileStream stream = new FileStream(savefiledialoge.FileName, FileMode.Create))
                {
                    Document pdfdoc = new Document(PageSize.A4, 10f, 10f, 10f, 10f);
                    PdfWriter.GetInstance(pdfdoc, stream);
                    pdfdoc.Open();
         
                    pdfdoc.Add(pdftable);
               
                    pdfdoc.Close();
                    stream.Close();

                }
                Formlar.Rapor rpr = new Formlar.Rapor();
                rpr.adres = savefiledialoge.FileName;
                rpr.Show();
            }
         
        }
        private void LinkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)//UST LINK
        {
            pnlstokh.Controls.Clear();
            Formlar.StokHareket fe2 = new Formlar.StokHareket();
            fe2.TopLevel = false;
            pnlstokh.Controls.Add(fe2);
            fe2.Show();
            fe2.Dock = DockStyle.Fill;
            fe2.BringToFront();
        }


    }
}

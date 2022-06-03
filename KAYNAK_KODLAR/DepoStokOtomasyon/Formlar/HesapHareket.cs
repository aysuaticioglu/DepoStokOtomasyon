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
    public partial class HesapHareket : Form
    {
        public HesapHareket()
        {
            InitializeComponent();
        }
        SqlConnection baglan = new SqlConnection(ConfigurationManager.ConnectionStrings["Baglanti"].ToString());
        private void Tcmbara_SelectedIndexChanged(object sender, EventArgs e)//Hesap İşlemine Göre Arama
        {
            DataTable tablo = new DataTable();
            SqlDataAdapter adtr;
            baglan.Open();
            if (tcmbara.SelectedIndex == 0)
            {

                adtr = new SqlDataAdapter("SELECT H.HESAP_AD AS [Hesap Adı],G.TUTAR  as Tutar,G.ACIKLAMA as Açıklama,G.TARIH  as Tarih FROM T_HESAP H, T_HESAPGIRIS G WHERE H.HESAP_ID = G.HESAP_ID  ORDER BY G.TARIH DESC; ", baglan);
                adtr.Fill(tablo);
                bunifuCustomDataGrid1.DataSource = tablo;
                bunifuCustomDataGrid1.Columns["TUTAR"].DefaultCellStyle.ForeColor = Color.FromArgb(0, 192, 0);

            }
            else if (tcmbara.SelectedIndex == 1)
            {


                adtr = new SqlDataAdapter("SELECT H.HESAP_AD AS [Hesap Adı],C.TUTAR  as Tutar,C.ACIKLAMA as Açıklama,C.TARIH  as Tarih  FROM T_HESAP H, T_HESAPCIKIS C WHERE H.HESAP_ID = C.HESAP_ID  ORDER BY C.TARIH DESC; ", baglan);
                adtr.Fill(tablo);
                bunifuCustomDataGrid1.DataSource = tablo;
                bunifuCustomDataGrid1.Columns["TUTAR"].DefaultCellStyle.ForeColor = Color.FromArgb(192, 0, 0);

            }
            else if (tcmbara.SelectedIndex == 2)
            {

                adtr = new SqlDataAdapter("SELECT H.HESAP_AD AS [Transfer Edilen],X.HESAP_AD AS [Transfer],T.TUTAR as Tutar,T.ACIKLAMA as Açıklama,T.TARIH as Tarih  FROM T_HESAP H, T_HESAP X, T_HESAPTRANSFER T WHERE H.HESAP_ID = T.GIDEN_HESAP_ID  AND X.HESAP_ID = T.GELEN_HESAP_ID ORDER BY T.TARIH DESC; ", baglan);
                adtr.Fill(tablo);
                bunifuCustomDataGrid1.DataSource = tablo;
                bunifuCustomDataGrid1.Columns["TUTAR"].DefaultCellStyle.ForeColor = Color.FromArgb(0, 192, 192);
                baglan.Close();
                bunifuCustomDataGrid1.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
            else if (tcmbara.SelectedIndex == 3)
            {

                adtr = new SqlDataAdapter("SELECT H.HESAP_AD AS [Hesap Adı],F2.FIRMA_AD as [Firma],F.TUTAR  as Tutar,F.ACIKLAMA as Açıklama,F.TARIH  as Tarih FROM T_HESAP H, T_FIRMAODEME F, T_FIRMA F2 WHERE H.HESAP_ID = F.HESAP_ID AND F.FIRMA_ID = F2.FIRMA_ID ORDER BY F.TARIH DESC; ", baglan);
                adtr.Fill(tablo);
                bunifuCustomDataGrid1.DataSource = tablo;
                bunifuCustomDataGrid1.Columns["TUTAR"].DefaultCellStyle.ForeColor = Color.FromArgb(192, 0, 0);
                baglan.Close();
                bunifuCustomDataGrid1.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
            else if (tcmbara.SelectedIndex == 4)
            {

                adtr = new SqlDataAdapter("SELECT H.HESAP_AD AS [Hesap Adı],F2.FIRMA_AD AS [Firma],F.TUTAR  as Tutar,F.ACIKLAMA as Açıklama,F.TARIH  as Tarih FROM T_HESAP H, T_FIRMATAHSILAT F, T_FIRMA F2 WHERE H.HESAP_ID = F.HESAP_ID AND F.FIRMA_ID = F2.FIRMA_ID  ORDER BY F.TARIH DESC; ", baglan);
                adtr.Fill(tablo);
                bunifuCustomDataGrid1.DataSource = tablo;
                bunifuCustomDataGrid1.Columns["TUTAR"].DefaultCellStyle.ForeColor = Color.FromArgb(0, 192, 0);

                bunifuCustomDataGrid1.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
            baglan.Close();
            bunifuCustomDataGrid1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            bunifuCustomDataGrid1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            bunifuCustomDataGrid1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            bunifuCustomDataGrid1.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

        }
        private void LinkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)//UST LINK
        {
            pnlhesaph.Controls.Clear();
            Formlar.Islemler fe2 = new Formlar.Islemler();
            fe2.TopLevel = false;
            pnlhesaph.Controls.Add(fe2);
            fe2.Show();
            fe2.Dock = DockStyle.Fill;
            fe2.BringToFront();
        }
        private void LinkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)//UST LINK
        {
            pnlhesaph.Controls.Clear();
            Formlar.HesapHareket fe2 = new Formlar.HesapHareket();
            fe2.TopLevel = false;
            pnlhesaph.Controls.Add(fe2);
            fe2.Show();
            fe2.Dock = DockStyle.Fill;
            fe2.BringToFront();
        }
        private void ToolStripButton2_Click(object sender, EventArgs e)//Raporlama
        {
            exportgridtopdf(bunifuCustomDataGrid1, Application.StartupPath.ToString()+ "HesapHareketRapor_" + DateTime.Today.ToShortDateString()); 
        }
        public void exportgridtopdf(DataGridView dgw, string filename)//RAPORLAMA İŞLEMLERİ
        {

            BaseFont bf = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1250, BaseFont.EMBEDDED);
            iTextSharp.text.Font text = new iTextSharp.text.Font(bf, 10, iTextSharp.text.Font.NORMAL);
            PdfPTable pdftable = new PdfPTable(dgw.Columns.Count);
            pdftable.DefaultCell.Padding = 3;
            pdftable.WidthPercentage = 100;
            pdftable.HorizontalAlignment = Element.ALIGN_LEFT;
            pdftable.DefaultCell.BorderWidth = 1;


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
    }
}

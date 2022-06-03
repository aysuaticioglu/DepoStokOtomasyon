using iTextSharp.text;
using iTextSharp.text.pdf;
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
using System.IO;
using System.Configuration;
using LiveCharts.Wpf;
using LiveCharts;

namespace DepoStokOtomasyon
{
    public partial class MevcutStok : Form
    {
        SqlConnection baglan = new SqlConnection(ConfigurationManager.ConnectionStrings["Baglanti"].ToString());
        DataSet daset = new DataSet();
        DataTable tablo = new DataTable();
        SqlDataAdapter adptr;
        public MevcutStok()
        {
            InitializeComponent();
        }
        private void MevcutStok_Load(object sender, EventArgs e)//DataGridView Doldurma
        {
            bunifuCustomDataGrid1.ClearSelection();
            baglan.Open();

            adptr = new SqlDataAdapter("SELECT S.STOK_KOD AS [Stok Kodu],S.STOK_AD AS [Stok Adı],K.KATEGORI_AD AS [Kategori],D.DEPO_AD AS [DEPO]," +
                "M.KALAN_MIKTAR AS [Stok Miktar] FROM T_DEPO D, T_STOK S, T_MIKTAR M, T_KATEGORI K " +
                "WHERE K.KATEGORI_ID = S.KATEGORI_ID AND M.DEPO_ID=D.DEPO_ID  AND M.STOK_ID = S.STOK_ID AND M.KALAN_MIKTAR <> 0 " +
                "GROUP BY S.STOK_KOD, M.KALAN_MIKTAR, S.STOK_AD, K.KATEGORI_AD,D.DEPO_AD", baglan);
            adptr.Fill(daset, "T_STOK");
            bunifuCustomDataGrid1.DataSource = daset.Tables["T_STOK"];
            baglan.Close();
            TablePnl();

        }
        private void Ttxtara_TextChanged(object sender, EventArgs e)//DataGridViewde Kayıt Arama
        {
            baglan.Open();
            if (tcmbara.Text == "Stok Kodu")
            {
                tablo.Clear();

                adptr = new SqlDataAdapter("SELECT S.STOK_KOD AS [Stok Kodu],S.STOK_AD AS [Stok Adı],K.KATEGORI_AD AS" +
               " [Kategori],D.DEPO_AD AS [DEPO],M.KALAN_MIKTAR AS [Stok Miktar] FROM T_DEPO D, T_STOK S, T_MIKTAR M, T_KATEGORI K " +
               "WHERE K.KATEGORI_ID = S.KATEGORI_ID  AND  M.DEPO_ID=D.DEPO_ID AND M.STOK_ID = S.STOK_ID AND M.KALAN_MIKTAR <> 0 " +
               "AND  S.STOK_KOD Like'%" + ttxtara.Text + "%'" +
               "GROUP BY S.STOK_KOD, M.KALAN_MIKTAR, S.STOK_AD, K.KATEGORI_AD,D.DEPO_AD ", baglan);
                adptr.Fill(tablo);
                bunifuCustomDataGrid1.DataSource = tablo;


            }
            if (tcmbara.Text == "Stok Adı")
            {
                tablo.Clear();

                adptr = new SqlDataAdapter("SELECT S.STOK_KOD AS [Stok Kodu],S.STOK_AD AS [Stok Adı],K.KATEGORI_AD AS" +
               " [Kategori],D.DEPO_AD AS [DEPO],M.KALAN_MIKTAR AS [Stok Miktar] FROM T_DEPO D, T_STOK S, T_MIKTAR M, T_KATEGORI K " +
               "WHERE K.KATEGORI_ID = S.KATEGORI_ID  AND M.DEPO_ID=D.DEPO_ID AND M.STOK_ID = S.STOK_ID AND M.KALAN_MIKTAR <> 0 " +
               "AND  S.STOK_AD Like'%" + ttxtara.Text + "%'" +
               "GROUP BY S.STOK_KOD, M.KALAN_MIKTAR, S.STOK_AD, K.KATEGORI_AD,D.DEPO_AD ", baglan);
                adptr.Fill(tablo);
                bunifuCustomDataGrid1.DataSource = tablo;



            }
            if (tcmbara.Text == "Kategori")
            {

                tablo.Clear();
                adptr = new SqlDataAdapter("SELECT S.STOK_KOD AS [Stok Kodu],S.STOK_AD AS [Stok Adı],K.KATEGORI_AD AS" +
               " [Kategori],D.DEPO_AD AS [DEPO],M.KALAN_MIKTAR AS [Stok Miktar] FROM  T_DEPO D,T_STOK S, T_MIKTAR M, T_KATEGORI K " +
               "WHERE K.KATEGORI_ID = S.KATEGORI_ID  AND M.DEPO_ID=D.DEPO_ID AND M.STOK_ID = S.STOK_ID AND M.KALAN_MIKTAR <> 0 " +
               "AND  K.KATEGORI_AD Like'%" + ttxtara.Text + "%'" +
               "GROUP BY S.STOK_KOD, M.KALAN_MIKTAR, S.STOK_AD, K.KATEGORI_AD,D.DEPO_AD ", baglan);
                adptr.Fill(tablo);
                bunifuCustomDataGrid1.DataSource = tablo;



            }
            if (tcmbara.Text == "Stok Miktar")
            {

                tablo.Clear();
                adptr = new SqlDataAdapter("SELECT S.STOK_KOD AS [Stok Kodu],S.STOK_AD AS [Stok Adı],K.KATEGORI_AD AS" +
               " [Kategori],D.DEPO_AD AS [DEPO],M.KALAN_MIKTAR AS [Stok Miktar] FROM  T_DEPO D,T_STOK S, T_MIKTAR M, T_KATEGORI K " +
               "WHERE K.KATEGORI_ID = S.KATEGORI_ID  AND  M.DEPO_ID=D.DEPO_ID AND M.STOK_ID = S.STOK_ID AND M.KALAN_MIKTAR <> 0 " +
               "AND M.KALAN_MIKTAR Like'%" + ttxtara.Text + "%'" +
               "GROUP BY S.STOK_KOD, M.KALAN_MIKTAR, S.STOK_AD, K.KATEGORI_AD ,D.DEPO_AD", baglan);
                adptr.Fill(tablo);
                bunifuCustomDataGrid1.DataSource = tablo;

            }
            baglan.Close();
            TablePnl();
        }
        private void ToolStripButton2_Click(object sender, EventArgs e)//RAPORLAMA
        {
            exportgridtopdf(bunifuCustomDataGrid1, "MevcutStokRapor_" + DateTime.Today.ToShortDateString());
        }
        public void exportgridtopdf(DataGridView dgw, string filename)//RAPORLAMA İŞLEMİ
        {
            BaseFont bf = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1250, BaseFont.EMBEDDED);
            PdfPTable pdftable = new PdfPTable(dgw.Columns.Count);
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
        private void LinkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)//ÜST LINK
        {
            pnlmevcuts.Controls.Clear();
            Formlar.Islemler fe2 = new Formlar.Islemler();
            fe2.TopLevel = false;
            pnlmevcuts.Controls.Add(fe2);
            fe2.Show();
            fe2.Dock = DockStyle.Fill;
            fe2.BringToFront();
        }
        private void LinkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)//ÜST LINK
        {
            pnlmevcuts.Controls.Clear();
            MevcutStok fe2 = new MevcutStok();
            fe2.TopLevel = false;
            pnlmevcuts.Controls.Add(fe2);
            fe2.Show();
            fe2.Dock = DockStyle.Fill;
            fe2.BringToFront();
        }
        private void TablePnl()//DATAGRIDVIEW BOYUT
        {
            bunifuCustomDataGrid1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            bunifuCustomDataGrid1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            bunifuCustomDataGrid1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            bunifuCustomDataGrid1.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            bunifuCustomDataGrid1.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }
        
    }
}

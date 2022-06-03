using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;

namespace DepoStokOtomasyon.Formlar
{
    public partial class AnalizDepoTransferleri : Form
    {
        SqlConnection baglan = new SqlConnection(ConfigurationManager.ConnectionStrings["Baglanti"].ToString());
        DataSet daset = new DataSet();
        DataTable tablo = new DataTable();
        SqlDataAdapter adtr;
        public AnalizDepoTransferleri()
        {
            InitializeComponent();
        }

        private void AnalizDepoTransferleri_Load(object sender, EventArgs e)//DATAGRIDVIEWE DOLDURMA
        {
            bunifuCustomDataGrid1.ClearSelection();
            baglan.Open();
            SqlDataAdapter adptr = new SqlDataAdapter
                ("SELECT T.TRANSFER_NO AS [Transfer No],S.STOK_KOD as [Stok Kod],P.DEPO_AD as [Çıkış Depo],P2.DEPO_AD as [Giris Depo],D.MIKTAR as [Miktar],T.TRANSFER_TARIH as [Transfer Tarih]" +
                " FROM T_DEPOTRANSFER D, T_TRANSFER T, T_STOK S, T_DEPO P, T_DEPO P2 WHERE T.TRANSFER_ID = D.TRANSFER_ID AND D.STOK_ID = S.STOK_ID AND T.CIKIS_DEPO_ID = P.DEPO_ID AND" +
                " T.GIRIS_DEPO_ID = P2.DEPO_ID", baglan);
            adptr.Fill(daset, "T_STOK");
            bunifuCustomDataGrid1.DataSource = daset.Tables["T_STOK"];
            baglan.Close();
            TableLayoutpnl();
        }
        private void Ttxtara_TextChanged(object sender, EventArgs e)//COMBOBOXTAN SEÇİM YAPILDIĞINDA
        {
            baglan.Open();
            if (tcmbara.Text == "Transfer No")
            {

                tablo.Clear();
                adtr = new SqlDataAdapter("SELECT T.TRANSFER_NO AS [Transfer No],S.STOK_KOD as [Stok Kod],P.DEPO_AD as [Çıkış Depo],P2.DEPO_AD as [Giris Depo],D.MIKTAR as [Miktar],T.TRANSFER_TARIH as [Transfer Tarih]" +
               " FROM T_DEPOTRANSFER D, T_TRANSFER T, T_STOK S, T_DEPO P, T_DEPO P2 WHERE T.TRANSFER_ID = D.TRANSFER_ID AND D.STOK_ID = S.STOK_ID AND T.CIKIS_DEPO_ID = P.DEPO_ID AND" +
               " T.GIRIS_DEPO_ID = P2.DEPO_ID AND T.TRANSFER_NO LIKE'%" + ttxtara.Text + "%'", baglan);
                adtr.Fill(tablo);
                bunifuCustomDataGrid1.DataSource = tablo;

                TableLayoutpnl();

            }
            if (tcmbara.Text == "Stok Kodu")
            {

                tablo.Clear();
                adtr = new SqlDataAdapter("SELECT T.TRANSFER_NO AS [Transfer No],S.STOK_KOD as [Stok Kod],P.DEPO_AD as [Çıkış Depo],P2.DEPO_AD as [Giris Depo],D.MIKTAR as [Miktar],T.TRANSFER_TARIH as [Transfer Tarih]" +
               " FROM T_DEPOTRANSFER D, T_TRANSFER T, T_STOK S, T_DEPO P, T_DEPO P2 WHERE T.TRANSFER_ID = D.TRANSFER_ID AND D.STOK_ID = S.STOK_ID AND T.CIKIS_DEPO_ID = P.DEPO_ID AND" +
               " T.GIRIS_DEPO_ID = P2.DEPO_ID AND S.STOK_KOD LIKE'%" + ttxtara.Text + "%'", baglan);
                adtr.Fill(tablo);
                bunifuCustomDataGrid1.DataSource = tablo;
                TableLayoutpnl();



            }
            if (tcmbara.Text == "Çıkış Depo")
            {
                tablo.Clear();

                adtr = new SqlDataAdapter("SELECT T.TRANSFER_NO AS[Transfer No], S.STOK_KOD as [Stok Kod], P.DEPO_AD as [Çıkış Depo], P2.DEPO_AD as [Giris Depo], D.MIKTAR as [Miktar], T.TRANSFER_TARIH as [Transfer Tarih]" +
               " FROM T_DEPOTRANSFER D, T_TRANSFER T, T_STOK S, T_DEPO P, T_DEPO P2 WHERE T.TRANSFER_ID = D.TRANSFER_ID AND D.STOK_ID = S.STOK_ID AND T.CIKIS_DEPO_ID = P.DEPO_ID AND" +
               " T.GIRIS_DEPO_ID = P2.DEPO_ID AND P.DEPO_AD LIKE'%" + ttxtara.Text + "%'", baglan);
                adtr.Fill(tablo);
                bunifuCustomDataGrid1.DataSource = tablo;

                TableLayoutpnl();
            }
            if (tcmbara.Text == "Giriş Depo")
            {


                adtr = new SqlDataAdapter("SELECT T.TRANSFER_NO AS [Transfer No],S.STOK_KOD as [Stok Kod],P.DEPO_AD as [Çıkış Depo],P2.DEPO_AD as [Giris Depo],D.MIKTAR as [Miktar],T.TRANSFER_TARIH as [Transfer Tarih]" +
               " FROM T_DEPOTRANSFER D, T_TRANSFER T, T_STOK S, T_DEPO P, T_DEPO P2 WHERE T.TRANSFER_ID = D.TRANSFER_ID AND D.STOK_ID = S.STOK_ID AND T.CIKIS_DEPO_ID = P.DEPO_ID AND" +
               " T.GIRIS_DEPO_ID = P2.DEPO_ID AND P2.DEPO_AD LIKE'%" + ttxtara.Text + "%'", baglan);
                adtr.Fill(tablo);
                bunifuCustomDataGrid1.DataSource = tablo;

                TableLayoutpnl();
            }
            baglan.Close();
        }
        private void ToolStripButton2_Click(object sender, EventArgs e)//RAPORLAMA
        {

            exportgridtopdf(bunifuCustomDataGrid1, "DepoTransferRapor_" + DateTime.Today.ToShortDateString()); 

        }
        public void exportgridtopdf(DataGridView dgw, string filename)//RAPORLAMA İŞLEMİ
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
        private void LinkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)//ÜST LINK
        {
            pnlanaliz.Controls.Clear();
            Formlar.Islemler fe2 = new Formlar.Islemler();
            fe2.TopLevel = false;
            pnlanaliz.Controls.Add(fe2);
            fe2.Show();
            fe2.Dock = DockStyle.Fill;
            fe2.BringToFront();
        }
        private void LinkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)//ÜST LINK
        {
            pnlanaliz.Controls.Clear();
            Formlar.AnalizDepoTransferleri fe2 = new Formlar.AnalizDepoTransferleri();
            fe2.TopLevel = false;
            pnlanaliz.Controls.Add(fe2);
            fe2.Show();
            fe2.Dock = DockStyle.Fill;
            fe2.BringToFront();
        }
        private void TableLayoutpnl()//DATAGRIDVIEW BOYUT AYARLAMA
        {
            bunifuCustomDataGrid1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            bunifuCustomDataGrid1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            bunifuCustomDataGrid1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            bunifuCustomDataGrid1.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            bunifuCustomDataGrid1.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            bunifuCustomDataGrid1.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

    }
}

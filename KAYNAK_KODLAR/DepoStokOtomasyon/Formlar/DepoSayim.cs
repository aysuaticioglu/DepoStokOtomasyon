using iTextSharp.text;
using iTextSharp.text.pdf;
using LiveCharts;
using LiveCharts.Wpf;
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
    public partial class DepoSayim : Form
    {
        public DepoSayim()
        {
            InitializeComponent();
        }
        SqlConnection baglan = new SqlConnection(ConfigurationManager.ConnectionStrings["Baglanti"].ToString());
        SqlCommand komut;SqlDataReader data;
        private void DepoSayim_Load(object sender, EventArgs e)//DROPDOWNA DEPOLARI DOLDURMA
        {
            baglan.Open();
            komut = new SqlCommand("Select * From t_DEPO", baglan);

            data = komut.ExecuteReader();
            while (data.Read())
            {
                tcmbara.Items.Add(data[2].ToString());
            }
            baglan.Close();

        }
        private void Tcmbara_SelectedIndexChanged(object sender, EventArgs e)//DROPDOWNDAN SEÇİLENE GÖRE İŞLEM YAPMA
        {

            if (tcmbara.SelectedItem != null)
            {

                DataTable tablo = new DataTable();
                baglan.Open();
                SqlDataAdapter adtr = new SqlDataAdapter("SELECT D.DEPO_AD AS Depo,S.STOK_KOD AS [Stok Kodu],M.KALAN_MIKTAR AS [Toplam Miktar] FROM T_DEPO D, T_STOK S, T_MIKTAR M  WHERE  D.DEPO_ID = M.DEPO_ID AND M.STOK_ID = S.STOK_ID AND M.KALAN_MIKTAR<>0 AND  D.DEPO_AD Like'%" + tcmbara.Text + "%' GROUP BY S.STOK_KOD,D.DEPO_AD,M.KALAN_MIKTAR", baglan);
                adtr.Fill(tablo);
                bunifuCustomDataGrid1.DataSource = tablo;
                baglan.Close();


                for (int i = 0; i < bunifuCustomDataGrid1.Rows.Count; i++)
                {
                    DataGridViewCellStyle renk = new DataGridViewCellStyle();
                    if (Convert.ToInt32(bunifuCustomDataGrid1.Rows[i].Cells[2].Value) < 10)
                    {
                        renk.BackColor = Color.FromArgb(248, 197, 198);
                    }
                    else
                    {
                        renk.BackColor = Color.FromArgb(198, 247, 200);

                    }
                    bunifuCustomDataGrid1.Rows[i].DefaultCellStyle = renk;
                }

            }
            bunifuCustomDataGrid1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            bunifuCustomDataGrid1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            bunifuCustomDataGrid1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

        }
        private void LinkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)//ÜST LINK
        {
            pnlsayim.Controls.Clear();
            Formlar.Islemler fe2 = new Formlar.Islemler();
            fe2.TopLevel = false;
            pnlsayim.Controls.Add(fe2);
            fe2.Show();
            fe2.Dock = DockStyle.Fill;
            fe2.BringToFront();
        }
        private void LinkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)//ÜST LINK
        {
            pnlsayim.Controls.Clear();
            DepoSayim fe2 = new DepoSayim();
            fe2.TopLevel = false;
            pnlsayim.Controls.Add(fe2);
            fe2.Show();
            fe2.Dock = DockStyle.Fill;
            fe2.BringToFront();
        }
        private void ToolStripButton2_Click(object sender, EventArgs e)//RAPORLAMA
        {
            exportgridtopdf(bunifuCustomDataGrid1, "DepoSayimRapor_" + DateTime.Today.ToShortDateString());
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
    }
}

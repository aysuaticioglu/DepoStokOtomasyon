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
    public partial class StokListele : Form
    {
        public StokListele()
        {
            InitializeComponent();
        }
        SqlConnection baglan = new SqlConnection(ConfigurationManager.ConnectionStrings["Baglanti"].ToString());
        DataSet daset = new DataSet();
        public string StokID;

        public int FromClosing { get; internal set; }

        private void ToolStripButton1_Click(object sender, EventArgs e)
        {
            baglan.Open();
            SqlCommand komut = new SqlCommand("Delete From T_STOK Where STOK_KOD='" + dataGridView1.CurrentRow.Cells["STOK_KOD"].Value.ToString() + "'", baglan);
            komut.ExecuteNonQuery();
            baglan.Close();
            daset.Tables["T_STOK"].Clear();
            KayitGoster();
            MessageBox.Show("Stok Kaydı Silindi.");
            foreach (Control item in this.Controls)
            {
                if (item is TextBox)
                {
                    item.Text = "";
                }

            }
        }
        private void KayitGoster()
        {
            baglan.Open();
            SqlDataAdapter adptr = new SqlDataAdapter("SELECT S.STOK_ID,S.STOK_KOD,S.STOK_AD,S.BARKOD,K.KATEGORI_AD,B.BIRIM_AD,S.FIYAT,S.KDV " +
                "FROM  T_STOK S,T_KATEGORI K,T_BIRIM B " +
                "WHERE (S.KATEGORI_ID=K.KATEGORI_ID AND B.BIRIM_ID=S.BIRIM_ID)", baglan);

            adptr.Fill(daset, "T_STOK");
            dataGridView1.DataSource = daset.Tables["T_STOK"];
            baglan.Close();
        }

        private void StokListele_Load(object sender, EventArgs e)
        {
            KayitGoster();
        }
        private void ToolStripTextBox1_TextChanged(object sender, EventArgs e)
        {
            if (tcmbara.Text == "Stok Kodu")
            {
                DataTable tablo = new DataTable();
                baglan.Open();
                SqlDataAdapter adtr = new SqlDataAdapter("SELECT S.STOK_ID,S.STOK_KOD,S.STOK_AD,S.BARKOD,K.KATEGORI_AD,B.BIRIM_AD,S.FIYAT,S.KDV " +
                "FROM  T_STOK S,T_KATEGORI K,T_BIRIM B " +
                "WHERE (S.KATEGORI_ID=K.KATEGORI_ID AND B.BIRIM_ID=S.BIRIM_ID) AND S.STOK_KOD Like'%" + ttxtara.Text + "%'", baglan);
                adtr.Fill(tablo);
                dataGridView1.DataSource = tablo;
                baglan.Close();
            }
            else if (tcmbara.Text == "Barkod")
            {
                DataTable tablo = new DataTable();
                baglan.Open();
                SqlDataAdapter adtr = new SqlDataAdapter("SELECT S.STOK_ID,S.STOK_KOD,S.STOK_AD,S.BARKOD,K.KATEGORI_AD,B.BIRIM_AD,S.FIYAT,S.KDV " +
                "FROM  T_STOK S,T_KATEGORI K,T_BIRIM B " +
                "WHERE (S.KATEGORI_ID=K.KATEGORI_ID AND B.BIRIM_ID=S.BIRIM_ID)AND S.BARKOD Like'%" + ttxtara.Text + "%'", baglan);
                adtr.Fill(tablo);
                dataGridView1.DataSource = tablo;
                baglan.Close();
            }
            else if (tcmbara.Text == "Stok Adı")
            {
                DataTable tablo = new DataTable();
                baglan.Open();
                SqlDataAdapter adtr = new SqlDataAdapter("SELECT S.STOK_ID,S.STOK_KOD,S.STOK_AD,S.BARKOD,K.KATEGORI_AD,B.BIRIM_AD,S.FIYAT,S.KDV " +
                "FROM  T_STOK S,T_KATEGORI K,T_BIRIM B " +
                "WHERE (S.KATEGORI_ID=K.KATEGORI_ID AND B.BIRIM_ID=S.BIRIM_ID) AND S.STOK_AD Like'%" + ttxtara.Text + "%'", baglan);
                adtr.Fill(tablo);
                dataGridView1.DataSource = tablo;
                baglan.Close();
            }
        }

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            StokCikis frm2 = new StokCikis();
            frm2.Name = "STOK";
            if (Application.OpenForms["STOK"] == null)
            {
               
                frm2.StokID = dataGridView1.CurrentRow.Cells["STOK_ID"].Value.ToString();
                frm2.ShowDialog();
             
            }
            else
            {
                Application.OpenForms["STOK"].BringToFront();
            }
        }
    }
}

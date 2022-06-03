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
    public partial class StokListeleGiris : Form
    {
        SqlConnection baglan = new SqlConnection(ConfigurationManager.ConnectionStrings["Baglanti"].ToString());
        DataSet daset = new DataSet();
        public string StokID;
        public StokListeleGiris()
        {
            InitializeComponent();
        }

        private void StokListeleGiris_Load(object sender, EventArgs e)
        {
            KayitGoster();
        }
        private void KayitGoster()
        {
            DataGridViewCheckBoxColumn chk = new DataGridViewCheckBoxColumn();
            dataGridView1.Columns.Add(chk);
            chk.HeaderText = "SEÇ";
            chk.Name = "chk";

            baglan.Open();
            SqlDataAdapter adptr = new SqlDataAdapter("SELECT S.STOK_KOD,S.STOK_AD,S.BARKOD,B.BIRIM_AD,S.FIYAT,S.KDV " +
                "FROM  T_STOK S,T_BIRIM B " +
                "WHERE  B.BIRIM_ID=S.BIRIM_ID", baglan);

            adptr.Fill(daset, "T_STOK");
            dataGridView1.DataSource = daset.Tables["T_STOK"];
            baglan.Close();
          

        }
        private void DataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            foreach (DataGridViewRow row  in dataGridView1.Rows)
            {

                if (Convert.ToBoolean(row.Cells[0].Value)==true)
                {

                }
            }
        }

        private void ToolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
}
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
    public partial class StokTanim : Form
    {
        public StokTanim()
        {
            InitializeComponent();

        }
        public string StokID = "";
        int sayac = 0;
        SqlCommand komut,komut2,komut3;

        int[] depo = new int[50];
        SqlDataReader data;
        int deposayac = 0;
        string id = "";
        DataSet daset = new DataSet();
        SqlConnection baglan = new SqlConnection(ConfigurationManager.ConnectionStrings["Baglanti"].ToString());
        private void ToolStripButton3_Click(object sender, EventArgs e)//LİSTELE
        {
            KayitGoster();
            panel3.Visible = true;
            sayac++;
            if (sayac % 2 == 0)
            {
                daset.Clear();
                panel3.Visible = false;

            }

        }
        private void ToolStripButton1_Click(object sender, EventArgs e)//YENİ BUTONUNA BASILDIĞINDA
        {
            mtxtod.ReadOnly = false;
            txtsat.Text = "";
            txtbarkod.Text = "";
            txtfiyat.Text = "";
            txtkdv.Text = "";
            cmbkat.Text = "";
            cmbbirim.Text = "";
            StokID = "";
        }
        private void ToolStripButton2_Click(object sender, EventArgs e)//KAYDET BUTONUNA BASILDIĞINDA
        {
            if (StokID == "" && txtsat.Text!="" && txtbarkod.Text!="" && cmbbirim.Text!="" && cmbkat.Text!="" && mtxtod.Text != "")
            {
                baglan.Open();
                komut = new SqlCommand("INSERT INTO T_STOK VALUES( @STOK_KOD,@STOK_AD,@BARKOD,@KATEGORI_ID,@BIRIM_ID,@FIYAT,@KDV);select  insert_ID=@@Identity; ", baglan);
                //EKLENEN VERİNİN IDSINI ALMA @@IDENTITY

                komut.Parameters.AddWithValue("@STOK_KOD", mtxtod.Text);
                komut.Parameters.AddWithValue("@STOK_AD", txtsat.Text);
                komut.Parameters.AddWithValue("@BARKOD", txtbarkod.Text);
                komut.Parameters.AddWithValue("@KATEGORI_ID", cmbkat.SelectedValue);
                komut.Parameters.AddWithValue("@BIRIM_ID", cmbbirim.SelectedValue);
                komut.Parameters.AddWithValue("@FIYAT", Convert.ToDecimal(txtfiyat.Text));
                komut.Parameters.AddWithValue("@KDV", Convert.ToDecimal(txtkdv.Text));

                id = komut.ExecuteScalar().ToString();

                baglan.Close();

                MessageBox.Show("Stok Kaydı Eklendi");
                StokGirisCikisEkle();
                daset.Clear();
                KayitGoster();



            }

            else if (StokID != "" && txtsat.Text != "" && txtbarkod.Text != "" && cmbbirim.Text != "" && cmbkat.Text != "" && mtxtod.Text!="")
            {
                baglan.Open();
                komut = new SqlCommand("UPDATE T_STOK  SET " +
                    "STOK_KOD=@STOK_KOD,STOK_AD=@STOK_AD,BARKOD=@BARKOD,KATEGORI_ID=@KATEGORI_ID,BIRIM_ID=@BIRIM_ID,FIYAT=@FIYAT,KDV=@KDV " +
                    "WHERE STOK_ID='" + StokID + "'", baglan);
                komut.Parameters.AddWithValue("@STOK_KOD", mtxtod.Text);
                komut.Parameters.AddWithValue("@STOK_AD", txtsat.Text);
                komut.Parameters.AddWithValue("@BARKOD", txtbarkod.Text);
                komut.Parameters.AddWithValue("@KATEGORI_ID", cmbkat.SelectedValue);
                komut.Parameters.AddWithValue("@BIRIM_ID", cmbbirim.SelectedValue);
                komut.Parameters.AddWithValue("@FIYAT", Convert.ToDecimal(txtfiyat.Text));
                komut.Parameters.AddWithValue("@KDV", Convert.ToDecimal(txtkdv.Text));
                komut.ExecuteNonQuery();

                baglan.Close();
                MessageBox.Show("Stok Kaydı Güncellendi");
                daset.Clear();
                KayitGoster();

            }
            else
            {
                txtsat.Focus(); txtbarkod.Focus(); cmbkat.Focus(); cmbbirim.Focus();mtxtod.Focus();
                errorProvider1.SetError(txtsat, "Boş Geçilmez");
                errorProvider1.SetError(txtbarkod, "Boş Geçilmez");
                errorProvider1.SetError(cmbbirim, "Boş Geçilmez");
                errorProvider1.SetError(cmbkat, "Boş Geçilmez");
                errorProvider1.SetError(mtxtod, "Boş Geçilmez");



            }

        }
        private void StokTanim_Load(object sender, EventArgs e)//ISLEM NO EKLEME KISMI
        {
            // TODO: This line of code loads data into the 'birimDS.T_BIRIM' table. You can move, or remove it, as needed.
            this.t_BIRIMTableAdapter.Fill(this.birimDS.T_BIRIM);
            // TODO: This line of code loads data into the 'kategoriDS.T_KATEGORI' table. You can move, or remove it, as needed.
            this.t_KATEGORITableAdapter.Fill(this.kategoriDS.T_KATEGORI);


            baglan.Open();
            komut3 = new SqlCommand("SELECT STOK_KOD FROM T_STOK WHERE STOK_ID = (select IDENT_CURRENT('T_STOK'));", baglan);
            
            data = komut3.ExecuteReader();
            

            if (data.Read() != false)
            {
                string islemno = data[0].ToString().Substring(3);
                mtxtod.Text += Convert.ToInt32(islemno) + 1;
            }
            else
            {
               
            }

            baglan.Close();

        }
        private void StokGirisCikisEkle()//EKLEME KISMI
        {
            Depo();
            baglan.Open();
            for (int i = 0; i < deposayac; i++)
            {
                komut2 = new SqlCommand("INSERT INTO T_MIKTAR VALUES(@STOK_ID,@DEPO_ID,@KALAN_MIKTAR)", baglan);


                komut2.Parameters.AddWithValue("@STOK_ID", id);
                komut2.Parameters.AddWithValue("@DEPO_ID", depo[i]);
                komut2.Parameters.AddWithValue("@KALAN_MIKTAR", 0);
                komut2.ExecuteNonQuery();
            }

            baglan.Close();


        }
        private void Depo()//DİZİYE DEPO EKLEME
        {

            baglan.Open();

            SqlCommand komut3 = new SqlCommand("Select DEPO_ID From T_DEPO", baglan);
            SqlDataReader data;
            data = komut3.ExecuteReader();
            while (data.Read())
            {
                depo[deposayac] = Convert.ToInt32(data[0].ToString());
                deposayac++;
            }
            baglan.Close();

        }
        private void KayitGoster()//KAYIT GÖSTERME
        {
            daset.Clear();
            baglan.Open();
            SqlDataAdapter adptr = new SqlDataAdapter("SELECT S.STOK_ID,S.STOK_KOD,S.STOK_AD,S.BARKOD,K.KATEGORI_AD,B.BIRIM_AD,S.FIYAT,S.KDV " +
                "FROM  T_STOK S,T_KATEGORI K,T_BIRIM B " +
                "WHERE (S.KATEGORI_ID=K.KATEGORI_ID AND B.BIRIM_ID=S.BIRIM_ID)", baglan);

            adptr.Fill(daset, "T_STOK");
            dataGridView1.DataSource = daset.Tables["T_STOK"];
            baglan.Close();
            dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }
        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)//GÜNCELLEME
        {


            StokID = dataGridView1.CurrentRow.Cells["STOK_ID"].Value.ToString();
            if (StokID != "")
            {

                baglan.Open();
                SqlCommand komut = new SqlCommand("Select * From T_STOK where STOK_ID='" + StokID + "'", baglan);
                SqlDataReader data;
                data = komut.ExecuteReader();
                while (data.Read())
                {
                    mtxtod.Text = data[1].ToString();
                    txtsat.Text = data[2].ToString();
                    txtbarkod.Text = data[3].ToString();
                    cmbkat.SelectedValue = data[4].ToString();
                    cmbbirim.SelectedValue = data[5].ToString();
                    txtfiyat.Text = data[6].ToString();
                    txtkdv.Text = data[7].ToString();



                }
                baglan.Close();

            }

        }
        private void ToolStripButton4_Click(object sender, EventArgs e)//SİL BUTONUNA BASILDIĞINDA
        {
            string message = "Kaydı Silmek İstiyor Musunuz?";
            string title = "Sil";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;

            DialogResult result = MessageBox.Show(message, title, buttons, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
            if (result == DialogResult.Yes)
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
            else
            {
            }


        }
        private void Button2_Click(object sender, EventArgs e)
        {
            daset.Clear();
            panel3.Visible = false;
        }
        private void Ttxtara_TextChanged(object sender, EventArgs e)//ARAMA YAPILDIĞINDA
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
        private void LinkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)//UST LINK
        {
            pnlstok.Controls.Clear();
            StokTanim fe2 = new StokTanim();
            fe2.TopLevel = false;
            pnlstok.Controls.Add(fe2);
            fe2.Show();
            fe2.Dock = DockStyle.Fill;
            fe2.BringToFront();
        }
        private void LinkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)//UST LINK
        {
            pnlstok.Controls.Clear();
            Formlar.Islemler fe2 = new Formlar.Islemler();
            fe2.TopLevel = false;
            pnlstok.Controls.Add(fe2);
            fe2.Show();
            fe2.Dock = DockStyle.Fill;
            fe2.BringToFront();
        }
    }
}

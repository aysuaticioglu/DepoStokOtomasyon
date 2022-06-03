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
    public partial class FirmaTanim : Form
    {
        public FirmaTanim()
        {
            InitializeComponent();
        }
        SqlConnection baglan = new SqlConnection(ConfigurationManager.ConnectionStrings["Baglanti"].ToString());
        SqlCommand komut;
        public string firmaID = "";
        int sayac = 0;
        DataSet daset = new DataSet();

        private void FirmaTanim_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'iLDS.T_IL' table. You can move, or remove it, as needed.
            this.t_ILTableAdapter.Fill(this.iLDS.T_IL);


        }
        private void KayitGoster()//DATAGRIDVIEWE DOLDURMA
        {
            daset.Clear();
            baglan.Open();
            SqlDataAdapter adptr = new SqlDataAdapter("Select F.FIRMA_ID,F.FIRMA_AD,I.IL_AD AS IL,F.ADRES,F.TEL,F.VDAIRE,F.HESAP_NO From " +
                "T_FIRMA AS F , T_IL AS I " +
                "WHERE I.IL_ID=F.IL_ID", baglan);
            adptr.Fill(daset, "T_FIRMA");
            dataGridView1.DataSource = daset.Tables["T_FIRMA"];
            baglan.Close();
            dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }
        private void ToolStripButton1_Click_1(object sender, EventArgs e)//YENİ BUTONU BASILDIĞINDA
        {
            txtad.Text = "";
            mtxttel.Text = "";
            cmbil.Text = "";
            txtadres.Text = "";
            txtvergi.Text = "";
            txthesap.Text = "";

            firmaID = "";
        }
        private void ToolStripButton2_Click_1(object sender, EventArgs e)//KAYDET BUTONUNA BASILDIĞINDA
        {
            if (firmaID == "" && txtad.Text != "")
            {
                baglan.Open();
                komut = new SqlCommand("INSERT INTO T_FIRMA VALUES( @FIRMA_AD,@IL_ID,@ADRES,@TEL,@VDAIRE,@HESAP_NO) ", baglan);
                komut.Parameters.AddWithValue("@FIRMA_AD", txtad.Text);
                komut.Parameters.AddWithValue("@IL_ID", cmbil.SelectedValue);
                komut.Parameters.AddWithValue("@ADRES", txtadres.Text);
                komut.Parameters.AddWithValue("@TEL", mtxttel.Text);
                komut.Parameters.AddWithValue("@VDAIRE", txtvergi.Text);
                komut.Parameters.AddWithValue("@HESAP_NO", txthesap.Text);

                komut.ExecuteNonQuery();
                baglan.Close();
                MessageBox.Show("Firma Kaydı Eklendi");
                daset.Clear();
                KayitGoster();

            }

            else if (firmaID != "" && txtad.Text != "")
            {
                baglan.Open();
                komut = new SqlCommand("UPDATE T_FIRMA SET  FIRMA_AD=@FIRMA_AD,IL_ID=@IL_ID,ADRES=@ADRES,TEL=@TEL,VDAIRE=@VDAIRE,HESAP_NO=@HESAP_NO WHERE FIRMA_ID=" + firmaID, baglan);
                komut.Parameters.AddWithValue("@FIRMA_AD", txtad.Text);
                komut.Parameters.AddWithValue("@IL_ID", cmbil.SelectedValue);
                komut.Parameters.AddWithValue("@ADRES", txtadres.Text);
                komut.Parameters.AddWithValue("@TEL", mtxttel.Text);
                komut.Parameters.AddWithValue("@VDAIRE", txtvergi.Text);
                komut.Parameters.AddWithValue("@HESAP_NO", txthesap.Text);

                komut.ExecuteNonQuery();
                baglan.Close();
                MessageBox.Show("Firma Kaydı Güncellendi");
                daset.Clear();
                KayitGoster();
            }
            else
            {
                txtad.Focus();
                errorProvider1.SetError(txtad, "Boş Geçilmez");
            }
        }
        private void ToolStripButton3_Click_1(object sender, EventArgs e)//LİSTELE BUTONUNA BASILDIĞINDA
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
        private void ToolStripButton4_Click(object sender, EventArgs e)//SİL BUTONUNA BASILDIĞINDA
        {
            string message = "Kaydı Silmek İstiyor Musunuz?";
            string title = "Sil";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;

            DialogResult result = MessageBox.Show(message, title, buttons, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
            if (result == DialogResult.Yes)
            {
                baglan.Open();
                SqlCommand komut = new SqlCommand("Delete From T_FIRMA Where FIRMA_AD='" + dataGridView1.CurrentRow.Cells["FIRMA_AD"].Value.ToString() + "'", baglan);
                komut.ExecuteNonQuery();
                baglan.Close();
                daset.Tables["T_FIRMA"].Clear();
                KayitGoster();
                MessageBox.Show("Firma Kaydı Silindi.");
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
        private void Ttxtara_TextChanged(object sender, EventArgs e)//ARA YAPILDIĞINDA
        {
            if (tcmbara.Text == "Firma Adı")
            {
                DataTable tablo = new DataTable();
                baglan.Open();
                SqlDataAdapter adtr = new SqlDataAdapter("Select F.FIRMA_ID, F.FIRMA_AD, I.IL_AD AS IL, F.ADRES, F.TEL, F.VDAIRE, F.HESAP_NO  From " +
                "T_FIRMA AS F , T_IL AS I " +
                "WHERE I.IL_ID=F.IL_ID AND  F.FIRMA_AD Like'%" + ttxtara.Text + "%'", baglan);
                adtr.Fill(tablo);
                dataGridView1.DataSource = tablo;
                baglan.Close();

            }
            if (tcmbara.Text == "Telefon")
            {
                DataTable tablo = new DataTable();
                baglan.Open();
                SqlDataAdapter adtr = new SqlDataAdapter("Select F.FIRMA_ID, F.FIRMA_AD, I.IL_AD AS IL, F.ADRES, F.TEL, F.VDAIRE, F.HESAP_NO  From " +
                "T_FIRMA AS F , T_IL AS I " +
                "WHERE I.IL_ID=F.IL_ID AND  F.TEL Like'%" + ttxtara.Text + "%'", baglan);

                adtr.Fill(tablo);

                dataGridView1.DataSource = tablo;

                baglan.Close();
            }
        }
        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)//GÜNCELLEME
        {
            firmaID = dataGridView1.CurrentRow.Cells["FIRMA_ID"].Value.ToString();
            if (firmaID != "")
            {

                baglan.Open();
                SqlCommand komut = new SqlCommand("Select * From T_FIRMA where FIRMA_ID='" + firmaID + "'", baglan);
                SqlDataReader data;
                data = komut.ExecuteReader();
                while (data.Read())
                {
                    txtad.Text = data[1].ToString();
                    cmbil.SelectedValue = data[2].ToString();
                    txtadres.Text = data[3].ToString();
                    mtxttel.Text = data[4].ToString();
                    txtvergi.Text = data[5].ToString();
                    txthesap.Text = data[6].ToString();

                }
                baglan.Close();
            }

        }
        private void Button2_Click(object sender, EventArgs e)
        {
            daset.Clear();
            panel3.Visible = false;
        }
        private void LinkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)//ÜST LINK
        {
            pnlfirma.Controls.Clear();
            FirmaTanim fe2 = new FirmaTanim();
            fe2.TopLevel = false;
            pnlfirma.Controls.Add(fe2);
            fe2.Show();
            fe2.Dock = DockStyle.Fill;
            fe2.BringToFront();
        }
        private void LinkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)//ÜST LINK
        {
            pnlfirma.Controls.Clear();
            Formlar.Islemler fe2 = new Formlar.Islemler();
            fe2.TopLevel = false;
            pnlfirma.Controls.Add(fe2);
            fe2.Show();
            fe2.Dock = DockStyle.Fill;
            fe2.BringToFront();
        }
    }
}

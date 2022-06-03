using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DepoStokOtomasyon.Formlar
{
    public partial class Rapor : Form
    {
        public Rapor()
        {
            InitializeComponent();
        }
        public string adres;
        private void Rapor_Load(object sender, EventArgs e)
        {

            //PDF AÇMA
            OpenFileDialog pdfac = new OpenFileDialog();

            pdfac.Title = "Pdf Aç";
            pdfac.Filter = "Pdf Dosyaları(*.Pdf)| *.Pdf";

            pdfac.FileName = adres;
            axAcroPDF1.LoadFile(pdfac.FileName);


        }
    }
}

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

namespace DepoStokOtomasyon.Formlar
{
    public partial class Islemler : Form
    {
        SqlConnection baglan = new SqlConnection(ConfigurationManager.ConnectionStrings["Baglanti"].ToString());
        DataTable tablo = new DataTable();
        DateTime tarih = DateTime.Today;
        DateTime zaman = DateTime.Now;
        SqlCommand komut, komut2, komut3;
        SqlDataReader data_depo, data_hesap, data_hesapc, data_hesapt, data_stokg, data_stokc, data_firma, data_firmat, data, data3;
        int sonuc_depo, sonuc_hesapgiris, sonuc_hesapcikis, sonuc_hesaptransfer, sonuc_stokgiris, sonuc_stokcikis, ay, stokmax, stokmin, sonuc_firmao, sonuc_firmat;
        decimal total, total2;
        string stokmax2, stokmin2;
        decimal[] toplamgider = new decimal[12];
        decimal[] toplamgelir = new decimal[12];
        SeriesCollection seri = new SeriesCollection();
        public Islemler()
        {
            InitializeComponent();
        }
        private void Islemler_Load_1(object sender, EventArgs e)
        {
            Islem();
            livechart1.AxisX.Add(new LiveCharts.Wpf.Axis
            {
                Title = "Aylar",
                Labels = new[] { "Ocak", "Şubat", "Mart", "Nisan", "Mayıs", "Haziran", "Temmuz", "Ağustos", "Eylül", "Ekim", "Kasım", "Aralık" }
            });
            livechart1.AxisY.Add(new LiveCharts.Wpf.Axis
            {
                Title = "Tutar(TL)",
                LabelFormatter = value => value.ToString("C")

            });
            livechart1.LegendLocation = LiveCharts.LegendLocation.Right;
            livechart1.Series.Clear();

            Gelir();
            Gider();
            KarZarar();
            EnCok();


        }
        private void Gider()//GELİR-GİDER GRAFİĞİ HESAPLARI
        {

            baglan.Open();
            komut2 = new SqlCommand("SELECT * FROM T_GIDER;", baglan);

            SqlDataReader data2 = komut2.ExecuteReader();

            while (data2.Read())
            {

                ay = Convert.ToInt32(data2[1]);
                for (int i = 0; i < 12; i++)
                {
                    if (i + 1 == ay)
                    {
                        toplamgider[i] += Convert.ToInt32(data2[2]);
                        total += toplamgider[i];
                    }
                }


            }


            seri.Add(new LineSeries() { Title = "Gider", Values = new ChartValues<decimal>(toplamgider) });
            LiveCharts.Wpf.Charts.Base.Chart.Colors = new List<System.Windows.Media.Color>
            {
                System.Windows.Media.Colors.DarkSlateBlue,
                 System.Windows.Media.Colors.MediumPurple,
            };
            livechart1.Series = seri;
            baglan.Close();




        }
        private void Gelir()//GELİR-GİDER GRAFİĞİ HESAPLARI
        {

            baglan.Open();
            komut3 = new SqlCommand("SELECT * FROM T_GELIR;", baglan);

            data3 = komut3.ExecuteReader();

            while (data3.Read())
            {

                ay = Convert.ToInt32(data3[1]);
                for (int i = 0; i < 12; i++)
                {
                    if (i + 1 == ay)
                    {
                        toplamgelir[i] += Convert.ToInt32(data3[2]);
                        total2 += toplamgelir[i];
                        total += toplamgelir[i];
                    }
                }


            }

            seri.Add(new LineSeries() { Title = "Gelir", Values = new ChartValues<decimal>(toplamgelir) });

            livechart1.Series = seri;
            baglan.Close();




        }
        private void KarZarar()//KAR-ZARAR GRAFİĞİ HESAPLARI
        {

            Func<ChartPoint, string> labelPoint = ChartPoint => string.Format("{0}({1:P})", ChartPoint.Y, ChartPoint.Participation);
            SeriesCollection piedata = new SeriesCollection
            {  new PieSeries{

                    Title="Kar(TL)",
                    Values=new ChartValues<decimal>{total2},
                    DataLabels=true,
                    LabelPoint=labelPoint,
                    Fill=System.Windows.Media.Brushes.DarkSlateBlue

                },
                 new PieSeries{
                    Title="Toplam Gelir-Gider(TL)",
                    Values=new ChartValues<decimal>{total},

                    DataLabels=true,
                    LabelPoint=labelPoint,
                    Fill=System.Windows.Media.Brushes.MediumPurple
                },

            };
            pieChart1.Series = piedata;
            pieChart1.LegendLocation = LegendLocation.Bottom;

        }
        private void Islem()//İŞLEMLER KISMI 
        {
            zaman = Convert.ToDateTime(zaman.ToShortTimeString());
            tablo.Columns.Add("İşlemler", typeof(string));
            tablo.Columns.Add("  ", typeof(string));
            baglan.Open();
            SqlCommand hesap_kmt = new SqlCommand("SELECT H.HESAP_AD AS [Hesap Adı],G.TUTAR  as Tutar,G.TARIH as Tarih FROM T_HESAP H, T_HESAPGIRIS G WHERE H.HESAP_ID = G.HESAP_ID", baglan);
            data_hesap = hesap_kmt.ExecuteReader();
            while (data_hesap.Read())
            {

                DateTime hesapgiris_tarih = Convert.ToDateTime(data_hesap[2].ToString());
                sonuc_hesapgiris = DateTime.Compare(Convert.ToDateTime(hesapgiris_tarih.ToShortDateString()), Convert.ToDateTime(tarih.ToShortDateString()));
                if (sonuc_hesapgiris == 0)
                {

                    TimeSpan fark_hesapgiris = zaman.Subtract(hesapgiris_tarih);

                    int saat_hg = Convert.ToInt32(fark_hesapgiris.TotalMinutes / 60);
                    int dakika_hg = Convert.ToInt32(fark_hesapgiris.TotalMinutes % 60);
                    if (saat_hg == 0)
                    {
                        tablo.Rows.Add(data_hesap[0] + " Hesabına " + data_hesap[1] + " TL giriş yapıldı. ", dakika_hg + "  dakika önce");

                    }
                    else if (dakika_hg == 0)
                    {
                        tablo.Rows.Add("Şimdi");
                    }
                    else
                    {
                        tablo.Rows.Add(data_hesap[0] + " Hesabına " + data_hesap[1] + " TL giriş yapıldı. ", saat_hg + " saat " + dakika_hg + "  dakika önce");

                    }
                    islemlerdatagrid.DataSource = tablo;


                }
            }
            baglan.Close();
            //<-----------------------------------------Hesap Girişleri------------------------------------------------->


            baglan.Open();
            SqlCommand depo_kmt = new SqlCommand("SELECT P.DEPO_AD as [Çıkış Depo],P2.DEPO_AD as [Giris Depo],T.TRANSFER_TARIH as [Transfer Tarih] FROM  T_TRANSFER T, T_DEPO P, T_DEPO P2 WHERE  T.CIKIS_DEPO_ID = P.DEPO_ID AND T.GIRIS_DEPO_ID = P2.DEPO_ID", baglan);

            data_depo = depo_kmt.ExecuteReader();

            while (data_depo.Read())
            {
                DateTime transfer_tarih = Convert.ToDateTime(data_depo[2].ToString());

                sonuc_depo = DateTime.Compare(Convert.ToDateTime(transfer_tarih.ToShortDateString()), Convert.ToDateTime(tarih.ToShortDateString()));
                if (sonuc_depo == 0)
                {
                    TimeSpan fark_depo = zaman.Subtract(transfer_tarih);

                    int saat = Convert.ToInt32(fark_depo.TotalMinutes / 60);
                    int dakika = Convert.ToInt32(fark_depo.TotalMinutes % 60);
                    if (saat == 0)
                    {
                        tablo.Rows.Add("Depo " + data_depo[0] + " den " + data_depo[1] + "'e DepoTransferi Yapıldı. ", dakika + "  dakika önce");


                    }
                    else if (dakika == 0)
                    {
                        tablo.Rows.Add("Şimdi");
                    }
                    else
                    {
                        tablo.Rows.Add("Depo " + data_depo[0] + " den " + data_depo[1] + "'e DepoTransferi Yapıldı. ", saat + " saat " + dakika + "  dakika önce");

                    }

                    islemlerdatagrid.DataSource = tablo;
                }
            }
            baglan.Close();
            //<------------------------------------Depo Transferleri-------------------------------------------------->

            baglan.Open();
            SqlCommand hesap_cikis = new SqlCommand("SELECT H.HESAP_AD AS [Hesap Adı],C.TUTAR  as Tutar,C.TARIH  as Tarih  FROM T_HESAP H, T_HESAPCIKIS C WHERE H.HESAP_ID = C.HESAP_ID  ORDER BY H.HESAP_AD", baglan);

            data_hesapc = hesap_cikis.ExecuteReader();

            while (data_hesapc.Read())
            {
                DateTime hesapc_tarih = Convert.ToDateTime(data_hesapc[2].ToString());

                sonuc_hesapcikis = DateTime.Compare(Convert.ToDateTime(hesapc_tarih.ToShortDateString()), Convert.ToDateTime(tarih.ToShortDateString()));
                if (sonuc_hesapcikis == 0)
                {
                    TimeSpan fark_hesapc = zaman.Subtract(hesapc_tarih);

                    int saat_hc = Convert.ToInt32(fark_hesapc.TotalMinutes / 60);
                    int dakika_hc = Convert.ToInt32(fark_hesapc.TotalMinutes % 60);
                    if (saat_hc == 0)
                    {
                        tablo.Rows.Add(data_hesapc[0] + " Hesabından " + data_hesapc[1] + " TL çıkış yapıldı. ", dakika_hc + "  dakika önce");


                    }
                    else if (dakika_hc == 0)
                    {
                        tablo.Rows.Add("Şimdi");
                    }
                    else
                    {
                        tablo.Rows.Add(data_hesapc[0] + " Hesabından " + data_hesapc[1] + " TL çıkış yapıldı. ", saat_hc + " saat " + dakika_hc + "  dakika önce");

                    }

                    islemlerdatagrid.DataSource = tablo;
                }
            }
            baglan.Close();
            //<------------------------------------Hesap Çıkış-------------------------------------------------->
            baglan.Open();
            SqlCommand firmaodeme = new SqlCommand("SELECT H.HESAP_AD AS [Hesap Adı],F1.FIRMA_AD,F.TUTAR  as Tutar,F.TARIH  as Tarih FROM T_HESAP H, T_FIRMAODEME F, T_FIRMA F1 WHERE F.HESAP_ID = F.HESAP_ID AND F.FIRMA_ID = F1.FIRMA_ID ORDER BY H.HESAP_AD", baglan);

            data_firma = firmaodeme.ExecuteReader();

            while (data_firma.Read())
            {
                DateTime firma_tarih = Convert.ToDateTime(data_firma[3].ToString());

                sonuc_firmao = DateTime.Compare(Convert.ToDateTime(firma_tarih.ToShortDateString()), Convert.ToDateTime(tarih.ToShortDateString()));
                if (sonuc_firmao == 0)
                {
                    TimeSpan fark_firmao = zaman.Subtract(firma_tarih);

                    int saat_fo = Convert.ToInt32(fark_firmao.TotalMinutes / 60);
                    int dakika_fo = Convert.ToInt32(fark_firmao.TotalMinutes % 60);
                    if (saat_fo == 0)
                    {
                        tablo.Rows.Add(data_firma[0] + " Hesabından " + data_firma[1] + " Firmasına " + data_firma[2] + "TL ödeme yapıldı.", dakika_fo + "  dakika önce");


                    }
                    else if (saat_fo == 0)
                    {
                        tablo.Rows.Add("Şimdi");
                    }
                    else
                    {
                        tablo.Rows.Add(data_firma[0] + " Hesabından " + data_firma[1] + " Firmasına " + data_firma[2] + "TL ödeme yapıldı.", saat_fo + " saat " + dakika_fo + "  dakika önce");

                    }

                    islemlerdatagrid.DataSource = tablo;
                }
            }
            baglan.Close();
            //<------------------------------------Firma Ödeme-------------------------------------------------->
            baglan.Open();
            SqlCommand firmatah = new SqlCommand("SELECT H.HESAP_AD AS [Hesap Adı],F1.FIRMA_AD,F.TUTAR  as Tutar,F.TARIH  as Tarih FROM T_HESAP H, T_FIRMATAHSILAT F, T_FIRMA F1 WHERE F.HESAP_ID = F.HESAP_ID AND F.FIRMA_ID = F1.FIRMA_ID ORDER BY H.HESAP_AD", baglan);

            data_firmat = firmaodeme.ExecuteReader();

            while (data_firmat.Read())
            {
                DateTime firmat_tarih = Convert.ToDateTime(data_firmat[3].ToString());

                sonuc_firmat = DateTime.Compare(Convert.ToDateTime(firmat_tarih.ToShortDateString()), Convert.ToDateTime(tarih.ToShortDateString()));
                if (sonuc_firmat == 0)
                {
                    TimeSpan fark_firmao = zaman.Subtract(firmat_tarih);

                    int saat_ft = Convert.ToInt32(fark_firmao.TotalMinutes / 60);
                    int dakika_ft = Convert.ToInt32(fark_firmao.TotalMinutes % 60);
                    if (saat_ft == 0)
                    {
                        tablo.Rows.Add(data_firmat[0] + " Hesabından " + data_firmat[1] + " Firmasından " + data_firmat[2] + "TL ödeme yapıldı.", dakika_ft + "  dakika önce");


                    }
                    else if (saat_ft == 0)
                    {
                        tablo.Rows.Add("Şimdi");
                    }
                    else
                    {
                        tablo.Rows.Add(data_firmat[0] + " Hesabından " + data_firmat[1] + " Firmasından " + data_firmat[2] + "TL ödeme yapıldı.", saat_ft + " saat " + dakika_ft + "  dakika önce");

                    }

                    islemlerdatagrid.DataSource = tablo;
                }
            }
            baglan.Close();
            //<------------------------------------Firmadan Tahsilat-------------------------------------------------->

            baglan.Open();
            SqlCommand hesap_transfer = new SqlCommand("SELECT H.HESAP_AD AS [Transfer Edilen],X.HESAP_AD AS [Transfer],T.TUTAR as Tutar,T.TARIH as Tarih  FROM T_HESAP H, T_HESAP X, T_HESAPTRANSFER T WHERE H.HESAP_ID = T.GIDEN_HESAP_ID  AND X.HESAP_ID = T.GELEN_HESAP_ID ;", baglan);

            data_hesapt = hesap_transfer.ExecuteReader();

            while (data_hesapt.Read())
            {
                DateTime hesapt_tarih = Convert.ToDateTime(data_hesapt[3].ToString());

                sonuc_hesaptransfer = DateTime.Compare(Convert.ToDateTime(hesapt_tarih.ToShortDateString()), Convert.ToDateTime(tarih.ToShortDateString()));
                if (sonuc_hesaptransfer == 0)
                {
                    TimeSpan fark_hesapt = zaman.Subtract(hesapt_tarih);

                    int saat_ht = Convert.ToInt32(fark_hesapt.TotalMinutes / 60);
                    int dakika_ht = Convert.ToInt32(fark_hesapt.TotalMinutes % 60);
                    if (saat_ht == 0)
                    {
                        tablo.Rows.Add(data_hesapt[0] + " Hesabından " + data_hesapt[1] + " Hesabına" + data_hesapt[2] + " TL transfer yapıldı. ", dakika_ht + "  dakika önce");


                    }
                    else if (dakika_ht == 0)
                    {
                        tablo.Rows.Add("Şimdi");
                    }
                    else
                    {
                        tablo.Rows.Add(data_hesapt[0] + " Hesabından " + data_hesapt[1] + " Hesabına" + data_hesapt[2] + " TL transfer yapıldı. ", saat_ht + " saat " + dakika_ht + "  dakika önce");

                    }

                    islemlerdatagrid.DataSource = tablo;
                }
            }
            baglan.Close();
            //<------------------------------------Hesap Transfer-------------------------------------------------->
            baglan.Open();
            SqlCommand stok_giris = new SqlCommand("SELECT F.FIRMA_AD,D.DEPO_AD,G.TARIH FROM T_STOKGIRIS G,T_FIRMA F,T_DEPO D WHERE D.DEPO_ID=G.DEPO_ID AND G.FIRMA_ID=F.FIRMA_ID  ;", baglan);

            data_stokg = stok_giris.ExecuteReader();

            while (data_stokg.Read())
            {
                DateTime stokg_tarih = Convert.ToDateTime(data_stokg[2].ToString());

                sonuc_stokgiris = DateTime.Compare(Convert.ToDateTime(stokg_tarih.ToShortDateString()), Convert.ToDateTime(tarih.ToShortDateString()));
                if (sonuc_stokgiris == 0)
                {
                    TimeSpan fark_stokg = zaman.Subtract(stokg_tarih);

                    int saat_sg = Convert.ToInt32(fark_stokg.TotalMinutes / 60);
                    int dakika_sg = Convert.ToInt32(fark_stokg.TotalMinutes % 60);
                    if (saat_sg == 0)
                    {
                        tablo.Rows.Add(data_stokg[0] + " Firmadan " + data_stokg[1] + " Depoya Stok Girişi Yapıldı. ", dakika_sg + "  dakika önce");


                    }
                    else if (dakika_sg == 0)
                    {
                        tablo.Rows.Add("Şimdi");
                    }
                    else
                    {
                        tablo.Rows.Add(data_stokg[0] + " Firmadan " + data_stokg[1] + " Depoya Stok Girişi Yapıldı. ", saat_sg + " saat " + dakika_sg + "  dakika önce");

                    }

                    islemlerdatagrid.DataSource = tablo;
                }
            }
            baglan.Close();
            //<------------------------------------Stok Giriş-------------------------------------------------->

            baglan.Open();
            SqlCommand stok_cikis = new SqlCommand("SELECT F.FIRMA_AD,D.DEPO_AD,G.TARIH FROM T_STOKCIKIS G,T_FIRMA F,T_DEPO D WHERE D.DEPO_ID=G.DEPO_ID AND G.FIRMA_ID=F.FIRMA_ID  ;", baglan);

            data_stokc = stok_cikis.ExecuteReader();

            while (data_stokc.Read())
            {
                DateTime stokc_tarih = Convert.ToDateTime(data_stokc[2].ToString());

                sonuc_stokcikis = DateTime.Compare(Convert.ToDateTime(stokc_tarih.ToShortDateString()), Convert.ToDateTime(tarih.ToShortDateString()));
                if (sonuc_stokcikis == 0)
                {
                    TimeSpan fark_stokc = zaman.Subtract(stokc_tarih);

                    int saat_sc = Convert.ToInt32(fark_stokc.TotalMinutes / 60);
                    int dakika_sc = Convert.ToInt32(fark_stokc.TotalMinutes % 60);
                    if (saat_sc == 0)
                    {
                        tablo.Rows.Add(data_stokc[0] + " Firmadan " + data_stokc[1] + " Depoya Stok Çıkışı Yapıldı. ", dakika_sc + "  dakika önce");


                    }
                    else if (dakika_sc == 0)
                    {
                        tablo.Rows.Add("Şimdi");
                    }
                    else
                    {
                        tablo.Rows.Add(data_stokc[0] + " Firmadan " + data_stokc[1] + " Depoya Stok Çıkışı Yapıldı. ", saat_sc + " saat " + dakika_sc + "  dakika önce");

                    }

                    islemlerdatagrid.DataSource = tablo;
                }
            }
            baglan.Close();

            //<------------------------------------Stok Çıkış-------------------------------------------------->

            try
            {


                islemlerdatagrid.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                islemlerdatagrid.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                islemlerdatagrid.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                islemlerdatagrid.Columns[1].SortMode = DataGridViewColumnSortMode.Programmatic;
            }
            catch (Exception)
            {


            }


        }
        private void EnCok()//STOK DURUMU GRAFİĞİ
        {
            baglan.Open();
            komut = new SqlCommand("SELECT  TOP 1 SUM(M.KALAN_MIKTAR),S.STOK_AD FROM  T_MIKTAR  M,T_STOK S WHERE S.STOK_ID=M.STOK_ID  GROUP BY S.STOK_AD ORDER BY SUM(M.KALAN_MIKTAR) DESC", baglan);
            data = komut.ExecuteReader();
            if (data.Read())
            {

                stokmax = Convert.ToInt32(data[0]);
                stokmax2 = data[1].ToString();


            }
            baglan.Close();
            baglan.Open();
            komut = new SqlCommand("SELECT TOP 1 SUM(M.KALAN_MIKTAR),S.STOK_AD FROM  T_MIKTAR  M,T_STOK S WHERE S.STOK_ID=M.STOK_ID  GROUP BY S.STOK_AD ORDER BY SUM(M.KALAN_MIKTAR) ", baglan);
            data = komut.ExecuteReader();
            if (data.Read())
            {

                stokmin = Convert.ToInt32(data[0]);
                stokmin2 = data[1].ToString();


            }
            baglan.Close();

            Func<ChartPoint, string> labelPoint2 = ChartPoint => string.Format("{0}({1:P})", ChartPoint.Y, ChartPoint.Participation);
            SeriesCollection piedata2 = new SeriesCollection {
                new PieSeries
                {

                    Title = stokmax2,
                    Values = new ChartValues<decimal> { stokmax},
                    DataLabels = true,
                    LabelPoint = labelPoint2,
                    Fill = System.Windows.Media.Brushes.DarkSlateBlue

                },
                  new PieSeries
                {

                    Title = stokmin2,
                    Values = new ChartValues<decimal> { stokmin},
                    DataLabels = true,
                    LabelPoint = labelPoint2,
                    Fill = System.Windows.Media.Brushes.MediumPurple

                },
             };


            pastagrafik.Series = piedata2;
            pastagrafik.LegendLocation = LegendLocation.Bottom;

        }
    }
}

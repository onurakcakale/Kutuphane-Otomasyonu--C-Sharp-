using KutuphaneOtomasyonuKatmanli;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZedGraph;

namespace KutuphaneOtomasyonu
{
    public partial class Grafik : Form
    {
        public Grafik()
        {
            InitializeComponent();
        }

        private void zedGraphControl1_Load(object sender, EventArgs e)
        {

        }

        public void DrawSineCurve()
        {
            PointPairList _pointPairList = new PointPairList();

            int x = 0;
            int x2 = 4;
            int y1 = OduncVerilmemisKitaplar();//DATABASE'DEN OKUNAN VERİLER.
            int y2 = OduncVerilenKitaplar();//DATABASE'DEN OKUNAN VERİLER.

            PointPair _pointPair = new PointPair(x, y1);//DATABASE'DEN OKUNAN VERİLER EŞLEŞTİRİLDİ.
            PointPair _pointPair2 = new PointPair(x2, y2);//DATABASE'DEN OKUNAN VERİLER EŞLEŞTİRİLDİ.

            _pointPairList.Add(_pointPair);//ÇİZİM İŞLEMLERİ.
            _pointPairList.Add(_pointPair2);

            LineItem _lineitem = zedGraphControl1.GraphPane.AddCurve("Kitap Sayısı", _pointPairList, Color.Black, SymbolType.Circle);//GRAFİK ÇİZGİSİ TİPİ AYARLANDI.

            zedGraphControl1.AxisChange();
        }

        private void Grafik_Load(object sender, EventArgs e)
        {
            DrawSineCurve();
            zedGraphControl1.GraphPane.XAxis.Title.Text = "Kütüphanede Bulunan Kitaplar: ";//X EKSENİ BAŞLIĞI.
            zedGraphControl1.GraphPane.YAxis.Title.Text = "Kitap Adeti";//Y EKSENİ BAŞLIĞI.
            zedGraphControl1.GraphPane.Legend.Position = LegendPos.Left;
            zedGraphControl1.GraphPane.Legend.FontSpec.Size = 11;
            zedGraphControl1.GraphPane.Title.Text = "Grafik";
            zedGraphControl1.ForeColor = Color.Black;
            zedGraphControl1.Font = new System.Drawing.Font("Segoe UI", 16, FontStyle.Bold);//YAZI TİPİ.
            zedGraphControl1.GraphPane.YAxis.Scale.Max = 8;
            zedGraphControl1.GraphPane.YAxis.Scale.Min = 0;
            zedGraphControl1.GraphPane.XAxis.Scale.Max = 2.5;
            zedGraphControl1.GraphPane.XAxis.Scale.Min = 0;
            string[] labels = new string[2];
            labels[0] = "Verilmemiş Kitaplar";
            labels[1] = "Verilmiş Kitaplar";
            zedGraphControl1.GraphPane.XAxis.Type = AxisType.Text;
            zedGraphControl1.GraphPane.XAxis.Scale.TextLabels = labels;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            YoneticiPaneli menu = new YoneticiPaneli();
            menu.Show();
            this.Hide();
        }

        int Oduncverilenler;
        public int OduncVerilenKitaplar()//DATABASE BAĞLANTISI.
        {
            OleDbConnection baglanti = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=|DataDirectory|\KutuphaneDatabase.mdb");
            baglanti.Open();
            OleDbCommand komut = new OleDbCommand("select * from Kitapİslemleri where statu = " + false + "", baglanti);
            komut.ExecuteNonQuery();
            object sayi1 = komut.ExecuteScalar();
            if (sayi1 != null)
            {
                Oduncverilenler = Convert.ToInt32(sayi1);
            }

            baglanti.Close();
            baglanti.Dispose();
            return Oduncverilenler;
        }

        int Oduncverilmeyenler;
        public int OduncVerilmemisKitaplar()//DATABASE BAĞLANTISI.
        {
            OleDbConnection baglanti = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=|DataDirectory|\KutuphaneDatabase.mdb");
            baglanti.Open();
            OleDbCommand komut = new OleDbCommand("select * from Kitapİslemleri where statu = " + true + "", baglanti);
            komut.ExecuteNonQuery();
            object sayi1 = komut.ExecuteScalar();
            if (sayi1 != null)// sayı1 boş değilse
            {
                Oduncverilmeyenler = Convert.ToInt32(sayi1);
            }

            baglanti.Close();
            baglanti.Dispose();
            return Oduncverilmeyenler;
        }
    }
}
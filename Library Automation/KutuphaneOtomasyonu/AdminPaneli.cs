using KutuphaneOtomasyonu;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KutuphaneOtomasyonuKatmanli
{
    public partial class YoneticiPaneli : Form
    {
        public YoneticiPaneli()
        {
            InitializeComponent();
        }

        //KİTAP İŞLEMLERİ MODÜLÜ.
        private void button1_Click(object sender, EventArgs e)
        {
            KitapIslemleri kitapislem = new KitapIslemleri();
            kitapislem.Show();
            this.Hide();
        }

        //ÖĞRENCİ İŞLEMLERİ MODULÜ.
        private void button2_Click(object sender, EventArgs e)
        {
            OgrenciIslemleri ogrenciislem = new OgrenciIslemleri();
            ogrenciislem.Show();
            this.Hide();
        }

        //ÖDÜNÇ İŞLEMLERİ MODULÜ.
        private void button3_Click(object sender, EventArgs e)
        {
            OduncIslemleri oduncverme = new OduncIslemleri();
            oduncverme.Show();
            this.Hide();
        }

        //MENNÜYE DÖN.
        private void button4_Click_1(object sender, EventArgs e)
        {
            Menu menu = new Menu();
            menu.Show();
            this.Hide();
        }
        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void menu_Load(object sender, EventArgs e)
        {
            this.MaximumSize = this.Size;
            this.MinimumSize = this.Size;
        }

        private void grafik_Click(object sender, EventArgs e)
        {
            Grafik graphics = new Grafik();
            graphics.Show();
            this.Hide();
        }
    }
}
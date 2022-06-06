using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Veri;
using System.Data.OleDb;
using BL;
using Entity;

namespace KutuphaneOtomasyonuKatmanli
{
    public partial class OgrenciGiris : Form
    {
        public OgrenciGiris()
        {
            InitializeComponent();
        }

        //KAYIT OLMA.
        private void button2_Click(object sender, EventArgs e)
        {
            ogrYöneticigiris giris = new ogrYöneticigiris();
            giris.Show();
            this.Hide();
        }

        //VERİTABANINDAN ÖĞRENCİNİN BİLGİLERİNİ ALMA.
        private void button1_Click(object sender, EventArgs e)
        {  
            int ogrid = 0;
            var adsifre = Listeleme.bogrencilistesi();
            bool giris = false;
            foreach (var ogrenci in adsifre)
            {
                if (txtk.Text==ogrenci.Isim && txts.Text==ogrenci.Sifre)
                {
                    ogrid = ogrenci.Ogrenciid;
                    OgrenciPaneli ogrencipanel = new OgrenciPaneli(ogrid);
                    ogrencipanel.Show();
                    this.Hide();
                    giris = true;
                    break;
                }
            }
            if (giris==false)
            {
                MessageBox.Show("Kullanıcı Adı Veya Şifre Yanlış");
            }  
        }

        private void öğrenciGiris_Load(object sender, EventArgs e)
        {
            this.MaximumSize = this.Size;
            this.MinimumSize = this.Size;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Menu menu = new Menu();
            menu.Show();
            this.Hide();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Menu menu = new Menu();
            menu.Show();
            this.Hide();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            Menu menu = new Menu();
            menu.Show();
            this.Hide();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void txts_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
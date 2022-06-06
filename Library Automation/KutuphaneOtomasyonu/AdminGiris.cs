using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using Veri;
using Entity;
using BL;

namespace KutuphaneOtomasyonuKatmanli
{
    public partial class YöneticiGiris : Form
    {
        public YöneticiGiris()
        {
            InitializeComponent();
        }

        private void AnaGiris_Load(object sender, EventArgs e)
        {
            this.MaximumSize = this.Size;
            this.MinimumSize = this.Size;
        }

        //GİRİŞ BUTONU.
        private void button1_Click(object sender, EventArgs e)
        {
            string kullaniciadi = txtkullaniciadi.Text;
            string sifre = txtsifre.Text;

            if (kullaniciadi==("admin")&&sifre==("123"))
            {
                YoneticiPaneli yoneticiPaneli = new YoneticiPaneli();
                yoneticiPaneli.Show();
                this.Hide();
            }

            else
            {
                MessageBox.Show("Kullanıcı Adı veya Şifre Yanlış");
                txtkullaniciadi.Clear();
                txtsifre.Clear();
            }
        }

        //MENÜYE DÖNME.
        private void button2_Click(object sender, EventArgs e)
        {
            Menu menu = new Menu();
            menu.Show();
            this.Hide();
        }
    }
}
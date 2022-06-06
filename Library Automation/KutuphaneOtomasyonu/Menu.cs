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
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        //ADMİN GİRİŞ BUTONU.
        private void button1_Click(object sender, EventArgs e)
        {
            YöneticiGiris yöneticiGiris = new YöneticiGiris();
            yöneticiGiris.Show();
            this.Hide();
        }

        //ÖĞRENCİ GİRİŞ BUTONU.
        private void button3_Click(object sender, EventArgs e)
        {
            OgrenciGiris ogrenciGiris = new OgrenciGiris();
            ogrenciGiris.Show();
            this.Hide();
        }

        //ÇIKIŞ BUTONU.
        private void cikis_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();
        }

        private void AnaGiris_Load(object sender, EventArgs e)
        {
            this.MaximumSize = this.Size;
            this.MinimumSize = this.Size;
            
        }

        private void AnaGiris_Load_1(object sender, EventArgs e)
        {
            this.MaximumSize = this.Size;
            this.MinimumSize = this.Size;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
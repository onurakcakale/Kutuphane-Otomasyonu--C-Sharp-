using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entity;
using System.Data.OleDb;
using Veri;
using BL;

namespace KutuphaneOtomasyonuKatmanli
{
    public partial class OduncIslemleri : Form
    {
        public OduncIslemleri()
        {
            InitializeComponent();
        }

        //ÖDÜNÇ VERME İŞLEMİ.
        private void button1_Click(object sender, EventArgs e)
        {
           Veriler nesne = new Veriler();
           nesne.kitapverme(Convert.ToInt32(kidtext.Text), Convert.ToInt32(sidtext.Text), oduncdate.Value, iadedate.Value);
           dataGridView1.DataSource = Listeleme.bodunc();
        }

        //İADE ALMA İŞLEMLERİ.
        private void button2_Click(object sender, EventArgs e)
        {

            Veriler veri = new Veriler();
            veri.kitapiade(Convert.ToInt32(kidtext.Text), Convert.ToInt32(sidtext.Text));
            dataGridView1.DataSource = Listeleme.bodunc();
            dataGridView2.DataSource = Listeleme.bogrencilistesi();
        }

        //KİTAPLARI LİSTELEME.
        private void button3_Click(object sender, EventArgs e)
        {
            List<int> kirmizirenk = new List<int>();
            List<int> sarirenk = new List<int>();
            var kitaplar = Listeleme.bkitaplistesi();
            var odunc = Listeleme.bodunc();

            dataGridView1.DataSource = kitaplar;

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells[5].Value.ToString() == "False")
                {
                    row.DefaultCellStyle.ForeColor = Color.Green;
                }

                foreach (var item in odunc)
                {
                    if (Convert.ToInt32(row.Cells[0].Value) == item.Kitapid)
                    {
                        if (item.Iadetarihi < DateTime.Now)
                        {
                            row.DefaultCellStyle.ForeColor = Color.Red;
                            continue;
                        }

                        if ((item.Iadetarihi - DateTime.Now).Days <= 2)
                        {
                            row.DefaultCellStyle.ForeColor = Color.Yellow;
                            row.DefaultCellStyle.BackColor = Color.Black;
                            continue;
                        }
                    }
                }
            }
        }

        //KİTAP GEÇMİŞİ
        private void button4_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = Listeleme.bkitapgecmisi();
        }

        //ÖĞRENCİ LİSTELEME
        private void button5_Click(object sender, EventArgs e)
        {
            dataGridView2.DataSource = Listeleme.bogrencilistesi();
        }

        //KİTAP LİSTELEME.
        private void button6_Click(object sender, EventArgs e)
        {

            var list = Listeleme.bverilenkitapliste();
            dataGridView1.DataSource = list;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                row.DefaultCellStyle.ForeColor = Color.Green;
            }
        }

        //MENÜYE DÖNME
        private void button7_Click(object sender, EventArgs e)
        {
            YoneticiPaneli yoneticiPaneli = new YoneticiPaneli();
            yoneticiPaneli.Show();
            this.Hide();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void odunc_Load(object sender, EventArgs e)
        {
            this.MaximumSize = this.Size;
            this.MinimumSize = this.Size;
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void iadedate_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void oduncdate_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
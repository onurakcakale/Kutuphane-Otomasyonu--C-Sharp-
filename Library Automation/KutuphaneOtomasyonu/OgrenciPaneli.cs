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
using BL;
using Veri;
using System.Data.OleDb;

namespace KutuphaneOtomasyonuKatmanli
{
    public partial class OgrenciPaneli : Form
    {
        int ogrid;
        public OgrenciPaneli(int sayi)
        {
            InitializeComponent();
            ogrid = sayi;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Listeleme nesne = new Listeleme();
            var odunclist = Listeleme.bodunc();
            List<Odunc> odunc = new List<Odunc>();
            foreach (var item in odunclist)
            {
                if (item.Ogrenciid == ogrid)
                {
                    odunc.Add(item);
                }
            }
            dataGridView1.DataSource = odunc;

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                foreach (var item in odunclist)
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

        private void button2_Click(object sender, EventArgs e)
        {
            Listeleme nesne = new Listeleme();
            var listgecmis = Listeleme.bogrencigecmisi();
            var listKitap = Listeleme.bkitaplistesi();
            List<string> KitapListesi = new List<string>();

            foreach (var item in listgecmis)
            {
                if (item.Ogrenciid == ogrid)
                {

                    foreach (var item1 in listKitap)
                    {

                        if (item1.Kitapid == item.Kitapid)
                        {

                            KitapListesi.Add(item1.Ad);
                         
                        }
                    }

                }
            }

            foreach (var item in KitapListesi)
            {
                Console.WriteLine(item);
            }

            dataGridView1.DataSource = KitapListesi.Select(x => new { Kitaplar = x }).ToList();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var list = Listeleme.bkitaplistesi();
            int sonuc;

            for (int i = 0; i < list.Count; i++)
            {

                if (Int32.TryParse(textBox1.Text, out sonuc))
                {
                    if (list[i].Kitapid == sonuc)
                    {
                        label1.Text = list[i].Ad;
                        label2.Text = list[i].Yazar;
                        label3.Text = list[i].Tur;
                        label4.Text = list[i].Yeri;
                        if (list[i].Statu.ToString().Equals("True"))
                        {
                            label5.Text = "Alındı.";
                        }

                        else
                        {
                            label5.Text = "Rafta";
                        }
                    }
                }
            }         
        }

        private void ogrencisayfa_Load(object sender, EventArgs e)
        {
            this.MaximumSize = this.Size;
            this.MinimumSize = this.Size;
        }

        private void button4_Click(object sender, EventArgs e)
        {
           dataGridView2.DataSource = Listeleme.bkitaplistesi();

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Menu menu = new Menu();
            menu.Show();
            this.Hide();
        }
    }
}
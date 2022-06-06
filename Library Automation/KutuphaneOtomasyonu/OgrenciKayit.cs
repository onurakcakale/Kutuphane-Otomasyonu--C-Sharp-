using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Veri;

namespace KutuphaneOtomasyonuKatmanli
{
    public partial class ogrYöneticigiris : Form
    {
        public ogrYöneticigiris()
        {
            InitializeComponent();
        }

        //VERİTABANINA ÖĞRENCİ KAYDETME.
        private void button1_Click(object sender, EventArgs e)
        {
            Veri.Connection baglanti = new Veri.Connection();
            baglanti.c = new OleDbCommand();
            baglanti.c.Connection = baglanti.connections;
            baglanti.c.CommandText = "insert into ogrenci (isim,tcNo,sifre) values('" + textBox3.Text + "','" + textBox1.Text + "','" + textBox2.Text + "')";
            baglanti.c.ExecuteNonQuery();
            baglanti.c.Clone();
            MessageBox.Show("Kayıt Oluşturuldu");
            OgrenciGiris g3 = new OgrenciGiris();
            g3.Show();
            this.Hide();  
        }

        //MENÜYE DÖNME.
        private void button2_Click(object sender, EventArgs e)
        {
            OgrenciGiris giris = new OgrenciGiris();
            giris.Show();
            this.Hide();
        }

        private void ogrYöneticigiris_Load(object sender, EventArgs e)
        {
            this.MaximumSize = this.Size;
            this.MinimumSize = this.Size;
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
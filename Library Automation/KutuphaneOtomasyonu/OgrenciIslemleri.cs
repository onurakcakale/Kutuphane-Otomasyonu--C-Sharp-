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
using Entity;
using BL;
using Veri;

namespace KutuphaneOtomasyonuKatmanli
{
    public partial class OgrenciIslemleri : Form
    {
        public OgrenciIslemleri()
        {
            InitializeComponent();
        }

        //ÖĞRENCİ EKLE.
        private void btnekle_Click(object sender, EventArgs e)
        {
            Ogrenci ogrenci = new Ogrenci();
            ogrenci.Isim = txtad.Text;
            ogrenci.TcNO = txttc.Text;
            ogrenci.Sifre = txtsfre.Text;
            OgrenciIslem.bogrenciekle(ogrenci);
            MessageBox.Show("Öğrenci Eklendi.");
            txtad.Clear();
            txttc.Clear();
            txtsfre.Clear();
        }

        //ÖĞRENCİ LİSTELE.
        private void Öğrenciİslemleri_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = Listeleme.bogrencilistesi();
            this.MaximumSize = this.Size;
            this.MinimumSize = this.Size;
            txtad.Clear();
            txttc.Clear();
            txtsfre.Clear();
        }

        //ÖĞRENCİ SİLME.
        private void btnsil_Click(object sender, EventArgs e)
        {
            Ogrenci ogrenci = new Ogrenci();
            foreach (DataGridViewRow drow in dataGridView1.SelectedRows)
            {
                ogrenci.Ogrenciid = Convert.ToInt32(drow.Cells[0].Value);
                OgrenciIslem.bogrencisil(ogrenci.Ogrenciid);
            }
            MessageBox.Show("Silme İşlemi Tamamlandı.");
            dataGridView1.DataSource = Listeleme.bogrencilistesi();
        }

        //ÖĞRENCİ GÜNCELLEME
        private void button1_Click(object sender, EventArgs e)
        {
            Ogrenci ogrenci = new Ogrenci();
            foreach (DataGridViewRow drow in dataGridView1.SelectedRows)
            {
                ogrenci.Ogrenciid = Convert.ToInt32(drow.Cells[0].Value);
                ogrenci.Isim = txtad.Text;
                ogrenci.TcNO = txttc.Text;
                ogrenci.Sifre = txtsfre.Text;
                OgrenciIslem.bogrenciguncelle(ogrenci);

            }

            MessageBox.Show("Güncelleme İşlemi Tamamlandı.");
            dataGridView1.DataSource = Listeleme.bogrencilistesi();
        }

        //ÖĞRENCİ ARANA
        private void txtara_TextChanged(object sender, EventArgs e)
        {
            OleDbDataAdapter oda = new OleDbDataAdapter();
            OleDbCommand c = new OleDbCommand();
            Veri.Connection b = new Veri.Connection();
            b.oda = new OleDbDataAdapter("select * from ogrenci where isim like '%" + txtara.Text + "%'", b.connections);
            b.oda.Fill(b.data, "ogrenci");
            dataGridView1.DataSource = b.data.Tables[0];
        }

        //MENÜYE DÖNME
        private void button2_Click(object sender, EventArgs e)
        {
            YoneticiPaneli menu = new YoneticiPaneli();
            menu.Show();
            this.Hide();
        }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            txtad.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txttc.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            txtsfre.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
        }

        private void btnlist_Click(object sender, EventArgs e)
        {
           
            dataGridView1.DataSource = Listeleme.bogrencilistesi();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void txtad_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
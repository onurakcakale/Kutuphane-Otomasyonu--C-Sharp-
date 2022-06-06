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
    public partial class KitapIslemleri : Form
    {
        public KitapIslemleri()
        {
            InitializeComponent();
        }

        private void btnlist_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource=Listeleme.bkitaplistesi();  
        }

        //KİTAP EKLEME
        private void btnekle_Click(object sender, EventArgs e)
        {
            Kitaplar kitap = new Kitaplar();
            kitap.Ad = txtad.Text;
            kitap.Yazar = txtyazar.Text;
            kitap.Tur = txttur.Text;
            kitap.Yeri = txtyer.Text;
            KitapIslem.bkitapekle(kitap);
            MessageBox.Show("Kitap Eklendi.");
            txtad.Clear();
            txtyazar.Clear();
            txttur.Clear();
            txtyer.Clear();
        }

        //KİTAP LİSTELEME
        private void Kitapİslemleri_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = Listeleme.bkitaplistesi();
            this.MaximumSize = this.Size;
            this.MinimumSize = this.Size;
            txtad.Clear();
            txtyazar.Clear();
            txttur.Clear();
            txtyer.Clear();
        }

        //KİTAP SİLME
        private void btnsil_Click(object sender, EventArgs e)
        {
           
            Kitaplar ktp = new Kitaplar();
            foreach (DataGridViewRow drow in dataGridView1.SelectedRows)
            {
                ktp.Kitapid = Convert.ToInt32(drow.Cells[0].Value);
                KitapIslem.bkitapsil(ktp.Kitapid);
            }
            MessageBox.Show("Silme İşlemi Başarılı.");
            dataGridView1.DataSource = Listeleme.bkitaplistesi();
     
        }

        //KİTAP GÜNCELLEME
        private void button1_Click(object sender, EventArgs e)
        {
            Kitaplar ktp = new Kitaplar();
            foreach (DataGridViewRow drow in dataGridView1.SelectedRows)
            {
                ktp.Kitapid = Convert.ToInt32(drow.Cells[0].Value);
                ktp.Ad = txtad.Text;
                ktp.Yazar = txtyazar.Text;
                ktp.Tur = txttur.Text;
                ktp.Yeri = txtyer.Text;
                KitapIslem.bkitapguncelle(ktp);
            }
            MessageBox.Show("Güncelleme İşlemi Başarılı.");
            dataGridView1.DataSource = Listeleme.bkitaplistesi();
        }

        //KİTAP ARAMA
        private void txtara_TextChanged(object sender, EventArgs e)
        {
            OleDbDataAdapter oda = new OleDbDataAdapter();
            OleDbCommand c = new OleDbCommand();
            Veri.Connection b = new Veri.Connection();
            b.oda = new OleDbDataAdapter("select * from Kitapİslemleri where ad like '%" + txtara.Text + "%'", b.connections);
            b.oda.Fill(b.data, "Kitapİslemleri");
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
            txtyazar.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            txttur.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            txtyer.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
          
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {


        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}
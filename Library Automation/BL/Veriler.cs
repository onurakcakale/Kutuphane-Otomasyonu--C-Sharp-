using Entity;
using System;
using System.Collections.Generic;
using System.Data;
using Veri;
using System.Data.OleDb;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BL
{
    public class Veriler
    {
        //ÖDÜNÇ VERME İŞLEMLERİ. 
        public void kitapverme([Optional] int x, [Optional] int y, DateTime dateTimeX, DateTime dateTimeY, [Optional] DateTime dateTimeZ, [Optional] int borc)
        {
            Odunc eo = new Odunc();
            eo.Kitapid = x;
            eo.Ogrenciid = y;
            eo.Emanettarihi = dateTimeX.Date;
            eo.Iadetarihi = dateTimeY.Date;
            eo.Iadeedilentarih = dateTimeZ.Date;
            eo.Borc = borc;
            var ogrencilist = Listeleme.bogrencilistesi();
            var kitaplist = Listeleme.bkitaplistesi();
            bool kitapVerilmis = false;
            bool kitapVar = false;
            bool ogrenciVar = false;
            foreach (var student in ogrencilist)
            {
                if (eo.Ogrenciid == student.Ogrenciid)
                    ogrenciVar = true;
            }

            if (ogrenciVar == false)
            {
                MessageBox.Show("Böyle bir öğrenci yok");
                return;
            }

            foreach (var book in kitaplist)
            {
                if (eo.Kitapid == book.Kitapid && ogrenciVar == true)
                {
                    if (book.Statu == false)
                    {
                        kitapVar = true;
                        OleDbCommand komut1 = new OleDbCommand("insert into odunc (kitapid,ogrenciid,emanettarihi,iadetarihi,iadeedilentarih) values (@p1,@p2,@p3,@p4,@p5)",baglantii.connectionline);
                        if (komut1.Connection.State != ConnectionState.Open)
                        {
                            komut1.Connection.Open();
                        }

                        komut1.Parameters.AddWithValue("@p1", eo.Kitapid);
                        komut1.Parameters.AddWithValue("@p2", eo.Ogrenciid);
                        komut1.Parameters.AddWithValue("@p3", eo.Emanettarihi);
                        komut1.Parameters.AddWithValue("@p4", eo.Iadetarihi);
                        komut1.Parameters.AddWithValue("@p4", eo.Iadeedilentarih);
                        komut1.ExecuteNonQuery();
                        komut1 = new OleDbCommand("update Kitapİslemleri set statu=@p1 where kitapid=@p2", baglantii.connectionline);
                        komut1.Parameters.AddWithValue("@p1" , kitapVar);
                        komut1.Parameters.AddWithValue("@p2", eo.Kitapid);
                        komut1.ExecuteNonQuery();
                        komut1 = new OleDbCommand("insert into kitapgecmisi (kitapid,ogrenciid,emanettarihi,iadeedilentarih) values (@p1,@p2,@p3,@p4)",baglantii.connectionline);
                        komut1.Parameters.AddWithValue("@p1",eo.Kitapid); 
                        komut1.Parameters.AddWithValue("@p2",eo.Ogrenciid);
                        komut1.Parameters.AddWithValue("@p3",eo.Emanettarihi);
                        komut1.Parameters.AddWithValue("@p4",eo.Iadeedilentarih);
                        komut1.ExecuteNonQuery();
                        komut1 = new OleDbCommand("insert into ogrencigecmisi(kitapid,ogrenciid) values (@p1,@p2)",baglantii.connectionline);
                        komut1.Parameters.AddWithValue("@p1",eo.Kitapid);
                        komut1.Parameters.AddWithValue("@p2",eo.Ogrenciid);
                        komut1.ExecuteNonQuery();
                        MessageBox.Show("Kitap ödünç verildi.");
                        kitapVerilmis = true;
                    }    
                }
            }

            if (kitapVerilmis == true)
            {
                MessageBox.Show("Kitap zaten ödünç verilmiş");
            }
            if (kitapVar == false)
            {
                MessageBox.Show("Böyle bir kitap yok");
            }
        }

        //İADE ETME İŞLEMLERİ.
        public void kitapiade(int x, int y)
        {
            Odunc odunc = new Odunc();
            KitapGecmisi kitapgecmisi = new KitapGecmisi();
            Ogrenci ogrenci = new Ogrenci();
            odunc.Ogrenciid = y;
            odunc.Kitapid = x;
            decimal borc = 0;
            var list1 = Listeleme.bodunc();
            for (int i = 0; i < list1.Count; i++)
            {
                if (list1[i].Ogrenciid == odunc.Ogrenciid)
                {
                    borc = Convert.ToDecimal((list1[i].Iadetarihi - list1[i].Emanettarihi).Days);
                    kitapgecmisi.Emanettarihi = list1[i].Emanettarihi;
                    kitapgecmisi.Iadeedilentarih = DateTime.Now;
                }
            }
        
            Connection baglantinesne = new Connection();
            baglantinesne.c = new OleDbCommand();
            baglantinesne.c.Connection = baglantinesne.connections;
            baglantinesne.c.CommandText = "DELETE *from odunc where kitapid =" +odunc.Kitapid + " AND ogrenciid =" + odunc.Ogrenciid + "";
            baglantinesne.c.ExecuteNonQuery();
            baglantinesne.c.CommandText = "update Kitapİslemleri set statu =" + false + " where kitapid =" + odunc.Kitapid + "";
            baglantinesne.c.ExecuteNonQuery();
            baglantinesne.c.CommandText = "update ogrenci set borc =" + borc + " where ogrenciid =" + odunc.Ogrenciid + "";
            baglantinesne.c.ExecuteNonQuery();
            baglantinesne.c.CommandText = "update kitapgecmisi set emanettarihi ='" + odunc.Emanettarihi + "', iadeedilentarih = '" + DateTime.Now + "' where kitapid =" + odunc.Kitapid + " AND ogrenciid = " + odunc.Ogrenciid + "";
            baglantinesne.c.ExecuteNonQuery();
            MessageBox.Show("Kitap iade edildi.");
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Data;
using Entity;

namespace Veri
{
   public class SQLQuery
    {
       public OleDbConnection bgl;

        //KİTAP EKLEME İŞLEMLERİ.
        public static int kitapekle(Kitaplar kitap)
        {
            OleDbCommand baglanti = new OleDbCommand("insert into Kitapİslemleri (ad,yazar,tur,yeri) values (@P1,@P2,@P3,@P4)", baglantii.connectionline);
            if (baglanti.Connection.State != ConnectionState.Open)
            {
                baglanti.Connection.Open();
            }
            baglanti.Parameters.AddWithValue("@p1", kitap.Ad);
            baglanti.Parameters.AddWithValue("@p2", kitap.Yazar);
            baglanti.Parameters.AddWithValue("@p3", kitap.Tur);
            baglanti.Parameters.AddWithValue("@p4", kitap.Yeri);
            return baglanti.ExecuteNonQuery();
        }

        //KİTAP SİLME İŞLEMLERİ.
        public static bool kitapsil(int parame)
        {
            OleDbCommand baglanti = new OleDbCommand("DELETE From Kitapİslemleri WHERE kitapid =@ps1", baglantii.connectionline);
            if (baglanti.Connection.State != ConnectionState.Open)
            {
                baglanti.Connection.Open();
            }
            baglanti.Parameters.AddWithValue("@ps1", parame);
            return baglanti.ExecuteNonQuery() > 0;
        }

        //KİTAP LİSTELEME İŞLEMLERİ.
        public static List<Kitaplar> kitaplistesi()
       {
           List<Kitaplar> veriler = new List<Kitaplar>();
           OleDbCommand komut1 = new OleDbCommand("select * from Kitapİslemleri",baglantii.connectionline);
           if (komut1.Connection.State != ConnectionState.Open)
           {
               komut1.Connection.Open();
           }
           OleDbDataReader odr = komut1.ExecuteReader();
           while (odr.Read())
           {
                 Kitaplar ek = new Kitaplar();
                 ek.Kitapid = int.Parse(odr["kitapid"].ToString());
                 ek.Ad = odr["ad"].ToString();
                 ek.Yazar = odr["yazar"].ToString();
                 ek.Tur = odr["tur"].ToString();
                 ek.Yeri = odr["yeri"].ToString();
                 ek.Statu = Convert.ToBoolean(odr["statu"]);
                veriler.Add(ek);
           }
           odr.Close();
           return veriler;
       }

       //KİTAP GÜNCELLEME İŞLEMLERİ.
       public static bool kitapguncelle(Kitaplar kitap)
       {
           OleDbCommand baglanti = new OleDbCommand("update Kitapİslemleri set ad=@p1,yazar=@p2,tur=@p3,yeri=@p4 where kitapid=@p5", baglantii.connectionline);
           if (baglanti.Connection.State != ConnectionState.Open)
           {
               baglanti.Connection.Open();
           }
           baglanti.Parameters.AddWithValue("@p1", kitap.Ad);
           baglanti.Parameters.AddWithValue("@p2", kitap.Yazar);
           baglanti.Parameters.AddWithValue("@p3", kitap.Tur);
           baglanti.Parameters.AddWithValue("@p4", kitap.Yeri);
           baglanti.Parameters.AddWithValue("@p5", kitap.Kitapid);
           return baglanti.ExecuteNonQuery() > 0;

       }

        //ÖĞRENCİ EKLEME İŞLEMLERİ.
        public static int ogrenciekle(Ogrenci ogrenci)
        {
            OleDbCommand baglanti = new OleDbCommand("insert into ogrenci (isim,tcNo,sifre) values (@P1,@P2,@P3)", baglantii.connectionline);
            if (baglanti.Connection.State != ConnectionState.Open)
            {
                baglanti.Connection.Open();
            }
            baglanti.Parameters.AddWithValue("@p1", ogrenci.Isim);
            baglanti.Parameters.AddWithValue("@p2", ogrenci.TcNO);
            baglanti.Parameters.AddWithValue("@p3", ogrenci.Sifre);
            return baglanti.ExecuteNonQuery();
        }

        //ÖĞRENCİ SİLME İŞLEMLERİ.
        public static bool ogrencisil(int ogrenci)
        {
            OleDbCommand baglanti = new OleDbCommand("DELETE From ogrenci WHERE ogrenciid =@ps1", baglantii.connectionline);
            if (baglanti.Connection.State != ConnectionState.Open)
            {
                baglanti.Connection.Open();
            }
            baglanti.Parameters.AddWithValue("@ps1", ogrenci);
            return baglanti.ExecuteNonQuery() > 0;
        }

        //ÖĞRENCİ LİSTELEME İŞLEMLERİ.
        public static List<Ogrenci> ogrencilistesi()
       {
           List<Ogrenci> degerler = new List<Ogrenci>();
           OleDbCommand k1 = new OleDbCommand("select * from ogrenci", baglantii.connectionline);
           if (k1.Connection.State != ConnectionState.Open)
           {
               k1.Connection.Open();
           }
           OleDbDataReader odr = k1.ExecuteReader();
           while (odr.Read())
           {
               Ogrenci ogrenci= new Ogrenci();
               ogrenci.Ogrenciid = int.Parse(odr["ogrenciid"].ToString());
               ogrenci.Isim = odr["isim"].ToString();
               ogrenci.TcNO = odr["tcNO"].ToString();
               ogrenci.Sifre = odr["sifre"].ToString();
               if (odr["borc"]!=DBNull.Value)
               {
                   ogrenci.Borc = (decimal)odr["borc"];
               }
               degerler.Add(ogrenci);
           }
           odr.Close();
           return degerler;
       }

       //ÖĞRENCİ GÜNCELLEME İŞLEMLERİ.
       public static bool ogrenciguncelle(Ogrenci ogrenci)
       {
           OleDbCommand baglanti = new OleDbCommand("update ogrenci set isim=@p1,tcNo=@p2,sifre=@p3 where ogrenciid=@p4", baglantii.connectionline);
           if (baglanti.Connection.State != ConnectionState.Open)
           {
                baglanti.Connection.Open();
           }
           baglanti.Parameters.AddWithValue("@p1", ogrenci.Isim);
           baglanti.Parameters.AddWithValue("@p2", ogrenci.TcNO);
           baglanti.Parameters.AddWithValue("@p3", ogrenci.Sifre);
           baglanti.Parameters.AddWithValue("@p4", ogrenci.Ogrenciid);
           return baglanti.ExecuteNonQuery() > 0;
       }

       //ÖDÜNÇ VERME VE LİSTELEME İŞLEMLERİ.
       public static List<Odunc> odunclisteleme()
       {
           List<Odunc> degerler = new List<Odunc>();
           OleDbCommand baglanti = new OleDbCommand("select * from odunc", baglantii.connectionline);
           if (baglanti.Connection.State != ConnectionState.Open)
           {
                baglanti.Connection.Open();
           }
           OleDbDataReader read = baglanti.ExecuteReader();
           while (read.Read())
           {
               Odunc odunc = new Odunc();
               odunc.Kitapid = int.Parse(read["kitapid"].ToString());
               odunc.Ogrenciid = int.Parse(read["ogrenciid"].ToString());
               odunc.Emanettarihi = (DateTime)read["emanettarihi"];
               odunc.Iadetarihi = (DateTime)read["iadetarihi"];
               odunc.Iadeedilentarih = (DateTime)read["iadeedilentarih"];
               odunc.Borc=(decimal)read["borc"];
               degerler.Add(odunc);
           }
           read.Close();
           return degerler;
       }

       //KİTAP GEÇMİŞ İŞLEMLERİ LİSTELEME.
       public static List<KitapGecmisi> kitapgecmisilisteleme()
       {
           List<KitapGecmisi> degerler = new List<KitapGecmisi>();
           OleDbCommand baglanti = new OleDbCommand("select * from kitapgecmisi", baglantii.connectionline);
           if (baglanti.Connection.State != ConnectionState.Open)
           {
               baglanti.Connection.Open();
           }
           OleDbDataReader read = baglanti.ExecuteReader();
           while (read.Read())
           {
               KitapGecmisi kgecmis = new KitapGecmisi();
               kgecmis.Kitapid = int.Parse(read["kitapid"].ToString());
               kgecmis.Ogrenciid = int.Parse(read["ogrenciid"].ToString());
               kgecmis.Emanettarihi = (DateTime)read["emanettarihi"];
               kgecmis.Iadeedilentarih = (DateTime)read["iadeedilentarih"];
               degerler.Add(kgecmis);
           }
           read.Close();
           return degerler;
       }

       //ÖĞRENCİ GEÇMİŞ İSLEMLERİ LİSTELEME.
       public static List<OgrenciGecmisi> ogrencigecmisilisteleme()
       {
           List<OgrenciGecmisi> degerler = new List<OgrenciGecmisi>();
           OleDbCommand baglanti = new OleDbCommand("select * from ogrencigecmisi", baglantii.connectionline);
           if (baglanti.Connection.State != ConnectionState.Open)
           {
               baglanti.Connection.Open();
           }
           OleDbDataReader read = baglanti.ExecuteReader();
           while (read.Read())
           {
               OgrenciGecmisi ogecmis = new OgrenciGecmisi();
               ogecmis.Kitapid = int.Parse(read["kitapid"].ToString());
               ogecmis.Ogrenciid = int.Parse(read["ogrenciid"].ToString());
               degerler.Add(ogecmis);
           }
           read.Close();
           return degerler;
       }

       //ÖDÜNÇ VERİLEN KİTAPLARI LİSTELEME.
       public static List<Kitaplar> verilenkitapliste()
       {
           List<Kitaplar> degerler = new List<Kitaplar>();
           OleDbCommand baglanti = new OleDbCommand("select * from Kitapİslemleri where statu = "+false+"", baglantii.connectionline);
           if (baglanti.Connection.State != ConnectionState.Open)
           {
               baglanti.Connection.Open();
           }
           OleDbDataReader read = baglanti.ExecuteReader();
           while (read.Read())
           {
               Kitaplar kitap = new Kitaplar();
               kitap.Kitapid = int.Parse(read["kitapid"].ToString());
               kitap.Ad = read["ad"].ToString();
               kitap.Yazar = read["yazar"].ToString();
               kitap.Tur = read["tur"].ToString();
               kitap.Yeri = read["yeri"].ToString();
               degerler.Add(kitap);
           }
           read.Close();
           return degerler;
       }
   }
}
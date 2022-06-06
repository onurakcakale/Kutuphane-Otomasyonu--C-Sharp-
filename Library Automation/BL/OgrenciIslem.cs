using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.OleDb;
using Veri;
using Entity;
namespace BL
{
    public class OgrenciIslem
    {
        //EKLE.
        public static int bogrenciekle(Ogrenci oekle)
        {
            return SQLQuery.ogrenciekle(oekle);
        }

        //SİL.
        public static bool bogrencisil(int osil)
        {
            return SQLQuery.ogrencisil(osil);
        }

        //GÜNCELLE.
        public static bool bogrenciguncelle(Ogrenci oguncelle)
        {
            return SQLQuery.ogrenciguncelle(oguncelle);
        }
    }
}
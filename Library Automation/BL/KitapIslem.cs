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
    public class KitapIslem
    {
        //EKLE.
        public static int bkitapekle(Kitaplar kekle)
        {       
            return SQLQuery.kitapekle(kekle);       
        }
        
        //SİL.
        public static bool bkitapsil(int ksil)
        {         
            return SQLQuery.kitapsil(ksil);
        }
          
        //GÜNCELLE.
        public static bool bkitapguncelle(Kitaplar kguncelle)
        {
            return SQLQuery.kitapguncelle(kguncelle);
        }
    }
}
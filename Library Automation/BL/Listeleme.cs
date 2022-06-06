using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Runtime.InteropServices;
using Veri;
using Entity;
using System.Data;
namespace BL
{
    //LİSTELE.
    public  class Listeleme
    {
        public static List<Ogrenci> bogrencilistesi()
        {
            return SQLQuery.ogrencilistesi();
        }

        public static List<Kitaplar> bkitaplistesi()
        {
            return SQLQuery.kitaplistesi();
        }

        public static List<Odunc> bodunc()
        {
            return SQLQuery.odunclisteleme();
        }

        public static List<KitapGecmisi> bkitapgecmisi()
        {
            return SQLQuery.kitapgecmisilisteleme();
        }

        public static List<OgrenciGecmisi> bogrencigecmisi()
        {
            return SQLQuery.ogrencigecmisilisteleme();
        }

        public static List<Kitaplar> bverilenkitapliste()
        {
            return SQLQuery.verilenkitapliste();
        }
    }
}
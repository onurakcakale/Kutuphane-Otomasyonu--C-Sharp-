using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.OleDb;
namespace Veri
{
   public  class Connection
   {
        public OleDbConnection connections;
        public OleDbDataAdapter oda;
        public OleDbCommand c;
        public DataSet data;

        //Veritabanı Bağlantısı.
        public Connection()
        {
            connections = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:|DataDirectory|\KutuphaneDatabase.mdb");
            data = new DataSet();
            connections.Open();
        }
   }

    //Ekleme, Listeleme, Güncelleme ve Silme İşlemlerinin Gerçekleştirileceği Bağlantı Yolu.
    public  class baglantii
    {
        public static OleDbConnection connectionline = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=|DataDirectory|\KutuphaneDatabase.mdb");
    }
}
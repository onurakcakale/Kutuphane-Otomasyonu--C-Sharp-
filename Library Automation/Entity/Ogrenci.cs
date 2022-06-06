using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Ogrenci
    {
        private int ogrenciid;
        public int Ogrenciid
        {
            get 
            { 
                return ogrenciid; 
            }

            set
            { 
                ogrenciid = value; 
            }
        }

        private string isim;
        public string Isim
        {
            get
            { 
                return isim;
            }

            set 
            { 
                isim = value;
            }
        }

        private string tcNO;
        public string TcNO
        {
            get 
            {
                return tcNO;
            }

            set 
            {
                tcNO = value;
            }
        }

        private string sifre;
        public string Sifre
        {
            get 
            { 
                return sifre; 
            }

            set 
            {
                sifre = value; 
            }
        }

        private decimal borc;
        public decimal Borc
        {
            get 
            {
                return borc;
            }

            set 
            { 
                borc = value; 
            }
        }
    }
}
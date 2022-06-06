using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
   public class Odunc
    {
        private int kitapid;
        public int Kitapid
        {
            get 
            { 
                return kitapid; 
            }

            set 
            { 
                kitapid = value;
            }
        }

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

        private DateTime emanettarihi;
        public DateTime Emanettarihi
        {
            get 
            { 
                return emanettarihi;
            }

            set
            { 
                emanettarihi = value;
            }
        }

        private DateTime iadetarihi;
        public DateTime Iadetarihi
        {
            get 
            {
                return iadetarihi;
            }

            set 
            { 
                iadetarihi = value;
            }
        }

        private DateTime iadeedilentarih;
        public DateTime Iadeedilentarih
        {
            get 
            {
                return iadeedilentarih; 
            }

            set 
            { 
                iadeedilentarih = value;
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
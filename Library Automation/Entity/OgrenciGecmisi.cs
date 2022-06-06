using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
   public class OgrenciGecmisi
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
    }
}
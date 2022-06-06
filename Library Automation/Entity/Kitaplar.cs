using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Kitaplar
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

        private string ad;
        public string Ad
        {
            get 
            { 
                return ad; 
            }

            set 
            { 
                ad = value;
            }
        }


        private string yazar;
        public string Yazar
        {
            get 
            { 
                return yazar;
            }

            set 
            { 
                yazar = value; 
            }
        }


        private string tur;
        public string Tur
        {
            get 
            { 
                return tur; 
            }

            set
            { 
                tur = value; 
            }
        }


        private string yeri;
        public string Yeri
        {
            get 
            { 
                return yeri; 
            }

            set 
            {
                yeri = value;
            }
        }


        private bool statu;
        public bool Statu
        {
            get 
            { 
                return statu; 
            }

            set 
            { 
                statu = value; 
            }
        }
    }
}
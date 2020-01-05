using System;
using System.Collections.Generic;
using System.Text;

namespace WarriorWars
{
    class Arma
    {

        private const int danio_Alianza = 5;
        private const int danio_Horda = 5;
        private int danio;

        public int Danio 
        {
            get
            {
                return danio;
            }    
        }

        public Arma(Faccion faccion)
        {
            switch (faccion)
            {
                case Faccion.Alianza:
                    danio = danio_Alianza;
                    break;
                case Faccion.Horda:
                    danio = danio_Horda;
                    break;
                default:
                    break;
            }
        }
    }
}

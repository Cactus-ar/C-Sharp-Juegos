using System;
using System.Collections.Generic;
using System.Text;

namespace WarriorWars
{
    class Armadura
    {
        private const int armadura_Alianza = 5;
        private const int armadura_Horda = 5;
        private int puntosArmadura;

        public int PuntosArmadura 
        {
            get
            {
                return puntosArmadura;
            }
        }

        public Armadura(Faccion faccion)
        {
            switch (faccion)
            {
                case Faccion.Alianza:
                    puntosArmadura = armadura_Alianza;
                    break;
                case Faccion.Horda:
                    puntosArmadura = armadura_Horda;
                    break;
                default:
                    break;
            }
        }
    }
}

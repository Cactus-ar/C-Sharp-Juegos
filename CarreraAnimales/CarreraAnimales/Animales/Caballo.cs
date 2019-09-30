using System;
using System.Collections.Generic;
using System.Text;

namespace CarreraAnimales
{
    class Caballo : Corredor
    {
        public Caballo(int posicionActual, int carril, string nombre)
        {
            PosicionActual = posicionActual;
            Carril = carril;
            Nombre = nombre;
            SimboloDelCorredor = "C";
            Descripcion = $"{Nombre} esta Listo!..yyYYYY Arranca!";
            Participantes.Add(this);

        }

        public override void CalcularMovida()
        {
            var movida = TipoDeMovida();

            if (movida >= 1 && movida <= 20) //20% de las movidas
            {
                Moverse(Movida.Dormitar);
                Descripcion = $"{Nombre} se ha movido a {Movida.Dormitar}";
            }
            else if (movida >= 21 && movida <= 40) //otro 20%
            {
                Moverse(Movida.PasoLigero);
                Descripcion = $"{Nombre} se ha movido a {Movida.PasoLigero}";
            }
            else if (movida >= 41 && movida <= 50) //10%
            {
                Moverse(Movida.GranSalto);
                Descripcion = $"{Nombre} se ha movido a {Movida.GranSalto}";
            }
            else if (movida >= 51 && movida <= 80) //otro 30%
            {
                Moverse(Movida.Tropezon);
                Descripcion = $"{Nombre} se ha movido a {Movida.Tropezon}";
            }
            else
            {
                Moverse(Movida.PasoPesado); //20 restante
                Descripcion = $"{Nombre} se ha movido a {Movida.PasoPesado}";
            }
        }
    }
}

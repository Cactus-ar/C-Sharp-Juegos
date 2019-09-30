﻿using System;
using System.Collections.Generic;
using System.Text;

namespace CarreraAnimales
{
    class Perro : Corredor
    {
        public Perro(int posicionActual, int carril, string nombre)
        {
            PosicionActual = posicionActual;
            Carril = carril;
            Nombre = nombre;
            SimboloDelCorredor = "P";
            Descripcion = $"{Nombre} esta Listo!..yyYYYY Arranca!";
            Participantes.Add(this);

        }

        public override void CalcularMovida()
        {
            var movida = TipoDeMovida();

            if (movida >= 1 && movida <= 50) //50% de las movidas
            {
                Moverse(Movida.PasoLigero);
                Descripcion = $"{Nombre} se ha movido a {Movida.PasoLigero}";
            }
            else if (movida >= 51 && movida <= 60)
            {
                Moverse(Movida.Resbalarse);
                Descripcion = $"{Nombre} se ha movido a {Movida.Resbalarse}";
            }
            else
            {
                Moverse(Movida.PasoPesado);
                Descripcion = $"{Nombre} se ha movido a {Movida.PasoPesado}";
            }

        }
    }
}

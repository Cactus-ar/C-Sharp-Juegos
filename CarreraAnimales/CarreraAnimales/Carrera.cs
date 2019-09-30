using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CarreraAnimales
{
    public class Carrera
    {
        private Pista _pista;
        private bool _terminoLaCarrera;

        public Carrera()
        {
            _pista = new Pista();
            new Vaca(0, 0, "Margarita");
            new Caballo(0, 1, "Pincha Rata");
            new Gallina(0, 2, "Turuleca");
            new Mosquito(0, 3, "Palito");
            new Perro(0, 4, "Pepe");
            _terminoLaCarrera = false;

        }


        public void Corriendo()
        {
            InicializarCarrera();

            do
            {
                Console.ReadLine();
                Console.Clear();
                _pista.DibujarLaPista();

                foreach (var corredor in Corredor.Participantes)
                {
                    Console.WriteLine(corredor.Descripcion);
                    corredor.CalcularMovida();
                    _pista.PosicionCorredor(corredor);

                    if (corredor.EsGanador(corredor))
                        _terminoLaCarrera = true;

                }

            } while (!_terminoLaCarrera);
            _pista.DibujarLaPista(); //la carrera termino
            ObtenerPosicion();

        }

        private void InicializarCarrera()
        {
            foreach (var corredor in Corredor.Participantes)
            {
                _pista.PosicionCorredor(corredor);
            }
            Console.WriteLine("Bienvenido a la Carrera de Animales!!..presione una tecla");
        }

        public void ObtenerPosicion()
        {
            foreach (var corredor in Corredor.Participantes.Where(x => x.PosicionActual == Pista.LargoDeLaPista))
            {
                Console.WriteLine($"y el Ganador ess:{corredor.Nombre} !!");
            }
        }
    }
}

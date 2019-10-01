using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SaltoACaballo
{
    public class Caballo
    {
        private Random _rnd = new Random();
        private int _actH;
        private int _actV;
        private Tablero _tablero;
        private bool _recorridoTerminado = false;
        private bool _noMasMovidas = false;
        private static int _mejorPuntaje = 0;
        private static int _contarPasadas = 0;
        private int _contarMovidas;

        public Caballo()
        {
            _tablero = new Tablero();
        }

        public void Mover()
        {
            while (!_recorridoTerminado)
            {
                _actH = _rnd.Next(Tablero.tamanio);
                _actV = _rnd.Next(Tablero.tamanio);
                _contarMovidas = 1;
                _tablero.PoblarArray(_actH, _actV);
                _noMasMovidas = false;

                do
                {
                    if (!Moviendo())
                        ObtenerResultados();
                } while (!_noMasMovidas);

            }
        }

        public bool Moviendo()
        {
            /* Hay que ir contando las movidas que hace el caballo
             * para no entrar en un loop infinito
             * por eso simplemente luego de cada movida
             * verificamos si no esta repetida y la agregamos 
             * al array.
             * cuando el array se completa no existen movidas posibles sin hacer
             */
            int[] movidasPosibles = { 0, 0, 0, 0, 0, 0, 0, 0 };
            var sinMovidasPosibles = false;

            while (!sinMovidasPosibles)
            {
                var i = _rnd.Next(8);
                if (movidasPosibles[i] == 0)
                {
                    var hMove = _actH + _tablero.Horizontal[i];
                    var vMove = _actV + _tablero.Vertical[i];

                    if (hMove >= 0 && hMove < Tablero.tamanio && vMove >= 0 && vMove < Tablero.tamanio &&
                      _tablero.TableroAjedrez[hMove, vMove] == Tablero.simboloCasilla)
                    {
                        _actH = hMove;
                        _actV = vMove;
                        _tablero.TableroAjedrez[_actH, _actV] = Tablero.simboloMovida;
                        _contarMovidas++;
                        return true;
                    }

                    movidasPosibles[i] = 1;
                }

                if (!movidasPosibles.Contains(0))
                    sinMovidasPosibles = true;
            }

            _contarPasadas++;
            return false;
        }

        private void ObtenerResultados()
        {
            /* Muestra las estadisticas al terminar el recorrido o quedarse sin movidas */
            _noMasMovidas = true;

            if(_contarMovidas == Tablero.tamanio * Tablero.tamanio) //Si es igual, el tablero esta completo
            {
                _recorridoTerminado = true;
                _tablero.MostrarTablero();
                Console.WriteLine($"El intento # {_contarPasadas} se completo con exito\n");
                return;
            }
            if (_contarMovidas == _mejorPuntaje)
            {
                _tablero.MostrarTablero();
                Console.WriteLine($"No Resuelto. Mejor puntaje de {_mejorPuntaje} cantidad de movidas # {_contarPasadas}\n");
            }
            else if (_contarMovidas > _mejorPuntaje)
            {
                _mejorPuntaje = _contarMovidas;
                _tablero.MostrarTablero();
                Console.WriteLine($"No Resuelto, pero mejor todavia. Puntaje de {_mejorPuntaje} cantidad de movidas # {_contarPasadas}\n");
            }
        }


    }
}

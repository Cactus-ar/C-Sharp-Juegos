using System;
using System.Collections.Generic;
using System.Text;

namespace OchoDamas
{
    public class Resolver
    {
        private Tablero _tablero;
        private int _solucionNumero;
        private int _contadorReinas;
        private bool[] _filaUsada;
        private static Random _rnd;

        public Resolver()
        {
            _rnd = new Random();
            _tablero = new Tablero();
            _filaUsada = new bool[8];
            _solucionNumero = 0;
            _contadorReinas = 0;
        }

        public void InitPos()
        {
            var col = 0;
            var fila = 0;

            while (_contadorReinas < 8)
            {
                fila = _rnd.Next(0, 8);
                if (filaEsValida(fila))
                {
                    _tablero.tablero[fila, col] = Tablero.CaracterDama;
                    col++;
                    _contadorReinas++;
                }
            }
            _solucionNumero++;
        }

        public bool Solucionado()
        {
            _tablero.MostrarTablero();
            Console.WriteLine();


            //chequear diagonales


            var damaAtacante = 0;
            for (int col = 0; col < 7; col++)
            {
                /* ********
                 *  *******
                 *   ******
                 *    *****
                 *     ****
                 *      ***
                 *       **
                 *        *
                 */
                for (int fila = 0; fila <= 7 - col; fila++)
                {
                    if (_tablero.tablero[fila, fila+col] != Tablero.CaracterTablero) //si existe una dama en esa pos
                    {
                        damaAtacante++;
                        if (!ContarDamas(damaAtacante))
                        {
                            return false;
                        }
                    }
                }
                damaAtacante = 0;
            }

            damaAtacante = 0;
            for (int fila = 0; fila < 7; fila++)
            {
                /*        *
                 *       **
                 *      ***
                 *     ****
                 *    *****
                 *   ******
                 *  *******
                 * ********
                 */
                for (int col = 7; col >= fila; col--)
                {
                    if(_tablero.tablero[7 - col + fila, col] != Tablero.CaracterTablero) //si existe dama
                    {
                        damaAtacante++;
                        if (!ContarDamas(damaAtacante))
                        {
                            return false;
                        }
                    }
                }
                damaAtacante = 0;

            }

            damaAtacante = 0;
            for (int col = 7; col > 0; col--)
            {
                /* *
                 * **
                 * ***
                 * ****
                 * *****
                 * ******
                 * *******
                 * ********
                 */
                for (int fila = 7; fila >= 7 - col; fila--)
                {
                    if (_tablero.tablero[fila, fila + col - 7] != Tablero.CaracterTablero) //si existe una dama en esa pos
                    {
                        damaAtacante++;
                        if (!ContarDamas(damaAtacante))
                        {
                            return false;
                        }
                    }
                }
                damaAtacante = 0;
            }

            damaAtacante = 0;
            for (int fila = 7; fila > 0; fila--)
            {
                /* ********
                 * *******
                 * ******
                 * *****
                 * ****
                 * ***
                 * **
                 * *
                 */
                for (int col = 0; col <= fila; col++)
                {
                    if (_tablero.tablero[fila - col, col] != Tablero.CaracterTablero) //si existe una dama en esa pos
                    {
                        damaAtacante++;
                        if (!ContarDamas(damaAtacante))
                        {
                            return false;
                        }
                    }
                }
                damaAtacante = 0;
            }
            return true;

        }

        public void UbicarDamas()
        {
            _tablero.Init();

            do
            {
                InitPos();
                Console.WriteLine(_solucionNumero);
            } while (!Solucionado());

            Console.WriteLine($"Ha tomado {_solucionNumero} intentos posicionar las Damas en el Tablero");
        }

        private bool ContarDamas(int damaAtacante)
        {
            if (damaAtacante > 1)
            {
                _contadorReinas = 0;
                Array.Clear(_filaUsada, 0, 8);
                _tablero.Init();
                return false;
            }
            return true;
        }

        public bool filaEsValida(int fila)
        {
            if (!_filaUsada[fila])
            {
                _filaUsada[fila] = true;
                return true;

            }
            return false;
        }
    }
}

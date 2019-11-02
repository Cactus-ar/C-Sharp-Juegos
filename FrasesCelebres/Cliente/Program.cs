using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Cliente
{
    class Program
    {

        private static Socket socketCliente = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            LoopDeConexion();
            LoopDeEnvio();
            Console.WriteLine();
        }

        private static void LoopDeEnvio()
        {
            while (true)
            {
                Console.Write("Ingrese un Comando: ");
                string comando = Console.ReadLine();
                byte[] buffer = Encoding.ASCII.GetBytes(comando);
                socketCliente.Send(buffer);


                byte[] buffRecibido = new byte[1024];
                int rec = socketCliente.Receive(buffRecibido);
                byte[] datos = new byte[rec];
                Array.Copy(buffRecibido, datos, rec);
                Console.WriteLine("Datos Recibidos :" + Encoding.ASCII.GetString(datos));
            }
        }

        private static void LoopDeConexion()
        {
            int intentos = 0;

            while (! socketCliente.Connected)
            {
                try
                {
                    intentos++;
                    socketCliente.Connect(IPAddress.Loopback, 100);
                }
                catch (SocketException)
                {
                    Console.Clear();
                    Console.WriteLine("Error:..Intentos " + intentos.ToString());

                }
            }
            Console.Clear();
            Console.WriteLine("Conectado");

        }
    }
}

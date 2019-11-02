using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Servidor
{
    class Program
    {

        private static List<Socket> socketDeClientes = new List<Socket>();
        private static Socket serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        private static byte[] buffer = new byte[1024];

        
        static void Main(string[] args)
        {
            var listado = new Listado();
            listado.GenerarListado();
            Frase frase = listado.ObtenerFrase(false, Frase.categoria.Celebre);
            SetearServer();
            Console.ReadLine();


        }

        private static void SetearServer()
        {
            Console.WriteLine("Inicializando Server...");
            serverSocket.Bind(new IPEndPoint(IPAddress.Any, 100));
            serverSocket.Listen(5);
            serverSocket.BeginAccept(new AsyncCallback(AcceptCallback), null);
        }

        private static void AcceptCallback(IAsyncResult AR)
        {
            Socket socket = serverSocket.EndAccept(AR);
            socketDeClientes.Add(socket);
            Console.WriteLine("Cliente conectado...");
            socket.BeginReceive(buffer, 0, buffer.Length, SocketFlags.None, new AsyncCallback(RecibirCallback), null);
            serverSocket.BeginAccept(new AsyncCallback(AcceptCallback), null);

        }

        private static void EnviarCallBack(IAsyncResult AR)
        {
            Socket socket = (Socket)AR.AsyncState;
            socket.EndSend(AR);
        }

        private static void RecibirCallback(IAsyncResult AR)
        {
            Socket socket = (Socket)AR.AsyncState;
            int recibido = socket.EndReceive(AR);
            byte[] buffDeDatos = new byte[recibido];
            Array.Copy(buffer, buffDeDatos, recibido);
            string texto = Encoding.ASCII.GetString(buffDeDatos);
            Console.WriteLine("Comando recibido: " + texto);
            string respuesta = string.Empty;

            if(texto.ToLower() != "fecha")
            {
                respuesta = "invalido";
            }else
            {
                respuesta = DateTime.Now.ToLongDateString();
            }
            byte[] datos = Encoding.ASCII.GetBytes(respuesta);
            socket.BeginSend(datos, 0, datos.Length, SocketFlags.None, new AsyncCallback(EnviarCallBack), socket);
            socket.BeginReceive(buffer, 0, buffer.Length, SocketFlags.None, new AsyncCallback(RecibirCallback), null);
        }

        

    }

    public class Listado
    {
        List<Frase> listado = new List<Frase>();

        public void GenerarListado()
        {
            //es obvio lo que hay que hacer aca..pero para pruebas
            for (int i = 0; i < 50; i++)
            {
                Frase loca = new Frase(i, $"No todo lo que brilla es oro {i}", "El Loco", "Popular", false, Frase.categoria.Celebre);
                listado.Add(loca);
            }
        }

        public Frase ObtenerFrase(bool SoloAdultos, Frase.categoria _categoria)
        {
            Random rnd = new Random();
            var indice = rnd.Next(1, listado.Count);
            return listado[indice];

        }

    }
}

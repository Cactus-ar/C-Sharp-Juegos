using System;
using System.Collections.Generic;
using System.Text;

namespace Servidor
{
    public class Frase
    {
        public enum categoria
        {
            Celebre, Chiste, Historica, Refran, Fabula, Todas
        }

        private int Numero;
        private string Texto;
        private string Autor;
        private string Nota;
        private bool SoloAdultos;
        private categoria Categoria;

        public Frase(int _numero, string _texto, string _autor, string _nota, bool _soloAdultos, categoria _categoria)
        {
            Numero = _numero;
            Texto = _texto;
            Autor = _autor;
            Nota = _nota;
            SoloAdultos = _soloAdultos;
            Categoria = _categoria;
        }

        public int ObtenerNumero() => Numero;
        public string ObtenerTexto() => Texto;
        public string ObtenerAutor() => Autor;
        public string ObtenerNota() => Nota;
        public bool ParaAdultos() => SoloAdultos;
        public categoria ObtenerCategoria() => Categoria;




        
    }


}

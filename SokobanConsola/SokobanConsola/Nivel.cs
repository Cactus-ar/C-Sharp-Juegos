using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace SokobanConsola
{
    //la clase solo devuelve del archivo el nivel pedido por el constructor
    //los niveles se encuentran alojados dentro del archivo Original.xml

    public class Nivel
    {


        public int Id { get; set; }
        public bool NivelIniciado { get; set; }
        public int Ancho { get; set; }
        public int Alto { get; set; }
        public XmlNodeList DibujoNivel { get; set; }
        


        public Nivel(int nivel)
        {
            XmlDocument archivo = new XmlDocument();
            archivo.Load("recursos\\original.xml");
            XmlNodeList datos = archivo.DocumentElement.SelectNodes("/SokobanLevels/LevelCollection/Level");
            
            foreach (XmlNode dato in datos)
            {
                int level = Convert.ToInt32(dato.Attributes["Id"].Value);

                if (nivel == level)
                {
                    Id = level;
                    Ancho = Convert.ToInt32(dato.Attributes["Width"].Value);
                    Alto = Convert.ToInt32(dato.Attributes["Height"].Value);
                    DibujoNivel = dato.ChildNodes;
                    return;        
                    

                }

            }
        }
    }
}

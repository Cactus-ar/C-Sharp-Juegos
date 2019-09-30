using System;

/*Carrera de Animales trata de imitar
 * una carrera con 5 animales que tienen diferentes
 * caracteristicas
 * 
 * cada animal deriva de corredor, implementando sus propias habilidades basadas
 * en un porcentaje
 * 
 * la clase movida aloja todas las habilidades que puede tener un corredor
 */


namespace CarreraAnimales
{
    class Program
    {
        static void Main(string[] args)
        {
            var carrera = new Carrera();
            carrera.Corriendo();
        }
    }
}

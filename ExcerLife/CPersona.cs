using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcerLife
{
    /// Esta clase inicializa los datos que se usaran para serializar, también posee un método para mostrar la información.
    /// Autor: Miguel Angel Arellano Juárez
    /// Fecha: 21-04-2024
    /// Versión: 1.0.0.0
    /// Modificación: 21-04-2024
    public class CPersona
    {
        private double peso;//Aquí se guarda el peso
        private double altura; //Aquí se guarda la altura

        //Constructor
        public CPersona()
        {
            peso = 0;
            altura = 0;
        }

        public double Peso { set { peso = value; } get { return peso; } }

        public double Altura { set { altura = value; } get { return altura; } }

        /// Método para mostrar la información de los datos ya serializados.
        /// Autor: Miguel Angel Arellano Juárez
        /// Fecha: 21-04-2024
        /// Versión: 1.0.0.0
        /// Modificación: 21-04-2024
        /// <param > No posee parametros</param>
        /// <returns> No regresa nada</returns>
        public void MostrarInfo()
        {
            Console.WriteLine("Tu peso actual es de: {0} kg", peso);
            Console.WriteLine("Tu altura actual es de {0} cm", altura);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcerLife
{
    public class CPersona
    {
        private double peso;
        private double altura;

        public double Peso { set { peso = value; } get { return peso; } }

        public double Altura { set { altura = value; } get { return altura; } }

        public CPersona() 
        {
            peso = 0;
            altura = 0;
        }

        public void MostrarInfo()
        {
            Console.WriteLine("Tu peso actual es de: {0} kg", peso);
            Console.WriteLine("Tu altura actual es de {0} cm", altura);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcerLife
{
    /// Esta clase sirve para llevar a cabo la sobrecarga del operador "decremento".
    /// Autor: Miguel Angel Arellano Juárez
    /// Fecha: 22-04-2024
    /// Versión: 1.0.0.0
    /// Modificación: 22-04-2024
    internal class CImc
    {
        private double weight;
        private double height;

        public CImc(double pWeight, double pHeight)
        {
            weight = pWeight;//Aquí se guarda el peso
            height = pHeight;//Aquí se guarda la altura
        }

        public double Weight { get { return weight; } set { weight = value; } }
        public double Height { get { return height; } set { height = value; } }

        /// Método para calcular el IMC.
        /// Autor: Miguel Angel Arellano Juárez
        /// Fecha: 21-04-2024
        /// Versión: 1.0.0.0
        /// Modificación: 21-04-2024
        /// <param > No posee parámetros</param>
        /// <returns> No regresa nada</returns>
        public double CalculateIMC()
        {
            return Weight / (Height * Height);
        }

        //Transforma los datos recibidos para que sean legibles en la consola.
        public override string ToString()
        {
            return $"Peso: {Weight}, Altura: {Height}";
        }

        /// Sobrecarga del operador decremento.
        /// Autor: Miguel Angel Arellano Juárez
        /// Fecha: 21-04-2024
        /// Versión: 1.0.0.0
        /// Modificación: 21-04-2024
        /// <param name="day1"> Aquí se guarda el imc del dia 1</param>
        /// <param name="day2"> Aquí se guarda el imc del dia 2</param>
        /// <returns> regresa un temporal.</returns>
        public static CImc operator -(CImc day1, CImc day2)
        {
            double imc1 = day1.CalculateIMC();
            double imc2 = day2.CalculateIMC();

            CImc temp = new CImc(imc1, imc2);
            return temp;
        }
    }
}

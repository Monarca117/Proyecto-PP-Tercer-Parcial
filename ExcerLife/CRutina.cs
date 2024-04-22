using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcerLife
{
    /// Esta clase almacena los delegados que se usan para suministrar las rutinas dependiendo del dia.
    /// Autor: Miguel Angel Arellano Juárez
    /// Fecha: 21-04-2024
    /// Versión: 1.0.0.0
    /// Modificación: 21-04-2024
    internal class CRutina
    {
        // Declaración de delegados para cada día de la semana
        public delegate void DRutinaLunes();
        public delegate void DRutinaMartes();
        public delegate void DRutinaMiercoles();
        public delegate void DRutinaJueves();
        public delegate void DRutinaViernes();

        // Campos públicos para almacenar los delegados de rutina para cada día
        public DRutinaLunes delRutinaL;
        public DRutinaMartes delRutinaM;
        public DRutinaMiercoles delRutinaMi;
        public DRutinaJueves delRutinaJ;
        public DRutinaViernes delRutinaV;

        // Constructor vacío
        public CRutina() { }

        /// Método para asignar un método de rutina de lunes a el delegado del lunes y mostrar un mensaje de confirmación.
        /// Autor: Miguel Angel Arellano Juárez
        /// Fecha: 21-04-2024
        /// Versión: 1.0.0.0
        /// Modificación: 21-04-2024
        /// <param name="pMetodo"> pMetodo</param>
        /// <returns> No regresa nada</returns>
        public void AdicionaMetodoRutinaL(DRutinaLunes pMetodo)
        {
            delRutinaL = pMetodo;
            Console.WriteLine("Delegado de RutinaLunes asignado correctamente.");
        }

        /// Método para asignar un método de rutina de martes a el delegado del martes y mostrar un mensaje de confirmación.
        /// Autor: Miguel Angel Arellano Juárez
        /// Fecha: 21-04-2024
        /// Versión: 1.0.0.0
        /// Modificación: 21-04-2024
        /// <param name="pMetodo"> pMetodo</param>
        /// <returns> No regresa nada</returns>
        public void AdicionaMetodoRutinaM(DRutinaMartes pMetodo)
        {
            delRutinaM = pMetodo;
            Console.WriteLine("Delegado de RutinaMartes asignado correctamente.");
        }

        /// Método para asignar un método de rutina de Miercoles a el delegado del Miercoles y mostrar un mensaje de confirmación.
        /// Autor: Miguel Angel Arellano Juárez
        /// Fecha: 21-04-2024
        /// Versión: 1.0.0.0
        /// Modificación: 21-04-2024
        /// <param name="pMetodo"> pMetodo</param>
        /// <returns> No regresa nada</returns>
        public void AdicionaMetodoRutinaMi(DRutinaMiercoles pMetodo)
        {
            delRutinaMi = pMetodo;
            Console.WriteLine("Delegado de RutinaMiercoles asignado correctamente.");
        }

        /// Método para asignar un método de rutina de Jueves a el delegado del Jueves y mostrar un mensaje de confirmación.
        /// Autor: Miguel Angel Arellano Juárez
        /// Fecha: 21-04-2024
        /// Versión: 1.0.0.0
        /// Modificación: 21-04-2024
        /// <param name="pMetodo"> pMetodo</param>
        /// <returns> No regresa nada</returns>
        public void AdicionaMetodoRutinaJ(DRutinaJueves pMetodo)
        {
            delRutinaJ = pMetodo;
            Console.WriteLine("Delegado de RutinaJueves asignado correctamente.");
        }

        /// Método para asignar un método de rutina de Viernes a el delegado del Viernes y mostrar un mensaje de confirmación.
        /// Autor: Miguel Angel Arellano Juárez
        /// Fecha: 21-04-2024
        /// Versión: 1.0.0.0
        /// Modificación: 21-04-2024
        /// <param name="pMetodo"> pMetodo</param>
        /// <returns> No regresa nada</returns>
        public void AdicionaMetodoRutinaV(DRutinaViernes pMetodo)
        {
            delRutinaV = pMetodo;
            Console.WriteLine("Delegado de RutinaViernes asignado correctamente.");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcerLife
{
    internal class CRutina
    {
        public delegate void DRutinaLunes();
        public delegate void DRutinaMartes();
        public delegate void DRutinaMiercoles();
        public delegate void DRutinaJueves();
        public delegate void DRutinaViernes();

        public DRutinaLunes delRutinaL;
        public DRutinaMartes delRutinaM;
        public DRutinaMiercoles delRutinaMi;
        public DRutinaJueves delRutinaJ;
        public DRutinaViernes delRutinaV;

        public CRutina() { }

        public void AdicionaMetodoRutinaL(DRutinaLunes pMetodo)
        {
            delRutinaL = pMetodo;
            Console.WriteLine("Delegado de RutinaLunes asignado correctamente.");
        }
        public void AdicionaMetodoRutinaM(DRutinaMartes pMetodo)
        {
            delRutinaM = pMetodo;
            Console.WriteLine("Delegado de RutinaLunes asignado correctamente.");
        }

        public void AdicionaMetodoRutinaMi(DRutinaMiercoles pMetodo)
        {
            delRutinaMi = pMetodo;
            Console.WriteLine("Delegado de RutinaLunes asignado correctamente.");
        }
        public void AdicionaMetodoRutinaJ(DRutinaJueves pMetodo)
        {
            delRutinaJ = pMetodo;
            Console.WriteLine("Delegado de RutinaLunes asignado correctamente.");
        }
        public void AdicionaMetodoRutinaV(DRutinaViernes pMetodo)
        {
            delRutinaV = pMetodo;
            Console.WriteLine("Delegado de RutinaLunes asignado correctamente.");
        }
    }
}

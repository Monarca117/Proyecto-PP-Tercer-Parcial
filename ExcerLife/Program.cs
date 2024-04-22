using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ExcerLife
{
    /// Programa principal.
    /// Autor: Miguel Angel Arellano Juárez
    /// Fecha: 21-04-2024
    /// Versión: 1.0.0.1
    /// Modificación: 22-04-2024

    internal class Program
    {
        
        static void Main(string[] args)
        {
            //Variables necesarias para que el usuario realize elecciones
            int op;
            string val;

            //Menú principal
            Console.WriteLine("*******************************");
            Console.WriteLine("*           M E N U           *");
            Console.WriteLine("*  1. Obtener mi ejercicios   *");
            Console.WriteLine("*  2. Guardar mis datos       *");
            Console.WriteLine("*  3. IMC                     *");
            Console.WriteLine("*  4. Salir                   *");
            Console.WriteLine("*******************************");

            //Conversión de String a Entero
            val = Console.ReadLine();
            op = Convert.ToInt32(val);

            //Switch del menú
            switch(op) 
            {
                case 1:
                    // Variables
                    int dia = 0; // Esta variable se encarga de guardar la elección del día.
                    String valor = "";

                    // Creamos nuestro objeto Rutina
                    CRutina rutina = new CRutina();

                    //Menú de dias disponibles
                    Console.WriteLine("*******************************");
                    Console.WriteLine("*           M E N U           *");
                    Console.WriteLine("*         1. Lunes            *");
                    Console.WriteLine("*         2. Martes           *");
                    Console.WriteLine("*         3. Miércoles        *");
                    Console.WriteLine("*         4. Jueves           *");
                    Console.WriteLine("*         5. Viernes          *");
                    Console.WriteLine("*******************************");

                    //Conversión de String a Entero
                    valor = Console.ReadLine();
                    dia = Convert.ToInt32(valor);

                    //Switch de días
                    switch (dia)
                    {
                        case 1:
                            // Pasar el método RutinaLunes como argumento al delegado DRutinaLunes
                            rutina.AdicionaMetodoRutinaL(RutinaLunes);

                            // Invocar el delegado para ejecutar el método RutinaLunes
                            rutina.delRutinaL();
                        break;

                        case 2:
                            // Pasar el método RutinaMartes como argumento al delegado DRutinaMartes
                            rutina.AdicionaMetodoRutinaM(RutinaMartes);

                            // Invocar el delegado para ejecutar el método RutinaMartes
                            rutina.delRutinaM();
                        break;

                        case 3:
                            // Pasar el método RutinaMiercoles como argumento al delegado DRutinaMiercoles
                            rutina.AdicionaMetodoRutinaMi(RutinaMiercoles);

                            // Invocar el delegado para ejecutar el método RutinaMiercoles
                            rutina.delRutinaMi();
                        break;
                        case 4:
                            // Pasar el método RutinaJueves como argumento al delegado DRutinaJueves
                            rutina.AdicionaMetodoRutinaJ(RutinaJueves);

                            // Invocar el delegado para ejecutar el método RutinaJueves
                            rutina.delRutinaJ();
                        break;
                        case 5:
                            // Pasar el método RutinaViernes como argumento al delegado DRutinaViernes
                            rutina.AdicionaMetodoRutinaV(RutinaViernes);

                            // Invocar el delegado para ejecutar el método RutinaViernes
                            rutina.delRutinaV();
                        break;
                        default:
                            //Mensaje de error si se escoge un valor invalido.
                            Console.WriteLine("Opción no válida. Por favor, ingrese un número del 1 al 5.");
                        break;
                    }
                break;

                case 2:

                    //Menú para introducir datos.
                    Console.WriteLine("*******************************");
                    Console.WriteLine("*           M E N U           *");
                    Console.WriteLine("*    1. Introducir datos.     *");
                    Console.WriteLine("*    2. Leer datos.           *");
                    Console.WriteLine("*******************************");

                    //Conversión de String a Entero
                    valor = Console.ReadLine();
                    op = Convert.ToInt32(valor);

                    if (op == 1)
                    {
                        double peso = 0; //Aquí se guarda la variable para el peso
                        double altura = 0; //Aquí se guarda la variable para la altura

                        //Petición de peso y conversión de Cadena a entero
                        Console.WriteLine("Dame tu peso en kilogramos");
                        valor = Console.ReadLine();
                        peso = Convert.ToDouble(valor);

                        //Petición de altura y conversión de Cadena a entero
                        Console.WriteLine("Dame tu altura en centímetros");
                        valor = Console.ReadLine();
                        altura = Convert.ToDouble(valor);

                        //Creamos a una persona
                        CPersona persona = new CPersona();
                        persona.Peso = peso;
                        persona.Altura = altura;

                        persona.MostrarInfo();

                        //Selecionamos el formateador
                        XmlSerializer formateador = new XmlSerializer(typeof(CPersona));

                        //Se crea el stream
                        Stream miStream = new FileStream("Personas.per", FileMode.Create, FileAccess.Write, FileShare.None);

                        //Serializamos
                        formateador.Serialize(miStream, persona);

                        //Cerramos el stream
                        miStream.Close();
                    }
                    else if(op == 2) 
                    {
                        //Seleccionamos el formateador
                        XmlSerializer formateador = new XmlSerializer(typeof(CPersona));

                        //Creamos el Stream
                        Stream miStream = new FileStream("Personas.per", FileMode.Open, FileAccess.Read, FileShare.None);

                        //Deserializamos
                        CPersona persona = (CPersona)formateador.Deserialize(miStream);

                        //Cerramos el stream
                        miStream.Close();

                        //Usamos el objeto
                        persona.MostrarInfo();
                    }    
                break;

                case 3:

                    //Menú para el IMC
                    Console.WriteLine("*******************************");
                    Console.WriteLine("*           M E N U           *");
                    Console.WriteLine("*    1. Calcula tu IMC.       *");
                    Console.WriteLine("*    2. Compara IMC.          *");
                    Console.WriteLine("*******************************");

                    //Conversión de Cadena a Altura
                    valor = Console.ReadLine();
                    op = Convert.ToInt32(valor);

                    if(op == 1) 
                    {
                        double peso = 0; //Aquí se guarda la variable para el peso
                        double altura = 0; //Aquí se guarda la variable para la altura
                        double imc; //Aquí se guarda el imc

                        //Petición de peso y conversión de Cadena a entero
                        Console.WriteLine("Dame tu peso en kilogramos");
                        valor = Console.ReadLine();
                        peso = Convert.ToDouble(valor);

                        //Petición de altura y conversión de Cadena a entero
                        Console.WriteLine("Dame tu altura en metros");
                        valor = Console.ReadLine();
                        altura = Convert.ToDouble(valor);

                        //Calculo del imc
                        imc = (peso / (altura * altura));

                        //Impresión dle imc
                        Console.WriteLine(imc);
                    }
                    else if (op == 2) 
                    {
                        //Petición del peso y la altura del primer dia. Conversión de cadena a entero.
                        Console.WriteLine("Introduce el peso y la altura para el primer día:");
                        Console.Write("Peso (kg): ");
                        double weight1 = Convert.ToDouble(Console.ReadLine());
                        Console.Write("Altura (m): ");
                        double height1 = Convert.ToDouble(Console.ReadLine());

                        //Petición del peso y la altura del primer dia. Conversión de cadena a entero.
                        Console.WriteLine("\nIntroduce el peso y la altura para el segundo día:");
                        Console.Write("Peso (kg): ");
                        double weight2 = Convert.ToDouble(Console.ReadLine());
                        Console.Write("Altura (m): ");
                        double height2 = Convert.ToDouble(Console.ReadLine());

                        // Se crean instancias de la clase CImc con los valores introducidos por el usuario
                        CImc day1 = new CImc(weight1, height1);
                        CImc day2 = new CImc(weight2, height2);
                        CImc imct;

                        //Calculo de la comparación del imc
                        imct = day2 - day1;

                        // Mostrar los resultados
                        Console.WriteLine("\nPrimer día: " + day1);
                        Console.WriteLine("Segundo día: " + day2);
                        Console.WriteLine("Diferencia en IMC: " + imct.CalculateIMC());
                    }
                break;
            }
        }

        /// Método para asignar una rutina entre 5 para trabajar un cierto grupo muscular.
        /// Autor: Miguel Angel Arellano Juárez
        /// Fecha: 21-04-2024
        /// Versión: 1.0.0.0
        /// Modificación: 21-04-2024
        /// <param > No posee parámetros</param>
        /// <returns> No regresa nada</returns>
        public static void RutinaLunes()
        {
            //Uso del randomizador para generar un numero aleatorio que servira para elegir una rutina aleatoria.
            Random rnd = new Random();

            int elecL = rnd.Next(1, 6);

            switch (elecL)
            {
                //Rutina 1
                case 1:
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                    Console.WriteLine("Pecho y Tríceps");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("Press de banca: 4 series x 8-10 repeticiones");
                    Console.WriteLine("Fondos en máquina o banco: 3 series x máximas repeticiones");
                    Console.WriteLine("Press de tríceps en polea alta: 3 series x 10-12 repeticiones");
                    Console.WriteLine("Extensiones de tríceps con mancuerna: 3 series x 10-12 repeticiones");
                    break;

                //Rutina 2
                case 2:
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                    Console.WriteLine("Pecho y Hombros");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("Press de banca inclinado: 4 series x 8-10 repeticiones");
                    Console.WriteLine("Aperturas con mancuernas: 3 series x 10-12 repeticiones");
                    Console.WriteLine("Press militar con barra: 4 series x 8-10 repeticiones");
                    Console.WriteLine("Elevaciones laterales con mancuernas: 3 series x 10-12 repeticiones");
                    break;
                
                //Rutina 3
                case 3:
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                    Console.WriteLine("Pecho y Abdominales");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("Press de banca declinado: 4 series x 8-10 repeticiones");
                    Console.WriteLine("Pull-over con mancuerna: 3 series x 10-12 repeticiones");
                    Console.WriteLine("Crunches: 4 series x 15-20 repeticiones");
                    Console.WriteLine("Russian twists: 3 series x 15-20 repeticiones por lado");
                    break;

                //Rutina 4
                case 4:
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                    Console.WriteLine("Tríceps y Hombros");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("Press francés con barra EZ: 4 series x 8-10 repeticiones");
                    Console.WriteLine("Extensiones de tríceps con mancuerna a una mano: 3 series x 10-12 repeticiones");
                    Console.WriteLine("Press militar con mancuernas: 4 series x 8-10 repeticiones");
                    Console.WriteLine("Elevaciones frontales con barra: 3 series x 10-12 repeticiones");
                    break;

                //Rutina 5
                case 5:
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                    Console.WriteLine("Tríceps y Abdominales");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("Fondos en paralelas: 4 series x máximas repeticiones");
                    Console.WriteLine("Press de tríceps con cuerda en polea alta: 3 series x 10-12 repeticiones");
                    Console.WriteLine("Plancha con elevación de piernas: 4 series x 30 segundos");
                    Console.WriteLine("Crunches con elevación de piernas: 3 series x 15-20 repeticiones");
                    break;
            }

        }

        /// Método para asignar una rutina entre 5 para trabajar un cierto grupo muscular.
        /// Autor: Miguel Angel Arellano Juárez
        /// Fecha: 21-04-2024
        /// Versión: 1.0.0.0
        /// Modificación: 21-04-2024
        /// <param > No posee parámetros</param>
        /// <returns> No regresa nada</returns>
        public static void RutinaMartes()
        {
            //Uso del randomizador para generar un numero aleatorio que servira para elegir una rutina aleatoria.
            Random rnd = new Random();

            int elecM = rnd.Next(1, 6);

            switch (elecM)
            {
                //Rutina 1
                case 1:
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                    Console.WriteLine("Espalda y Bíceps");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("Dominadas: 4 series x máximas repeticiones");
                    Console.WriteLine("Remo con barra: 4 series x 8-10 repeticiones");
                    Console.WriteLine("Curl de bíceps con barra: 3 series x 10-12 repeticiones");
                    Console.WriteLine("Curl de martillo con mancuernas: 3 series x 10-12 repeticiones");
                    break;

                //Rutina 2
                case 2:
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                    Console.WriteLine("Espalda y Tríceps");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("Pull-ups: 4 series x máximas repeticiones");
                    Console.WriteLine("Peso muerto: 4 series x 8-10 repeticiones");
                    Console.WriteLine("Press de tríceps con mancuerna: 3 series x 10-12 repeticiones");
                    Console.WriteLine("Extensiones de tríceps en polea alta: 3 series x 10-12 repeticiones");
                    break;

                //Rutina 3
                case 3:
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                    Console.WriteLine("Espalda y Hombros");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("Remo con mancuerna: 4 series x 8-10 repeticiones");
                    Console.WriteLine("Pulldowns en polea alta: 4 series x 8-10 repeticiones");
                    Console.WriteLine("Press militar con barra: 3 series x 10-12 repeticiones");
                    Console.WriteLine("Elevaciones laterales con mancuernas: 3 series x 10-12 repeticiones");
                    break;

                //Rutina 4
                case 4:
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                    Console.WriteLine("Espalda y Abdominales");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("Hip Thrust: 4 series x 8-10 repeticiones");
                    Console.WriteLine("Hiperextensiones: 3 series x 10-12 repeticiones");
                    Console.WriteLine("Crunches: 4 series x 15-20 repeticiones");
                    Console.WriteLine("Elevación de piernas colgado: 3 series x 12-15 repeticiones");
                    break;

                //Rutina 5
                case 5:
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                    Console.WriteLine("Bíceps y Hombros");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("Curl de bíceps con mancuernas alternado: 4 series x 10-12 repeticiones por brazo");
                    Console.WriteLine("Curl de araña en polea baja: 3 series x 10-12 repeticiones");
                    Console.WriteLine("Press Arnold: 4 series x 8-10 repeticiones");
                    Console.WriteLine("Elevaciones frontales con mancuernas: 3 series x 10-12 repeticiones");
                    break;
            }
        }

        /// Método para asignar una rutina entre 5 para trabajar un cierto grupo muscular.
        /// Autor: Miguel Angel Arellano Juárez
        /// Fecha: 21-04-2024
        /// Versión: 1.0.0.0
        /// Modificación: 21-04-2024
        /// <param > No posee parámetros</param>
        /// <returns> No regresa nada</returns>
        public static void RutinaMiercoles()
        {
            //Uso del randomizador para generar un numero aleatorio que servira para elegir una rutina aleatoria.
            Random rnd = new Random();

            int elecMi = rnd.Next(1, 6);

            switch (elecMi)
            {
                //Rutina 1
                case 1:
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                    Console.WriteLine("Piernas");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("Sentadillas: 4 series x 8-10 repeticiones");
                    Console.WriteLine("Prensa de piernas: 4 series x 10-12 repeticiones");
                    Console.WriteLine("Extensiones de cuádriceps en máquina: 3 series x 10-12 repeticiones");
                    Console.WriteLine("Curl de piernas acostado: 3 series x 10-12 repeticiones");
                    break;
                //Rutina 2
                case 2:
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                    Console.WriteLine("Espalda y Trapecios");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("Pull-ups: 4 series x máximas repeticiones");
                    Console.WriteLine("Peso muerto: 4 series x 8-10 repeticiones");
                    Console.WriteLine("Encogimientos con barra: 4 series x 10-12 repeticiones");
                    Console.WriteLine("Encogimientos con mancuernas: 3 series x 10-12 repeticiones");
                    break;

                //Rutina 3
                case 3:
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                    Console.WriteLine("Piernas y Abdominales");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("Sentadilla frontal: 4 series x 8-10 repeticiones");
                    Console.WriteLine("Zancadas con mancuernas: 3 series x 10-12 repeticiones por pierna");
                    Console.WriteLine("Crunches: 4 series x 15-20 repeticiones");
                    Console.WriteLine("Plancha: 3 series x 30-45 segundos");
                    break;

                //Rutina 4
                case 4:
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                    Console.WriteLine("Piernas y Hombros");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("Sentadilla hack: 4 series x 8-10 repeticiones");
                    Console.WriteLine("Prensa de hombros: 4 series x 8-10 repeticiones");
                    Console.WriteLine("Elevaciones laterales con mancuernas: 3 series x 10-12 repeticiones");
                    Console.WriteLine("Pájaros: 3 series x 10-12 repeticiones");
                    break;

                //Rutina 5
                case 5:
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                    Console.WriteLine("Piernas y Glúteos");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("Peso muerto rumano: 4 series x 8-10 repeticiones");
                    Console.WriteLine("Hip Thrust: 4 series x 10-12 repeticiones");
                    Console.WriteLine("Patada de glúteos en máquina: 3 series x 10-12 repeticiones");
                    Console.WriteLine("Elevación de talones de pie: 4 series x 12-15 repeticiones");
                    break;
            }
        }

        /// Método para asignar una rutina entre 5 para trabajar un cierto grupo muscular.
        /// Autor: Miguel Angel Arellano Juárez
        /// Fecha: 21-04-2024
        /// Versión: 1.0.0.0
        /// Modificación: 21-04-2024
        /// <param > No posee parámetros</param>
        /// <returns> No regresa nada</returns>
        public static void RutinaJueves()
        {
            //Uso del randomizador para generar un numero aleatorio que servira para elegir una rutina aleatoria.
            Random rnd = new Random();

            int elecJ = rnd.Next(1, 6);

            switch (elecJ)
            {
                //Rutina 1
                case 1:
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                    Console.WriteLine("Pecho y Bíceps");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("Press de banca: 4 series x 8-10 repeticiones");
                    Console.WriteLine("Curl de bíceps con barra: 3 series x 10-12 repeticiones");
                    Console.WriteLine("Aperturas con mancuernas: 3 series x 10-12 repeticiones");
                    Console.WriteLine("Curl de bíceps en banco Scott: 3 series x 10-12 repeticiones");
                    break;

                //Rutina 2
                case 2:
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                    Console.WriteLine("Hombros y Trapecios");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("Press militar con barra: 4 series x 8-10 repeticiones");
                    Console.WriteLine("Elevaciones laterales con mancuernas: 3 series x 10-12 repeticiones");
                    Console.WriteLine("Encogimientos con barra: 4 series x 10-12 repeticiones");
                    Console.WriteLine("Pájaros: 3 series x 10-12 repeticiones");
                    break;

                //Rutina 3
                case 3:
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                    Console.WriteLine("Bíceps y Abdominales");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("Curl de bíceps con mancuernas alternado: 4 series x 10-12 repeticiones por brazo");
                    Console.WriteLine("Curl de araña en polea baja: 3 series x 10-12 repeticiones");
                    Console.WriteLine("Crunches: 4 series x 15-20 repeticiones");
                    Console.WriteLine("Plancha: 3 series x 30-45 segundos");
                    break;

                //Rutina 4
                case 4:
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                    Console.WriteLine("Tríceps y Glúteos");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("Press francés con barra EZ: 4 series x 8-10 repeticiones");
                    Console.WriteLine("Patada de glúteos en máquina: 3 series x 10-12 repeticiones");
                    Console.WriteLine("Extensiones de tríceps en polea alta: 3 series x 10-12 repeticiones");
                    Console.WriteLine("Hip Thrust: 4 series x 10-12 repeticiones");
                    break;

                //Rutina 5
                case 5:
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                    Console.WriteLine("Piernas y Abdominales");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("Sentadillas: 4 series x 8-10 repeticiones");
                    Console.WriteLine("Crunches: 4 series x 15-20 repeticiones");
                    Console.WriteLine("Zancadas con mancuernas: 3 series x 10-12 repeticiones por pierna");
                    Console.WriteLine("Plancha lateral: 3 series x 30-45 segundos por lado");
                    break;
            }
        }

        /// Método para asignar una rutina entre 5 para trabajar un cierto grupo muscular.
        /// Autor: Miguel Angel Arellano Juárez
        /// Fecha: 21-04-2024
        /// Versión: 1.0.0.0
        /// Modificación: 21-04-2024
        /// <param > No posee parámetros</param>
        /// <returns> No regresa nada</returns>
        public static void RutinaViernes()
        {
            //Uso del randomizador para generar un numero aleatorio que servira para elegir una rutina aleatoria.
            Random rnd = new Random();

            int elecV = rnd.Next(1, 6);

            switch (elecV)
            {
                //Rutina 1
                case 1:
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                    Console.WriteLine("Espalda y Tríceps");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("Dominadas: 4 series x máximas repeticiones");
                    Console.WriteLine("Peso muerto: 4 series x 8-10 repeticiones");
                    Console.WriteLine("Press de tríceps con mancuerna: 3 series x 10-12 repeticiones");
                    Console.WriteLine("Extensiones de tríceps en polea alta: 3 series x 10-12 repeticiones");
                    break;

                //Rutina 2
                case 2:
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                    Console.WriteLine("Pecho y Hombros");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("Press de banca inclinado: 4 series x 8-10 repeticiones");
                    Console.WriteLine("Aperturas con mancuernas: 3 series x 10-12 repeticiones");
                    Console.WriteLine("Press militar con barra: 4 series x 8-10 repeticiones");
                    Console.WriteLine("Elevaciones laterales con mancuernas: 3 series x 10-12 repeticiones");
                    break;

                //Rutina 3
                case 3:
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                    Console.WriteLine("Bíceps y Abdominales");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("Curl de bíceps con barra: 4 series x 10-12 repeticiones");
                    Console.WriteLine("Crunches: 4 series x 15-20 repeticiones");
                    Console.WriteLine("Curl de araña en polea baja: 3 series x 10-12 repeticiones");
                    Console.WriteLine("Plancha: 3 series x 30-45 segundos");
                    break;

                //Rutina 4
                case 4:
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                    Console.WriteLine("Piernas y Glúteos");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("Sentadillas: 4 series x 8-10 repeticiones");
                    Console.WriteLine("Prensa de piernas: 4 series x 10-12 repeticiones");
                    Console.WriteLine("Patada de glúteos en máquina: 3 series x 10-12 repeticiones");
                    Console.WriteLine("Hip Thrust: 4 series x 10-12 repeticiones");
                    break;

                //Rutina 5
                case 5:
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                    Console.WriteLine("Espalda y Hombros");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("Remo con barra: 4 series x 8-10 repeticiones");
                    Console.WriteLine("Pulldowns en polea alta: 4 series x 8-10 repeticiones");
                    Console.WriteLine("Press militar con barra: 3 series x 10-12 repeticiones");
                    Console.WriteLine("Elevaciones frontales con mancuernas: 3 series x 10-12 repeticiones");
                    break;
            }
        }
    }
}

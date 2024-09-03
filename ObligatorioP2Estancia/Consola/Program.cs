using Dominio;
using System.ComponentModel.Design;
using System.Threading;
using static Dominio.Animal;

namespace Consola
{
    public class Program
    {

        static Sistema unS = Sistema.Instancia;

        static void Main(string[] args)
        {
            
            int opcion = 0;
            string[] opciones = { "Listar Animales", "Listar Potreros", "Establecer precio por Kg de lana en los Ovino", "Agregar Bovino" };
            do
            {
                Menu(opciones);
                opcion = LeerNumero();
                switch (opcion)
                {
                    case 1:
                        ListarAnimales();
                        break;
                    case 2:
                        DatosPotrero();
                        break;
                    case 3:
                        PrecioKgOvino();
                        break;
                    case 4:
                        AgregarBovino();
                        break;
                }

            } while (opcion != 0);

        }
        static void Menu(string[] opciones)
        {
            int numero = 1;
            Console.Clear();
            Console.WriteLine("Ingrese una de las siguientes opciones (0 para terminar)");
            foreach (string opcion in opciones)
            {
                Console.WriteLine($"{numero} - {opcion} ");
                numero++;
            }
        }
        static int LeerNumero()
        {
            int opcion;
            Console.Write("Ingrese Opcion:");
            while (!(int.TryParse(Console.ReadLine(), out opcion)))
            {
                Console.WriteLine("El valor ingresado no es correcto");
                Console.Write("Ingrese Opcion:");
            }
            return opcion;
        }
        static void ListarAnimales()
        {
            List<Animal> lista = unS.ObtenerAnimales();
            Console.Clear();
            foreach (Animal animal in lista)
            {
                Console.WriteLine(animal.ToString());
            }
            Console.WriteLine("Enter para continuar");
            Console.ReadLine();
        }
        static void DatosPotrero()
        {
            int hectareasMinimas;
            int capacidadMinima;

            Console.WriteLine("Ingrese cantidad de hectareas minimas:");
            while (!int.TryParse(Console.ReadLine(), out hectareasMinimas) || hectareasMinimas <= 0)
            {
                Console.WriteLine("Entrada invalida. Por favor, ingrese un numero valido mayor que cero:");
            }

            Console.WriteLine("Ingrese capacidad minima:");
            while (!int.TryParse(Console.ReadLine(), out capacidadMinima) || capacidadMinima <= 0)
            {
                Console.WriteLine("Entrada invalida. Por favor, ingrese un numero valido mayor que cero:");
            }

            // Obtener la lista de potreros filtrada por los criterios ingresados
            ListarPotrerosFiltrados(hectareasMinimas, capacidadMinima);
        }
        static void ListarPotrerosFiltrados(int hectareasMinimas, int capacidadMinima)
        {
            List<Potrero> lista = unS.ObtenerPotreros();

            Console.Clear();
            Console.WriteLine($"Potreros con al menos {hectareasMinimas} hectareas y capacidad minima de {capacidadMinima}:");

            bool encontrados = false;

            foreach (Potrero potrero in lista)
            {
                if (potrero.Hectareas >= hectareasMinimas && potrero.CapMax >= capacidadMinima)
                {
                    Console.WriteLine(potrero.ToString());
                    encontrados = true;
                }
            }

            if (!encontrados)
            {
                Console.WriteLine("No hay potreros con esas caracteristicas.");
            }
            Console.WriteLine("Presione Enter para continuar...");
            Console.ReadLine();
        }
        static void PrecioKgOvino()
        {
            decimal precioKg;
            Console.WriteLine("Ingrese el precio por Kg de Ovino: ");
            if (decimal.TryParse(Console.ReadLine(), out precioKg))
            {
                Ovino.PrecioLana = precioKg;

                Console.WriteLine($"El precio por kilogramo de lana ha sido actualizado a: {precioKg}");
            }
            else
            {
                Console.WriteLine("Entrada invalida.");
            }
            Console.WriteLine("Presione Enter para continuar...");
            Console.ReadLine();
        }
        static void AgregarBovino()
        {
            Bovino.TipoAlim tipoAlimento = Bovino.TipoAlim.Grano;
            string codigo = "";
            Sexo genero = Sexo.Hembra;
            string raza = "";
            DateTime fechaNc = DateTime.MinValue;
            decimal precioCompra = 0;
            decimal costoAlim = 0;
            decimal peso = 0;
            bool hibrido = false;

            Console.WriteLine("Ingrese los datos del nuevo Bovino:");

            bool tipoAlimentoValido = false;
            while (!tipoAlimentoValido)
            {
                Console.Write("Tipo de Alimento (Grano/Pastura): ");
                string tipoAlimentoStr = Console.ReadLine();
                if (tipoAlimentoStr == "Grano" || tipoAlimentoStr == "Pastura")
                {
                    tipoAlimento = (Bovino.TipoAlim)Enum.Parse(typeof(Bovino.TipoAlim), tipoAlimentoStr, true);
                    tipoAlimentoValido = true;
                }
                else
                {
                    Console.WriteLine("Error: Tipo de alimento inválido. Ingrese 'Grano' o 'Pastura'.");
                }
            }

            // Solicitar y validar el Código
            while (codigo == "" || codigo?.Length != 8)
            {  
                Console.Write("Codigo debe tener 8 digitos.");
                codigo = Console.ReadLine();
                if (codigo == "")
                {
                    Console.WriteLine("Error: Codigo invalido. Por favor, ingrese un codigo valido.");
                }
            }

            // Solicitar y validar el Género
            bool generoValido = false;
            while (!generoValido)
            {
                Console.Write("Genero (Hembra/Macho): ");
                string generoStr = Console.ReadLine();
                if (generoStr == "Hembra" || generoStr == "Macho")
                {
                    genero = (Sexo)Enum.Parse(typeof(Sexo), generoStr, true);
                    generoValido = true;
                }
                else
                {
                    Console.WriteLine("Error: Genero invalido. Ingrese 'Hembra' o 'Macho'.");
                }
            }

            // Solicitar y validar la Raza
            while (raza == "")
            {
                Console.Write("Raza: ");
                raza = Console.ReadLine().Trim(); // Puedes usar .Trim() para eliminar espacios en blanco alrededor de la raza
                if (raza == "")
                {
                    Console.WriteLine("Error: Raza invalida. Por favor, ingrese una raza valida.");
                }
            }

            // Solicitar y validar la Fecha de Nacimiento
            bool fechaValida = false;
            while (!fechaValida)
            {
                Console.Write("Fecha de Nacimiento (Año-Mes-dia): ");
                string fechaStr = Console.ReadLine();
                if (DateTime.TryParse(fechaStr, out fechaNc))
                {
                    fechaValida = true;
                }
                else
                {
                    Console.WriteLine("Error: Formato de fecha invalido. Ingrese una fecha valida (ejemplo: 2024-04-30).");
                }
            }

            // Solicitar y validar el Precio de Compra
            bool precioValido = false;
            while (!precioValido)
            {
                Console.Write("Precio de Compra: ");
                string precioStr = Console.ReadLine();
                if (decimal.TryParse(precioStr, out precioCompra) && precioCompra > 0)
                {
                    precioValido = true;
                }
                else
                {
                    Console.WriteLine("Error: Precio de compra invalido. Ingrese un valor numerico positivo.");
                }
            }

            // Solicitar y validar el Costo de Alimentación
            bool costoValido = false;
            while (!costoValido)
            {
                Console.Write("Costo de Alimentacion: ");
                string costoStr = Console.ReadLine();
                if (decimal.TryParse(costoStr, out costoAlim) && costoAlim > 0)
                {
                    costoValido = true;
                }
                else
                {
                    Console.WriteLine("Error: Costo de alimentación invalido. Ingrese un valor numerico positivo.");
                }
            }
            // Solicitar y validar el Peso
            bool pesoValido = false;
            while (!pesoValido)
            {
                Console.Write("Peso: ");
                if (!decimal.TryParse(Console.ReadLine(), out peso) || peso <= 0)
                {
                    Console.WriteLine("Error: Peso invalido. Ingrese un valor numerico positivo.");
                }
                else
                {
                    pesoValido = true;
                }
            }
            // Solicitar y validar si es híbrido
            bool hibridoValido = false;
            while (!hibridoValido)
            {
                Console.Write("¿Es hibrido? (true/false): ");
                if (!bool.TryParse(Console.ReadLine(), out hibrido))
                {
                    Console.WriteLine("Error: Valor de hibrido invalido. Ingrese 'true' o 'false'.");
                }
                else
                {
                    hibridoValido = true;
                }
            }
            
            Bovino nuevoBovino = new Bovino(tipoAlimento, codigo, genero, raza, fechaNc, precioCompra, costoAlim, peso, hibrido);

            // Agregar el nuevo bovino a la lista de animales en el sistema
            unS.AgregarAnimal(nuevoBovino);
            Console.ReadLine();
        }
    }
}


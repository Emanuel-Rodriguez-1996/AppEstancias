using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Dominio
{
    public class Ovino : Animal
    {
        int kgLana;
        static int precioLana = 1500;
        static int preciokgOvino = 500;

        public int KgLana { get => kgLana; set => kgLana = value; }
        public static int PrecioLana { get => precioLana; set => precioLana = value; }
        public static int PrecioKgOvino { get => preciokgOvino; set => preciokgOvino = value; }

        public Ovino () : base()
        {

        }

        public Ovino(int kgLana, string codigo, Sexo genero, string raza, DateTime fechaNc, int precioCompra, int costoAlim, int peso, bool hibrido, List<AdministracionVacuna> vacunas, Potrero potrero) :
    base(codigo, genero, raza, fechaNc, precioCompra, costoAlim, peso, hibrido, vacunas, potrero)
        {
            KgLana = kgLana;
            Vacunas = new List<AdministracionVacuna>();
            Potrero = potrero; 
        }


        public override int PrecioVenta()
        {
            int total = (kgLana * precioLana) + (preciokgOvino * Peso);
            if(Hibirido)
            {
                total -= (int)(total * 0.05);
            }
            return total;
        }

        public override string ToString()
        {
            return $"{base.ToString()}Peso de lana: {KgLana}";
        }
    }
}

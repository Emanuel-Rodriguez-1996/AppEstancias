using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Dominio.Animal;

namespace Dominio
{
    public class Bovino : Animal
    {
        public enum TipoAlim { Grano, Pastura }
        TipoAlim alimento;
        static int preciokg = 700;

        public TipoAlim Alimento { get => alimento; set => alimento = value; }
        public static int Preciokg { get => preciokg; set => preciokg = value; }

        public Bovino() : base()
        {

        }

        public Bovino(TipoAlim alimento, string codigo, Sexo genero, string raza, DateTime fechaNc, int precioCompra, int costoAlim, int peso, bool hibrido, List<AdministracionVacuna> vacunas, Potrero potrero) :
    base(codigo, genero, raza, fechaNc, precioCompra, costoAlim, peso, hibrido, vacunas, potrero)
        {
            Alimento = alimento;
            Vacunas = new List<AdministracionVacuna>();
            Potrero = potrero; 
        }

        public override int PrecioVenta()
        {
           int total = Peso * Preciokg;
           
           if(Alimento == TipoAlim.Grano)
            {
                total += (int)(total * 0.30);
            }
            if (Genero == Sexo.Hembra)
            {
                total += (int)(total * 0.10);
            }
            return total;
        }
        public override string ToString()
        {
            return $"{base.ToString()}\n Se alimenta a {Alimento}";
        }
    }
}

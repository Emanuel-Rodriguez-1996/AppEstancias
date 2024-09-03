using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public abstract class Animal
    {
        string? codigo;
        public enum Sexo { Macho, Hembra };
        Sexo genero;
        string? raza;
        DateTime fechaNac;
        int precioCompra;
        int costoAlim;
        int peso;
        bool hibirido;
        List<AdministracionVacuna> listVacunas = new List<AdministracionVacuna>();
        Potrero potrero = null;

        public string? Codigo { get => codigo; set => codigo = value; }
        public Sexo Genero { get => genero; set => genero = value; }
        public string? Raza { get => raza; set => raza = value; }
        public DateTime FechaNac { get => fechaNac; set => fechaNac = value; }
        public int PrecioCompra { get => precioCompra; set => precioCompra = value; }
        public int CostoAlim { get => costoAlim; set => costoAlim = value; }
        public int Peso { get => peso; set => peso = value; }
        public bool Hibirido { get => hibirido; set => hibirido = value; }
        public List<AdministracionVacuna> Vacunas { get => listVacunas; set => listVacunas = value; }
        public Potrero Potrero { get => potrero; set => potrero = value; }

        public Animal()
        {

        }

        public Animal(string? codigo, Sexo genero, string? raza, DateTime fechaNac, int precioCompra, int costoAlim, int peso, bool hibirido, List<AdministracionVacuna> vacunas, Potrero potrero)
        {
            Codigo = codigo;
            Genero = genero;
            Raza = raza;
            FechaNac = fechaNac;
            PrecioCompra = precioCompra;
            CostoAlim = costoAlim;
            Peso = peso;
            Hibirido = hibirido;
            Vacunas = vacunas ?? new List<AdministracionVacuna>();
            Potrero = potrero;
        }
        public void Validar()
        {
            if (Codigo?.Length != 8)
            {
                throw new Exception("Código inválido: debe tener exactamente 8 caracteres alfanuméricos.");
            }
            if (Genero == null)
            {
                throw new Exception("El género no puede ser nulo.");
            }

            if (Raza == null)
            {
                throw new Exception("La raza no puede ser nula.");
            }

            if (FechaNac == null)
            {
                throw new Exception("La fecha de nacimiento no puede ser nula.");
            }
            if (PrecioCompra == null)
            {
                throw new Exception("El precio de compra no puede ser nulo.");
            }
            if (CostoAlim == null)
            {
                throw new Exception("El costo de alimentación no puede ser nulo.");
            }
            if (Peso == null)
            {
                throw new Exception("El peso no puede ser nulo.");
            }
            if (Hibirido == null)
            {
                throw new Exception("El atributo hibrido no puede ser nulo.");
            }
        }
        public abstract int PrecioVenta();
      
        public virtual int CostoCrianza()
        {
            int total;
            total = PrecioCompra + CostoAlim;
            if (Vacunas.Count > 0)
            {
                total = Vacunas.Count * 200;
            }
            return total;
        }
         public bool ValidarEdad()
         {
            return DateTime.Now >= FechaNac.AddMonths(3);
         }
        public override bool Equals(object? obj)
        {
            return obj is Animal animal &&
                codigo == animal.Codigo;    
        }
        public override string ToString()
        {
            return $"N° Caravana: {Codigo}, Raza: {Raza}, Peso: {Peso}, Sexo: {Genero}";
        }

    }
}

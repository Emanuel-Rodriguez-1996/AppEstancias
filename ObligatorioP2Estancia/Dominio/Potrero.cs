using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Potrero
    {
        int id;
        static int ultimoId = -1;
        string? descripcion;
        decimal hectareas;
        int capMax;
        List<Animal> animales = new List<Animal>();

        public int Id { get => id; set => id = value; }
        public static int UltimoId { get => ultimoId; set => ultimoId = value; }
        public string? Descripcion { get => descripcion; set => descripcion = value; }
        public decimal Hectareas { get => hectareas; set => hectareas = value; }
        public int CapMax { get => capMax; set => capMax = value; }
        public List<Animal> Animales { get => animales; set => animales = value; }
        
        public Potrero()
        {

        }

        public Potrero( string? descripcion, decimal hectareas, int capMax)
        {
            Id = ++ultimoId;
            Descripcion = descripcion;
            Hectareas = hectareas;
            CapMax = capMax;
        }

        public int Ganancias()
        {
            int gananciasTotales = 0;

            foreach (Animal animal in Animales)
            {
                gananciasTotales += animal.PrecioVenta() - animal.CostoCrianza();
            }

            return gananciasTotales;
        }
        public void AsignarAnimal(Animal animal, Potrero unP)
        {
            if(animales.Count >= capMax)
            {
                throw new Exception($"Capacidad del potrero {id}. alcanzada.");
            }
            if (animal.Potrero != null) 
            {
                throw new Exception($"El animal {animal.Codigo} ya está asignado a un potrero y no puede ser movido.");   
            }
            animal.Potrero = unP;
            unP.animales.Add(animal);
            throw new Exception($"El animal {animal.Codigo} ha sido asignado al potrero {id}.");
        }
        public int ContarAnimales()
        {
           return Animales.Count;
        }
        public override string ToString()
        {
            return $"Potrero ID: {id}\n Descripción: {descripcion}\n Animales Asignados: {animales.Count}";
        }

    }
}

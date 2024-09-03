using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Vacuna
    {
        string? nombre;
        string? descripcion;
        string? patogeno;

        public string? Nombre { get => nombre; set => nombre = value; }
        public string? Descripcion { get => descripcion; set => descripcion = value; }
        public string? Patogeno { get => patogeno; set => patogeno = value; }
        public Vacuna() 
        {

        }
        public Vacuna(string? nombre, string? descripcion, string? patogeno)
        {
            Nombre = nombre;
            Descripcion = descripcion;
            Patogeno = patogeno;
        }

        public override string ToString()
        {
            return $"Nombre {Nombre}, Descripcion: {Descripcion}, Patogeno que previene: {Patogeno}";
        }
    }
}

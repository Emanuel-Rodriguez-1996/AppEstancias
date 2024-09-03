using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Tarea
    {
        int id;
        static int ultimoId = 0;
        string? descripcion;
        DateTime fechaInicio;
        bool completa;
        DateTime fechaFin;
        string? comentario;

        public int Id { get => id; set => id = value; }
        public static int UltimoId { get => ultimoId; set => ultimoId = value; }
        public string? Descripcion { get => descripcion; set => descripcion = value; }
        public DateTime FechaInicio { get => fechaInicio; set => fechaInicio = value; }
        public bool Completa { get => completa; set => completa = value; }
        public DateTime FechaFin { get => fechaFin; set => fechaFin = value; }
        public string? Comentario { get => comentario; set => comentario = value; }

        public Tarea()
        {

        }

        public Tarea(string? descripcion, DateTime fechaInicio, bool completa, DateTime fechaFin, string? comentario)
        {
            Id = ++ultimoId;
            Descripcion = descripcion;
            FechaInicio = fechaInicio;
            Completa = completa;
            FechaFin = fechaFin;
            Comentario = comentario;
        }

        public override bool Equals(object? obj)
        {
            return obj is Tarea tarea &&
                Id == tarea.Id;
        }
        public override string ToString()
        {
            return $"Tarea Descripcion: {Descripcion}\nFecha Inicio: {FechaInicio}\nCompleta{Completa}\nFecha fin: {FechaFin}\nComentario : {Comentario} ";
        }
    }
}

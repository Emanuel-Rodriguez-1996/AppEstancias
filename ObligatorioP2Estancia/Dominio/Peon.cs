using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Dominio
{
    public class Peon : Empleado
    {
        bool residente;
        List<Tarea> listTareas = new List<Tarea>();
       

        public List<Tarea> Tareas { get => listTareas; set => listTareas = value; }
        public bool Residente { get => residente; set => residente = value; }

        public Peon () : base ()
        {

        }

        public Peon(bool residente, string email, string contraseña, string nombre, DateTime fechaIngreso) :
            base (email, contraseña, nombre, fechaIngreso) 
        {
            
            Residente = residente;
        }
        public override void AsignarTarea(Tarea tarea)
        {
                Tareas.Add(tarea); 
        }

        public override string ToString()
        {
            return $"{base.ToString()} Residente : {Residente}";
        }



    }
}

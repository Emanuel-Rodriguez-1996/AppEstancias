using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Capataz : Empleado
    {

        List<Peon> listPeones = new List<Peon>();
        int cantPersonasACargo = 0;
        public List<Peon> PeonACargo { get => listPeones; set => listPeones = value; }
        public int CantPersonasACargo{ get => cantPersonasACargo; set => cantPersonasACargo = value; }

        public Capataz () : base () 
        { 

        } 

        public Capataz(int cantPersonasACargo, string? email, string? contraseña, string? nombre, DateTime fechaIngreso): 
            base( email, contraseña, nombre, fechaIngreso)
        {
            CantPersonasACargo = cantPersonasACargo;
        }

       
        public int ContarPeones(List<Peon> peones) 
        { 
            return cantPersonasACargo = peones.Count;
        }
        public override string ToString()
        {
            
            return $"{base.ToString()} Cantidad de personas a cargo: {cantPersonasACargo}";
        }
    }
}


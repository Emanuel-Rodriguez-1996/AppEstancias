using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Dominio
{
    public class Empleado
    {
        string? email;
        string? contraseña;
        string? nombre;
        DateTime fechaIngreso;
        public string? Email { get => email; set => email = value; }
        public string? Contraseña
        {
            get => contraseña;
            set
            {
                if (value?.Length < 3) 
                {
                    throw new ArgumentException("La contraseña debe tener al menos 3 caracteres.");

                }
                contraseña = value;
            }
        }
        public string? Nombre { get => nombre; set => nombre = value; }
        public DateTime FechaIngreso { get => fechaIngreso; set => fechaIngreso = value; }

        public Empleado()
        {

        }
        public Empleado (string? email, string? contraseña, string? nombre, DateTime fechaIngreso)
        {
            Email = email;
            Contraseña = contraseña;
            Nombre = nombre;
            FechaIngreso = fechaIngreso;
        }

        public void Validar()
        {
            if (Email?.Length < 5)
            {
                throw new Exception("Email inválido"); 
            }
            if(Contraseña == null)
            {
                throw new Exception("Ingrese Contraseña");
            }
            if (Nombre == null)
            {
                throw new Exception("Ingrese Nombre");
            }
        }
        public virtual void AsignarTarea(Tarea tarea)
        {
    
        }
        public override bool Equals(object? obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;

            Empleado other = (Empleado)obj;
            return Email == other.Email;
        }

        public override int GetHashCode()
        {
            return Email.GetHashCode();
        }
        public override string ToString()
        {
            return $"Nombre : {Nombre}\n Email : {Email}\n Fecha de ingreso : {FechaIngreso}";
        }
    }
}


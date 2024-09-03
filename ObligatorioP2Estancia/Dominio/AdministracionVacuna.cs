using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class AdministracionVacuna
    {

        Vacuna vacuna = new Vacuna();
        DateTime fechaAdm;
        static DateTime fechaVenc;

        public Vacuna Vacuna { get => vacuna; set => vacuna = value; }
        public DateTime FechaAdm { get => fechaAdm; set => fechaAdm = value; }
        public static DateTime FechaVenc { get => fechaVenc; set => fechaVenc = value; }

        public AdministracionVacuna()
        {

        }
        public AdministracionVacuna( Vacuna vacuna, DateTime fechaAdm) 
        {
            
            Vacuna = vacuna;
            FechaAdm = fechaAdm; 
        }

        public string FechaVencimiento()
        {
            DateTime FechaVenc = fechaAdm.AddYears(1);
            return $"{FechaVenc}";
        }

        public override string ToString()
        {
            DateTime fechaVencimiento = fechaAdm.AddYears(1);
            return $"Tipo de vacuna {Vacuna}\n fecha de vacunacion: {FechaAdm}\n fecha de vencimiento {fechaVencimiento}";
        }
    }

  }
    

    
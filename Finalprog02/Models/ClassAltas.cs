using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Finalprog02.Models
{
    public class ClassAltas
    {

        [Key]
        public int ID_Altas { get; set; }

        public string Nombre_Paciente { get; set; }

        public string Fecha_Ingreso { get; set; }

        public string Fecha_Salida { get; set; }

        public string Habitacion { get; set; }

        public double Monto { get; set; }

        public int ID_Ingreso { get; set; }
        [ForeignKey("ID_Ingreso")]

        public ClassIngresos Ingresos { get; set; }

        public ClassPacientes Pacientes { get; set; }

        public ClassHabitaciones Habitaciones { get; set; }
    }
}
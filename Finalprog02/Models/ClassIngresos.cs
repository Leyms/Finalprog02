using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Finalprog02.Models
{
    public class ClassIngresos
    {
        [Key]
        public int ID_Ingresos { get; set; }

        [Required]
        public int ID_Habitacion { get; set; }
        [ForeignKey("ID_Habitacion")]
        public ClassHabitaciones Habitacion { get; set; }

        [Required]
        public int ID_Paciente { get; set; }
        [ForeignKey("ID_Paciente")]
        public ClassPacientes Pacientes { get; set; }

        [Required]
        public string Fecha_Ingreso { get; set; }
    }
}
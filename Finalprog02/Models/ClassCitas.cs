using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Finalprog02.Models
{
    public class ClassCitas
    {
        [Key]
        public int ID_Citas { get; set; }

        [Required]
        public int ID_Paciente { get; set; }
        [ForeignKey("ID_Paciente")]
        public ClassPacientes Pacientes { get; set; }

        [Required]
        public string Fecha_Cita { get; set; }

        [Required]
        public string Hora_cita { get; set; }

        [Required]
        public int ID_Medico { get; set; }
        [ForeignKey("ID_Medico")]
        public ClassMedicos Medicos { get; set; }
    }
}
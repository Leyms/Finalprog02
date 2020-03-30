using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Finalprog02.Models
{
    public class ClassPacientes
    {
        [Key]
        public int ID_Paciente { get; set; }

        [Required]
        public string Nombre_Paciente { get; set; }

        [Required]
        public string Cedula_Paciente { get; set; }

        [Required]
        public Boolean Asegurado { get; set; }
    }
}
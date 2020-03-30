using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Finalprog02.Models
{
    public class ClassMedicos
    {
        [Key]
        public int ID_Medico { get; set; }

        [Required]
        public string Nombre_Medico { get; set; }

        [Required]
        public string Exequátur_Medico { get; set; }

        [Required]
        public string Especialidad_Medico { get; set; }
    }
}
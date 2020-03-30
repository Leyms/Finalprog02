using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Finalprog02.Models
{
    public class ClassHabitaciones
    {
        [Key]
        public int ID_Habitacion { get; set; }

        [Required]
        public string Num_Habitacion { get; set; }

        [Required]
        public Tipo_Habitacion Tipo_Habitacion { get; set; }

        [Required]
        public int PrecioDia_Habitacion { get; set; }
    }

    public enum Tipo_Habitacion
    {
        Doble, privada, Suite
    }
}
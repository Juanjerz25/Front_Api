using System;
using System.ComponentModel.DataAnnotations;

namespace DojoApplicationWeb.Models
{
    public class RetoModel
    {
        public int Id { get; set; }
        public int DojoId { get; set; }
        [Display(Name = "Nombre Reto")]
        [Required]
        public string Nombre { get; set; }
        [Display(Name = "Tiempo Limite (Dias)")]
        [Required]
        public Nullable<int> DiasTiempoLimite { get; set; }
    }
}

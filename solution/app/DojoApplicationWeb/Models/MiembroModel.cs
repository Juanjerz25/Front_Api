using System.ComponentModel.DataAnnotations;

namespace DojoApplicationWeb.Models
{
    public class MiembroModel
    {
        public int Id { get; set; }
        [Display(Name = "Nombre Miembro")]
        [Required]
        public string Nombre { get; set; }

    }
}

using System.ComponentModel.DataAnnotations;

namespace DojoApplicationWeb.Models
{
    public class DojoModel
    {
        [Display(Name = "Id Dojo")]
        public int Id { get; set; }
        [Display(Name = "Nombre Dojo")]
        [Required]
        public string Nombre { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace DojoApplicationWeb.Models
{
    public class RetoMiembroModel
    {
        public RetoModel RetoModel { get; set; }
        public MiembroModel MiembroModel { get; set; }
        [Display(Name = "Tiempo Limite")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public System.DateTime TiempoLimite { get; set; }
    }
}

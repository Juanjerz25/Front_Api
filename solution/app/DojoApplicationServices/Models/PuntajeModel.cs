using System;

namespace DojoApplicationServices.Models
{
    public class PuntajeModel
    {
        public int Id { get; set; }
        public int RetoMiembroId { get; set; }
        public Nullable<int> PuntajeReto { get; set; }
    }
}

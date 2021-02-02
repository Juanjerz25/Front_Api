using System;

namespace DojoApplicationWeb.Models
{
    public class PuntajeModel
    {
        public int Id { get; set; }
        public int RetoMiembroId { get; set; }
        public Nullable<int> PuntajeReto { get; set; }
    }
}

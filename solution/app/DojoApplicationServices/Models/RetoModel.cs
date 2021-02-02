using System;

namespace DojoApplicationServices.Models
{
    public class RetoModel
    {
        public int Id { get; set; }
        public int DojoId { get; set; }
        public string Nombre { get; set; }
        public Nullable<int> DiasTiempoLimite { get; set; }
    }
}

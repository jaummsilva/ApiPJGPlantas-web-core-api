using System;
using System.Collections.Generic;

namespace apiteste.Models
{
    public partial class Comentario
    {
        public int Id { get; set; }
        public string? Texto { get; set; }
        public int UsuarioId { get; set; }
        public int PlantaId { get; set; }
        public DateTime Dth { get; set; }

        public virtual Planta Planta { get; set; } = null!;
        public virtual Usuario Usuario { get; set; } = null!;
    }
}

using System;
using System.Collections.Generic;

namespace apiteste.Models
{
    public partial class ItemCompra
    {
        public int Id { get; set; }
        public int CompraId { get; set; }
        public int PlantaId { get; set; }
        public int Quantidade { get; set; }
        public DateTime Dth { get; set; }

        public virtual Compra Compra { get; set; } = null!;
        public virtual Planta Planta { get; set; } = null!;
    }
}

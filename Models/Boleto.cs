using System;
using System.Collections.Generic;

namespace apiteste.Models
{
    public partial class Boleto
    {
        public Boleto()
        {
            Compras = new HashSet<Compra>();
        }

        public int Id { get; set; }
        public string? Nome { get; set; }

        public virtual ICollection<Compra> Compras { get; set; }
    }
}

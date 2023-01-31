using System;
using System.Collections.Generic;

namespace apiteste.Models
{
    public partial class Pix
    {
        public Pix()
        {
            Compras = new HashSet<Compra>();
        }

        public int Id { get; set; }
        public string? Cnpj { get; set; }
        public string? Email { get; set; }
        public string? Banco { get; set; }

        public virtual ICollection<Compra> Compras { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace apiteste.Models
{
    public partial class Cartao
    {
        public Cartao()
        {
            Compras = new HashSet<Compra>();
        }

        public int Id { get; set; }
        public string NomeTitular { get; set; } = null!;
        public string Validade { get; set; } = null!;
        public string Cvv { get; set; } = null!;
        public string Numero { get; set; } = null!;
        public int UsuarioId { get; set; }

        public virtual Usuario Usuario { get; set; } = null!;
        public virtual ICollection<Compra> Compras { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace apiteste.Models
{
    public partial class Usuario
    {
        public Usuario()
        {
            Cartaos = new HashSet<Cartao>();
            Comentarios = new HashSet<Comentario>();
            Compras = new HashSet<Compra>();
        }

        public int Id { get; set; }
        public string? Nome { get; set; }
        public string? Email { get; set; }
        public string? Cpf { get; set; }

        public virtual ICollection<Cartao> Cartaos { get; set; }
        public virtual ICollection<Comentario> Comentarios { get; set; }
        public virtual ICollection<Compra> Compras { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace apiteste.Models
{
    public partial class Planta
    {
        public Planta()
        {
            Comentarios = new HashSet<Comentario>();
            ItemCompras = new HashSet<ItemCompra>();
        }

        public int Id { get; set; }
        public string? Nome { get; set; }
        public double Preco { get; set; }
        public string? Descricao { get; set; }

        public virtual ICollection<Comentario> Comentarios { get; set; }
        public virtual ICollection<ItemCompra> ItemCompras { get; set; }
    }
}

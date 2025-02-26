using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFramework2.Shared.Entities
{
    public partial class Categoria
    {
        public int CategoriaId { get; set; }

        public string Nombre { get; set; } = null!;

        public virtual ICollection<Subcategoria> Subcategoria { get; set; } = new List<Subcategoria>();
    }
}

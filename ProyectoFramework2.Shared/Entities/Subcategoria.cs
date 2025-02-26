using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFramework2.Shared.Entities
{
    public partial class Subcategoria
    {
        public int SubcategoriaId { get; set; }

        public int? CategoriaId { get; set; }

        public string Nombre { get; set; } = null!;

        public virtual Categoria? Categoria { get; set; }

        public virtual ICollection<Habito> Habitos { get; set; } = new List<Habito>();
    }
}

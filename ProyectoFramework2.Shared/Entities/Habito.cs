using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFramework2.Shared.Entities
{
    public partial class Habito
    {
        public int HabitoId { get; set; }

        public int? SubcategoriaId { get; set; }

        public string? Meta { get; set; }

        public int? Duracion { get; set; }

        public string? Color { get; set; }

        public string? Frecuencia { get; set; }

        public virtual Subcategoria? Subcategoria { get; set; }
    }
}

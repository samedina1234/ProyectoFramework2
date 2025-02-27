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

        public DateOnly FechaCreacion { get; set; }

        public DateOnly? Meta { get; set; }

        public int? Duracion { get; set; }

        public string? Color { get; set; }

        public string? Frecuencia { get; set; }

        public virtual ICollection<RegistroHabito> RegistroHabitos { get; set; } = new List<RegistroHabito>();

        public virtual Subcategoria? Subcategoria { get; set; }
    }
}

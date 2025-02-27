using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFramework2.Shared.Entities
{
    public partial class RegistroHabito
    {
        public int HabitoId { get; set; }

        public int UsuarioId { get; set; }

        public DateOnly FechaCompletado { get; set; }

        public DateOnly? FechaCreacionHabito { get; set; }

        public int VecesCompletado { get; set; }

        public bool EstadoHabito { get; set; }

        public virtual Habito Habito { get; set; } = null!;

        public virtual Usuario Usuario { get; set; } = null!;
    }
}

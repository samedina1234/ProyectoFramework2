using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFramework2.Shared.Entities
{
    public partial class RegistroHabito
    {
        public int IdRegistro { get; set; }

        public int IdHabito { get; set; }

        public DateOnly? Fecha { get; set; }

        public string? Estado { get; set; }

        public virtual Habito IdHabitoNavigation { get; set; } = null!;
    }
}

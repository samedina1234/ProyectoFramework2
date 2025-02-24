using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFramework2.Shared.Entities
{
    public partial class Habito
    {
        public int IdHabito { get; set; }

        public int IdUsuario { get; set; }

        public string Titulo { get; set; } = null!;

        public string? Descripcion { get; set; }

        public string? Duracion { get; set; }

        public string? Tipo { get; set; }

        public string? Color { get; set; }

        public DateTime? FechaCreacion { get; set; }

        public string? Estado { get; set; }

        public string? Frecuencia { get; set; }

        public string? Meta { get; set; }

        public int? Progreso { get; set; }

        public string? HoraDia { get; set; }

        public string? Ubicacion { get; set; }

        public string? Motivacion { get; set; }

        public int? Dificultad { get; set; }

        public int? Satisfaccion { get; set; }

        public string? Notas { get; set; }

        public DateTime? FechaUltimaRealizacion { get; set; }

        public virtual Usuario IdUsuarioNavigation { get; set; } = null!;

        public virtual ICollection<RegistroHabito> RegistroHabitos { get; set; } = new List<RegistroHabito>();
    }
}

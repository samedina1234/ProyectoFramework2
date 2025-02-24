using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFramework2.Shared.Entities
{
    public partial class Usuario
    {
        public int IdUsuario { get; set; }

        public string NombreCompleto { get; set; } = null!;

        public string Correo { get; set; } = null!;

        public string Contraseña { get; set; } = null!;

        public string? Genero { get; set; }

        public int? Edad { get; set; }

        public DateTime? FechaRegistro { get; set; }

        public bool? DarkMode { get; set; }

        public virtual ICollection<Habito> Habitos { get; set; } = new List<Habito>();
    }
}

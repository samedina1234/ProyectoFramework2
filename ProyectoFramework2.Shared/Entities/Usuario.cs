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

        public DateOnly? FechaNacimiento { get; set; }

        public string Correo { get; set; } = null!;

        public string Contraseña { get; set; } = null!;

        public string? Apodo { get; set; }

        public string? Genero { get; set; }

        public DateOnly? FechaRegistro { get; set; }

        public bool Estado { get; set; }
    }
}

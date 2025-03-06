using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFramework2.Shared.Entities
{
    public class UsuarioUpdateDto
    {
        public string Apodo { get; set; }
        public DateOnly? FechaNacimiento { get; set; }
        public string Correo { get; set; }
        public string Genero { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFramework2.Shared.Entities
{
    public partial class Usuario
    {
        public int IdUsuario { get; set; }

        [StringLength(100, MinimumLength = 6, ErrorMessage = "El nombre completo debe tener al menos 3 caracteres.")]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "El nombre completo solo puede contener letras y espacios.")]
        public string NombreCompleto { get; set; } = null!;

        [MayorDeEdad(18, ErrorMessage = "Debe ser mayor de 18 años para registrarse.")]
        public DateOnly? FechaNacimiento { get; set; }

        [RegularExpression(@"^[a-zA-Z0-9.]+@[a-zA-Z0-9.]+\.[a-zA-Z]{2,}$", ErrorMessage = "El formato del correo electrónico no es válido.")]
        public string Correo { get; set; } = null!;

        [StringLength(100, MinimumLength = 8, ErrorMessage = "La contraseña debe tener al menos 8 caracteres.")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[!@#$]).{8,}$",
        ErrorMessage = "La contraseña debe contener al menos una letra mayúscula, una letra minúscula, un número y un carácter especial permitido (!@#$).")]
        public string Contraseña { get; set; } = null!;

        [StringLength(100, MinimumLength = 8, ErrorMessage = "Su NickName o Apodo debe tener al menos 8 caracteres.")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?:.*[!@#$])?.{8,}$",
        ErrorMessage = "Su NickName o Apodo debe contener al menos una letra mayúscula, una letra minúscula, un número y, opcionalmente, un carácter especial permitido (!@#$).")]
        public string? Apodo { get; set; }

        public string? Genero { get; set; }

        public DateOnly FechaRegistro { get; set; }

        public bool Estado { get; set; }

        public virtual ICollection<RegistroHabito> RegistroHabitos { get; set; } = new List<RegistroHabito>();
    }

    public class MayorDeEdadAttribute : ValidationAttribute
    {
        private readonly int _edadMinima;

        public MayorDeEdadAttribute(int edadMinima)
        {
            _edadMinima = edadMinima;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value is DateOnly fechaNacimiento)
            {
                var dateTimeFechaNacimiento = fechaNacimiento.ToDateTime(TimeOnly.MinValue); // Convertir DateOnly a DateTime
                var edad = CalcularEdad(dateTimeFechaNacimiento);
                if (edad < _edadMinima)
                {
                    return new ValidationResult(ErrorMessage);
                }
            }
            return ValidationResult.Success;
        }

        private int CalcularEdad(DateTime fechaNacimiento)
        {
            var hoy = DateTime.Today;
            var edad = hoy.Year - fechaNacimiento.Year;
            if (fechaNacimiento.Date > hoy.AddYears(-edad)) edad--;
            return edad;
        }
    }
}


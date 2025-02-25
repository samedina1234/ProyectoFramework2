using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoFramework2.Data;
using ProyectoFramework2.Shared.Entities;

namespace ProyectoFramework2.Controller
{
    [Route("api/auth")] // Cambiamos la ruta a /api/auth
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly HabitosDbContext _context;

        public AuthController(HabitosDbContext context)
        {
            _context = context;
        }

        [HttpPost("login")] // Endpoint para el login
        public async Task<ActionResult<Usuario>> Login([FromBody] LoginRequest request)
        {
            var usuario = await _context.Usuarios.FirstOrDefaultAsync(u => u.Correo == request.Correo && u.Contraseña == request.Contraseña);

            if (usuario == null)
            {
                return Unauthorized("Credenciales incorrectas"); // Devuelve 401 si las credenciales son incorrectas
            }

            return Ok(usuario);
        }

        public class LoginRequest // Clase para manejar la peticion de login
        {
            public required string Correo { get; set; }
            public required string Contraseña { get; set; }
        }
    }
}

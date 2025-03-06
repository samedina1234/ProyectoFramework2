using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoFramework2.Client.Pages;
using ProyectoFramework2.Data;
using ProyectoFramework2.Shared.Entities;

namespace ProyectoFramework2.Controller
{
    [Route("api/auth")] // Cambiamos la ruta a /api/auth
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ContraseñaHash _passwordHasher;
        private readonly HabitosContext _context;
        private readonly ILogger<AuthController> _logger;

        public AuthController(HabitosContext context, ContraseñaHash passwordHasher, ILogger<AuthController> logger)
        {
            _passwordHasher = passwordHasher;
            _context = context;
            _logger = logger;
        }

        [HttpPost("login")] // Endpoint para el login
        public async Task<ActionResult<Usuario>> Login([FromBody] LoginRequest request)
        {
            var usuario = await _context.Usuarios.FirstOrDefaultAsync(u => u.Correo == request.Correo);
            if (usuario != null && _passwordHasher.VerifyPassword(request.Contraseña, usuario.Contraseña))
            {
                //_logger.LogInformation("Usuario encontrado: {@Usuario}", usuario); // Usar el logger
                return Ok(usuario);
            }
            return Unauthorized("Credenciales incorrectas");
        }

        public class LoginRequest // Clase para manejar la peticion de login
        {
            public required string Correo { get; set; }
            public required string Contraseña { get; set; }
        }
    }
}

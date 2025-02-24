using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoFramework2.Data;
using ProyectoFramework2.Shared.Entities;

namespace ProyectoFramework2.Controller
{
    [Route("api/usuario")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly HabitosDbContext _context;

        public UsuarioController(HabitosDbContext context)
        {
            _context = context;
        }

        [HttpGet("{id}")] // Agrega un parámetro 'id' a la ruta
        public async Task<ActionResult<Usuario>> GetUsuarioByIdAsync(int id)
        {
            var usuario = await _context.Usuarios.FindAsync(id);

            if (usuario == null)
            {
                return NotFound(); // Devuelve 404 si el usuario no se encuentra
            }

            return usuario;
        }
    }
}

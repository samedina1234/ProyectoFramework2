using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
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
        private readonly HabitosContext _context;

        public UsuarioController(HabitosContext context)
        {
            _context = context;
        }

        [HttpGet("{id}")] // Extraer el usuario por su id
        public async Task<ActionResult<Usuario>> GetUsuarioByIdAsync(int id)
        {
            var usuario = await _context.Usuarios.FindAsync(id);

            if (usuario == null)
            {
                return NotFound("Usuario No Existe"); // Devuelve 404 si el usuario no se encuentra
            }

            return usuario;
        }

        [HttpPut("{id}")] // Actualizar un usuario por su id
        public async Task<ActionResult<Usuario>> UpdateUsuarioAsync(int id, Usuario updatedUsuario)
        {
            var dbUsuario = await _context.Usuarios.FindAsync(id);

            if (dbUsuario == null)
            {
                return NotFound("No se encontro el Usuario"); // Devuelve 404 si el usuario no se encuentra
            }

            dbUsuario.Apodo = updatedUsuario.Apodo;
            dbUsuario.Correo = updatedUsuario.Correo;
            dbUsuario.Genero = updatedUsuario.Genero;
            dbUsuario.FechaNacimiento = updatedUsuario.FechaNacimiento;

            await _context.SaveChangesAsync();

            return Ok(dbUsuario);
        }

        [HttpPost] // Crear un usuario
        public async Task<ActionResult<Usuario>> AddUsuarioAsync(Usuario newUsuario)
        {
            _context.Add(newUsuario);
            await _context.SaveChangesAsync();

            return Ok(newUsuario);
        }
    }
}
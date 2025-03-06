using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoFramework2.Client.Pages;
using ProyectoFramework2.Data;
using ProyectoFramework2.Shared.Entities;

namespace ProyectoFramework2.Controller
{
    [Route("api/usuario")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly ContraseñaHash _passwordHasher;
        private readonly HabitosContext _context;

        public UsuarioController(HabitosContext context, ContraseñaHash passwordHasher)
        {
            _passwordHasher = passwordHasher;
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
        public async Task<ActionResult<Usuario>> UpdateUsuarioAsync(int id, UsuarioUpdateDto updatedUsuarioDto)
        {
            var dbUsuario = await _context.Usuarios.FindAsync(id);

            if (dbUsuario == null)
            {
                return NotFound("No se encontro el Usuario");
            }

            dbUsuario.Apodo = updatedUsuarioDto.Apodo;
            dbUsuario.Correo = updatedUsuarioDto.Correo;
            dbUsuario.Genero = updatedUsuarioDto.Genero;
            dbUsuario.FechaNacimiento = updatedUsuarioDto.FechaNacimiento;

            await _context.SaveChangesAsync();

            return Ok(dbUsuario);
        }

        [HttpPost("registro")] // Crear un usuario


        public async Task<ActionResult<Usuario>> AddUsuarioAsync(Usuario newUsuario)
        {
            //_context.Add(newUsuario);
            //await _context.SaveChangesAsync();
            //return Ok(newUsuario);

            try
            {
                newUsuario.Contraseña = _passwordHasher.HashPassword(newUsuario.Contraseña);
                _context.Usuarios.Add(newUsuario);
                await _context.SaveChangesAsync();
                return Ok(newUsuario);
            }
            catch (DbUpdateException ex)
            {
                // Manejar errores de base de datos (por ejemplo, restricciones de unicidad)
                // Registra el error en los logs
                return BadRequest("Error al guardar el usuario: " + ex.Message);
            }
            catch (Exception ex)
            {
                // Manejar otros errores
                // Registra el error en los logs
                return StatusCode(500, "Error interno del servidor: " + ex.Message);
            }
        }

    }
}
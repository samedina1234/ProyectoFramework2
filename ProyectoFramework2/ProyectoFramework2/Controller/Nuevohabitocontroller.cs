
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoFramework2.Data;
using ProyectoFramework2.Shared.Entities;

namespace ProyectoFramework2.Controller
{
    [Route("api/new-habito")]
    [ApiController]
    public class Nuevohabitocontroller : ControllerBase
    {
        private readonly HabitosContext _context;

        public Nuevohabitocontroller(HabitosContext context)
        {
            _context = context;
        }

        [HttpPost("categoria")]
        public async Task<ActionResult<Categoria>> CrearCategoria([FromBody] Categoria categoria)
        {
            if (string.IsNullOrEmpty(categoria.Nombre))
            {
                return BadRequest("Nombre de categoría no puede estar vacío.");
            }

            _context.Categorias.Add(categoria);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(CrearCategoria), new { id = categoria.CategoriaId }, categoria);
        }

        [HttpPost("subcategoria")]
        public async Task<ActionResult<Subcategoria>> CrearSubcategoria([FromBody] Subcategoria subcategoria)
        {
            if (string.IsNullOrEmpty(subcategoria.Nombre))
            {
                return BadRequest("Nombre de subcategoría no puede estar vacío.");
            }

            if (!_context.Categorias.Any(c => c.CategoriaId == subcategoria.CategoriaId))
            {
                return BadRequest("CategoriaId no existe.");
            }

            _context.Subcategorias.Add(subcategoria);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(CrearSubcategoria), new { id = subcategoria.SubcategoriaId }, subcategoria);
        }

        [HttpPost("habito")]
        public async Task<ActionResult<Habito>> CrearHabito([FromBody] Habito habito)
        {
            try
            {

                _context.Habitos.Add(habito);
                await _context.SaveChangesAsync();

                return CreatedAtAction(nameof(CrearHabito), new { id = habito.HabitoId }, habito);
            }
            catch (DbUpdateException ex)
            {
                // Manejar errores específicos de la base de datos
                Console.WriteLine($"Error al guardar el hábito: {ex.Message} - {ex.StackTrace}");
                return StatusCode(500, "Error al guardar el hábito en la base de datos.");
            }
            catch (Exception ex)
            {
                // Manejar otros errores
                Console.WriteLine($"Error inesperado al crear el hábito: {ex.Message} - {ex.StackTrace}");
                return StatusCode(500, "Error interno del servidor.");
            }
        }

        [HttpGet("subcategorias")]
        public async Task<ActionResult<IEnumerable<Subcategoria>>> GetSubcategorias()
        {
            return await _context.Subcategorias.ToListAsync();
        }
    }
}


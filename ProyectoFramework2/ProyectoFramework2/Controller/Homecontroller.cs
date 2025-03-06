using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoFramework2.Data;
using ProyectoFramework2.Shared.Entities;

namespace ProyectoFramework2.Controller
{
    [Route("api/home")]

    [ApiController]
    public class Homecontroller : ControllerBase
    {

        private readonly HabitosContext _context; // O ApplicationDbContext si aplica

        public Homecontroller(HabitosContext context) // O ApplicationDbContext si aplica
        {
            _context = context;
        }

        [HttpGet("subcategoriaspro")]

        public async Task<ActionResult<List<Subcategoria>>> GetSubcategorias()
        {
            var subcategorias = await _context.Subcategorias.ToListAsync();
            return Ok(subcategorias);
        }

    }
}
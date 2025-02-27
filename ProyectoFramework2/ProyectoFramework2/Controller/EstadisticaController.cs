using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoFramework2.Data;
using ProyectoFramework2.Shared.Entities;

namespace ProyectoFramework2.Controller
{
    [Route("api/estadisticas")]
    [ApiController]
    public class EstadisticaController : ControllerBase
    {
        private readonly HabitosContext _context;

        public EstadisticaController(HabitosContext context)
        {
            _context = context;
        }

        // Obtener hábitos completados por usuario
        [HttpGet("usuario/{usuarioId}")]
        public async Task<ActionResult<IEnumerable<RegistroHabito>>> GetHabitosCompletadosPorUsuario(int usuarioId)
        {
            var registros = await _context.RegistroHabitos
                .Where(r => r.UsuarioId == usuarioId)
                .ToListAsync();

            return registros;
        }

        // Obtener hábitos completados en un rango de fechas
        [HttpGet("fechas/{fechaInicio}/{fechaFin}")]
        public async Task<ActionResult<IEnumerable<RegistroHabito>>> GetHabitosCompletadosPorFecha(DateTime fechaInicio, DateTime fechaFin)
        {
            var registros = await _context.RegistroHabitos
                .Where(r => r.FechaCompletado >= DateOnly.FromDateTime(fechaInicio) && r.FechaCompletado <= DateOnly.FromDateTime(fechaFin))
                .ToListAsync();

            return registros;
        }

        // Contar cuantas veces se completó un habito por usuario.
        [HttpGet("conteo/{usuarioId}/{habitoId}")]
        public async Task<ActionResult<int>> GetConteoHabito(int usuarioId, int habitoId)
        {
            var conteo = await _context.RegistroHabitos
                .Where(r => r.UsuarioId == usuarioId && r.HabitoId == habitoId)
                .SumAsync(r => r.VecesCompletado);

            return conteo;
        }
    }
}

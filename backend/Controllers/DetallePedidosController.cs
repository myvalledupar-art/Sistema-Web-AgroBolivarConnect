using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using backend.Data;
using backend.Models;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DetallePedidosController : ControllerBase
    {
        private readonly AgroBolivarContext _context;
        public DetallePedidosController(AgroBolivarContext context) { _context = context; }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DetallePedido>>> GetDetallePedidos() => await _context.DetallePedidos.ToListAsync();

        [HttpGet("{id}")]
        public async Task<ActionResult<DetallePedido>> GetDetallePedido(int id)
        {
            var d = await _context.DetallePedidos.FindAsync(id);
            if (d == null) return NotFound();
            return d;
        }

        [HttpPost]
        public async Task<ActionResult<DetallePedido>> PostDetallePedido(DetallePedido detalle)
        {
            _context.DetallePedidos.Add(detalle);
            await _context.SaveChangesAsync();
            return Ok(detalle);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutDetallePedido(int id, DetallePedido detalle)
        {
            _context.Entry(detalle).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDetallePedido(int id)
        {
            var d = await _context.DetallePedidos.FindAsync(id);
            if (d == null) return NotFound();
            _context.DetallePedidos.Remove(d);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
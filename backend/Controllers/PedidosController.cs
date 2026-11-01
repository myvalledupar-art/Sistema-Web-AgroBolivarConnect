using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using backend.Data;
using backend.Models;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidosController : ControllerBase
    {
        private readonly AgroBolivarContext _context;
        public PedidosController(AgroBolivarContext context) { _context = context; }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pedido>>> GetPedidos() => await _context.Pedidos.ToListAsync();

        [HttpGet("{id}")]
        public async Task<ActionResult<Pedido>> GetPedido(int id)
        {
            var p = await _context.Pedidos.FindAsync(id);
            if (p == null) return NotFound();
            return p;
        }

        [HttpPost]
        public async Task<ActionResult<Pedido>> PostPedido(Pedido pedido)
        {
            _context.Pedidos.Add(pedido);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetPedido), new { id = pedido.IdPedido }, pedido);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutPedido(int id, Pedido pedido)
        {
            if (id != pedido.IdPedido) return BadRequest();
            _context.Entry(pedido).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePedido(int id)
        {
            var p = await _context.Pedidos.FindAsync(id);
            if (p == null) return NotFound();
            _context.Pedidos.Remove(p);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
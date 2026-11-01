using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using backend.Data;
using backend.Models;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompradoresController : ControllerBase
    {
        private readonly AgroBolivarContext _context;

        public CompradoresController(AgroBolivarContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Comprador>>> GetCompradores()
        {
            return await _context.Compradores.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Comprador>> GetComprador(int id)
        {
            var comprador = await _context.Compradores.FindAsync(id);
            if (comprador == null) return NotFound();
            return comprador;
        }

        [HttpPost]
        public async Task<ActionResult<Comprador>> PostComprador(Comprador comprador)
        {
            _context.Compradores.Add(comprador);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetComprador), new { id = comprador.IdComprador }, comprador);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutComprador(int id, Comprador comprador)
        {
            if (id != comprador.IdComprador) return BadRequest();
            _context.Entry(comprador).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteComprador(int id)
        {
            var comprador = await _context.Compradores.FindAsync(id);
            if (comprador == null) return NotFound();
            _context.Compradores.Remove(comprador);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using backend.Data;
using backend.Models;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AgricultoresController : ControllerBase
    {
        private readonly AgroBolivarContext _context;

        public AgricultoresController(AgroBolivarContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Agricultor>>> GetAgricultores()
        {
            return await _context.Agricultores.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Agricultor>> GetAgricultor(int id)
        {
            var agricultor = await _context.Agricultores.FindAsync(id);
            if (agricultor == null) return NotFound();
            return agricultor;
        }

        [HttpPost]
        public async Task<ActionResult<Agricultor>> PostAgricultor(Agricultor agricultor)
        {
            _context.Agricultores.Add(agricultor);
            await _context.SaveChangesAsync();
            return Ok(agricultor); // <--- ¡ESTO ARREGLA EL SWAGGER!
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAgricultor(int id, Agricultor agricultor)
        {
            if (id != agricultor.IdAgricultor) return BadRequest();
            _context.Entry(agricultor).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAgricultor(int id)
        {
            var agricultor = await _context.Agricultores.FindAsync(id);
            if (agricultor == null) return NotFound();
            _context.Agricultores.Remove(agricultor);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
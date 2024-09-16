using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using sprint3.NET.Database.Models;
using sprint3.NET.Database.Persistencia;

namespace sprint3.NET.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FazendasController : ControllerBase
    {
        private readonly FIAPDbContext _context;

        public FazendasController(FIAPDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Fazenda>>> GetFazendas()
        {
            return await _context.Fazenda
                .Include(f => f.Agricultor)
                .Include(f => f.Solos)
                .Include(f => f.Safras)
                .ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Fazenda>> GetFazenda(int id)
        {
            var fazenda = await _context.Fazenda
                .Include(f => f.Agricultor)
                .Include(f => f.Solos)
                .Include(f => f.Safras)
                .FirstOrDefaultAsync(f => f.Fazenda_Id == id);

            if (fazenda == null)
            {
                return NotFound();
            }

            return fazenda;
        }

        [HttpPost]
        public async Task<ActionResult<Fazenda>> PostFazenda(Fazenda fazenda)
        {
            _context.Fazenda.Add(fazenda);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFazenda", new { id = fazenda.Fazenda_Id }, fazenda);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutFazenda(int id, Fazenda fazenda)
        {
            if (id != fazenda.Fazenda_Id)
            {
                return BadRequest();
            }

            _context.Entry(fazenda).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FazendaExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFazenda(int id)
        {
            var fazenda = await _context.Fazenda.FindAsync(id);
            if (fazenda == null)
            {
                return NotFound();
            }

            _context.Fazenda.Remove(fazenda);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FazendaExists(int id)
        {
            return _context.Fazenda.Any(e => e.Fazenda_Id == id);
        }
    }
}

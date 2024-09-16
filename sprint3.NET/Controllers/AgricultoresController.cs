using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using sprint3.NET.Database.Models;
using sprint3.NET.Database.Persistencia;

namespace sprint3.NET.Controllers
{
    namespace SeuProjeto.Controllers
    {
        [Route("api/[controller]")]
        [ApiController]
        public class AgricultoresController : ControllerBase
        {
            private readonly FIAPDbContext _context;

            public AgricultoresController(FIAPDbContext context)
            {
                _context = context;
            }

            [HttpGet]
            public async Task<ActionResult<IEnumerable<Agricultor>>> GetAgricultores()
            {
                return await _context.Agricultor
                    .Include(a => a.Usuario)
                    .Include(a => a.Fazendas)
                    .ToListAsync();
            }

            [HttpGet("{id}")]
            public async Task<ActionResult<Agricultor>> GetAgricultor(int id)
            {
                var agricultor = await _context.Agricultor
                    .Include(a => a.Usuario)
                    .Include(a => a.Fazendas)
                    .FirstOrDefaultAsync(a => a.Agricultor_Id == id);

                if (agricultor == null)
                {
                    return NotFound();
                }

                return agricultor;
            }

            [HttpPost]
            public async Task<ActionResult<Agricultor>> PostAgricultor(Agricultor agricultor)
            {
                _context.Agricultor.Add(agricultor);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetAgricultor", new { id = agricultor.Agricultor_Id }, agricultor);
            }

            [HttpPut("{id}")]
            public async Task<IActionResult> PutAgricultor(int id, Agricultor agricultor)
            {
                if (id != agricultor.Agricultor_Id)
                {
                    return BadRequest();
                }

                _context.Entry(agricultor).State = EntityState.Modified;

                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AgricultorExists(id))
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
            public async Task<IActionResult> DeleteAgricultor(int id)
            {
                var agricultor = await _context.Agricultor.FindAsync(id);
                if (agricultor == null)
                {
                    return NotFound();
                }

                _context.Agricultor.Remove(agricultor);
                await _context.SaveChangesAsync();

                return NoContent();
            }

            private bool AgricultorExists(int id)
            {
                return _context.Agricultor.Any(e => e.Agricultor_Id == id);
            }
        }
    }

}

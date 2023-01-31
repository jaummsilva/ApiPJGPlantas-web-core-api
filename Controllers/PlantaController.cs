using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Threading.Tasks;
using apiteste.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System.Linq;
using System.Net.Mime;

namespace ApiPJGPlantas.Controllers
{
        [Route("api/[controller]")]
        [ApiController]
    [Produces(MediaTypeNames.Application.Json)]
    public class PlantasController : ControllerBase
        {
            private readonly dbContext _context;

            public PlantasController(dbContext context)
            {
                _context = context;
            }

            // GET: api/Plantas
            [HttpGet]
        [Produces("application/json")]
        [Consumes("application/json")]
        public async Task<ActionResult<IEnumerable<Planta>>> GetPlanta()
            {
                return await _context.Plantas.ToListAsync();
            }

            // GET: api/Plantas/5


        [HttpGet("{id}")]
        [Produces("application/json")]
        [Consumes("application/json")]
        public async Task<ActionResult<Planta>> GetPlanta([FromBody] int id)
            {
                var planta = await _context.Plantas.FindAsync(id);

                if (planta == null)
                {
                    return NotFound();
                }

                return planta;
            }

            // PUT: api/Plantas/5
            // To protect from overposting attacks, enable the specific properties you want to bind to, for
            // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
            [HttpPut("{id}")]
        public async Task<IActionResult> PutPlanta([FromForm] int id, Planta planta)
            {
                if (id != planta.Id)
                {
                    return BadRequest();
                }

                _context.Entry(planta).State = EntityState.Modified;

                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PlantaExists(id))
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

            // POST: api/Plantas
            // To protect from overposting attacks, enable the specific properties you want to bind to, for
            // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
            [HttpPost]
        public async Task<ActionResult<Planta>> PostPlanta([FromBody] Planta planta)
            {
                _context.Plantas.Add(planta);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetPlanta", new { id = planta.Id }, planta);
            }

            // DELETE: api/Plantas/5
            [HttpDelete("{id}")]
        [Produces("application/json")]
        [Consumes("application/json")]
        public async Task<ActionResult<Planta>> DeletePlanta([FromForm] int id)
            {
                var planta = await _context.Plantas.FindAsync(id);
                if (planta == null)
                {
                    return NotFound();
                }

                _context.Plantas.Remove(planta);
                await _context.SaveChangesAsync();

                return planta;
            }

            private bool PlantaExists(int id)
            {
                return _context.Plantas.Any(e => e.Id == id);
            }
        }
    }

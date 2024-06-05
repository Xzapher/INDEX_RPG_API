using INDEX_RPG_API.Models;
using INDEX_RPG_API.Repositories.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace INDEX_RPG_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CharacterStatsController : ControllerBase
    {
        private readonly ApiIndexRpgContext _context;

        public CharacterStatsController(ApiIndexRpgContext context)
        {
            _context = context;
        }

        // GET: api/CharacterStats
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CharacterStat>>> GetCharacterStats()
        {
            return await _context.CharacterStats.ToListAsync();
        }

        // GET: api/CharacterStats/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CharacterStat>> GetCharacterStat(int id)
        {
            var characterStat = await _context.CharacterStats.FindAsync(id);

            if (characterStat == null)
            {
                return NotFound();
            }

            return characterStat;
        }

        // PUT: api/CharacterStats/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCharacterStat(int id, CharacterStat characterStat)
        {
            if (id != characterStat.Id)
            {
                return BadRequest();
            }

            _context.Entry(characterStat).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CharacterStatExists(id))
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

        // POST: api/CharacterStats
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CharacterStat>> PostCharacterStat(CharacterStat characterStat)
        {
            _context.CharacterStats.Add(characterStat);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (CharacterStatExists(characterStat.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetCharacterStat", new { id = characterStat.Id }, characterStat);
        }

        // DELETE: api/CharacterStats/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCharacterStat(int id)
        {
            var characterStat = await _context.CharacterStats.FindAsync(id);
            if (characterStat == null)
            {
                return NotFound();
            }

            _context.CharacterStats.Remove(characterStat);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CharacterStatExists(int id)
        {
            return _context.CharacterStats.Any(e => e.Id == id);
        }
    }
}

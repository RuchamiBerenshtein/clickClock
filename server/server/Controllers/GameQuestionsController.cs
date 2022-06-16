using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using server.Models;

namespace server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameQuestionsController : ControllerBase
    {
        private readonly clickersContext _context;

        public GameQuestionsController(clickersContext context)
        {
            _context = context;
        }

        // GET: api/GameQuestions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GameQuestion>>> GetGameQuestions()
        {
            return await _context.GameQuestions.ToListAsync();
        }

        // GET: api/GameQuestions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GameQuestion>> GetGameQuestion(int id)
        {
            var gameQuestion = await _context.GameQuestions.FindAsync(id);

            if (gameQuestion == null)
            {
                return NotFound();
            }

            return gameQuestion;
        }

        // PUT: api/GameQuestions/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGameQuestion(int id, GameQuestion gameQuestion)
        {
            if (id != gameQuestion.GameId)
            {
                return BadRequest();
            }

            _context.Entry(gameQuestion).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GameQuestionExists(id))
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

        // POST: api/GameQuestions
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<GameQuestion>> PostGameQuestion(GameQuestion gameQuestion)
        {
            _context.GameQuestions.Add(gameQuestion);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (GameQuestionExists(gameQuestion.GameId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetGameQuestion", new { id = gameQuestion.GameId }, gameQuestion);
        }

        // DELETE: api/GameQuestions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGameQuestion(int id)
        {
            var gameQuestion = await _context.GameQuestions.FindAsync(id);
            if (gameQuestion == null)
            {
                return NotFound();
            }

            _context.GameQuestions.Remove(gameQuestion);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool GameQuestionExists(int id)
        {
            return _context.GameQuestions.Any(e => e.GameId == id);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using QuizAPI.Models;

namespace QuizAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ParticipantsController : Controller
    {
        private readonly QuizDbContext _context;

        public ParticipantsController(QuizDbContext context)
        {
            _context = context;
        }

        // GET: Participants
        public async Task<IActionResult> Index()
        {
            return View(await _context.Participants.ToListAsync());
        }

        // GET: Participants/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Participants == null)
            {
                return NotFound();
            }

            var participant = await _context.Participants
                .FirstOrDefaultAsync(m => m.ParticipantId == id);
            if (participant == null)
            {
                return NotFound();
            }

            return View(participant);
        }

        // GET: Participants/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Participants/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ParticipantId,Email,Name,Score,TimeTaken")] Participant participant)
        {
            if (ModelState.IsValid)
            {
                var temp = _context.Participants.Where(x => x.Name == participant.Name && x.Email == participant.Email).FirstOrDefault();
                if (temp == default)
                {
                    _context.Add(participant);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    participant = temp;
                }
            }
            return Ok(participant);
        }

        // GET: Participants/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Participants == null)
            {
                return NotFound();
            }

            var participant = await _context.Participants.FindAsync(id);
            if (participant == null)
            {
                return NotFound();
            }
            return View(participant);
        }

        // POST: Participants/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ParticipantId,Email,Name,Score,TimeTaken")] Participant participant)
        {
            if (id != participant.ParticipantId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(participant);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ParticipantExists(participant.ParticipantId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(participant);
        }

        // GET: Participants/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Participants == null)
            {
                return NotFound();
            }

            var participant = await _context.Participants
                .FirstOrDefaultAsync(m => m.ParticipantId == id);
            if (participant == null)
            {
                return NotFound();
            }

            return View(participant);
        }

        // POST: Participants/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Participants == null)
            {
                return Problem("Entity set 'QuizDbContext.Participants'  is null.");
            }
            var participant = await _context.Participants.FindAsync(id);
            if (participant != null)
            {
                _context.Participants.Remove(participant);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ParticipantExists(int id)
        {
            return _context.Participants.Any(e => e.ParticipantId == id);
        }
    }
}

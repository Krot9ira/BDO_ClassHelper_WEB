using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BDnew_class.Models;
using Microsoft.AspNetCore.Authorization;

namespace BDnew_class.Controllers
{
    [Authorize]
    public class SpellsController : Controller
    {
        private readonly CUSERSKAHASDESKTOPBDO_GUIDE_CLASSMDFContext _context;

        public SpellsController(CUSERSKAHASDESKTOPBDO_GUIDE_CLASSMDFContext context)
        {
            _context = context;
        }

        // GET: Spells
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var cUSERSKAHASDESKTOPBDO_GUIDE_CLASSMDFContext = _context.Spell.Include(s => s.Class);
            return View(await cUSERSKAHASDESKTOPBDO_GUIDE_CLASSMDFContext.ToListAsync());
        }

        // GET: Spells/Details/5
        [AllowAnonymous]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var spell = await _context.Spell.Where(a => a.ClassId == id)
                .Include(s => s.Class)
                .FirstOrDefaultAsync(m => m.ClassId == id);
            if (spell == null)
            {
                return NotFound();
            }
           
            return View(spell);
        }

        // GET: Spells/Create
        public IActionResult Create()
        {
            ViewData["ClassId"] = new SelectList(_context.Class, "IdClass", "NameClass");
            return View();
        }

        // POST: Spells/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdSpell,NameSpell,SpellDescription,SpellVid,ClassId")] Spell spell)
        {
            if (ModelState.IsValid)
            {
                _context.Add(spell);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClassId"] = new SelectList(_context.Class, "IdClass", "NameClass", spell.ClassId);
            return View(spell);
        }

        // GET: Spells/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var spell = await _context.Spell.FindAsync(id);
            if (spell == null)
            {
                return NotFound();
            }
            ViewData["ClassId"] = new SelectList(_context.Class, "IdClass", "NameClass", spell.ClassId);
            return View(spell);
        }

        // POST: Spells/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdSpell,NameSpell,SpellDescription,SpellVid,ClassId")] Spell spell)
        {
            if (id != spell.IdSpell)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(spell);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SpellExists(spell.IdSpell))
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
            ViewData["ClassId"] = new SelectList(_context.Class, "IdClass", "NameClass", spell.ClassId);
            return View(spell);
        }

        // GET: Spells/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var spell = await _context.Spell
                .Include(s => s.Class)
                .FirstOrDefaultAsync(m => m.IdSpell == id);
            if (spell == null)
            {
                return NotFound();
            }

            return View(spell);
        }

        // POST: Spells/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var spell = await _context.Spell.FindAsync(id);
            _context.Spell.Remove(spell);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SpellExists(int id)
        {
            return _context.Spell.Any(e => e.IdSpell == id);
        }
    }
}

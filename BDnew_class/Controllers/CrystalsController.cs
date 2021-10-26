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
    public class CrystalsController : Controller
    {
        private readonly CUSERSKAHASDESKTOPBDO_GUIDE_CLASSMDFContext _context;

        public CrystalsController(CUSERSKAHASDESKTOPBDO_GUIDE_CLASSMDFContext context)
        {
            _context = context;
        }

        // GET: Crystals
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            return View(await _context.Crystal.ToListAsync());
        }

        // GET: Crystals/Details/5
        [AllowAnonymous]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var crystal = await _context.Crystal
                .FirstOrDefaultAsync(m => m.IdCrystal == id);
            if (crystal == null)
            {
                return NotFound();
            }

            return View(crystal);
        }

        // GET: Crystals/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Crystals/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdCrystal,CrystalName,CrystalDescription")] Crystal crystal)
        {
            if (ModelState.IsValid)
            {
                _context.Add(crystal);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(crystal);
        }

        // GET: Crystals/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var crystal = await _context.Crystal.FindAsync(id);
            if (crystal == null)
            {
                return NotFound();
            }
            return View(crystal);
        }

        // POST: Crystals/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdCrystal,CrystalName,CrystalDescription")] Crystal crystal)
        {
            if (id != crystal.IdCrystal)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(crystal);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CrystalExists(crystal.IdCrystal))
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
            return View(crystal);
        }

        // GET: Crystals/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var crystal = await _context.Crystal
                .FirstOrDefaultAsync(m => m.IdCrystal == id);
            if (crystal == null)
            {
                return NotFound();
            }

            return View(crystal);
        }

        // POST: Crystals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var crystal = await _context.Crystal.FindAsync(id);
            _context.Crystal.Remove(crystal);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CrystalExists(int id)
        {
            return _context.Crystal.Any(e => e.IdCrystal == id);
        }
    }
}

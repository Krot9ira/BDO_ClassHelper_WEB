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
    public class SpotsController : Controller
    {
        private readonly CUSERSKAHASDESKTOPBDO_GUIDE_CLASSMDFContext _context;

        public SpotsController(CUSERSKAHASDESKTOPBDO_GUIDE_CLASSMDFContext context)
        {
            _context = context;
        }

        // GET: Spots
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            return View(await _context.Spot.ToListAsync());
        }

        // GET: Spots/Details/5
        [AllowAnonymous]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound($"anulla, {id}");
            }
            
                var spot = await _context.Farm.Where(a => a.WhatAClass == id)
               
                       .FirstOrDefaultAsync(m => m.WhatAClass == id); 
                 
          
            if (spot == null)
            {
                return NotFound($"aaaaaaaaaaaaaaaaaaaaaaaa, {id}");
            }

            return View(spot);
        }
       

        // GET: Spots/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Spots/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdSpot,NameSpot,SpotDescription,SpotGif,Ap,Dp")] Spot spot)
        {
            if (ModelState.IsValid)
            {
                _context.Add(spot);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(spot);
        }

        // GET: Spots/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var spot = await _context.Spot.FindAsync(id);
            if (spot == null)
            {
                return NotFound();
            }
            return View(spot);
        }

        // POST: Spots/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdSpot,NameSpot,SpotDescription,SpotGif,Ap,Dp")] Spot spot)
        {
            if (id != spot.IdSpot)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(spot);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SpotExists(spot.IdSpot))
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
            return View(spot);
        }

        // GET: Spots/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var spot = await _context.Spot
                .FirstOrDefaultAsync(m => m.IdSpot == id);
            if (spot == null)
            {
                return NotFound();
            }

            return View(spot);
        }

        // POST: Spots/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var spot = await _context.Spot.FindAsync(id);
            _context.Spot.Remove(spot);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SpotExists(int id)
        {
            return _context.Spot.Any(e => e.IdSpot == id);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using BDnew_class.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace BDnew_class.Controllers
{
    
    public class HomeController : Controller
    {
        
        private CUSERSKAHASDESKTOPBDO_GUIDE_CLASSMDFContext db;
        public HomeController(CUSERSKAHASDESKTOPBDO_GUIDE_CLASSMDFContext context)
        {
            db = context;
        }

        

        public async Task<IActionResult> Index()
        {
            return View(await db.Class.ToListAsync());
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]

        public async Task<IActionResult> Create(Class clas)
        {
            db.Class.Add(clas);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");

        }

        public async Task<IActionResult> Details(int? id)
        {
           // if (id != null)
           // {

                return View(await db.Spell.ToListAsync());
              //  Spell clas = await db.Spell.FirstOrDefaultAsync(p => p.IdSpell == id);
//                CUSERSKAHASDESKTOPBDO_GUIDE_CLASSMDFContext context = new CUSERSKAHASDESKTOPBDO_GUIDE_CLASSMDFContext();
//
 //               var names = context.Spell
 //                                  .OrderBy(c => c.ClassId)
  //                                 .Select(c => c.ClassId);
   //             
   //
    //            if (clas != null)
     //           {
      //              
       //             return View(clas);
       //
         //       }
         //   }
           // return NotFound();
        }
        public async Task<IActionResult> Edit(int? id)
        {
            if (id != null)
            {
                Class clas = await db.Class.FirstOrDefaultAsync(p => p.IdClass == id);
                if (clas != null)
                    return View(clas);
            }
            return NotFound();
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Class clas)
        {
            db.Class.Update(clas);
           
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        [HttpGet]
        [ActionName("Delete")]
        public async Task<IActionResult> ConfirmDelete(int? id)
        {
            if (id != null)
            {
                Class clas = await db.Class.FirstOrDefaultAsync(p => p.IdClass == id);
                if (clas != null)
                    return View(clas);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id != null)
            {
                Class clas = new Class { IdClass = id.Value };
                db.Entry(clas).State = EntityState.Deleted;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return NotFound();
        }
        public static void GetListSPelClass(int spellid)
        { CUSERSKAHASDESKTOPBDO_GUIDE_CLASSMDFContext context = new CUSERSKAHASDESKTOPBDO_GUIDE_CLASSMDFContext();
            var spell = context.SpellClass.Where(a => a.ClassId == spellid);
            foreach (SpellClass a in spell )
            {
                var spelldis = context.Spell.Where(q => q.IdSpell == a.SpellId);
                
            }
            
        }



    }
}

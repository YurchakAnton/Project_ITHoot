using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Project_ITHoot.Models;

namespace Project_ITHoot.Controllers
{
    public class ProgrammerController : Controller
    {
        private readonly ProjectDbContext _context;

        public ProgrammerController(ProjectDbContext context)
        {
            _context = context;
        }


        // GET: Programmer
        public async Task<IActionResult> Index()
        {
            return View(await _context.Programmers.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var project = await _context.ProgrammersAndProjects
                .Include(p => p.ProgrammersModel)
                .Include(p => p.ProjectsModel)
                .FirstOrDefaultAsync(m => m.IdProgrammer == id);
            if (project == null)
            {
                return NotFound();
            }

            return View(project);
        }


        [NoDirectAccess]
        public async Task<ActionResult> AddOrEdit(int id=0)
        {
            if (id == 0)
            return View(new ProgrammerModel());
            else
            {
                var programmerModel = await _context.Programmers.FindAsync(id);
                if (programmerModel == null)
                {
                    return NotFound();
                }
                return View(programmerModel);
            }
        }


        // POST: Programmer/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEdit(int id, [Bind("IdProgrammer,FullName,Position,Activity")] ProgrammerModel programmerModel)
        {
            if (ModelState.IsValid)
            {
                if (id == 0)
                {
                    _context.Add(programmerModel);
                    await _context.SaveChangesAsync();
                }
                else 
                {
                    try
                    {
                        _context.Update(programmerModel);
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!ProgrammerModelExists(programmerModel.IdProgrammer))
                        {
                            return NotFound();
                        }
                        else
                        {
                            throw;
                        }
                    }
                }

                return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "_ViewAll", _context.Programmers.ToList()) });
            }
            return Json(new { isValid = false, html = Helper.RenderRazorViewToString(this, "AddOrEdit", programmerModel) });
        }


        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var programmerModel = await _context.Programmers
                .FirstOrDefaultAsync(m => m.IdProgrammer == id);
            if (programmerModel == null)
            {
                return NotFound();
            }

            return View(programmerModel);
        }


        // POST: Programmer/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            Debug.WriteLine("id=" + id);
            /*var programmerModel = await _context.Programmers.FindAsync(id);
            _context.Programmers.Remove(programmerModel);
            await _context.SaveChangesAsync();*/
            return Json(new { html = Helper.RenderRazorViewToString(this, "_ViewAll", _context.Programmers.ToList()) });

        }

        private bool ProgrammerModelExists(int id)
        {
            return _context.Programmers.Any(e => e.IdProgrammer == id);
        }
    }
}

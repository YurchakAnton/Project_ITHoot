using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Project_ITHoot.Models;
using System.Diagnostics;

namespace Project_ITHoot.Controllers
{
    public class ProgrammersAndProjectsController : Controller
    {
        private readonly ProjectDbContext _context;

        public ProgrammersAndProjectsController(ProjectDbContext context)
        {
            _context = context;
        }

        // GET: ProgrammersAndProjects
        public async Task<IActionResult> Index()
        {
            var projectDbContext = _context.ProgrammersAndProjects.Include(p => p.ProgrammersModel).Include(p => p.ProjectsModel);
            return View(await projectDbContext.ToListAsync());
        }

        // GET: ProgrammersAndProjects/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            bool res = _context.ProgrammersAndProjects.Any(i => i.IdProgrammer == id);
            if (res == false)
            {
                return NotFound();
            }
            else
            {
                if (id == null)
                {
                    return NotFound();
                }
                var programmersAndProjects = await _context.ProgrammersAndProjects
                .Include(p => p.ProgrammersModel)
                .Include(p => p.ProjectsModel)
                .FirstOrDefaultAsync(m => m.IdProgrammer == id);
                if (programmersAndProjects == null)
                {
                    return NotFound();
                }
                return View(programmersAndProjects);
            }
        }

        // GET: ProgrammersAndProjects/Create
        public IActionResult Create(int? id)
        {
            if (id == null)
                return NotFound();
            else
            {
                ViewData["IdProgrammer"] = new SelectList(_context.Programmers, "IdProgrammer", "IdProgrammer");
                ViewData["IdProject"] = new SelectList(_context.Projects, "IdProject", "NameOfProject");
                ViewData["Id"] = id;
                return View();
            }
        }

        // POST: ProgrammersAndProjects/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(int id,[Bind("IdProgrammer,IdProject")] ProgrammersAndProjects programmersAndProjects)
        {
            if (ModelState.IsValid)
            {
                _context.Add(programmersAndProjects);
                await _context.SaveChangesAsync();
                return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "Index", await _context.Programmers.ToListAsync()) });
            }
            ViewData["IdProgrammer"] = new SelectList(_context.Programmers, "IdProgrammer", "FullName", programmersAndProjects.IdProgrammer);
            ViewData["Id"] = id;
            ViewData["IdProject"] = new SelectList(_context.Projects, "IdProject", "NameOfProject", programmersAndProjects.IdProject);
            return View(programmersAndProjects);
        }

        // GET: ProgrammersAndProjects/Edit/5
        public async Task<IActionResult> Edit(int? id1, int? id2)
        {
            if (id1 == null || id2==null)
            {
                return NotFound();
            }

            var programmersAndProjects = await _context.ProgrammersAndProjects.FindAsync(id1, id2);
            if (programmersAndProjects == null)
            {
                return NotFound();
            }
            ViewData["IdProgrammer"] = new SelectList(_context.Programmers, "IdProgrammer", "FullName", programmersAndProjects.IdProgrammer);
            ViewData["IdProject"] = new SelectList(_context.Projects, "IdProject", "NameOfProject", programmersAndProjects.IdProject);
            return View(programmersAndProjects);
        }

        // POST: ProgrammersAndProjects/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdProgrammer,IdProject")] ProgrammersAndProjects programmersAndProjects)
        {
            if (id != programmersAndProjects.IdProgrammer)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(programmersAndProjects);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProgrammersAndProjectsExists(programmersAndProjects.IdProgrammer))
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
            ViewData["IdProgrammer"] = new SelectList(_context.Programmers, "IdProgrammer", "Activity", programmersAndProjects.IdProgrammer);
            ViewData["IdProject"] = new SelectList(_context.Projects, "IdProject", "NameOfProject", programmersAndProjects.IdProject);
            return View(programmersAndProjects);
        }

        // GET: ProgrammersAndProjects/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var programmersAndProjects = await _context.ProgrammersAndProjects
                .Include(p => p.ProgrammersModel)
                .Include(p => p.ProjectsModel)
                .FirstOrDefaultAsync(m => m.IdProgrammer == id);
            if (programmersAndProjects == null)
            {
                return NotFound();
            }

            return View(programmersAndProjects);
        }

        // POST: ProgrammersAndProjects/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            Debug.WriteLine("id1" + id);
            var programmersAndProjects = await _context.ProgrammersAndProjects
                            .Include(p => p.ProgrammersModel)
                            .Include(p => p.ProjectsModel)
                            .FirstOrDefaultAsync(m => m.IdProgrammer == id);
            Debug.WriteLine(programmersAndProjects);
            _context.ProgrammersAndProjects.Remove(programmersAndProjects);
            await _context.SaveChangesAsync();
            return Json(new { html = Helper.RenderRazorViewToString(this, "Index", _context.Programmers.ToList()) });

        }

        private bool ProgrammersAndProjectsExists(int id)
        {
            return _context.ProgrammersAndProjects.Any(e => e.IdProgrammer == id);
        }
    }
}

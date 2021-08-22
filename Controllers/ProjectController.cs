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
    public class ProjectController : Controller
    {
        private readonly ProjectDbContext _context;

        public ProjectController(ProjectDbContext context)
        {
            _context = context;
        }

        // GET: Project
        public async Task<IActionResult> Index()
        {
            return View(await _context.Projects.ToListAsync());
        }

        [NoDirectAccess]
        public async Task<ActionResult> AddOrEdit(int id = 0)
        {
            Debug.WriteLine("uuuuu=" + id);
            if (id == 0)
                return View(new ProjectModel());
            else
            {
                var projectModel = await _context.Projects.FindAsync(id);
                if (projectModel == null)
                {
                    return NotFound();
                }
                return View(projectModel);
            }
        }


        // POST: Project/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEdit(int id, [Bind("IdProject,NameOfProject,ProjectDescription,TimeOfProject")] ProjectModel projectModel)
        {
            Debug.WriteLine("uuuuu=" + id);
            if (ModelState.IsValid)
            {
                if (id == 0)
                {
                    _context.Add(projectModel);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    try
                    {
                        _context.Update(projectModel);
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!ProjectModelExists(projectModel.IdProject))
                        {
                            return NotFound();
                        }
                        else
                        {
                            throw;
                        }
                    }
                }

                return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "_ViewAll", _context.Projects.ToList()) });
            }
            return Json(new { isValid = false, html = Helper.RenderRazorViewToString(this, "AddOrEdit", projectModel) });
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var projectModel = await _context.Projects
                .FirstOrDefaultAsync(m => m.IdProject == id);
            if (projectModel == null)
            {
                return NotFound();
            }

            return View(projectModel);
        }

        // POST: Project/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var projectModel = await _context.Projects.FindAsync(id);
            _context.Projects.Remove(projectModel);
            await _context.SaveChangesAsync();
            return Json(new { html = Helper.RenderRazorViewToString(this, "_ViewAll", _context.Projects.ToList()) });

        }

        private bool ProjectModelExists(int id)
        {
            return _context.Projects.Any(e => e.IdProject == id);
        }
    }
}

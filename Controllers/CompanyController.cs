using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Project_ITHoot.Models;

namespace Project_ITHoot.Controllers
{
    public class CompanyController : Controller
    {
        private readonly ProjectDbContext _context;

        public CompanyController(ProjectDbContext context)
        {
            _context = context;
        }

        // GET: Company
        public async Task<IActionResult> Index()
        {
            return View(await _context.Companies.ToListAsync());
        }


        public async Task<ActionResult> AddOrEdit(int id = 0)
        {
            if (id == 0)
                return View(new CompanyModel());
            else
            {
                var companyModel = await _context.Companies.FindAsync(id);
                if (companyModel == null)
                {
                    return NotFound();
                }
                return View(companyModel);
            }
        }

        // POST: Company/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEdit(int id, [Bind("Id,NameOfCompany,CompanyLocation,ActivityOfCompany")] CompanyModel companyModel)
        {
            if (ModelState.IsValid)
            {
                if (id == 0)
                {
                    _context.Add(companyModel);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    try
                    {
                        _context.Update(companyModel);
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!CompanyModelExists(companyModel.Id))
                        {
                            return NotFound();
                        }
                        else
                        {
                            throw;
                        }
                    }
                }

                return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "_ViewAll", _context.Companies.ToList()) });
            }
            return Json(new { isValid = false, html = Helper.RenderRazorViewToString(this, "AddOrEdit", companyModel) });
        }



        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var companyModel = await _context.Companies
                .FirstOrDefaultAsync(m => m.Id == id);
            if (companyModel == null)
            {
                return NotFound();
            }

            return View(companyModel);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var companyModel = await _context.Companies.FindAsync(id);
            _context.Companies.Remove(companyModel);
            await _context.SaveChangesAsync();
            return Json(new { html = Helper.RenderRazorViewToString(this, "_ViewAll", _context.Companies.ToList()) });

        }

        private bool CompanyModelExists(int id)
        {
            return _context.Companies.Any(e => e.Id == id);
        }
    }
}

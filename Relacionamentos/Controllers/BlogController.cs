using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Relacionamentos.Data;
using Relacionamentos.Models;

namespace Relacionamentos.Controllers
{
    public class BlogController : Controller
    {
        private readonly RelacionamentosContext _context;

        public BlogController(RelacionamentosContext context)
        {
            _context = context;
        }

        // GET: Blog
        public async Task<IActionResult> Index()
        {
              return _context.Blog != null ? 
                          View(await _context.Blog.ToListAsync()) :
                          Problem("Entity set 'RelacionamentosContext.Blog'  is null.");
        }

        // GET: Blog/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Blog == null)
            {
                return NotFound();
            }

            var blogClass = await _context.Blog
                .FirstOrDefaultAsync(m => m.Id == id);
            if (blogClass == null)
            {
                return NotFound();
            }

            return View(blogClass);
        }

        // GET: Blog/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Blog/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,SiteUri")] BlogClass blogClass)
        {
            if (ModelState.IsValid)
            {
                _context.Add(blogClass);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(blogClass);
        }

        // GET: Blog/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Blog == null)
            {
                return NotFound();
            }

            var blogClass = await _context.Blog.FindAsync(id);
            if (blogClass == null)
            {
                return NotFound();
            }
            return View(blogClass);
        }

        // POST: Blog/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, [Bind("Id,Name,SiteUri")] BlogClass blogClass)
        {
            if (id != blogClass.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(blogClass);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BlogClassExists(blogClass.Id))
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
            return View(blogClass);
        }

        // GET: Blog/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Blog == null)
            {
                return NotFound();
            }

            var blogClass = await _context.Blog
                .FirstOrDefaultAsync(m => m.Id == id);
            if (blogClass == null)
            {
                return NotFound();
            }

            return View(blogClass);
        }

        // POST: Blog/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            if (_context.Blog == null)
            {
                return Problem("Entity set 'RelacionamentosContext.Blog'  is null.");
            }
            var blogClass = await _context.Blog.FindAsync(id);
            if (blogClass != null)
            {
                _context.Blog.Remove(blogClass);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BlogClassExists(int? id)
        {
          return (_context.Blog?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}

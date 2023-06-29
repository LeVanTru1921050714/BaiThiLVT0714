using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BaiThiLVT.Models;


namespace BaiThiLVT.Controllers
{
    public class LVTCau3Controller : Controller
    {
        StringProcess nv = new StringProcess();
        private readonly LTQLDbContext _context;

        public LVTCau3Controller(LTQLDbContext context)
        {
            _context = context;
        }

        // GET: LVTCau3
        public async Task<IActionResult> Index()
        {
              return _context.LVTCau3 != null ? 
                          View(await _context.LVTCau3.ToListAsync()) :
                          Problem("Entity set 'LTQLDbContext.LVTCau3'  is null.");
        }

        // GET: LVTCau3/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.LVTCau3 == null)
            {
                return NotFound();
            }

            var lVTCau3 = await _context.LVTCau3
                .FirstOrDefaultAsync(m => m.IDNhanVien == id);
            if (lVTCau3 == null)
            {
                return NotFound();
            }

            return View(lVTCau3);
        }

        // GET: LVTCau3/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: LVTCau3/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IDNhanVien,TenNhanVien,DiaChi")] LVTCau3 lVTCau3)
        {
            if (ModelState.IsValid)
            {
                lVTCau3.TenNhanVien = nv.ToUpper(lVTCau3.TenNhanVien);
                _context.Add(lVTCau3);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(lVTCau3);
        }

        // GET: LVTCau3/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.LVTCau3 == null)
            {
                return NotFound();
            }

            var lVTCau3 = await _context.LVTCau3.FindAsync(id);
            if (lVTCau3 == null)
            {
                return NotFound();
            }
            return View(lVTCau3);
        }

        // POST: LVTCau3/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("IDNhanVien,TenNhanVien,DiaChi")] LVTCau3 lVTCau3)
        {
            if (id != lVTCau3.IDNhanVien)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(lVTCau3);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LVTCau3Exists(lVTCau3.IDNhanVien))
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
            return View(lVTCau3);
        }

        // GET: LVTCau3/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.LVTCau3 == null)
            {
                return NotFound();
            }

            var lVTCau3 = await _context.LVTCau3
                .FirstOrDefaultAsync(m => m.IDNhanVien == id);
            if (lVTCau3 == null)
            {
                return NotFound();
            }

            return View(lVTCau3);
        }

        // POST: LVTCau3/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.LVTCau3 == null)
            {
                return Problem("Entity set 'LTQLDbContext.LVTCau3'  is null.");
            }
            var lVTCau3 = await _context.LVTCau3.FindAsync(id);
            if (lVTCau3 != null)
            {
                _context.LVTCau3.Remove(lVTCau3);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LVTCau3Exists(string id)
        {
          return (_context.LVTCau3?.Any(e => e.IDNhanVien == id)).GetValueOrDefault();
        }
    }
}

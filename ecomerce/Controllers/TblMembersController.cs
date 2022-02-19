using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ecomerce.Models;

namespace ecomerce.Controllers
{
    public class TblMembersController : Controller
    {
        private readonly dbSmartAgricultureContext _context;

        public TblMembersController(dbSmartAgricultureContext context)
        {
            _context = context;
        }

        // GET: TblMembers
        public async Task<IActionResult> Index()
        {
            return View(await _context.TblMembers.ToListAsync());
        }

        // GET: TblMembers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblMembers = await _context.TblMembers
                .FirstOrDefaultAsync(m => m.MemberId == id);
            if (tblMembers == null)
            {
                return NotFound();
            }

            return View(tblMembers);
        }

        // GET: TblMembers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TblMembers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MemberId,FristName,LastName,EmailId,Password,IsActive,IsDelete,CreatedOn,ModifiedOn,GroupAdmin,UserName")] TblMembers tblMembers)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tblMembers);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tblMembers);
        }

        // GET: TblMembers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblMembers = await _context.TblMembers.FindAsync(id);
            if (tblMembers == null)
            {
                return NotFound();
            }
            return View(tblMembers);
        }

        // POST: TblMembers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MemberId,FristName,LastName,EmailId,Password,IsActive,IsDelete,CreatedOn,ModifiedOn,GroupAdmin,UserName")] TblMembers tblMembers)
        {
            if (id != tblMembers.MemberId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblMembers);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblMembersExists(tblMembers.MemberId))
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
            return View(tblMembers);
        }

        // GET: TblMembers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblMembers = await _context.TblMembers
                .FirstOrDefaultAsync(m => m.MemberId == id);
            if (tblMembers == null)
            {
                return NotFound();
            }

            return View(tblMembers);
        }

        // POST: TblMembers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tblMembers = await _context.TblMembers.FindAsync(id);
            _context.TblMembers.Remove(tblMembers);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TblMembersExists(int id)
        {
            return _context.TblMembers.Any(e => e.MemberId == id);
        }
    }
}

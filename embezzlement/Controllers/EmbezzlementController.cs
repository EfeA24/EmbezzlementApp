using embezzlement.Models;
using embezzlement.ViewModels;
using Entities.Data;
using IdentityApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace embezzlement.Controllers
{
    [Authorize]
    public class EmbezzlementController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EmbezzlementController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var embezzlements = await _context.Embezzlements
                .Include(e => e.Item)
                .Include(e => e.AppUser)
                .ToListAsync();

            return View(embezzlements);
        }

        public IActionResult Create()
        {
            return View(new EmbezzlementViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(EmbezzlementViewModel model)
        {
            if (ModelState.IsValid)
            {
                var embezzlement = new Embezzlement
                {
                    ItemId = model.Item.ItemId,
                    UserId = model.AppUser.Id,
                    HandoverDate = model.HandoverDate,
                    ReturnTime = model.ReturnTime
                };

                _context.Embezzlements.Add(embezzlement);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var embezzlement = await _context.Embezzlements
                .Include(e => e.Item)
                .Include(e => e.AppUser)
                .FirstOrDefaultAsync(e => e.Id == id);

            if (embezzlement == null) return NotFound();

            var model = new EmbezzlementViewModel
            {
                Item = embezzlement.Item,
                AppUser = embezzlement.AppUser,
                HandoverDate = embezzlement.HandoverDate,
                ReturnTime = embezzlement.ReturnTime
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, EmbezzlementViewModel model)
        {
            if (ModelState.IsValid)
            {
                var embezzlement = await _context.Embezzlements.FindAsync(id);
                if (embezzlement == null) return NotFound();

                embezzlement.HandoverDate = model.HandoverDate;
                embezzlement.ReturnTime = model.ReturnTime;

                _context.Embezzlements.Update(embezzlement);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var embezzlement = await _context.Embezzlements.FindAsync(id);
            if (embezzlement == null) return NotFound();

            _context.Embezzlements.Remove(embezzlement);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}

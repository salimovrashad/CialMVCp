using CialMVC.Areas.Admin.ViewModels;
using CialMVC.Context;
using CialMVC.Helpers;
using CialMVC.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace CialMVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class WorkerController : Controller
    {
        CialDbContext _db { get; }

        public WorkerController(CialDbContext db)
        {
            _db = db;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.SocialMedia = new SelectList(_db.SocialMedia, "Id", "Name");
            var emp = await _db.Workers.Select(s=> new WorkerListItemVM
            {
                Id = s.Id,
                Name = s.Name,
                ImageURL = s.ImageURL,
                SocialMedia = s.SocialMedia,
                SocialMedias = s.WorkerSMs.Select(sm => sm.SocialMedias).ToList(),
            }).ToListAsync();
            return View(emp);
        }

        public IActionResult Create()
        {
            ViewBag.SocialMedia = new SelectList(_db.SocialMedia, "Id", "Name");
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(WorkerCreateItemVM vm)
        {
            if (!ModelState.IsValid)
            {
                return View(vm);
            }
            ViewBag.SocialMedia = new SelectList(_db.SocialMedia, "Id", "Name");
            Worker worker = new Worker
            {
                Name = vm.Name,
                ImageURL = await vm.ImageURL.SaveAsync(PathConstants.Image),
                WorkerSMs = vm.SocialMediaId.Select(id => new WorkerSM { SocialMediaID = id }).ToList(),
            };
            await _db.Workers.AddAsync(worker);
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Update(int id)
        {
            var item = await _db.Workers.FindAsync(id);
            return View(new WorkerUpdateItemVM
            {
                Name= item.Name
            });
        }

        [HttpPost]

        public async Task<IActionResult> Update(int id, WorkerUpdateItemVM vm)
        {
            var item = await _db.Workers.FindAsync(id);
            item.ImageURL = await vm.ImageURL.SaveAsync(PathConstants.Image);
            item.Name = vm.Name;
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Delete(int id)
        {
            var item = await _db.Workers.FindAsync(id);
            _db.Workers.Remove(item);
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}

using CialMVC.Areas.Admin.ViewModels;
using CialMVC.Context;
using CialMVC.Helpers;
using CialMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace CialMVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SocialMediaController : Controller
    {
        CialDbContext _db { get; }

        public SocialMediaController(CialDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            return View(_db.SocialMedia.ToList());
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(SocialMediaCreateVm vm)
        {
            SocialMedia socialMedia = new SocialMedia
            {
                Name = vm.Name,
            };
            await _db.SocialMedia.AddAsync(socialMedia);
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}

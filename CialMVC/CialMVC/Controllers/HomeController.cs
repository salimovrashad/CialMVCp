using CialMVC.Context;
using Microsoft.AspNetCore.Mvc;

namespace CialMVC.Controllers
{
    public class HomeController : Controller
    {
        CialDbContext _db { get; }

        public HomeController(CialDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            return View(_db.Workers.ToList());
        }
    }
}

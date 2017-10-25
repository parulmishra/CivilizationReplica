using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using CivilizationReplica.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CivilizationReplica.Controllers
{
    public class NationController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<User> _userManager;

        public NationController(UserManager<User> userManager, ApplicationDbContext db)
        {
            _userManager = userManager;
            _db = db;
        }

        public IActionResult Index(string id)
        {
            ViewBag.user = _db.Users.FirstOrDefault(x => x.Id == id);
            return View();
        }


        public IActionResult Create(string id)
        {
            ViewBag.user = _db.Users.FirstOrDefault(x => x.Id == id);
            return View();
        }

        [HttpPost, ActionName("Create")]
        public async Task<IActionResult> CreateNation(Nation nation)
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var currentUser = await _userManager.FindByIdAsync(userId);
            nation.User = currentUser;
            _db.Nations.Add(nation);
            _db.SaveChanges();
            return RedirectToAction("Index", new { id = userId });
        }

        public async Task<IActionResult> Game()
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var currentUser = await _userManager.FindByIdAsync(userId);
            var thisNation = _db.Nations.Include(m => m.User)
                                .FirstOrDefault(m => m.User.Id == userId);
            return View(thisNation);
        }
    }
}

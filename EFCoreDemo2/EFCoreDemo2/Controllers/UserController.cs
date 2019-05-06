using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFCoreDemo2.Data;
using EFCoreDemo2.Models;
using Microsoft.AspNetCore.Mvc;

namespace EFCoreDemo2.Controllers
{
    public class UserController : Controller
    {
        private UserContext _context;

        public UserController(UserContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View(_context.Users.ToList());
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Register(Users registeruser)
        {
            if(ModelState.IsValid)
            {
                _context.Users.Add(registeruser);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(registeruser);
        }
    }
}
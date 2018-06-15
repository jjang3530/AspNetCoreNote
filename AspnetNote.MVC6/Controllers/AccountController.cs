using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspnetNote.MVC6.DataContext;
using AspnetNote.MVC6.Models;
using AspnetNote.MVC6.ViewModel;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AspnetNote.MVC6.Controllers
{
    public class AccountController : Controller
    {
        // GET: /<controller>/
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                using (var db = new AspnetNoteDbContext())
                {
                    //Linq - Mathod chaining  *** Linq query method ***
                    // => : A Go to B
                    //var user = db.Users.FirstOrDefault(u => u.UserId == model.UserId && u.UserPassword == model.UserPassword); //memory leaking

                    var user = db.Users.FirstOrDefault(u => u.UserId.Equals(model.UserId) && u.UserPassword.Equals(model.UserPassword));

                    // if....No ID??? // var user = db.Users.FirstOrDefault(u => u.UserId.Equals(model.UserId));

                    if (user != null)
                    {
                        //Success
                        return RedirectToAction("LoginSuccess", "Home");
                    }
                }

                //Fail
                ModelState.AddModelError(string.Empty, "User is not exist.");
            } 
            return View(model);
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(User model)
        {
            if (ModelState.IsValid)
            {
                using (var db = new AspnetNoteDbContext())
                {
                    db.Users.Add(model);
                    db.SaveChanges();
                }
                return RedirectToAction("Index", "Home");
            }
            return View(model);
        }
    }
}

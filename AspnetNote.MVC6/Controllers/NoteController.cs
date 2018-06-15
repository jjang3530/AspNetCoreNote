using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AspnetNote.MVC6.DataContext;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AspnetNote.MVC6.Controllers
{
    public class NoteController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            //var list = new List<Note>();

            using (var db = new AspnetNoteDbContext())
            {
                var list = db.Notes.ToList(); // Will bring all list
                return View(list);
            }

            
        }

        public IActionResult Add()
        {
            return View();
        }

        public IActionResult Edit()
        {
            return View();
        }

        public IActionResult Delete()
        {
            return View();
        }
    }
}

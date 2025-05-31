using ListApplication.Context;
using ListApplication.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ListApplication.Controllers
{
    public class ListAppController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ListAppController(ApplicationDbContext context)
        {
            _context = context;
        }

        // to show all 
        public IActionResult Index()
        {
            var data = _context.Lists.Include(l => l.Category).ToList();
            return View(data);
        }

        // create form
        public IActionResult Create()
        {
            ViewBag.Categories = _context.Categorys.ToList(); 
            return View();
        }

        // to  save what we create 
        [HttpPost]
        public IActionResult Create(ListApp list)
        {
            _context.Lists.Add(list);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        // edit form
        public IActionResult Edit(int id)
        {
            var item = _context.Lists.Find(id);
            ViewBag.Categories = _context.Categorys.ToList();
            return View(item);
        }




        // save the edit
        [HttpPost]
        public IActionResult Edit(ListApp list)
        {
            _context.Lists.Update(list);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }




        // delete confirm view
        public IActionResult Delete(int id)
        {
            var item = _context.Lists.Include(l => l.Category).FirstOrDefault(l => l.ListAppId == id);
            return View(item);
        }

        // confirm deletion 
        [HttpPost]
        public IActionResult DeleteConfirmed(int id)
        {
            var item = _context.Lists.Find(id);
            _context.Lists.Remove(item);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}

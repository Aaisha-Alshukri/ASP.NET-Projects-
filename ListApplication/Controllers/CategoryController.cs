using ListApplication.Context;
using ListApplication.Models;
using Microsoft.AspNetCore.Mvc;

namespace ListApplication.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CategoryController(ApplicationDbContext context)
        {
            _context = context;
        }

       
        public IActionResult Index()
        {
            var data = _context.Categorys.ToList();
            return View(data);
        }

       //to create 
        public IActionResult Create()
        {
            return View();
        }

        //to save what i create 
        [HttpPost]
        public IActionResult Create(Category category)
        {
            _context.Categorys.Add(category);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        // to edit 
        public IActionResult Edit(int id)
        {
            var cat = _context.Categorys.Find(id);
            return View(cat);
        }

         // to save what we edit 
        [HttpPost]
        public IActionResult Edit(Category category)
        {
            _context.Categorys.Update(category);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        // to see before the delete 
        public IActionResult Delete(int id)
        {
            var cat = _context.Categorys.Find(id);
            return View(cat);
        }

        // to delete 
        [HttpPost]
        public IActionResult DeleteConfirmed(int id)
        {
            var cat = _context.Categorys.Find(id);
            _context.Categorys.Remove(cat);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}

using CarCollection.Data;
using CarCollection.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace CarCollection.Controllers
{
    public class CarModelController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CarModelController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var models = _context.CarModels.Include(m => m.CarBrand).ToList();
            return View(models);
        }

        public IActionResult Create()
        {
            ViewBag.Brands = _context.CarBrands.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult Create(CarModel model)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Brands = _context.CarBrands.ToList();
                return View(model);
            }

            _context.CarModels.Add(model);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(int id)
        {
            var model = _context.CarModels.Find(id);
            if (model == null)
            {
                return NotFound();
            }
            ViewBag.Brands = _context.CarBrands.ToList();
            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(int id, CarModel model)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Brands = _context.CarBrands.ToList();
                return View(model);
            }

            _context.CarModels.Update(model);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int id)
        {
            var model = _context.CarModels.Find(id);
            if (model == null)
            {
                return NotFound();
            }

            _context.CarModels.Remove(model);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}

using CarCollection.Data;
using CarCollection.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace CarCollection.Controllers
{
    public class CarBrandController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CarBrandController(ApplicationDbContext context)
        {
            _context = context;
        }

        [AllowAnonymous]
        public IActionResult Index()
        {
            var brands = _context.CarBrands.Include(b => b.CarModels).ToList();
            return View(brands);
        }

        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        public IActionResult Create(CarBrand brand)
        {
            if (!ModelState.IsValid)
            {
                return View(brand);
            }

            _context.CarBrands.Add(brand);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        [Authorize]
        public IActionResult Edit(int id)
        {
            var brand = _context.CarBrands.Find(id);
            if (brand == null)
            {
                return NotFound();
            }
            return View(brand);
        }

        [HttpPost]
        [Authorize]
        public IActionResult Edit(int id, CarBrand brand)
        {
            if (!ModelState.IsValid)
            {
                return View(brand);
            }

            _context.CarBrands.Update(brand);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        [Authorize]
        public IActionResult Delete(int id)
        {
            var brand = _context.CarBrands.Find(id);
            if (brand == null)
            {
                return NotFound();
            }

            _context.CarBrands.Remove(brand);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}

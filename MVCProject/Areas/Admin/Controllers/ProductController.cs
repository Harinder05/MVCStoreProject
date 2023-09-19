using Microsoft.AspNetCore.Mvc;
using MVCProject.DataAccess.Repository.IRepository;
using MVCProject.Models;

namespace MVCProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IProductRepository _productRepo;
        public ProductController(IProductRepository db)
        {
            _productRepo = db;
        }
        public IActionResult Index()
        {
            List<Product> objProductList = _productRepo.GetAll().ToList();
            return View(objProductList);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Product obj)
        {
            if (ModelState.IsValid)
            {
                _productRepo.Add(obj);
                _productRepo.Save();
                TempData["success"] = "Product created successfully";
                return RedirectToAction("Index", "Product");
            }
            return View();
        }

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Product? productToEdit = _productRepo.Get(u => u.Id == id);
            if (productToEdit == null)
            {
                return NotFound();
            }
            return View(productToEdit);
        }
        [HttpPost]
        public IActionResult Edit(Product obj)
        {
            if (ModelState.IsValid)
            {
                _productRepo.Update(obj);
                _productRepo.Save();
                TempData["success"] = "Product updated successfully";
                return RedirectToAction("Index", "Product");
            }
            return View();
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Product? productToEdit = _productRepo.Get(u => u.Id == id);
            if (productToEdit == null)
            {
                return NotFound();
            }
            return View(productToEdit);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(int? id)
        {
            Product? obj = _productRepo.Get(u => u.Id == id);
            if (obj == null)
            {
                return NotFound();
            }
            _productRepo.Remove(obj);
            _productRepo.Save();
            TempData["success"] = "Product deleted successfully";
            return RedirectToAction("Index", "Product");
        }
    }
}

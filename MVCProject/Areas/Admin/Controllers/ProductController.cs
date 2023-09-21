using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MVCProject.DataAccess.Repository.IRepository;
using MVCProject.Models;

namespace MVCProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IProductRepository _productRepo;
        private readonly ICategoryRepository _categoryRepo;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public ProductController(IProductRepository db, ICategoryRepository categoryRepo, IWebHostEnvironment webHostEnvironment)
        {
            _productRepo = db;
            _categoryRepo = categoryRepo;
            _webHostEnvironment = webHostEnvironment;

        }
        public IActionResult Index()
        {
            List<Product> objProductList = _productRepo.GetAll().ToList();
            List<Category> CategoryList = _categoryRepo.GetAll().ToList();
            ViewBag.Categories = CategoryList;
            return View(objProductList);
        }

        public IActionResult CreateAndUpdate(int? id)
        {
            IEnumerable<SelectListItem> CategoryList = _categoryRepo.GetAll().Select(u => new SelectListItem
            {
                Text = u.Name,
                Value = u.Id.ToString()
            });
            
            ViewBag.Categories = CategoryList;

            if(id == null || id == 0)
            {
                // Create new product view
                return View(new Product());
            }
            else
            {
                // Update product view
                Product obj = _productRepo.Get(u => u.Id == id);
                return View(obj);
            }
            
        }
        [HttpPost]
        public IActionResult CreateAndUpdate(Product obj, IFormFile? imagefile)
        {
            if (ModelState.IsValid)
            {
                string wwwRootPath = _webHostEnvironment.WebRootPath;
                if(imagefile != null) 
                {
                    string filename = Guid.NewGuid().ToString() + Path.GetExtension(imagefile.FileName);
                    string productPath = Path.Combine(wwwRootPath, @"images\product");

                    if(!string.IsNullOrEmpty(obj.ImageUrl))
                    {
                        var oldImagePath = Path.Combine(wwwRootPath, obj.ImageUrl.TrimStart('\\'));

                        if (System.IO.File.Exists(oldImagePath))
                        {
                            System.IO.File.Delete(oldImagePath);
                        }
                    }

                    using( var fileStream = new FileStream(Path.Combine(productPath, filename), FileMode.Create))
                    {
                        imagefile.CopyTo(fileStream);
                    }

                    obj.ImageUrl = @"\images\product\" + filename;
                }

                if(obj.Id == 0)
                {
                    _productRepo.Add(obj);
                }
                else
                {
                    _productRepo.Update(obj);
                }
                
                _productRepo.Save();
                TempData["success"] = "Product created successfully";
                return RedirectToAction("Index", "Product");
            }
            else 
            {
                // If validation fails, repopulate form with data
                IEnumerable<SelectListItem> CategoryList = _categoryRepo.GetAll().Select(u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.Id.ToString()
                });

                ViewBag.Categories = CategoryList;
                return View(obj);
            }
            
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

using Microsoft.AspNetCore.Mvc;
using MVCProject.DataAccess.Repository.IRepository;
using MVCProject.Models;
using System.Diagnostics;

namespace MVCProject.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProductRepository _productRepo;
        private readonly ICategoryRepository _categoryRepo;

        public HomeController(ILogger<HomeController> logger, IProductRepository productRepository, ICategoryRepository categoryRepo)
        {
            _logger = logger;
            _productRepo = productRepository;
            _categoryRepo = categoryRepo;
        }

        public IActionResult Index()
        {
            IEnumerable<Product> productList = _productRepo.GetAll();
            return View(productList);
        }

        public IActionResult Details(int productId)
        {
            Product productDetails = _productRepo.Get(u=>u.Id==productId);
            string categoryName = _categoryRepo.Get(u => u.Id == productDetails.CategoryId).Name;
            ViewBag.CategoryName = categoryName;
            return View(productDetails);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
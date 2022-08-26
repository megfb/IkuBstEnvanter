using BstEnvanter.Business.Abstract;
using BstEnvanter.Entity.Concrete;
using BstEnvanter.WebUI.Models;
using Microsoft.AspNetCore.Mvc;

namespace BstEnvanter.WebUI.Controllers
{
    public class HomeController : Controller
    {
        private IStatusService _statusService;
        private ICategoryService _categoryService;
        private IProductService _productService;
        public HomeController(ICategoryService categoryService,IStatusService statusService)
        {
            _categoryService = categoryService;
            _statusService = statusService;
        }
        public IActionResult Index()
        {
            var lstModel = new List<IndexViewModel>();
            var categories = _categoryService.getAll();
            foreach (var item in categories)
            {
                var status = _statusService.getAllWithDetailsByCategory(item.id);

                lstModel.Add(new IndexViewModel
                {
                    DimensionOne = item.name,
                    Quantity = status.Count
                });
            }
            return View(lstModel);
        }
    }
}

using ElglalyStore.Models;
using Microsoft.AspNetCore.Mvc;

namespace ElglalyStore.Controllers
{
    public class ProductController : Controller
    {
      
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult supermarket(int id)
        {
            return View(Appdbcontext._Instance.Products.Where(p => p.product_category_id == id).ToString());
        }



    }
}

using ElglalyStore.Models;
using Microsoft.AspNetCore.Mvc;

namespace ElglalyStore.Controllers
{
    public class ProductController : Controller
    {
        Appdbcontext db = new Appdbcontext();
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult supermarket(int id)
        {
            return View(db.Products.Where(p => p.product_category_id == id).FirstOrDefault().ToString());
        }



    }
}

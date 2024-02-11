using ElglalyStore.Models;
using Microsoft.AspNetCore.Mvc;

namespace ElglalyStore.Controllers
{
	public class CategoryController : Controller
	{
		Appdbcontext db=new Appdbcontext();
		public IActionResult Index()
		{
			return View(db.Categorys.ToList());
		}


        public IActionResult Details(int id)
        {
            Category category = db.Categorys.SingleOrDefault(c => c.category_Id == id);
            if(category == null)
            {
                return NotFound();
            }
            TempData["cat"] = category.category_name;

            List<Product> products = db.Products.Where(p => p.product_category_id == id).ToList();

            if (products.Count == 0)
            {
                ViewBag.NoProductsMessage = "No products available for this category.";
            }
            return View(products);
        }
        public IActionResult product(int id)
        {
            return View(db.Products.Where(p=>p.product_category_id==id).ToList());
        }
    }
}

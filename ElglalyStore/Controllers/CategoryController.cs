using ElglalyStore.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace ElglalyStore.Controllers
{
	public class CategoryController : Controller
	{
		
		public IActionResult Index()
		{
			return View(Appdbcontext._Instance.Categorys.ToList());
		}


        public IActionResult Details(int id)
        {
            string category_name = string.Empty;

			try
            {
                category_name = Appdbcontext._Instance.Categorys.FirstOrDefault(c => c.category_Id == id)?.category_name ?? "";
            }
            catch (Exception)
            {
				category_name = string.Empty;

			}
            if(string.IsNullOrEmpty(category_name))
            {
                return NotFound();
            }
            TempData["cat"] = category_name;

            List<Product> products = Appdbcontext._Instance.Products.Where(p => p.product_category_id == id).ToList();

            if (products.Count == 0)
            {
                ViewBag.NoProductsMessage = "No products available for this category.";
            }
            return View(products);
        }
        public IActionResult product(int id)
        {
            return View(Appdbcontext._Instance.Products.Where(p=>p.product_category_id==id).ToList());
        }
    }
}

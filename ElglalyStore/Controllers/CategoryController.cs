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
			var res = db.Categorys.Where(c => c.category_Id == id).FirstOrDefault();
            ViewBag.cat = res.category_name;
            return View(db.Products.Where(p => p.product_category_id == id).ToList());

        }
        public IActionResult product(int id)
        {
            return View(db.Products.Where(p=>p.product_category_id==id).ToList());
        }
    }
}

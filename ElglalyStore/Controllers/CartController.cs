using ElglalyStore.Models;
using Microsoft.AspNetCore.Mvc;

namespace ElglalyStore.Controllers
{
	public class CartController : Controller
	{
		Appdbcontext db=new Appdbcontext();
		public IActionResult Index()
		{
			return View();
		}

        public IActionResult Additem(int id)
        {
            return View();
        }
    }
}

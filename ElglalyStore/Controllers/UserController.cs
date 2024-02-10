using Microsoft.AspNetCore.Mvc;

namespace ElglalyStore.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

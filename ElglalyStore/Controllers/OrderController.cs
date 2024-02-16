using ElglalyStore.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace ElglalyStore.Controllers
{
    public class OrderController : Controller
    {
		Appdbcontext db = new Appdbcontext();

		public ActionResult checkout()
            {
                var user = Request.Cookies["UserInfo"];
                if (user != null)
                {
				var carts = db.Carts.Where(cart => cart.Cart_custmer_id == int.Parse(user)).ToList();
				var cut = db.Customers.FirstOrDefault(c => c.Customer_Id == int.Parse(user));
				var users = new CheckoutModelView();
				List<CartModelView> cart_user = new List<CartModelView>();


					foreach (var cart in carts)
				    {
					var res = db.Products.FirstOrDefault(p => p.product_Id == cart.Cart_product_id);

					cart_user.Add(new CartModelView
					{
						Name = res.product_name,
						Image = res.product_image,
						Price = res.product_price,
						Quantity = cart.Cart_quantity,
						Total_Price = res.product_price * cart.Cart_quantity,
						Product_id = res.product_Id,

					});

			     	};
		
						users=new CheckoutModelView
					{
						Fisrt_name = cut.Fisrt_name,
						Last_name = cut.Last_name,
						total_price = decimal.Parse(TempData.Peek("price").ToString()),
						Address=cut.Address,
						Phone_number = cut.Phone_number,
						CartView= cart_user,
						Email=cut.Email,

						}; 
				

				    return View(users);
                }

                else
                {
                    return RedirectToAction("Index", "Home");
                }

            }

		public IActionResult Orders( CheckoutModelView check)
		{

			if(ModelState.IsValid)
			{
				return View("thanks");
			}

			else
			{

				return Json(ModelState);
			}
			
		}



	}

}

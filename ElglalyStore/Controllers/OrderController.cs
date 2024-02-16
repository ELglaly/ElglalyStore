using ElglalyStore.Models;
using Microsoft.AspNetCore.Mvc;

namespace ElglalyStore.Controllers
{
    public class OrderController : Controller
    {
           public ActionResult checkout()
            {
                var user = Request.Cookies["UserInfo"];
                if (user != null)
                {

                    List<CartModelView> users = new List<CartModelView>();
                    decimal price_before_Coupon = 0;

                    var carts = db.Carts.Where(cart => cart.Cart_custmer_id == int.Parse(user)).ToList();
                    foreach (var cart in carts)
                    {
                        var res = db.Products.FirstOrDefault(p => p.product_Id == cart.Cart_product_id);
                        users.Add(new CartModelView
                        {
                            Name = res.product_name,
                            Price = res.product_price,
                            Quantity = cart.Cart_quantity,
                            Total_Price = res.product_price * cart.Cart_quantity,
                            Product_id = res.product_Id,


                        });
                        price_before_Coupon += (res.product_price * cart.Cart_quantity);
                    }


                    TempData["price"] = price_before_Coupon.ToString();

                    return View(users);
                }

                else
                {
                    return RedirectToAction("Index", "Home");
                }

            }

		public ActionResult Order()
		{
			var user = Request.Cookies["UserInfo"];
			if (user != null)
			{

				List<CartModelView> users = new List<CartModelView>();
				decimal price_before_Coupon = 0;

				var carts = db.Carts.Where(cart => cart.Cart_custmer_id == int.Parse(user)).ToList();
				foreach (var cart in carts)
				{
					var res = db.Products.FirstOrDefault(p => p.product_Id == cart.Cart_product_id);
					users.Add(new CartModelView
					{
						Name = res.product_name,
						Price = res.product_price,
						Quantity = cart.Cart_quantity,
						Total_Price = res.product_price * cart.Cart_quantity,
						Product_id = res.product_Id,


					});
					price_before_Coupon += (res.product_price * cart.Cart_quantity);
				}


				TempData["price"] = price_before_Coupon.ToString();

				return View(users);
			}

			else
			{
				return RedirectToAction("Index", "Home");
			}

		}



	}

}

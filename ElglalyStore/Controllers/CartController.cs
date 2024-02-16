using ElglalyStore.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.DotNet.Scaffolding.Shared.Messaging;
using Microsoft.Identity.Client;

namespace ElglalyStore.Controllers
{
	public class CartController : Controller
	{
		Appdbcontext db=new Appdbcontext();

        
        public IActionResult Index()
		{

           // TempData["price"] = 0;
            var user = Request.Cookies["UserInfo"];
            if (user != null)
            {
                
                List<CartModelView> users = new List<CartModelView>();
                decimal price_before_Coupon = 0;

                var  carts=db.Carts.Where(cart=>cart.Cart_custmer_id==int.Parse(user)).ToList();
                foreach(var cart in carts)
                {
                    var res=db.Products.FirstOrDefault(p=>p.product_Id==cart.Cart_product_id);
                    users.Add(new CartModelView
                    {
                        Name = res.product_name,
                        Image = res.product_image,
                        Price = res.product_price,
                        Quantity = cart.Cart_quantity,
                        Total_Price = res.product_price * cart.Cart_quantity,
                        Product_id=res.product_Id,
                       

                    });
                    price_before_Coupon += (res.product_price * cart.Cart_quantity) ;
                }

               
                   TempData["price"]= price_before_Coupon.ToString();
          
                   return View(users);
            }

            else
            {
                return RedirectToAction("Index" ,"Home");
            }
            }

        public IActionResult AddItem(int id)
        {
            var res=db.Carts.FirstOrDefault(c=>c.Cart_product_id==id);
            if(res == null)
            {
                var userIdCookie = Request.Cookies["UserInfo"];


                if (int.TryParse(userIdCookie, out int userId))
                {

                    Cart cart = new Cart
                    {
                        Cart_custmer_id = userId,
                        Cart_product_id = id,
                        Cart_quantity = 1,
                    };

                    db.Carts.Add(cart);
                    

                    try
                    {
                        db.SaveChanges();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error saving cart item: {ex.Message}");
                    }
                }


            }
            int id_category = db.Products.FirstOrDefault(c => c.product_Id == res.Cart_product_id).product_category_id;
            return RedirectToAction("Details", "Category", new { id = id_category });

        }
        [HttpPost]
        public IActionResult Edit(int id, int Quantity)
        {
            decimal price_before = 0;
            if (TempData.ContainsKey("price"))
            {
                price_before = decimal.Parse(TempData.Peek("price").ToString());
            }

            var user = Request.Cookies["UserInfo"];
            decimal Price = db.Products.FirstOrDefault(c => c.product_Id == id).product_price;
          
            var res = db.Carts.FirstOrDefault(c => c.Cart_product_id == id &&
            c.Cart_custmer_id == int.Parse(user));
                if (res != null)
               { 

                price_before -= Price * res.Cart_quantity;
                res.Cart_quantity= Quantity;
                Price = Price * Quantity;
                db.Carts.Update(res);
                db.SaveChanges();
                }
              
            
             price_before += Price;
            TempData["price"] = price_before.ToString();
            return Json(new { price=Price, price2 = price_before});

        }

      
        public IActionResult Delete(int id)
        {
            var use = Request.Cookies["UserInfo"];
            var carts = db.Carts.Where(cart => cart.Cart_custmer_id == int.Parse(use) && id==cart.Cart_product_id).FirstOrDefault();
            db.Carts.Remove(carts);
            db.SaveChanges();
            return RedirectToAction("index");
        }

        public ActionResult Apply_Coupon(string coupon)
        {
            List<string > coupons = new List<string>();
            coupons.Add("sherif");
            coupons.Add( "Elglaly");
            coupons.Add("Ashraf");
            if (coupons.Contains(coupon))
            {
                if (TempData.ContainsKey("price"))
                {
                    TempData["price"]= (decimal.Parse(TempData.Peek("price").ToString())/2).ToString();
                }

                return Json(new { message = "Coupon Has Applied", price = decimal.Parse(TempData.Peek("price").ToString())});
            }
            else
            {
                return Json(new { message = "Coupon Does Not Correct", price = decimal.Parse(TempData.Peek("price").ToString()) });

            }
        }

       
    }
}

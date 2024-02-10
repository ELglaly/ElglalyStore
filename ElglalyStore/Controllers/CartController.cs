using ElglalyStore.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ElglalyStore.Controllers
{
	public class CartController : Controller
	{
		Appdbcontext db=new Appdbcontext();

        
        public IActionResult Index()
		{
          
            
            var user = Request.Cookies["UserInfo"];
            if (user != null)
            {
                
                List<CartModelView> users = new List<CartModelView>();
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
                        Product_id=res.product_Id

                    }); 
                }

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
            return RedirectToAction("Details", "Category", new { id = id });

        }
        [HttpPost]
        public ActionResult Edit(int id, int Quantity)
        {
            var user = Request.Cookies["UserInfo"];

            var res = db.Carts.FirstOrDefault(c => c.Cart_product_id == id &&
            c.Cart_custmer_id == int.Parse(user)
            );
                if (res != null)
               { 
                res.Cart_quantity= Quantity;
                db.Carts.Update(res);
                db.SaveChanges();
                }
 

            return RedirectToAction("Index");

        }

      
        public ActionResult Delete(int id)
        {
            var use = Request.Cookies["UserInfo"];
            var carts = db.Carts.Where(cart => cart.Cart_custmer_id == int.Parse(use) && id==cart.Cart_product_id).FirstOrDefault();
            db.Carts.Remove(carts);
            db.SaveChanges();
            return RedirectToAction("index");
        }
    }
}

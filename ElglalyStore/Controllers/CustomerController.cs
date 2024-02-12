using Microsoft.AspNetCore.Mvc;
using ElglalyStore.Models;
using ElglalyStore.Data;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;
//using AspNetCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.Identity.Client;
using System.Reflection.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Web;
namespace ElglalyStore.Controllers
{
    public class CustomerController : Controller
    {
       
         Appdbcontext db=new Appdbcontext();
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Registeration() {
                
            return View(new Customer());
        
        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult Save(Customer customer)
        {


            if (ModelState.IsValid)
            {
                if (db.Customers.Where(p=>p.Phone_number==customer.Phone_number).FirstOrDefault() != null)

                {
                    ModelState.AddModelError("phone_number", "This Phone Number is already registered.");
                        return View("Registeration",customer);
                }
                else if (db.Customers.Where(p => p.Email == customer.Email).FirstOrDefault() != null)

                {

                        ModelState.AddModelError("email", "This Email is already registered.");
                    return View("Registeration", customer);
                }
                else
                {
                    db.Customers.Add(customer);
                    db.SaveChanges();
                    
                    return RedirectToAction("Login");
                }
            }

            else
            {
                return View("Registeration",customer);
            }
         
        }

        
        public IActionResult Login()
        { 
                return View();
        }

        [HttpPost]
       // [ValidateAntiForgeryToken]
        public IActionResult Login_valid(string password,string email)
            {
            var res=new Customer();
            if (ModelState.IsValid)
            {
                res=db.Customers.FirstOrDefault(c=>c.Email == email);
                if(res != null)
                {
                    if(res.Password==password)
                    {
                        var User = new CookieOptions
                        {
                            // Set expiration time for the cookie (optional)
                            Expires = DateTime.Now.AddDays(30), // Adjust the expiration as needed
                            HttpOnly = true,
                        };
                        Response.Cookies.Append("UserInfo", $"{res.Customer_Id}", User);
                        return RedirectToAction("Index","Home");
                    }
                    else
                    {
                        ModelState.AddModelError("password", "Password does not Correct");
                        return View("Login");
                    }

                }
   
                else
                {
                    ModelState.AddModelError("email", "Email does not exist try a valid one");
                    return View("Login");
                }

            }
            else
            {

                return View("Login");
            }

        }


        public IActionResult account() {

            var user = Request.Cookies["UserInfo"];
          
            if (user != null)
            {

                    return View();
            }
            return RedirectToAction("Index","Home");
        }
        public IActionResult Profile()
        {
            var user = Request.Cookies["UserInfo"];
            Customer cust=db.Customers.FirstOrDefault(c=>c.Customer_Id==int.Parse(user));
            return PartialView("_EditProfilePartial", cust);
        }

        [HttpPost]
        public IActionResult Edit(Customer customer)
        {
            if(ModelState.IsValid)
            {
                
                db.Customers.Update(customer);
                db.SaveChanges();
                
                return RedirectToAction("Account", "Customer");

            }
            else
            {
              
                return RedirectToAction("Account", "Customer");
    
            }


        }
        public IActionResult logout()
        {

            var user = Request.Cookies["UserInfo"];

            if (user != null)
            {
                Response.Cookies.Delete("UserInfo");
            }
            return RedirectToAction("Index", "Home");
        }





    }
}

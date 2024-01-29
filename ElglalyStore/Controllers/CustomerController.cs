using Microsoft.AspNetCore.Mvc;
using ElglalyStore.Models;
using ElglalyStore.Data;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;
using AspNetCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.Identity.Client;
using System.Reflection.Metadata;

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
        public IActionResult Save(Customer customer)
        {


            if (ModelState.IsValid)
            {
                if (db.Customers.Where(p=>p.phone_number==customer.phone_number).FirstOrDefault() != null)

                {
                    ModelState.AddModelError("phone_number", "This Phone Number is already registered.");
                        return View("Registeration",customer);
                }
                else if (db.Customers.Where(p => p.email == customer.email).FirstOrDefault() != null)

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

        [HttpPost]
        public IActionResult Login(string email,string password)
        {

            var res=db.Customers.FirstOrDefault(c=>c.email == email);
            if ( res!=null)
            {
                return View("Inex", Cart);
            }
            else
            {
                return View("Login");
            }

            

           
        }
    }
}

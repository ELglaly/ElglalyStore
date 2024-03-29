﻿using Microsoft.AspNetCore.Mvc;
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
                if (Appdbcontext._Instance.Customers.Where(p=>p.Phone_number==customer.Phone_number).FirstOrDefault() != null)

                {
                    ModelState.AddModelError("phone_number", "This Phone Number is already registered.");
                        return View("Registeration",customer);
                }
                else if (Appdbcontext._Instance.Customers.Where(p => p.Email == customer.Email).FirstOrDefault() != null)

                {

                        ModelState.AddModelError("email", "This Email is already registered.");
                    return View("Registeration", customer);
                }
                else
                {
                    Appdbcontext._Instance.Customers.Add(customer);
                    Appdbcontext._Instance.SaveChanges();
                    
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
                res=Appdbcontext._Instance.Customers.FirstOrDefault(c=>c.Email == email);
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
                    return View(Appdbcontext._Instance.Customers.FirstOrDefault(c=>c.Customer_Id==int.Parse(user)));
            }
            return RedirectToAction("Index","Home");
        }
        [HttpGet]
        public IActionResult Profile(int id)
        {


            Customer cust=Appdbcontext._Instance.Customers.FirstOrDefault(c=>c.Customer_Id==id)!;

            return PartialView("_EditProfilePartial", cust);
        }

        [HttpPost]
        public IActionResult Edit(Customer NewCut)
        {
             if (ModelState.IsValid)
            {

                Customer cut = Appdbcontext._Instance.Customers.FirstOrDefault(c => c.Customer_Id == NewCut!.Customer_Id)!;

                cut.Fisrt_name = NewCut.Fisrt_name;
                cut.Address = NewCut.Address;
                cut.Phone_number = NewCut.Phone_number;

                Appdbcontext._Instance.Customers.Update(cut);
                Appdbcontext._Instance.SaveChanges();
                return PartialView("_EditProfilePartial", cut);

            }

            return PartialView("_EditProfilePartial", NewCut);

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

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using E_Shop.Dal;
using E_Shop.Models;
using Microsoft.AspNetCore.Mvc;

namespace E_Shop.Controllers
{
    public class HomeController : Controller
    {
       public IActionResult Index()
       {
           return View();
       }

       public IActionResult Buy(Dictionary<string,int> ProductNames, int UserId)
       {
           using (EShopContext context = new EShopContext())
           {
               var order = new Order();
               order.UserId = UserId;
               context.SaveChanges();

               var orders = new OrderProduct();

               foreach (var productName in ProductNames)
               {
                    var product = context.Products.SingleOrDefault(pro => pro.ProductName == productName.Key);
                    orders.ProductId = product.ProductId;
                    orders.OrderId = order.OrderId;
                    orders.Piece = productName.Value;
                }


                   
               context.SaveChanges();
           }
           return Content("Siparişiniz Başarıyla Alındı.");
       }

       public IList<Product> CatagorySearch(int id)
       {
           using (EShopContext context = new EShopContext())
           {
               var model = context.Products.Where(con => con.CatogoryId == id).ToList();
               return model;
           }
       }

       public List<Product> ProductNameSearch(string name)
       {
             using (EShopContext context = new EShopContext())
           {
               var model = context.Products.Where(con => con.ProductName == name).ToList();
               return model;
           }
       }


    }
}

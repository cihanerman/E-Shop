using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using E_Shop.Dal;
using E_Shop.Models;
using Microsoft.AspNetCore.Mvc;

namespace E_Shop.Controllers
{
    public class AdminController : Controller
    {
       public IActionResult Index()
       {
           return View();
       }

       public IActionResult Orders()
       {
           using (EShopContext con = new EShopContext())
           {
                var ordersList = (from op in con.OrderProduct
                                    join o in con.Orders on op.OrderId equals o.OrderId
                                    join u in con.Users on o.UserId equals u.UserId
                                    join p in con.Products on op.ProductId equals p.ProductId
                                    select new
                                    {
                                        UserFirstName = u.FirstName,
                                        UserLastName = u.LastName,
                                        OrderNu = o.OrderId,
                                        ProductName = p.ProductName
                                    }).GroupBy(op => con.OrderProduct,
                                                (op) => new { OrderId = op.OrderNu }).ToList();
               
               return Json(ordersList);
           }
       }

       public IActionResult AddProduct(
        int productId,
        string name,
        string description,
        decimal price,
        int stock,
        string url,
        int catogoryId)
       {
           using (EShopContext context = new EShopContext())
           {
                var product = new Product();
                product.ProductId = productId;
                product.ProductName = name;
                product.Description = description;
                product.Price = price;
                product.Stock = stock;
                product.PruductImageUrl = url;
                product.CatogoryId = catogoryId;

                context.Products.Add(product);
                context.SaveChanges();

                return Content("Ürün başarıyla kaydedildi");
            }
       }

       public IActionResult DeleteProduct(int id)
       {
           using (EShopContext context = new EShopContext())
           {
               var product =context.Products.SingleOrDefault(cont => cont.ProductId == id);
               context.Products.Remove(product);

               return Content("Ürün başarıyla silindi");
           }
       }

       public IActionResult UpdateProduct(
        int productId,
        string name,
        string description,
        decimal price,
        int stock,
        string url,
        int catogoryId)
       {
           using (EShopContext context = new EShopContext())
           {
                var product = context.Products.SingleOrDefault(con => con.ProductId == productId);
                product.ProductName = name;
                product.Description = description;
                product.Price = price;
                product.Stock = stock;
                product.PruductImageUrl = url;
                product.CatogoryId = catogoryId;

                context.SaveChanges();

                return Content("Ürün bilgileri başarıyla güncellendi");
           }
       }
    }
}

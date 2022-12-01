using Microsoft.AspNetCore.Mvc;
using store;
using Store.Memory;
using Store.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Store.Web.Controllers
{
    public class OrderController : Controller
    {
        private readonly IBookRepository bookRepository;
        private readonly IOrderRepository repository;
        public OrderController(IBookRepository bookRepository,IOrderRepository repository)
        {
            this.repository = repository;
            this.bookRepository = bookRepository;
        }

        public IActionResult Index()
        {


            if (HttpContext.Session.TryGetCart(out Cart cart))
            {
                var order = repository.GetById(cart.OrderId);
               // var model = null;
                //return model;
            }
            return View("Empty");
        }
        public IActionResult Add(int id)
        {
            var book = bookRepository.GetByID(id);
            Order order;
            Cart cart;
            
            if (HttpContext.Session.TryGetCart(out cart))
            {
                order = repository.GetById(cart.OrderId);
            }
            else
            {
                order = repository.Create();
                cart = new Cart(order.Id);
            }

            order.AddItem(book, 1);
            repository.Update();
            cart.TotalCount = order.TotalCount;
            cart.TotalPrice = order.TotalPrice;
            HttpContext.Session.Set(cart);
            return RedirectToAction("Index","Book",new { id=id});
        }
    }
}

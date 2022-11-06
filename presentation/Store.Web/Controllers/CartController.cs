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
    public class CartController : Controller
    {
        private readonly IBookRepository bookRepository;
        public CartController(IBookRepository bookRepository)
        {
            this.bookRepository = bookRepository;
        }
        public IActionResult Add(int id)
        {
            var book = bookRepository.GetByID(id);
            Cart cart;
            if (!HttpContext.Session.TryGetCart(out cart))
                cart = new Cart();
            if (cart.items.ContainsKey(id))
            {
                cart.items[id]++;
                cart.amount += book.Price;
            }
            else
            {
                cart.items[id] = 1;
            }
            HttpContext.Session.Set(cart);
            return RedirectToAction("Index","Book",new { id=id});
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Store.Memory;
using store;

namespace Store.Web.Controllers
{
    public class BookController : Controller
    {
        IBookRepository bookRepository;
       public BookController(IBookRepository book)
        {
            bookRepository = book;
        }
        public IActionResult Index(int id)
        {
            Book book = bookRepository.GetByID(id);
            return View(book);
        }
    }
}

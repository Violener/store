using Microsoft.AspNetCore.Mvc;
using store;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Store.Web.Controllers
{
    public class SearchController : Controller
    {
        private readonly BookServise bookservice;
        public SearchController(BookServise bookservice)
        {
            this.bookservice = bookservice;
        }
        public IActionResult Index(string query)
        {
            var books = bookservice.GetAllByQuery(query);
            return View(books);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Store.Web.Models
{
    public class OrderItemModel
    {
        public int bookId { get; }
        public string Title { get; }
        public string Author { get; }
        public int Count { get; }
        public decimal Price { get; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace store
{
    public class OrderItem
    {
        public int BookId { get; }
        public int Count { get; }
        public decimal Price { get; }

        public OrderItem(int bookid,int count,decimal price)
        {
            if (count <= 0)
                throw new ArgumentOutOfRangeException("Должно быть больше нуля");
            BookId = bookid;
            Count = count;
            Price = price;
        }
    }
}

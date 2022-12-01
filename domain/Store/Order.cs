using Store;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace store
{
    public class Order
    {
        public int Id { get; }
        private List<OrderItem> items;
        public IReadOnlyCollection<OrderItem> Items
        {
            get { return items; }
        }
        public int TotalCount
        {
            get { return items.Sum(item => item.Count); }
        }
        public decimal TotalPrice
        {
            get { return items.Sum(item => item.Price * item.Count); }
        }
        public Order(int id, IEnumerable<OrderItem> items)
        {
            if (items == null)
                throw new ArgumentNullException();
            Id = id;
            this.items = new List<OrderItem>(items);
        }
        public OrderItem Get(int bookId)
        {
            int index = items.FindIndex(item => item.BookId == bookId);
            return items[index];
        }
        public void AddorUpdateItem(Book book, int count)
        {
            if (book == null)
                throw new ArgumentNullException();
            var item = items.SingleOrDefault(x => x.BookId == book.Id);
            if (item == null)
            {
                items.Add(new OrderItem(book.Id, count, book.Price));
            }
            else
            {
                items.Remove(item);
                items.Add(new OrderItem(book.Id, item.Count + count, book.Price));
            }
            
        }
              public void RemoveItem(Book book)
              {
                if(book == null)
                throw new ArgumentNullException();

                
                var item = items.SingleOrDefault(x => x.BookId == book.Id);
            if (item == null)
                throw new InvalidOperationException();
            items.RemoveAll(x => x.BookId == book.Id);
        }
        
    }
}

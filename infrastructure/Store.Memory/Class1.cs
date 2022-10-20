using store;
using System;
using System.Linq;

namespace Store.Memory
{
    public class BookRepository : IBookRepository
    {
        private readonly Book[] books =
        {
            new Book(1,"Art of Programming" ),
            new Book(2,"Refactoring" ),
            new Book(3,"C Programming Language" )
        };
        public Book[] GetAllByTitle(string titlepart)
        {
           return books.Where(book => book.Title.Contains(titlepart)).ToArray();
        }
    }
}

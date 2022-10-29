using store;
using System;
using System.Linq;

namespace Store.Memory
{
    public class BookRepository : IBookRepository
    {
        private readonly Book[] books =
        {
            new Book(1,"ISBN - 12345-678910","Whkkkk","Art of Programming","fufuufufufufuf",29m ),
            new Book(2,"ISBN - 12345-678910","Whccccc","Refactoring","fufuufufufufuf",29m ),
            new Book(3,"ISBN - 12345-678910","Whvvvvv","C Programming Language","fufuufufufufuf",29m )
        };
        public Book[] GetAllByTitleOrAuthor(string titlepart)
        {
           return books.Where(book => book.Title.Contains(titlepart) || book.Author.Contains(titlepart)).ToArray();
        }
         
        public Book[] GetAllByIsbn(string isbn)
        {
            return books.Where(book => book.Isbn == isbn).ToArray();
        }
    }
}

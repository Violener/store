using store;
using System;
using System.Linq;

namespace Store.Memory
{
    public class BookRepository : IBookRepository
    {
        private readonly Book[] books =
        {
            new Book(1,"ISBN - 12345-678910","AAAAAA","Art of Programming","BBBBBBB",29m ),
            new Book(2,"ISBN - 12345-678910","BBBBBB","Refactoring","CCCCCCCCC",29m ),
            new Book(3,"ISBN - 12345-678910","CCCCCC","C Programming Language","DDDDDDDDDD",29m )
        };
        public Book[] GetAllByTitleOrAuthor(string titlepart)
        {
           return books.Where(book => book.Title.Contains(titlepart) || book.Author.Contains(titlepart)).ToArray();
        }
         
        public Book[] GetAllByIsbn(string isbn)
        {
            return books.Where(book => book.Isbn == isbn).ToArray();
        }

        public Book GetByID(int id)
        {
            return books.Single(book=>book.Id==id);
        }
    }
}

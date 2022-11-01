using store;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Tests
{
    class StubBookRepository : IBookRepository
    {

        public Book[] resultOfGetAllByTitleOrAuthor { get; set;}
        public Book[] resultOfGetAllByIsbn { get; set; }
        public Book[] GetAllByTitleOrAuthor(string titlepart)
        {
            return resultOfGetAllByTitleOrAuthor;
        }

        public Book[] GetAllByIsbn(string isbn)
        {
            return resultOfGetAllByIsbn;
        }

        public Book GetByID(int id)
        {
            throw new NotImplementedException();
        }
    }
}

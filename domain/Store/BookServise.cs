using Store;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace store
{
    public class BookServise
    {
        private readonly IBookRepository bookRepository;
        public BookServise(IBookRepository repository)
        {
            this.bookRepository = repository;
        }
        public Book[] GetAllByQuery(string query) {
            if (Book.IsIsbn(query))
                return bookRepository.GetAllByIsbn(query);

            return bookRepository.GetAllByTitleOrAuthor(query);
        }
    }
}

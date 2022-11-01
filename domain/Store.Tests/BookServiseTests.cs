using Moq;
using store;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Store.Tests
{
    public class BookServiseTests
    {
        [Fact]
        public void GetAllByQuery_WithIsISBN_CallsGetAllByISBN()
        {
            var bookRepositoryStub = new Mock< IBookRepository > ();
            bookRepositoryStub.Setup(x => x.GetAllByIsbn(It.IsAny<string>()))
                .Returns(new[] { new Book(1, "", "", "", "fufuufufufufuf", 29m) }) ;
            bookRepositoryStub.Setup(x => x.GetAllByTitleOrAuthor(It.IsAny<string>()))
               .Returns(new[] { new Book(2, "", "", "", "fufuufufufufuf", 29m) });

            var bookServise = new BookServise(bookRepositoryStub.Object);
            var validISBN = "ISBN 1234567890";
            var actual = bookServise.GetAllByQuery(validISBN);
            Assert.Collection(actual, book => Assert.Equal(1, book.Id));
        }

        [Fact]
        public void GetAllByQuery_WithIsISBN_CallsGetAllByAuthor()
        {
            var bookRepositoryStub = new Mock<IBookRepository>();
            bookRepositoryStub.Setup(x => x.GetAllByIsbn(It.IsAny<string>()))
                .Returns(new[] { new Book(1, "", "", "", "fufuufufufufuf", 29m) });
            bookRepositoryStub.Setup(x => x.GetAllByTitleOrAuthor(It.IsAny<string>()))
               .Returns(new[] { new Book(2, "", "", "", "fufuufufufufuf", 29m) });

            var bookServise = new BookServise(bookRepositoryStub.Object);
            var invalidISBN = " 1234567890";
            var actual = bookServise.GetAllByQuery(invalidISBN);
            Assert.Collection(actual, book => Assert.Equal(2, book.Id));
        }
        [Fact]
        public void GetAllByQueryWithISBN()
        {
            const int _IdISBN = 1;
            const int Author = 2;
            var bookrepository = new StubBookRepository();
            bookrepository.resultOfGetAllByIsbn = new[]
            {
                new Book (_IdISBN,"","","","fufuufufufufuf",29m)
            };
            bookrepository.resultOfGetAllByTitleOrAuthor = new[]
           {
                new Book (Author,"","","","fufuufufufufuf",29m)
            };
            var bookServise = new BookServise(bookrepository);
            var book = bookServise.GetAllByQuery("ISBN 123-456-789-1");
            Assert.Collection(book, book => Assert.Equal(_IdISBN, book.Id));
        }
        public void GetAllByQueryWithAuthor()
        {
            const int _IdISBN = 1;
            const int Author = 2;
            var bookrepository = new StubBookRepository();
            bookrepository.resultOfGetAllByIsbn = new[]
            {
                new Book (_IdISBN,"","","","fufuufufufufuf",29m)
            };
            bookrepository.resultOfGetAllByTitleOrAuthor = new[]
           {
                new Book (Author,"","","","fufuufufufufuf",29m)
            };
            var bookServise = new BookServise(bookrepository);
            var book = bookServise.GetAllByQuery("Who");
            Assert.Collection(book, book => Assert.Equal(Author, book.Id));
        }

    }
}

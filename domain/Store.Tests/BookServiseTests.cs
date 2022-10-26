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
                .Returns(new[] { new Book(1, "", "", "") }) ;
            bookRepositoryStub.Setup(x => x.GetAllByTitleOrAuthor(It.IsAny<string>()))
               .Returns(new[] { new Book(2, "", "", "") });

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
                .Returns(new[] { new Book(1, "", "", "") });
            bookRepositoryStub.Setup(x => x.GetAllByTitleOrAuthor(It.IsAny<string>()))
               .Returns(new[] { new Book(2, "", "", "") });

            var bookServise = new BookServise(bookRepositoryStub.Object);
            var invalidISBN = " 1234567890";
            var actual = bookServise.GetAllByQuery(invalidISBN);
            Assert.Collection(actual, book => Assert.Equal(2, book.Id));
        }

    }
}

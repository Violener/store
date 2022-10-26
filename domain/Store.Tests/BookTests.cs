using System;
using Xunit;

namespace Store.Tests
{
    public class BookTests
    {
        [Fact]
        public void IsIsbn_withNULL_returnfalse()
        {
            bool actual = Book.IsIsbn(null);
            Assert.False(actual);
        }

        [Fact]
        public void IsIsbn_withBlankString_returnfalse()
        {
            bool actual = Book.IsIsbn("      ");
            Assert.False(actual);
        }

        [Fact]
        public void IsIsbn_withInvalidIsbn_returnfalse()
        {
            bool actual = Book.IsIsbn("ISBN 123");
            Assert.False(actual);
        }
        [Fact]
        public void IsIsbn_with10ISBN_returnTrue()
        {
            bool actual = Book.IsIsbn("IsBN 123-456-789-0");
            Assert.True(actual);
        }
        [Fact]
        public void IsIsbn_with13ISBN_returnTrue()
        {
            bool actual = Book.IsIsbn("IsBN 123-456-789-012-3");
            Assert.True(actual);
        }
        [Fact]
        public void IsIsbn_withTrashStart_returnFalse()
        {
            bool actual = Book.IsIsbn("xxxxIsBN 123-456-789-012-3xxxxx");
            Assert.False(actual);
        }
    }
}

using store;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Store.Tests
{
    public class OrderItemTest
    {
        [Fact]
           public void Order_Count_Zero()
        {

            Assert.Throws<ArgumentOutOfRangeException>(() => new OrderItem(1, 0, 0m));
        }
    }
}

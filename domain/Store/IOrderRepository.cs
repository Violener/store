using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace store
{
   public interface IOrderRepository
    {
        Order Create();
        Order GetById(int Id);

        void Update(Order order);
    }
}

using Store;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace store
{
   public interface IBookRepository
    {
        Book[] GetAllByTitle(string titlepart);
        
    }
}

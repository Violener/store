using Microsoft.AspNetCore.Http;
using Store.Web.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Web
{
    public static class SessionExtensions
    {
        private const string key = "Cart";
        public static void Set(this ISession session, Cart value)
        {
            if (value == null)
                return;
            using(var stream = new MemoryStream())
                using(var writer = new BinaryWriter(stream, Encoding.UTF8, true))
            {
                writer.Write(value.items.Count);
                foreach(var items in value.items){
                    writer.Write(items.Key);
                    writer.Write(items.Value);
                }
                writer.Write(value.amount);
                session.Set(key, stream.ToArray());
            }
        }
        public static bool TryGetCart(this ISession session,out Cart value)
        {
            if(session.TryGetValue(key,out byte[] buffer))
            {
                using (var stream = new MemoryStream(buffer))
                    using(var reader = new BinaryReader(stream, Encoding.UTF8))
                {
                    value = new Cart();
                    var length = reader.ReadInt32();
                    for(int i = 0; i < length; i++)
                    {
                        var bookId = reader.ReadInt32();
                        var count = reader.ReadInt32();
                        value.items.Add(bookId, count);
                    }
                    value.amount = reader.ReadDecimal();
                    return true;
                }
                

            }
            value = null;
            return false;
        }
    }
}

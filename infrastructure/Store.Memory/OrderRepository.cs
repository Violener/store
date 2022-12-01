﻿using store;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Memory
{
    public class OrderRepository : IOrderRepository
    {
        private readonly List<Order> orders = new List<Order>();
        public Order Create()
        {
            int nextId = orders.Count + 1;
            var order = new Order(nextId, new OrderItem[0]);
            orders.Add(order);
            return order;
        }

        public Order GetById(int Id)
        {
            return orders.Single(order => order.Id == Id);
        }

        public void Update()
        {
            
        }
    }
}

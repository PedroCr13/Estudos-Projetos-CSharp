using ExercicioComposicaoOrder.Entities.Enuns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExercicioComposicaoOrder.Entities
{
    internal class Order
    {
        public DateTime Moment { get; set; }
        public OrderStatus Status { get; set; }
        public Client Client { get; set; }

        public List<OrderItem> Items = new List<OrderItem>();

        public Order() { }

        public Order(OrderStatus status, Client client)
        {
            Moment = DateTime.Now;
            Status = status;
            Client = client;
        }

        public void AddOrderItem(OrderItem orderItem)
        {
            Items.Add(orderItem);
        }

        public void RemoveOrderItem(OrderItem orderItem)
        {
            Items.Remove(orderItem);
        }
    }
}

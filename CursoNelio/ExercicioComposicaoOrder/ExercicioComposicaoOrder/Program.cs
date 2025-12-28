using System;
using System.Globalization;
using System.Xml.Serialization;
using ExercicioComposicaoOrder.Entities;
using ExercicioComposicaoOrder.Entities.Enuns;

namespace ExercicioComposicaoOrder.Pricipal
{ 
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Enter client data: ");
            Console.WriteLine("Name: ");
            string nameClient = Console.ReadLine();

            Console.WriteLine("Email: ");
            string email = Console.ReadLine();

            Console.WriteLine("Enter birth date: ");
            DateTime birthDate = DateTime.Parse(Console.ReadLine());

            Client client = new Client(nameClient, email, birthDate);

            Console.WriteLine("Enter a Order Data: ");
            Console.WriteLine("Status: ");
            OrderStatus status = Enum.Parse<OrderStatus>(Console.ReadLine());

            Order order = new Order(status, client);

            Console.WriteLine("");

            Console.WriteLine("How many items to this order?");
            int qtdItems = int.Parse(Console.ReadLine());

            for (int i = 1; i <= qtdItems; i++)
            {
                Console.WriteLine($"Enter #{i} item data:");
                Console.WriteLine("Product name: ");
                string productName = Console.ReadLine();

                Console.WriteLine("Product price: ");
                double price = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                Console.WriteLine("Quantity: ");
                int qtd = int.Parse(Console.ReadLine());

                Product product = new Product(productName, price);

                OrderItem orderItem = new OrderItem(qtd, price, product);

                order.AddOrderItem(orderItem);
            }

            Console.WriteLine("Order Sumary: ");
            Console.WriteLine("Order moment: " + order.Moment);
            Console.WriteLine("Order Status: " + order.Status.ToString());
            Console.WriteLine("Client: " + order.Client.Name);
            Console.WriteLine("BithDate cliente: " + order.Client.BirthDate);
            Console.WriteLine("Mail client: " + order.Client.Email);
            Console.WriteLine("Order itens: ");

            double soma = 0.0;

            foreach (OrderItem item in order.Items)
            {
                Console.WriteLine("Product: " + item.Product.Name);
                Console.WriteLine("Quantity: " + item.Quantity);
                Console.WriteLine("Subtotal: " + item.SubTotal());
                soma += item.SubTotal();
            }

            Console.WriteLine("Total Price: $" + soma);
        }
    }
}
// See https://aka.ms/new-console-template for more information
using System.Security.Cryptography.X509Certificates;

namespace SSNB4.ConsoleApp2
{
    internal class Program
    {
        static List<Product> Products = new List<Product>();
        static void Main(string[] args)
        {
        Start:
            Console.WriteLine("------ Restaurant Management ------");
            Console.WriteLine("1. Products");
            Console.WriteLine("2. Orders");
            Console.WriteLine("3. Employees");
            Console.WriteLine("4. Tables");
            Console.WriteLine("5. Customers");
            Console.WriteLine("6. Payments");
            Console.WriteLine("0. Exit");

            Console.Write("\nPlease choose an option: ");

            int option = Convert.ToInt32(Console.ReadLine());

            switch (option)
            {
                case 1:
                    AddProduct();
                    goto Start;

                case 2:
                    GetProduct();   // 現時点では Orders なし → とりあえず Product List を表示
                    goto Start;

                case 3:
                case 4:
                case 5:
                case 6:
                    Console.WriteLine("\n📌 This function is not implemented yet.\n");
                    goto Start;

                case 0:
                    Console.WriteLine("Exiting program...");
                    break;

                default:
                    Console.WriteLine("Invalid Option! Try again.");
                    goto Start;
            }
        }

        private static void GetProduct()
        {
            Console.WriteLine("\n--- Product List ---");
            foreach (Product product in Products)
            {
                Console.WriteLine($"Name: {product.Name} / Price: {product.Price} / Stock: {product.Quantity}");
                Console.WriteLine("--------------------------------------");
            }
        }

        private static void AddProduct()
        {
            Console.Write("\nEnter product name: ");
            string name = Console.ReadLine();

            Console.Write("Enter price: ");
            decimal price = Convert.ToDecimal(Console.ReadLine());

            Console.Write("Enter quantity: ");
            int quantity = Convert.ToInt32(Console.ReadLine());

            Product product = new Product(name, price, quantity);
            Products.Add(product);
            Console.WriteLine("\n✔ Product Saved!\n");
        }

        public class Product
        {
            public Product(string name, decimal price, int quantity)
            {
                Name = name;
                Price = price;
                Quantity = quantity;
            }
            public string Name { get; set; }
            public decimal Price { get; set; }
            public int Quantity { get; set; }
        }
    }
}

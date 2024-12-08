using System;
using System.Collections.Generic;

namespace ProductManagement
{
    // Classe que representa um Produto
    public class Product
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }

        public Product(string name, double price, int quantity)
        {
            Name = name;
            Price = price;
            Quantity = quantity;
        }

        public double GetTotalValue()
        {
            return Price * Quantity;
        }

        public override string ToString()
        {
            return $"{Name} - Preço: R${Price:F2} | Quantidade: {Quantity} | Valor Total: R${GetTotalValue():F2}";
        }
    }

    // Classe que gerencia a lista de produtos
    public class Inventory
    {
        private List<Product> products = new List<Product>();

        public void AddProduct(Product product)
        {
            products.Add(product);
        }

        public void ListProducts()
        {
            if (products.Count == 0)
            {
                Console.WriteLine("Nenhum produto cadastrado.");
                return;
            }

            Console.WriteLine("Produtos cadastrados:");
            foreach (var product in products)
            {
                Console.WriteLine(product);
            }
        }

        public double GetTotalInventoryValue()
        {
            double total = 0;
            foreach (var product in products)
            {
                total += product.GetTotalValue();
            }
            return total;
        }
    }

    // Classe principal para interação com o usuário
    public class Program
    {
        static void Main(string[] args)
        {
            Inventory inventory = new Inventory();
            bool running = true;

            while (running)
            {
                Console.WriteLine("\nSistema de Gerenciamento de Produtos");
                Console.WriteLine("1. Adicionar Produto");
                Console.WriteLine("2. Listar Produtos");
                Console.WriteLine("3. Mostrar Valor Total do Estoque");
                Console.WriteLine("4. Sair");
                Console.Write("Escolha uma opção: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.Write("Nome do Produto: ");
                        string name = Console.ReadLine();
                        Console.Write("Preço do Produto: ");
                        double price = Convert.ToDouble(Console.ReadLine());
                        Console.Write("Quantidade: ");
                        int quantity = Convert.ToInt32(Console.ReadLine());

                        Product product = new Product(name, price, quantity);
                        inventory.AddProduct(product);
                        Console.WriteLine("Produto adicionado com sucesso!");
                        break;

                    case "2":
                        inventory.ListProducts();
                        break;

                    case "3":
                        double totalValue = inventory.GetTotalInventoryValue();
                        Console.WriteLine($"Valor total do estoque: R${totalValue:F2}");
                        break;

                    case "4":
                        running = false;
                        Console.WriteLine("Encerrando o sistema. Até logo!");
                        break;

                    default:
                        Console.WriteLine("Opção inválida. Tente novamente.");
                        break;
                }
            }
        }
    }
}

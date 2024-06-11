using Shop.Business.Dtos;
using Shop.Business.Implementations;
using Shop.Business.Interfaces;

namespace Shop.CA
{
    public class Program
    {
        static void Main(string[] args)
        {
            IProductService productService = new ProductService();

            while (true)
            {
                Console.WriteLine("Menu:");
                Console.WriteLine("1) Create Product");
                Console.WriteLine("2) Delete Product");
                Console.WriteLine("3) Show Product");
                Console.WriteLine("4) Show All Products");
                Console.WriteLine("5) Exit");
                Console.Write("Select an option: ");

                string option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        CreateProduct(productService);
                        break;
                    case "2":
                        DeleteProduct(productService);
                        break;
                    case "3":
                        ShowProduct(productService);
                        break;
                    case "4":
                        ShowAllProducts(productService);
                        break;
                    case "5":
                        return;
                    default:
                        Console.WriteLine("Invalid option, please try again.");
                        break;
                }
            }
        }

        static void CreateProduct(IProductService productService)
        {
            Console.Write("Enter product name: ");
            string name = Console.ReadLine();

            Console.Write("Enter cost price: ");
            if (!double.TryParse(Console.ReadLine(), out double costPrice))
            {
                Console.WriteLine("Invalid cost price.");
                return;
            }

            Console.Write("Enter sale price: ");
            if (!double.TryParse(Console.ReadLine(), out double salePrice))
            {
                Console.WriteLine("Invalid sale price.");
                return;
            }

            productService.Create(new ProductCreateDto(name, costPrice, salePrice));
            Console.WriteLine("Product created successfully.");
        }

        static void DeleteProduct(IProductService productService)
        {
            Console.Write("Enter product ID to delete: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("Invalid product ID.");
                return;
            }

            productService.Delete(id);
            Console.WriteLine("Product deleted successfully.");
        }

        static void ShowProduct(IProductService productService)
        {
            Console.Write("Enter product ID to show: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("Invalid product ID.");
                return;
            }

            var product = productService.Get(id);
            if (product != null)
                Console.WriteLine($"Product found: Id={product.Id}, Name={product.Name}, SalePrice={product.SalePrice}");
            else
                Console.WriteLine("Product not found.");
        }

        static void ShowAllProducts(IProductService productService)
        {
            var allProducts = productService.GetAll();
            if (allProducts.Count == 0)
            {
                Console.WriteLine("No products found.");
                return;
            }

            foreach (var product in allProducts)
                Console.WriteLine($"Id={product.Id}, Name={product.Name}, SalePrice={product.SalePrice}");
        }
    }
}
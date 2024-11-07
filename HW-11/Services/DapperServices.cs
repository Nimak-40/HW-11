using HW_11.Dapper;
using HW_11.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_11.Services
{
    public class DapperServices
    {
        DapperRepository repo = new DapperRepository();



        public int AddProduct(Product product)
        {
            return repo.Add(product);
        }


        public List<Product> GetAllProducts()
        {
            return repo.GetAll();
        }

        public Product GetProductById(int id)
        {
            return repo.GetById(id);
        }


        public bool UpdateProduct(Product product)
        {
            return repo.Update(product);
        }


        public bool DeleteProduct(int id)
        {
            return repo.Delete(id);
        }

        // ادد کردن محصول جدید
        public void AddProduct()
        {
            Console.WriteLine("Add a new product:");

            Console.Write("Enter product name: ");
            string name = Console.ReadLine();

            Console.Write("Enter product price: ");
            decimal price = decimal.Parse(Console.ReadLine());

            Console.Write("Enter category ID: ");
            int categoryId = int.Parse(Console.ReadLine());

            Product newProduct = new Product
            {
                Name = name,
                Price = price,
                Category = new Category { Id = categoryId }
            };

            int productId = AddProduct(newProduct);
            Console.WriteLine($"Product with ID {productId} has been added.");
        }

        // نمایش لیست محصولات
        public void ShowAllProducts()
        {
            List<Product> products = GetAllProducts();

            Console.WriteLine("List of Products:");
            foreach (var product in products)
            {
                Console.WriteLine($"ID: {product.Id} | Name: {product.Name} | Price: {product.Price} | Category: {product.Category.Id}");
            }
        }

        // نمایش محصول بر اساس آیدی
        public void ShowProductById()
        {
            Console.Write("Enter product ID: ");
            int id = int.Parse(Console.ReadLine());

            Product product = GetProductById(id);

            if (product != null)
            {
                Console.WriteLine($"ID: {product.Id} | Name: {product.Name} | Price: {product.Price} | Category: {product.Category.Name}");
            }
            else
            {
                Console.WriteLine("No product found with this ID.");
            }
        }

        // ویرایش محصول
        public void UpdateProduct()
        {
            Console.Write("Enter the product ID you want to edit: ");
            int id = int.Parse(Console.ReadLine());

            Product product = GetProductById(id);

            if (product != null)
            {
                Console.WriteLine("Edit Product:");
                Console.Write($"Enter new product name ({product.Name}): ");
                product.Name = Console.ReadLine();

                Console.Write($"Enter new product price ({product.Price}): ");
                product.Price = decimal.Parse(Console.ReadLine());

                Console.Write($"Enter new category ID ({product.Category.Id}): ");
                product.Category.Id = int.Parse(Console.ReadLine());

                bool updated = UpdateProduct(product);
                Console.WriteLine(updated ? "Product updated successfully." : "Error updating product.");
            }
            else
            {
                Console.WriteLine("No product found with this ID.");
            }
        }

        // حذف محصول
        public void DeleteProduct()
        {
            Console.Write("Enter the product ID you want to delete: ");
            int id = int.Parse(Console.ReadLine());

            bool deleted = DeleteProduct(id);
            Console.WriteLine(deleted ? "Product deleted successfully." : "Error deleting product.");
        }
    }
}

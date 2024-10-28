using Newtonsoft.Json;
using ProductShop.Data;
using ProductShop.Models;

namespace ProductShop
{
    public class StartUp
    {
        public static void Main()
        {
            ProductShopContext shopDb = new();

            //Import files
            string usersJson = File.ReadAllText(@"../../../Datasets/users.json");
            string productsJson = File.ReadAllText(@"../../../Datasets/products.json");
            string categoriesJson = File.ReadAllText(@"../../../Datasets/categories.json");
            string categoriesProductsJson = File.ReadAllText(@"../../../Datasets/categories-products.json");
            
            // 01.Import Users
            //Console.WriteLine(ImportUsers(shopDb, usersJson));

            // 02.Import Products
            Console.WriteLine(ImportProducts(shopDb, productsJson));

            // 03.Import Categories
            //Console.WriteLine(ImportCategories(shopDb, categoriesJson));

            // 04.Import CategoriesProducts
            //Console.WriteLine(ImportCategoryProducts(shopDb, categoriesProductsJson));
        }

        public static string ImportProducts(ProductShopContext context, string inputJson)
        {
            var products = JsonConvert.DeserializeObject<List<Product>>(inputJson);

            context.Products.AddRange(products);
            context.SaveChanges();

            return $"Successfully imported {products.Count}";
        }

        public static string ImportUsers(ProductShopContext context, string inputJson)
        {
            var users = JsonConvert.DeserializeObject<List<User>>(inputJson);

            context.Users.AddRange(users);
            context.SaveChanges();

            return $"Successfully imported {users.Count}";
        }
    }
}
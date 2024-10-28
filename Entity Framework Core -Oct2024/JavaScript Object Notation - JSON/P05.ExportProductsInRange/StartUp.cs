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
            //Console.WriteLine(ImportProducts(shopDb, productsJson));

            // 03.Import Categories
            //Console.WriteLine(ImportCategories(shopDb, categoriesJson));

            // 04.Import CategoriesProducts
            //Console.WriteLine(ImportCategoryProducts(shopDb, categoriesProductsJson));

            // 05.Export Products in Range
            Console.WriteLine(GetProductsInRange(shopDb));
        }

        #region IMPORT METHODS
        public static string ImportUsers(ProductShopContext context, string inputJson)
        {
            var users = JsonConvert.DeserializeObject<List<User>>(inputJson);

            context.Users.AddRange(users);
            context.SaveChanges();

            return $"Successfully imported {users.Count}";
        }

        public static string ImportProducts(ProductShopContext context, string inputJson)
        {
            var products = JsonConvert.DeserializeObject<List<Product>>(inputJson);

            context.Products.AddRange(products);
            context.SaveChanges();

            return $"Successfully imported {products.Count}";
        }

        public static string ImportCategories(ProductShopContext context, string inputJson)
        {
            var categories = JsonConvert.DeserializeObject<List<Category>>(inputJson)
                .Where(c => c.Name != null).ToList();

            context.Categories.AddRange(categories);
            context.SaveChanges();

            return $"Successfully imported {categories.Count}";
        }

        public static string ImportCategoryProducts(ProductShopContext context, string inputJson)
        {
            var categoryProducts = JsonConvert.DeserializeObject<List<CategoryProduct>>(inputJson);

            context.CategoriesProducts.AddRange(categoryProducts);
            context.SaveChanges();

            return $"Successfully imported {categoryProducts.Count}";
        }
        #endregion

        #region EXPORT METHODS
        public static string GetProductsInRange(ProductShopContext context)
        {
            var products = context.Products
                .Where(p => p.Price >= 500 && p.Price <= 1000)
                .Select(p => new
                {
                    name = p.Name,
                    price = p.Price,
                    seller = $"{p.Seller.FirstName} {p.Seller.LastName}" 
                })
                .OrderBy(p => p.price)
                .ToList();

            string jsonResult = JsonConvert.SerializeObject(products, Formatting.Indented);
            return jsonResult;
        }
        #endregion
    }
}
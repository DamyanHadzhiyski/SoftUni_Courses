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
            //Console.WriteLine(GetProductsInRange(shopDb));

            // 06.Export Sold Products
            //Console.WriteLine(GetSoldProducts(shopDb));

            // 07.Export Categories by Products Count
            //Console.WriteLine(GetCategoriesByProductsCount(shopDb));

            // 08.Export Users and Produts
            Console.WriteLine(GetUsersWithProducts(shopDb));
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

        public static string GetSoldProducts(ProductShopContext context)
        {
            var sellers = context.Users
                .Where(u => u.ProductsSold.Any(p => p.BuyerId != null))
                .Select(u => new
                {
                    firstName = u.FirstName,
                    lastName = u.LastName,
                    soldProducts = u.ProductsSold
                        .Select(bp => new
                        {
                            name = bp.Name,
                            price = bp.Price,
                            buyerFirstName = bp.Buyer.FirstName,
                            buyerLastName = bp.Buyer.LastName
                        })
                        .ToList()
                })
                .OrderBy(b => b.lastName)
                    .ThenBy(b => b.firstName)
                .ToList();

            string jsonResult = JsonConvert.SerializeObject(sellers, Formatting.Indented);
            return jsonResult;
        }

        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            var categories = context.Categories
                    .Select(c => new
                    {
                        category = c.Name,
                        productsCount = c.CategoriesProducts.Count(p => p.CategoryId == c.Id),
                        averagePrice = c.CategoriesProducts.Average(p => p.Product.Price).ToString("f2"),
                        totalRevenue = c.CategoriesProducts.Sum(p => p.Product.Price).ToString("f2")
                    })
                    .OrderByDescending(c => c.productsCount)
                    .ToList();

            string jsonResult = JsonConvert.SerializeObject(categories, Formatting.Indented);
            return jsonResult;
        }

        public static string GetUsersWithProducts(ProductShopContext context)
        {
            var users = context.Users
                    .Where(u => u.ProductsSold.Any())
                    .Select(u => new
                    {
                        firstName = u.FirstName,
                        lastName = u.LastName,
                        age = u.Age,
                        soldProducts = new
                        {
                            count = u.ProductsSold.Count,
                            products = u.ProductsSold
                            .Where(ps => ps.BuyerId != null)
                            .Select(ps => new
                            {
                                name = ps.Name,
                                price = ps.Price
                            })
                        }
                    })
                    .OrderByDescending(u => u.soldProducts.count)
                    .ToList();

            var result = new
            {
                usersCount = users.Count(),
                users = users
            };

            JsonSerializerSettings config = new JsonSerializerSettings()
            {
                Formatting = Formatting.Indented,
                NullValueHandling = NullValueHandling.Ignore
            };

            string jsonResult = JsonConvert.SerializeObject(result, config);
            return jsonResult;
        }
        #endregion
    }
}
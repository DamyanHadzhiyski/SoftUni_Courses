using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ProductShop.Data;
using ProductShop.DTOs.Export;
using ProductShop.DTOs.Import;
using ProductShop.Models;
using System.Data.SqlTypes;
using System.Text;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace ProductShop
{
    public class StartUp
    {
        public static void Main()
        {
            ProductShopContext productsDb = new ProductShopContext();

            //Import paths
            string usersXML = File.ReadAllText(@"../../../Datasets/users.xml");
            string productsXML = File.ReadAllText(@"../../../Datasets/products.xml");
            string categoriesXML = File.ReadAllText(@"../../../Datasets/categories.xml");
            string productsCategoriesXML = File.ReadAllText(@"../../../Datasets/categories-products.xml");

            #region Import Calls
            // 01. Import users
            //Console.WriteLine(ImportUsers(productsDb, usersXML));

            // 02. Import products
            //Console.WriteLine(ImportProducts(productsDb, productsXML));

            // 03. Import categories
            //Console.WriteLine(ImportCategories(productsDb, categoriesXML));

            // 04. Import category-products
            //Console.WriteLine(ImportCategoryProducts(productsDb, productsCategoriesXML));
            #endregion

            #region Export Calls
            // 05. Export Products in Range
            //Console.WriteLine(GetProductsInRange(productsDb));

            // 06. Export Sold Products
            //Console.WriteLine(GetSoldProducts(productsDb));

            // 07. Export Categories By Products Count
            //Console.WriteLine(GetCategoriesByProductsCount(productsDb));

            // 08. Export Users and Products
            Console.WriteLine(GetUsersWithProducts(productsDb));

            #endregion
        }

        private static Mapper GetMapper()
        {
            MapperConfiguration cfg = new MapperConfiguration(c => c.AddProfile<ProductShopProfile>());
            return new Mapper(cfg);
        }

        #region Imports
        public static string ImportUsers(ProductShopContext context, string inputXml)
        {
            var serializer = new XmlSerializer(typeof(ImportUserDTO[]), new XmlRootAttribute("Users"));
            ImportUserDTO[] deserializedUsers = (ImportUserDTO[])serializer.Deserialize(new StringReader(inputXml));

            var mapper = GetMapper();
            User[] users = mapper.Map<User[]>(deserializedUsers);

            context.Users.AddRange(users);
            context.SaveChanges();

            return $"Successfully imported {users.Length}";
        }

        public static string ImportProducts(ProductShopContext context, string inputXml)
        {
            XmlSerializer serializer =
                new XmlSerializer(typeof(ImportProductDTO[]), new XmlRootAttribute("Products"));

            ImportProductDTO[] deserializedProducts =
                (ImportProductDTO[])serializer.Deserialize(new StringReader(inputXml));

            var mapper = GetMapper();
            Product[] products = mapper.Map<Product[]>(deserializedProducts);

            context.Products.AddRange(products);
            context.SaveChanges();

            return $"Successfully imported {products.Count()}";
        }

        public static string ImportCategories(ProductShopContext context, string inputXml)
        {
            XmlSerializer serializer =
                new XmlSerializer(typeof(ImportCategoryDTO[]), new XmlRootAttribute("Categories"));

            ImportCategoryDTO[] deserializedCategories =
                (ImportCategoryDTO[])serializer.Deserialize(new StringReader(inputXml));

            var mapper = GetMapper();
            Category[] categories = mapper.Map<Category[]>(deserializedCategories)
                                            .Where(c => c.Name != null)
                                            .ToArray();
            context.AddRange(categories);
            context.SaveChanges();

            return $"Successfully imported {categories.Count()}";
        }

        public static string ImportCategoryProducts(ProductShopContext context, string inputXml)
        {
            XmlSerializer serializer =
                new XmlSerializer(typeof(ImportCategoryProductDTO[]), new XmlRootAttribute("CategoryProducts"));

            ImportCategoryProductDTO[] deserializedCategoryProduct =
                (ImportCategoryProductDTO[])serializer.Deserialize(new StringReader(inputXml));

            var mapper = GetMapper();
            CategoryProduct[] categoryProducts = mapper.Map<CategoryProduct[]>(deserializedCategoryProduct)
                                                            .Where(cp => cp.ProductId != null && cp.CategoryId != null)
                                                            .ToArray();
            context.AddRange(categoryProducts);
            context.SaveChanges();

            return $"Successfully imported {categoryProducts.Count()}";
        }
        #endregion

        #region Exports
        public static string GetProductsInRange(ProductShopContext context)
        {
            var products = context.Products
                           .Where(p => p.Price >= 500 && p.Price <= 1000)
                           .Select(p => new ExportProductRangeDTO
                           {
                               ProductName = p.Name,
                               ProductPrice = p.Price,
                               BuyerName =
                                p.BuyerId != null ? $"{p.Buyer.FirstName} {p.Buyer.LastName}" : null
                           })
                           .OrderBy(p => p.ProductPrice)
                           .Take(10)
                           .ToArray();

            XmlSerializer serialize =
                new XmlSerializer(typeof(ExportProductRangeDTO[]), new XmlRootAttribute("Products"));

            StringBuilder result = new StringBuilder();

            XmlSerializerNamespaces xns = new XmlSerializerNamespaces();
            xns.Add(string.Empty, string.Empty);

            using StringWriter stringWriter = new StringWriter(result);

            serialize.Serialize(stringWriter, products, xns);

            return result.ToString().Trim();
        }

        public static string GetSoldProducts(ProductShopContext context)
        {
            var products = context.Users
                           .Where(u => u.ProductsSold.Any())
                           .Select(u => new ExportUserProductsDTO
                           {
                               FirstName = u.FirstName,
                               LastName = u.LastName,
                               SoldProducts = u.ProductsSold
                                                .Select(ps => new ExportProductDTO
                                                {
                                                    Name = ps.Name,
                                                    Price = ps.Price
                                                })
                                                .ToArray()
                           })
                           .OrderBy(u => u.LastName)
                           .ThenBy(u => u.FirstName)
                           .Take(5)
                           .ToArray();

            var serializer =
                new XmlSerializer(typeof(ExportUserProductsDTO[]), new XmlRootAttribute("Users"));

            var xns = new XmlSerializerNamespaces();
            xns.Add(string.Empty, string.Empty);

            StringBuilder result = new StringBuilder();

            using StringWriter stringWriter = new StringWriter(result);
            serializer.Serialize(stringWriter, products, xns);

            return result.ToString().Trim();
        }

        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            var categories = context.Categories
                                .Include(c => c.CategoryProducts)
                                .ThenInclude(cp => cp.Product)
                                .Select(c => new ExportCategoryDTO
                                {
                                    Name = c.Name,
                                    Count = c.CategoryProducts.Count,
                                    AveragePrice = (c.CategoryProducts
                                                    .Sum(cp => cp.Product.Price) / c.CategoryProducts.Count),
                                    TotalRevenue = c.CategoryProducts
                                                    .Sum(cp => cp.Product.Price)
                                })
                                .OrderByDescending(c => c.Count)
                                .ThenBy(c => c.TotalRevenue)
                                .ToArray();

            var serializer = new XmlSerializer(typeof(ExportCategoryDTO[]), new XmlRootAttribute("Categories"));
            var xns = new XmlSerializerNamespaces();
            xns.Add(string.Empty, string.Empty);

            StringBuilder result = new StringBuilder();

            StringWriter stringWriter = new StringWriter(result);

            serializer.Serialize(stringWriter, categories, xns);

            return result.ToString().Trim();
        }

        public static string GetUsersWithProducts(ProductShopContext context)
        {
            var usersRaw = context.Users
                        .Where(u => u.ProductsSold.Any())
                        .Select(u => new
                        {
                            u.FirstName,
                            u.LastName,
                            u.Age,
                            u.ProductsSold.Count,
                            soldPorducts = u.ProductsSold
                                           .Select(ps => new
                                           {
                                               ps.Name,
                                               ps.Price
                                           })
                                           .OrderByDescending(ps => ps.Price)
                                           .ToArray()
                        })
                        .OrderByDescending(u => u.Count)
                        .ToArray();

            var users = new ExportUsersDTO
            {
                Count = usersRaw.Count(),
                Users = usersRaw
                        .Select(ur => new ExportUserSoldProductsDTO
                        {
                            FirstName = ur.FirstName,
                            LastName = ur.LastName,
                            Age = ur.Age, //may be an issue if it is null
                            SoldProducts = new ExportProductsSoldDTO
                            {
                                Count = ur.soldPorducts.Length,
                                Products = ur.soldPorducts
                                             .Select(sp => new ExportProductDTO
                                             {
                                                 Name = sp.Name,
                                                 Price = sp.Price
                                             })
                                             .ToArray()
                            }

                        })
                        .Take(10)
                        .ToArray()
            };

            var serializer = new XmlSerializer(typeof(ExportUsersDTO), new XmlRootAttribute("Users"));
            var xns = new XmlSerializerNamespaces();
            xns.Add(string.Empty, string.Empty);

            StringBuilder result = new StringBuilder();

            StringWriter stringWriter = new StringWriter(result);

            serializer.Serialize(stringWriter, users, xns);

            return result.ToString().Trim();
        }
        #endregion
    }
}
using AutoMapper;
using ProductShop.Data;
using ProductShop.DTOs.Import;
using ProductShop.Models;
using System.Data.SqlTypes;
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

            // 02. Import users
            //Console.WriteLine(ImportProducts(productsDb, productsXML));

            // 03. Import users
            Console.WriteLine(ImportCategories(productsDb, categoriesXML));

            // 04. Import users
            //Console.WriteLine(ImportUsers(productsDb, productsCategoriesXML));
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
        #endregion
    }
}
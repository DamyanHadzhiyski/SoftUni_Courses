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
            Console.WriteLine(ImportUsers(productsDb, usersXML));
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
        #endregion
    }
}
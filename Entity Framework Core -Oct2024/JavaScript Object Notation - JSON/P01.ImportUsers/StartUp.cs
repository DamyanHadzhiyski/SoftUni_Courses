using Newtonsoft.Json;
using ProductShop.Data;
using ProductShop.Models;

namespace ProductShop
{
    public class StartUp
    {
        ProductShopProfile _mapper = new ProductShopProfile();
       
        public static void Main()
        {
            ProductShopContext _shopDb = new();
            string inputJson = File.ReadAllText(@"C:\Users\Damyan\Desktop\01. Import Users_Skeleton (Product Shop)\ProductShop\Datasets\users.json");

            Console.WriteLine(ImportUsers(_shopDb, inputJson));
        }

        public static string ImportUsers(ProductShopContext context, string inputJson)
        {
            var users = JsonConvert.DeserializeObject<List<User>>(inputJson).ToList();

            foreach (var user in users)
            {
                context.Add(user);
                context.SaveChanges();
            }

            return $"Successfully imported {users.Count}";
        }
    }
}
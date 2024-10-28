namespace BookShop
{
    using BookShop.Data;
    using BookShop.Initializer;
    using BookShop.Models.Enums;
    using System.Text;

    public class StartUp
    {
        public static void Main()
        {
            using var db = new BookShopContext();
            DbInitializer.ResetDatabase(db);

            //read the command
            string command = Console.ReadLine();

            //execute the method
            Console.WriteLine(GetBooksByAgeRestriction(db, command));
        }

        public static string GetBooksByAgeRestriction(BookShopContext context, string command)
        {
            AgeRestriction ageRestriction; 
            Enum.TryParse(command, true, out ageRestriction);

            var books = context.Books
                        .Select(b => new
                        {
                            b.Title,
                            b.AgeRestriction
                        })
                        .Where(b => b.AgeRestriction == ageRestriction)
                        .OrderBy(b => b.Title)
                        .ToList();

            string result = string.Join(Environment.NewLine, books.Select(b => b.Title));

            return result.ToString().Trim();
        }
    }
}



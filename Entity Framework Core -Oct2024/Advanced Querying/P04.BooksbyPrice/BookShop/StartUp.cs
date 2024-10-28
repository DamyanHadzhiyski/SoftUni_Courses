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
            //DbInitializer.ResetDatabase(db);

            //read the command
            //string command = Console.ReadLine();

            //execute the method
            //Console.WriteLine(GetBooksByAgeRestriction(db, command));

            //Console.WriteLine(GetGoldenBooks(db));

            Console.WriteLine(GetBooksByPrice(db));
        }

        //public static string GetBooksByAgeRestriction(BookShopContext context, string command)
        //{
        //    AgeRestriction ageRestriction; 
        //    Enum.TryParse(command, true, out ageRestriction);

        //    var books = context.Books
        //                .Select(b => new
        //                {
        //                    b.Title,
        //                    b.AgeRestriction
        //                })
        //                .Where(b => b.AgeRestriction == ageRestriction)
        //                .OrderBy(b => b.Title)
        //                .ToList();

        //    string result = string.Join(Environment.NewLine, books.Select(b => b.Title));

        //    return result.ToString().Trim();
        //}

        //public static string GetGoldenBooks(BookShopContext context)
        //{
        //    var goldenBooks = context.Books
        //                      .Select(b => new
        //                      {
        //                          b.BookId,
        //                          b.Title,
        //                          b.Copies,
        //                          b.EditionType
        //                      })
        //                      .Where(b => b.EditionType == EditionType.Gold
        //                                    && b.Copies < 5000)
        //                      .OrderBy(b => b.BookId)
        //                      .ToList();

        //    string result = string.Join(Environment.NewLine,goldenBooks.Select(gb => gb.Title));
        //    return result;
        //}

        public static string GetBooksByPrice(BookShopContext context)
        {
            var books = context.Books
                        .Select(b => new
                        {
                            b.Title,
                            b.Price
                        })
                        .Where(b => b.Price > 40)
                        .OrderByDescending(b => b.Price)
                        .ToList();

            StringBuilder result = new();

            foreach (var book in books)
            {
                result.AppendLine($"{book.Title} - ${book.Price:f2}");
            }

            return result.ToString().Trim();
        }
    }
}



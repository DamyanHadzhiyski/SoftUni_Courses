namespace BookShop
{
    using BookShop.Data;
    using BookShop.Initializer;
    using BookShop.Models;
    using BookShop.Models.Enums;
    using System.Collections.Immutable;
    using System.Diagnostics.Metrics;
    using System.Globalization;
    using System.Text;

    public class StartUp
    {
        public static void Main()
        {
            using var db = new BookShopContext();
            DbInitializer.ResetDatabase(db);

            //read the command
            //Console.WriteLine("Enter Value:");
            //string command = Console.ReadLine();

            //execute the method
            //Console.WriteLine(GetBooksByAgeRestriction(db, command));

            //Console.WriteLine(GetGoldenBooks(db));

            //Console.WriteLine(GetBooksByPrice(db));

            //Console.WriteLine(GetBooksNotReleasedIn(db, command));

            //Console.WriteLine(GetBooksByCategory(db, command));

            //Console.WriteLine(GetBooksReleasedBefore(db, command));

            //Console.WriteLine(GetAuthorNamesEndingIn(db, command));

            //Console.WriteLine(GetBookTitlesContaining(db,command));

            //Console.WriteLine(GetBooksByAuthor(db,command));

            //Console.WriteLine(CountBooks(db,int.Parse(command)));

            //Console.WriteLine(CountCopiesByAuthor(db));

            //Console.WriteLine(GetTotalProfitByCategory(db));

            //Console.WriteLine(GetMostRecentBooks(db));

            IncreasePrices(db);

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

        //public static string GetBooksByPrice(BookShopContext context)
        //{
        //    var books = context.Books
        //                .Select(b => new
        //                {
        //                    b.Title,
        //                    b.Price
        //                })
        //                .Where(b => b.Price > 40)
        //                .OrderByDescending(b => b.Price)
        //                .ToList();

        //    StringBuilder result = new();

        //    foreach (var book in books)
        //    {
        //        result.AppendLine($"{book.Title} - ${book.Price:f2}");
        //    }

        //    return result.ToString().Trim();
        //}

        //public static string GetBooksNotReleasedIn(BookShopContext context, int year)
        //{
        //    var books = context.Books
        //                .Select(b => new
        //                {
        //                    b.Title,
        //                    b.ReleaseDate,
        //                    b.BookId
        //                })
        //                .Where(b => b.ReleaseDate.Value.Year != year)
        //                .OrderBy(b => b.BookId)
        //                .ToList();

        //    string result = string.Join(Environment.NewLine, books.Select(b => b.Title));
        //    return result;
        //}

        //public static string GetBooksByCategory(BookShopContext context, string input)
        //{
        //    string[] splittedInput = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);

        //    var books = context.Books
        //                .Select(b => new
        //                {
        //                    b.Title,
        //                    BookCategories = b.BookCategories
        //                                      .Select(bc => bc.Category)

        //                })
        //                .OrderBy(b => b.Title)
        //                .ToList();

        //    StringBuilder result = new();

        //    foreach (var book in books)
        //    {
        //        foreach (var bookCategory in book.BookCategories)
        //        {
        //            if (splittedInput.Contains(bookCategory.Name.ToLower()))
        //            {
        //                result.AppendLine(book.Title);                        
        //            }
        //        }
        //    }

        //    return result.ToString().Trim();
        //}

        //public static string GetBooksReleasedBefore(BookShopContext context, string date)
        //{
        //    DateTime dateBefore = DateTime.ParseExact(date, "dd-MM-yyyy", CultureInfo.InvariantCulture);
        //    var books = context.Books
        //                .Select(b => new
        //                {
        //                    b.Title,
        //                    b.EditionType,
        //                    b.Price,
        //                    b.ReleaseDate,
        //                })
        //                .Where(b => b.ReleaseDate < dateBefore)
        //                .OrderByDescending(b => b.ReleaseDate)
        //                .ToList();

        //    StringBuilder result = new();

        //    foreach (var book in books)
        //    {
        //        result.AppendLine($"{book.Title} - {book.EditionType} - ${book.Price:f2}");
        //    }

        //    return result.ToString().Trim();
        //}

        //public static string GetAuthorNamesEndingIn(BookShopContext context, string input)
        //{
        //    var authors = context.Authors
        //                  .Select(a => new
        //                  {
        //                      a.FirstName,
        //                      AuthorName = a.FirstName + " " + a.LastName
        //                  })
        //                  .Where(a => a.FirstName.EndsWith(input))
        //                  .OrderBy(a => a.AuthorName)
        //                  .ToList();

        //    string result = string.Join(Environment.NewLine, authors.Select(a => a.AuthorName));
        //    return result;
        //}

        //public static string GetBookTitlesContaining(BookShopContext context, string input)
        //{
        //    var books = context.Books
        //                  .Select(b => new
        //                  {
        //                      b.Title
        //                  })
        //                  .Where(b => b.Title.ToLower().Contains(input.ToLower()))
        //                  .OrderBy(b => b.Title)
        //                  .ToList();

        //    string result = string.Join(Environment.NewLine, books.Select(b => b.Title));
        //    return result;
        //}

        //public static string GetBooksByAuthor(BookShopContext context, string input)
        //{
        //    var books = context.Books
        //                  .Select(b => new
        //                  {
        //                      b.BookId,
        //                      b.Title,
        //                      AuthorFirstName = b.Author.FirstName,
        //                      AuthorLastName = b.Author.LastName
        //                  })
        //                  .Where(b => b.AuthorLastName.ToLower().StartsWith(input.ToLower()))
        //                  .OrderBy(b => b.BookId)
        //                  .ToList();

        //    StringBuilder result = new();

        //    foreach (var book in books)
        //    {
        //        result.AppendLine($"{book.Title} ({book.AuthorFirstName} {book.AuthorLastName})");
        //    }
        //    return result.ToString().Trim();
        //}

        //public static int CountBooks(BookShopContext context, int lengthCheck)
        //{
        //    var books = context.Books
        //                .Select(b => new { b.Title })
        //                .Where(b => b.Title.Length > lengthCheck)
        //                .ToList();

        //    int result = books.Count;

        //    return result;
        //}

        //public static string CountCopiesByAuthor(BookShopContext context)
        //{
        //    var books = context.Books
        //                .GroupBy(b => new {
        //                    b.AuthorId,
        //                    b.Author.FirstName,
        //                    b.Author.LastName
        //                })
        //                .Select(gr => new
        //                {
        //                    AuthorFirstName = gr.Key.FirstName,
        //                    AuthorLastName = gr.Key.LastName,
        //                    CopiesCount = gr.Sum(gr => gr.Copies)
        //                })
        //                .OrderByDescending(c => c.CopiesCount)
        //                .ToList();

        //    StringBuilder result = new();

        //    foreach (var book in books)
        //    {
        //        result.AppendLine($"{book.AuthorFirstName} {book.AuthorLastName} - {book.CopiesCount}");
        //    }
        //    return result.ToString().Trim();
        //}

        //public static string GetTotalProfitByCategory(BookShopContext context)
        //{
        //    var categories = context.BooksCategories
        //                .GroupBy(c => new
        //                {
        //                    c.CategoryId,
        //                    c.Category.Name
        //                })
        //                .Select(gr => new
        //                {
        //                    TotalProfit = gr.Sum(b => b.Book.Copies * b.Book.Price),
        //                    CategoryName = gr.Key.Name
        //                })
        //                .OrderByDescending(gr => gr.TotalProfit)
        //                .ToList();

        //    StringBuilder result = new();

        //    foreach (var category in categories)
        //    {
        //        result.AppendLine($"{category.CategoryName} ${category.TotalProfit:f2}");
        //    }

        //    return result.ToString().Trim();
        //}

        //public static string GetMostRecentBooks(BookShopContext context)
        //{
        //    var categories = context.BooksCategories
        //                .GroupBy(c => new
        //                {
        //                    c.CategoryId,
        //                    c.Category.Name
        //                })
        //                .Select(gr => new
        //                {
        //                    CategoryName = gr.Key.Name,
        //                    RecentBooks = gr.Select(b => new
        //                    {
        //                        b.Book.Title,
        //                        b.Book.ReleaseDate
        //                    })
        //                                    .OrderByDescending(rb => rb.ReleaseDate)
        //                                    .Take(3)
        //                                    .ToList()
        //                })
        //                .OrderBy(gr => gr.CategoryName)
        //                .ToList();

        //    StringBuilder result = new();

        //    foreach (var category in categories)
        //    {
        //        result.AppendLine($"--{category.CategoryName}");

        //        foreach (var book in category.RecentBooks)
        //        {
        //            result.AppendLine($"{book.Title} ({book.ReleaseDate.Value.Year})");
        //        }
        //    }

        //    return result.ToString().Trim();
        //}

        public static void IncreasePrices(BookShopContext context)
        {
            var books = context.Books
                        .Where(b => b.ReleaseDate.Value.Year < 2010);

            foreach (var book in books)
            {              
                book.Price += 5m;
            }

            context.SaveChanges();
        }
    }
}



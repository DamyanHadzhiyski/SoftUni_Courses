namespace E03.Telephony
{
    public class Program
    {
        static void Main(string[] args)
        {
            //get the list with numbers
            List<string> listNumbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            //get the list with webpages
            List<string> listWebPages = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            //create the stationary and the smartphone
            ICalling stationary = new StationaryPhone();
            Smartphone smartphone = new();

            //check if the numbers are valid
            foreach (string number in listNumbers)
            {
                bool isValid = true;

                foreach (char digit in number)
                {
                    if (!Char.IsDigit(digit))
                    {
                        Console.WriteLine("Invalid number!");
                        isValid = false;
                        break;
                    }
                }

                if (isValid && number.Length == 7)
                {
                    stationary.Calling(number);
                }
                else if(isValid && number.Length == 10)
                {
                    smartphone.Calling(number);
                }

            }

            //check if the webpages are valid
            foreach (string webPage in listWebPages)
            {
                bool isValid = true;

                foreach (char symbol in webPage)
                {
                    if (Char.IsDigit(symbol))
                    {
                        Console.WriteLine("Invalid URL!");
                        isValid = false;
                        break;
                    }
                }

                if (isValid)
                {
                    smartphone.Browsing(webPage);
                }

            }
        }
    }
}
namespace E08.BalancedParenthesis
{
    using System;
    using System.Collections.Generic;

    class Program
    {
        static void Main(string[] args)
        {
            //read the input sequence
            string inputSequnce = Console.ReadLine();

            //parantheses types (, {, [, ], }, )
            //create stack for keeping the opening parantheses
            Stack<char> openingParantheses = new Stack<char>();

            //create parameter to mark, if the sequence is balanced
            bool balanced = true;

            //process the input string
            foreach (char ch in inputSequnce)
            {
                if (ch == '{' || ch == '(' || ch == '[')
                {
                    openingParantheses.Push(ch);
                }
                else if (openingParantheses.Count > 0 && ((ch == '}' && '{' == openingParantheses.Peek()) 
                    || (ch == ')' && '(' == openingParantheses.Peek())
                    || (ch == ']' && '[' == openingParantheses.Peek())))
                {
                    openingParantheses.Pop();
                }
                else
                {
                    balanced = false;
                    break;
                }
            }

            if (balanced)
            {
                Console.WriteLine("YES");
            }
            else
            {
                Console.WriteLine("NO");
            }    
        }
    }
}

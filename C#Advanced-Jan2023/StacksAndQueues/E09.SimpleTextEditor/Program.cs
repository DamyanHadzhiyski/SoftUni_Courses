namespace E09.SimpleTextEditor
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    class Program
    {
        static void Main(string[] args)
        {
            //read the number of operation
            int operationsCount = int.Parse(Console.ReadLine());

            //create string builder that will be used to perform the operation
            StringBuilder text = new StringBuilder(string.Empty);
            
            //create stack that will keep the changes of the text, when operation 1 or 2 is perfomred
            Stack<string> changes = new Stack<string>();
            changes.Push(text.ToString());

            //execute the procdure
            for (int i = 0; i < operationsCount; i++)
            {
                //read the operation
                string[] operation = Console.ReadLine()
                    .Split();

                //get the command name from the operation
                string command = operation[0];

                //find the command action and performed it
                if (command == "1")
                {
                    //append text
                    text.Append(operation[1]);

                    //save the changes in the stack
                    changes.Push(text.ToString());
                }
                else if (command == "2")
                {
                    //erase last count elements
                    int count = int.Parse(operation[1]);
                    int startIndex = text.Length - count;

                    if (startIndex < text.Length)
                    {
                        text.Remove(startIndex, count);

                        //save the changes in the stack
                        changes.Push(text.ToString());
                    }
                }
                else if (command == "3")
                {
                    //return the element at position
                    int index = int.Parse(operation[1]) - 1;

                    if (index < text.Length)
                    {
                        Console.WriteLine(text[index]);
                    }                   
                }
                else if (command == "4")
                {
                    //undo the last command of type 1 or 2
                    changes.Pop();
                    text.Clear();
                    text.Append(changes.Peek());
                }
            }
        }
    }
}

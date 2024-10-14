using CommandPattern.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandPattern.Core
{
    public class Engine : IEngine
    {
        private readonly ICommandInterpreter interpreter;

        public Engine(ICommandInterpreter interpreter)
        {
            this.interpreter = interpreter;
        }

        public void Run()
        {
            while (true)
            {
                string arguments = Console.ReadLine();

                try
                {
                    string result = interpreter.Read(arguments);
                    Console.WriteLine(result);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}

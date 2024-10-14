using CommandPattern.Core.Contracts;
using System;
using System.Linq;
using System.Reflection;

namespace CommandPattern.Core
{
    public class CommandInterpreter : ICommandInterpreter
    {
        public string Read(string args)
        {
            string[] arguments = args
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            string commandType = arguments[0];
            string[] commandArguments = arguments.Skip(1).ToArray();

            string commandName = $"{commandType}Command";

            Type type = Assembly
                .GetEntryAssembly()
                .GetTypes()
                .FirstOrDefault(t => t.Name == commandName);

            if (type == null )
            {
                throw new ArgumentException("Invalid command type");
            }

            ICommand command = Activator.CreateInstance(type) as ICommand;

            return command.Execute(commandArguments);
        }
    }
}

using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace PathlockAutomationPipeline.Commands
{
    internal class PlainTextCommandFileReader : ICommandFileReader
    {
        public List<ICommand> Read(string filePath)
        {
            string[] rawLines = File.ReadAllLines(filePath);
            List<ICommand> commands = new List<ICommand>();

            foreach(string line in rawLines)
            {
                string[] tokens = line.Split(' ');
                string commandName = tokens[0];

                string[] commandArgs = 
                    tokens.ToList().GetRange(1, tokens.Length - 1).ToArray();

                ICommand cmd = CommandFactory.Create(commandName, commandArgs);
                commands.Add(cmd);
            }

            return commands;
        }
    }
}

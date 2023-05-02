using PathlockAutomationPipeline.Commands;
using System.Collections.Generic;
using System.Xml;

namespace PathlockAutomationPipeline.CommandFileReaders
{
    internal class XmlCommandFileReader : ICommandFileReader
    {
        public List<ICommand> Read(string filePath)
        {
            string commandName = null;
            List<string> args = new List<string>();
            List<ICommand> commands = new List<ICommand>();
            using (XmlReader xr = XmlReader.Create(filePath))
            {
                while(xr.Read()) { 
                    if (xr.IsStartElement())
                    {
                        switch (xr.Name.ToString())
                        {
                            case "Name":
                                if (commandName != null)
                                {
                                    commands.Add(CommandFactory.Create(commandName, args.ToArray()));
                                    commandName = null;
                                    args = new List<string>();
                                }
                                commandName = xr.ReadElementContentAsString();
                                break;
                            case "Arg":
                                args.Add(xr.ReadElementContentAsString());
                                break;
                        }
                    }
                }

            }
            commands.Add(CommandFactory.Create(commandName, args.ToArray()));
            return commands;
        }
    }
}

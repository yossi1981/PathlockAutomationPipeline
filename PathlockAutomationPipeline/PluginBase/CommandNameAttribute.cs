using System;

namespace PluginBase
{
    [AttributeUsage(AttributeTargets.Class)]
    public class CommandNameAttribute : Attribute
    {
        private string _commandName;
        public string CommandName { get { return _commandName; } }

        public CommandNameAttribute(string commandName)
        {
            _commandName = commandName;
        }
    }
}

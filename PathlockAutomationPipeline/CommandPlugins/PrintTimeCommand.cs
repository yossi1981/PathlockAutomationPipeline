using PluginBase;
using System;

namespace CommandPlugins
{
    /// <summary>
    /// A command that prints to the console the current time with a formet 
    /// given as an argument
    /// syntax print-time [format]
    /// </summary>
    /// 
    [CommandName("print-time")]
    public class PrintTimeCommand : ICommandPlugin
    {
        public void Execute(string[] args)
        {
            Console.WriteLine(DateTime.Now.ToString(args[0]));
        }
    }
}
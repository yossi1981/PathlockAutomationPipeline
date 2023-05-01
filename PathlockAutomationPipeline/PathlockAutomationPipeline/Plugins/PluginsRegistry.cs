using PluginBase;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace PathlockAutomationPipeline.Plugins
{
    //I could make that a  singleton, instead of static class. 
    //I think that's too much of a show off, so I went with just a static class.
    internal static class PluginsRegistry
    {
        static private List<Type> _commandTypes = null;
        public static void Load(string pluginFileName)
        {
            FileInfo fi = new FileInfo(pluginFileName);
            Assembly assembly = Assembly.LoadFile(fi.FullName);
            _commandTypes = assembly.GetTypes().ToList();
        }

        public static ICommandPlugin CreateCommandPlugin(string commandName)
        {
            foreach (var plugin in _commandTypes)
            {
                CommandNameAttribute cmdNameAttr = 
                    plugin.GetCustomAttribute(typeof(CommandNameAttribute)) as CommandNameAttribute;

                if (cmdNameAttr.CommandName == commandName)
                {
                    return Activator.CreateInstance(plugin) as ICommandPlugin;
                }
            }
            return null;
        }
    }
}

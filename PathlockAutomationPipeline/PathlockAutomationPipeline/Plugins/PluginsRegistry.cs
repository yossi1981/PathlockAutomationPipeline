using PluginBase;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace PathlockAutomationPipeline.Plugins
{
    internal static class PluginsRegistry
    {
        static private List<Type> _commandTypes = new List<Type>();
        public static void Load(string pluginFileName)
        {
            FileInfo fi = new FileInfo(pluginFileName);
            if (fi.Exists == false) return;

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

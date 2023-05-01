using PathlockAutomationPipeline.Commands;
using PathlockAutomationPipeline.Plugins;
using PluginBase;

namespace PathlockAutomationPipeline
{
    //I could make that a  singleton, instead of static class. 
    //I think that's too much of a show off, so I went with just a static class.
    internal static class CommandFactory
    {
        static public ICommand Create(string _commandName, params string[] args)
        {
            /* I know, instead of this mapping, I could use  attributes and reflections.
            (mark each concrete command with an attribute for its command name and than 
            use reflections for matching).
            
            However, I don't think that's a good design, since it will couple the command class with its 
            command name, I think that the command class being unaware of it's command-name AND HOW IT IS invoked
            will makes it EASIER to extend.*/
            switch (_commandName) {
                case "copy-file":
                    return new FileCopyCommand(args[0], args[1]);
                case "delete-file":
                    return new FileDeleteCommand(args[0]);
                case "query-folder":
                    return new QueryFolderFilesCommand(args[0]);
                case "create-folder":
                    return new CreateFolderCommand(args[0], args[1]);
                case "download-file":
                    return new DownloadFileCommand(args[0], args[1]);
                case "wait":
                    return new WaitCommand(uint.Parse(args[0]));
                case "count-rows":
                    return new ConditionalCountRowsCommand(args[0], args[1]);
            }

            ICommandPlugin cmdPlugin = PluginsRegistry.CreateCommandPlugin(_commandName);
            if(cmdPlugin != null)
            {
                return new PluginAdapterCommand(cmdPlugin, args);
            }
            return null;
        }
    }
}

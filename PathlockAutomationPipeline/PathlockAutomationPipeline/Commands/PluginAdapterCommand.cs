using PluginBase;
namespace PathlockAutomationPipeline.Commands
{
    internal class PluginAdapterCommand : ICommand 
    {
        private readonly ICommandPlugin _plugin;
        private readonly string[] _args;

        public PluginAdapterCommand(ICommandPlugin plugin, string[] args)   
        {
            _plugin = plugin;
            _args = args;
        }

        public void Execute()
        {
            _plugin.Execute(_args);
        }
    }
}

using PathlockAutomationPipeline.AutomationPipeline;
using PathlockAutomationPipeline.CommandFileReaders;
using PathlockAutomationPipeline.Commands;
using PathlockAutomationPipeline.Plugins;
using System;
using System.Collections.Generic;
using System.Configuration;

namespace PathlockAutomationPipeline
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                //loading plugins
                PluginsRegistry.Load(ConfigurationManager.AppSettings["pluginFileName"]);
                
                //loading commands
                string commandFilePath = args[0];
                ICommandFileReader cfr = CommndFileReaderFactory.Create(commandFilePath);          
                List<ICommand> commands = cfr.Read(commandFilePath);

                //intializing and running an automation pipeline
                AutomationPipeline.AutomationPipeline pipeline = null;
                string pipelineMode = ConfigurationManager.AppSettings["PipelineMode"];
                if(pipelineMode == "Verbose")
                    pipeline = new VerboseAutomationPipeline();
                else
                    pipeline = new SilentAutomationPipeline();

                pipeline.Run(commands);
            }
            catch(Exception e)
            {
                Console.WriteLine(
                    "There was an error while trying to execute the automation pipeline : " +
                    e.Message);
            }
            Console.WriteLine("press any key to end the program");
            Console.ReadKey();
        }
    }
}

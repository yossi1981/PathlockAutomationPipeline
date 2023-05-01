
using PathlockAutomationPipeline.Commands;
using System;
using System.ComponentModel;

namespace PathlockAutomationPipeline.AutomationPipeline
{
    internal class VerboseAutomationPipeline : AutomationPipeline
    {
        public override void beforeExecute(ICommand command)
        {
            
            Console.WriteLine("Starting  command execution : {0}", command.ToString());
            foreach (PropertyDescriptor descriptor in TypeDescriptor.GetProperties(command))
            {
                string name = descriptor.Name;
                object value = descriptor.GetValue(command);
                Console.WriteLine("{0}={1}", name, value);
            }
        }

        public override void afterExecute(ICommand command)
        {
            Console.WriteLine("Finished command execution : {0}", command.ToString());
            Console.WriteLine("----------------------------------------------------------");
        }
    }
}

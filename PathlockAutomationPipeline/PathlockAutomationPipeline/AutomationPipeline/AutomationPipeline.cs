using PathlockAutomationPipeline.Commands;
using System.Collections.Generic;

namespace PathlockAutomationPipeline.AutomationPipeline
{
    internal abstract class AutomationPipeline
    {
        public void Run(List<ICommand> commands) 
        {
            commands.ForEach(command =>
            {
                beforeExecute(command);
                command.Execute();
                afterExecute(command);
            });
        }

        public abstract void beforeExecute(ICommand command);
        public abstract void afterExecute(ICommand command);
    }
}

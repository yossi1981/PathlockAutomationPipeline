using PathlockAutomationPipeline.Commands;

namespace PathlockAutomationPipeline.AutomationPipeline
{
    internal class SilentAutomationPipeline : AutomationPipeline
    {
        public override void afterExecute(ICommand command)
        {
        }

        public override void beforeExecute(ICommand command)
        {
        }
    }
}

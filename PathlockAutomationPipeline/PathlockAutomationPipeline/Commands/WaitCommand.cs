using System.Threading;

namespace PathlockAutomationPipeline.Commands
{
    internal class WaitCommand : ICommand
    {
        private readonly uint _seconds;

        public WaitCommand(uint seconds)
        {
            _seconds = seconds;
        }

        public void Execute()
        {
            Thread.Sleep((int)_seconds * 1000);
        }
    }
}

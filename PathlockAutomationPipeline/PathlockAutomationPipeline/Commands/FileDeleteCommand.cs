using System.IO;

namespace PathlockAutomationPipeline.Commands
{
    internal class FileDeleteCommand : ICommand
    {
        private readonly string _filePath;

        public FileDeleteCommand(string filePath)
        {
            _filePath = filePath;
        }

        public void Execute()
        {
            File.Delete(_filePath);
        }
    }
}

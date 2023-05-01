using System.IO;

namespace PathlockAutomationPipeline.Commands
{
    internal class CreateFolderCommand : ICommand
    {
        private readonly string _parentFolderPath;
        private readonly string _newFolder;

        public CreateFolderCommand(string parentFolderPath, string newFolder)
        {
            _parentFolderPath = parentFolderPath;
            _newFolder = newFolder;
        }

        public void Execute()
        {
            string fullpath = Path.Combine(_parentFolderPath, _newFolder);
            Directory.CreateDirectory(fullpath);
        }
    }
}

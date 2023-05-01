using System.IO;

namespace PathlockAutomationPipeline.Commands
{
    internal class FileCopyCommand : ICommand
    {
        private readonly string _srcFile;
        private readonly string _dstFile;

        public FileCopyCommand(string srcFile, string dstFile)
        {
            _srcFile = srcFile;
            _dstFile = dstFile;
        }

        public void Execute()
        {
            File.Copy( _srcFile, _dstFile );
        }
    }
}

using System;
using System.IO;

namespace PathlockAutomationPipeline.Commands
{
    internal class ConditionalCountRowsCommand : ICommand
    {
        private readonly string _srcFile;
        private readonly string _searchString;
        public ConditionalCountRowsCommand(string srcFile, string searchString)
        {
            _srcFile = srcFile;
            _searchString = searchString;
        }
        public void Execute()
        {
            UInt32 count = 0;
            string[] lines = File.ReadAllLines(_srcFile);
            foreach (string line in lines)
            {
                if (line.Contains(_searchString))
                {
                    count++;
                }
            }
            Console.WriteLine("The word '{0}' appears in {1} rows inside the file {2}",
                _searchString, count, _srcFile);

        }
    }
}

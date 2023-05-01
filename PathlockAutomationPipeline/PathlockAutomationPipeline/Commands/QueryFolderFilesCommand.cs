using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace PathlockAutomationPipeline.Commands
{
    internal class QueryFolderFilesCommand : ICommand
    {
        private readonly string _folderPath;

        public QueryFolderFilesCommand(string folderPath)
        {
            _folderPath = folderPath;
        }

        public void Execute()
        {
            List<string> files = Directory.GetFileSystemEntries(_folderPath).ToList();
            files.ForEach(f => { Console.WriteLine(f); });
        }
    }
}

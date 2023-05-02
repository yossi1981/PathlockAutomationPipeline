using PathlockAutomationPipeline.Commands;
using System;
using System.IO;

namespace PathlockAutomationPipeline.CommandFileReaders
{
    internal static class CommndFileReaderFactory
    {
        public static ICommandFileReader Create(string fileName)
        {
            if (File.Exists(fileName) == false) 
                throw new Exception(
                    String.Format("The file '{0}' doesn't exist", fileName));

            FileInfo fr = new FileInfo(fileName);
            string ext = fr.Extension;

            switch(ext)
            {
                case ".txt":
                    return new PlainTextCommandFileReader();
                case ".xml":
                    return new XmlCommandFileReader();
            }

            throw new Exception("Could not create a command file reader," +
                "file name should be with either the '.txt' or '.xml' extension");
        }
    }
}

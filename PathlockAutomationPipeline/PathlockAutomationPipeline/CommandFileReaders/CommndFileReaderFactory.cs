using PathlockAutomationPipeline.Commands;
using System;
using System.IO;

namespace PathlockAutomationPipeline.CommandFileReaders
{
    //I could make that a  singleton, instead of static class. 
    //I think that's too much of a show off, so I went with just a static class.
    internal static class CommndFileReaderFactory
    {
        public static ICommandFileReader Create(string fileName)
        {
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

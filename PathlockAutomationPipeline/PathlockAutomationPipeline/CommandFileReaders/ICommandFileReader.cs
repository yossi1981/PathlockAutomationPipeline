using System.Collections.Generic;

namespace PathlockAutomationPipeline.Commands
{
    internal interface ICommandFileReader
    {
        List<ICommand> Read(string filePath);
    }
}

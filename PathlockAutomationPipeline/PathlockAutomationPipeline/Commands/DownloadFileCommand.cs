using System.Net;

namespace PathlockAutomationPipeline.Commands
{
    internal class DownloadFileCommand : ICommand
    {
        private readonly string _srcUrl;
        private readonly string _dstFile;

        public DownloadFileCommand(string srcUrl, string dstFile)
        {
            _srcUrl = srcUrl;
            _dstFile = dstFile;
        }

        public void Execute()
        {
            using (WebClient wc = new WebClient())
            {
                wc.DownloadFile(_srcUrl, _dstFile);
            }
        }
    }
}

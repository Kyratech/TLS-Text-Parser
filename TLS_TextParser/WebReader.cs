using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace TLS_TextParser
{
    public class WebReader : InputReader
    {
        public const string InvalidAddressMessage = "The provided web address is not a valid webpage";

        private string path;

        public WebReader(string webpath)
        {
            path = webpath;
        }

        string InputReader.ReadInput()
        {
            try
            {
                WebClient client = new WebClient();
                string text = client.DownloadString(path);
                return text;
            }
            catch (WebException we)
            {
                throw new ArgumentException(InvalidAddressMessage, we);
            }
        }
    }
}

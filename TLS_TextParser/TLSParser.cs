using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TLS_TextParser
{
    public class TLSParser
    {
        public const string InvalidFileMessage = "The provided file path is not a valid text file";

        private TextReader textReader;

        static void Main(string[] args)
        {
            
        }

        public TLSParser(String filePath)
        {
            try
            {
                textReader = new TextReader(filePath);
            }
            catch (System.IO.IOException ae)
            {
                throw new ArgumentException(InvalidFileMessage, ae);
            }
        }
    }
}

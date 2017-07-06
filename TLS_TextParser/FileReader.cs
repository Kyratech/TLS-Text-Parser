using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TLS_TextParser
{
    public class FileReader : InputReader
    {
        public const string InvalidFileMessage = "The provided file path is not a valid text file";

        private string path;

        public FileReader(string filepath)
        {
            path = filepath;
        }

        string InputReader.ReadInput()
        {
            try
            {
                string text = System.IO.File.ReadAllText(path);
                return text;
            }
            catch (System.IO.IOException ae)
            {
                throw new ArgumentException(InvalidFileMessage, ae);
            }
        }
    }
}

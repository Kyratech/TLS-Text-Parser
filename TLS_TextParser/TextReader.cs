using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TLS_TextParser
{
    public class TextReader
    {
        string[] lines;

        public TextReader(string filePath)
        {
            lines = System.IO.File.ReadAllLines(filePath);
        }
    }
}

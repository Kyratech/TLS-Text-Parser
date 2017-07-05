using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

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

        public int RegexCount_tra()
        {
            int counter = 0;

            string pattern = "tra";

            string[] lines = textReader.GetLines();
            for(int line = 0; line < lines.Length; line++)
            {
                Regex regex = new Regex(pattern, RegexOptions.IgnoreCase);
                MatchCollection matches = regex.Matches(lines[line]);
                counter += matches.Count;
            }

            return counter;
        }
    }
}

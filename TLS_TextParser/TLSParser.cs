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

        public int RegexCount(string pattern)
        {
            int counter = 0;

            string[] lines = textReader.GetLines();
            for(int line = 0; line < lines.Length; line++)
            {
                counter += CountMatches(lines[line], pattern);
            }

            return counter;
        }

        public int CountMatches(string input, string pattern)
        {
            Regex regex = new Regex(pattern, RegexOptions.IgnoreCase);
            MatchCollection matches = regex.Matches(input);
            return matches.Count;
        }
    }
}

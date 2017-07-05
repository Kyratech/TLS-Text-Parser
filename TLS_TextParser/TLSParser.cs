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
        private TLSDictionary tlsDictionary;

        static void Main(string[] args)
        {
            TLSParser tlsParser = new TLSParser("C:/Work/Training/TLS_TextParser/TLS_TextParser/text/source_file.txt");
            tlsParser.RunTLSCount();
        }

        public TLSParser(String filePath)
        {
            try
            {
                textReader = new TextReader(filePath);
                tlsDictionary = new TLSDictionary();
            }
            catch (System.IO.IOException ae)
            {
                throw new ArgumentException(InvalidFileMessage, ae);
            }
        }

        public int GetTLSCount(string tls)
        {
            return tlsDictionary.GetCount(tls);
        }

        public void RunTLSCount()
        {
            string tlsPattern = "[a-z]{3}";
            Regex tlsRegex = new Regex(tlsPattern, RegexOptions.IgnoreCase);

            CountTLSInInput(tlsRegex);
        }

        private void CountTLSInInput(Regex tlsRegex)
        {
            string[] lines = textReader.GetLines();
            for(int line = 0; line < lines.Length; line++)
            {
                CountTLSInString(tlsRegex, lines[line]);
            }
        }

        private void CountTLSInString(Regex tlsRegex, string line)
        {
            Match match = tlsRegex.Match(line);
            while(match.Success)
            {
                tlsDictionary.IncrementTLS(match.Value);
                match = tlsRegex.Match(line, match.Index + 1);
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

        private int CountMatches(string input, string pattern)
        {
            Regex regex = new Regex(pattern, RegexOptions.IgnoreCase);
            MatchCollection matches = regex.Matches(input);
            return matches.Count;
        }
    }
}

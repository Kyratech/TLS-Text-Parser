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

        private string text;

        static void Main(string[] args)
        {
            TLSParser tlsParser = new TLSParser("C:/Work/Training/TLS_TextParser/TLS_TextParser/text/source_file.txt");
            TLSDictionary tlsDictionary = tlsParser.PopulateTLSDictionary();

            List<string> top10 = tlsDictionary.GetTopTLS(20);

            foreach (string tlsPair in top10)
            {
                Console.WriteLine(tlsPair);
            }
        }

        public TLSParser(String filePath)
        {
            try
            {
                text = System.IO.File.ReadAllText(filePath);
            }
            catch (System.IO.IOException ae)
            {
                throw new ArgumentException(InvalidFileMessage, ae);
            }
        }

        public TLSDictionary PopulateTLSDictionary()
        {
            TLSDictionary tlsDictionary = new TLSDictionary();

            string tlsPattern = "[a-z]{3}";
            Regex tlsRegex = new Regex(tlsPattern, RegexOptions.IgnoreCase);

            Match match = tlsRegex.Match(text);
            while(match.Success)
            {
                tlsDictionary.IncrementTLS(match.Value);
                match = tlsRegex.Match(text, match.Index + 1);
            }

            return tlsDictionary;
        }

        public int RegexCount(string pattern)
        {
            Regex regex = new Regex(pattern, RegexOptions.IgnoreCase);
            MatchCollection matches = regex.Matches(text);
            return matches.Count;
        }
    }
}

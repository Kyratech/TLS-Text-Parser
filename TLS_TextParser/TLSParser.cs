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
        private string text;

        static void Main(string[] args)
        {
            InputReader fileReader = new WebReader("https://en.wikipedia.org/wiki/C");
            TLSParser tlsParser = new TLSParser(fileReader.ReadInput());
            TLSDictionary tlsDictionary = tlsParser.PopulateTLSWithGapsDictionary();

            List<string> top10 = tlsDictionary.GetTopTLS(20);

            foreach (string tlsPair in top10)
            {
                Console.WriteLine(tlsPair);
            }
        }

        public TLSParser(String input)
        {
            text = input;
        }

        public TLSDictionary PopulateTLSWithGapsDictionary()
        {
            TLSDictionary tlsDictionary = new TLSDictionary();

            string tlsGapPattern = "[a-z][^a-z]*[a-z][^a-z]*[a-z]";
            string letterExtractorPattern = "[^a-z]";

            Regex tlsRegex = new Regex(tlsGapPattern, RegexOptions.IgnoreCase);
            Regex letterExtractorRegex = new Regex(letterExtractorPattern, RegexOptions.IgnoreCase);

            Match match = tlsRegex.Match(text);
            while (match.Success)
            {
                string tlsOnly = letterExtractorRegex.Replace(match.Value, "");
                tlsDictionary.IncrementTLS(tlsOnly);
                match = tlsRegex.Match(text, match.Index + 1);
            }

            return tlsDictionary;
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

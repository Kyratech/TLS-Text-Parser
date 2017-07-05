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

        private TLSDictionary tlsDictionary;
        private string text;

        static void Main(string[] args)
        {
            TLSParser tlsParser = new TLSParser("C:/Work/Training/TLS_TextParser/TLS_TextParser/text/source_file.txt");
            tlsParser.RunTLSCount();

            List<string> top10 = tlsParser.GetTopN(10);

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

        public List<string> GetTLSWithCount(int count)
        {
            return tlsDictionary.GetTLSWithCount(count);
        }

        public List<string> GetTopN(int n)
        {
            return tlsDictionary.GetTopTLS(n);
        }

        public void RunTLSCount()
        {
            string tlsPattern = "[a-z]{3}";
            Regex tlsRegex = new Regex(tlsPattern, RegexOptions.IgnoreCase);

            CountTLSInString(tlsRegex, text);
        }

        private void CountTLSInString(Regex tlsRegex, string input)
        {
            Match match = tlsRegex.Match(input);
            while(match.Success)
            {
                tlsDictionary.IncrementTLS(match.Value);
                match = tlsRegex.Match(input, match.Index + 1);
            }
        }

        public int RegexCount(string pattern)
        {
            Regex regex = new Regex(pattern, RegexOptions.IgnoreCase);
            MatchCollection matches = regex.Matches(text);
            return matches.Count;
        }
    }
}

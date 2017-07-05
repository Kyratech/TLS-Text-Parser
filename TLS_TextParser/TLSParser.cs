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
            TLSParser tlsParser = new TLSParser("C:/Work/Training/TLS_TextParser/TLS_TextParser/text/source_file.txt");
            int traCount = tlsParser.CountTLS_tra();
            Console.WriteLine("'tra' Count = " + traCount);
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

        public int CountTLS_tra()
        {
            int counter = 0;

            string[] lines = textReader.GetLines();

            for(int line = 0; line < lines.Length; line++)
            {
                char[] currentLine = lines[line].ToCharArray();
                for(int character = 0; character < currentLine.Length - 2; character++)
                {
                    if (char.ToUpperInvariant(currentLine[character]) == 'T' && char.ToUpperInvariant(currentLine[character + 1]) == 'R' && char.ToUpperInvariant(currentLine[character + 2]) == 'A')
                    {
                        counter++;
                    }
                }
            }

            return counter;
        }
    }
}

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TLS_TextParser;

namespace TLS_Test
{
    [TestClass]
    public class TLS_TextParser_Tests
    {
        [TestMethod]
        public void Parser_WithValidFile_NoErrors()
        {
            try
            {
                TLSParser tlsParser = new TLSParser("C:/Work/Training/TLS_TextParser/TLS_TextParser/text/source_file.txt");
            }
            catch(Exception e)
            {
                Assert.Fail("Expected no exception, but got: " + e.Message);
            }
        }

        [TestMethod]
        public void Parser_WithInvalidFile_ThrowsArgumentException()
        {
            try
            {
                TLSParser tlsParser = new TLSParser("C:/Work/Training/TLS_TextParser/TLS_TextParser/text/invalid_file.txt");
            }
            catch(ArgumentException ae)
            {
                StringAssert.Contains(ae.Message, TLSParser.InvalidFileMessage);
                return;
            }

            Assert.Fail("No Argument Exception was thrown");
        }

        [TestMethod]
        public void Reader_WithSourceFile_FirstLineCorrect()
        {
            TextReader textReader = new TextReader("C:/Work/Training/TLS_TextParser/TLS_TextParser/text/source_file.txt");
            string firstLine = textReader.GetLines()[0];
            StringAssert.Equals(firstLine, "The Project Gutenberg EBook of Romeo and Juliet, by William Shakespeare");
        }

        [TestMethod]
        public void Parser_WithSourceFile_CountsTRA()
        {
            TLSParser tlsParser = new TLSParser("C:/Work/Training/TLS_TextParser/TLS_TextParser/text/source_file.txt");
            int traCount = tlsParser.RegexCount("tra");
            Assert.AreEqual<int>(traCount, 63);
        }
    }
}

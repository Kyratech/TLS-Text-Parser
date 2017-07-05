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

        [TestMethod]
        public void Parser_WithSourceFile_AddsToDictionary()
        {
            TLSParser tlsParser = new TLSParser("C:/Work/Training/TLS_TextParser/TLS_TextParser/text/source_file.txt");
            tlsParser.RunTLSCount();

            int traCount = tlsParser.GetTLSCount("tra");
            int preCount = tlsParser.GetTLSCount("pre");
            int qqqCount = tlsParser.GetTLSCount("qqq");

            Assert.AreEqual<int>(traCount, 63);
            Assert.AreEqual<int>(preCount, 63);
            Assert.AreEqual<int>(qqqCount, 0);
        }

        [TestMethod]
        public void TLSDictionary_WithInvalidOutput_ReturnsZero()
        {
            TLSDictionary dict = new TLSDictionary();

            int xxxCount = dict.GetCount("xxx");
            int invalidCount = dict.GetCount("Invalid");

            Assert.AreEqual<int>(xxxCount, 0);
            Assert.AreEqual<int>(invalidCount, 0);
        }

        [TestMethod]
        public void TLSDictionary_WithIncorrectSizeInput_ThrowsException()
        {
            TLSDictionary dict = new TLSDictionary();

            try
            {
                dict.IncrementTLS("Invalid");
            }
            catch(ArgumentException ae)
            {
                StringAssert.Contains(ae.Message, TLSDictionary.IncorrectLengthTLSMessage);
                return;
            }

            Assert.Fail("No Argument Exception was thrown");
        }

        [TestMethod]
        public void TLSDictionary_IncrementsCounts()
        {
            TLSDictionary dict = new TLSDictionary();

            int emptyAAACount = dict.GetCount("aaa");

            dict.IncrementTLS("aaa");
            int oneAAACount = dict.GetCount("aaa");

            dict.IncrementTLS("aaa");
            int twoAAACount = dict.GetCount("aaa");

            int emptyBBBCount = dict.GetCount("bbb");

            Assert.AreEqual<int>(emptyAAACount, 0);
            Assert.AreEqual<int>(oneAAACount, 1);
            Assert.AreEqual<int>(twoAAACount, 2);
            Assert.AreEqual<int>(emptyBBBCount, 0);
        }
    }
}

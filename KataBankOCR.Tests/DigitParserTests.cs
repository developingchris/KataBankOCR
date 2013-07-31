using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace KataBankOCR.Tests
{
    [TestFixture]
    public class DigitParserTests
    {
        public LineParser Parser;

        [SetUp]
        public void Before()
        {
            var filecontents = @" _  _  _  _  _  _  _  _  _ 
| || || || || || || || || |
|_||_||_||_||_||_||_||_||_|
                                                      
  |  |  |  |  |  |  |  |  |
  |  |  |  |  |  |  |  |  |
                            _  _  _  _  _  _  _  _  _ 
 _| _| _| _| _| _| _| _| _|
|_ |_ |_ |_ |_ |_ |_ |_ |_ 

 _  _  _  _  _  _  _  _  _ 
 _| _| _| _| _| _| _| _| _|
 _| _| _| _| _| _| _| _| _|
                           
                           
|_||_||_||_||_||_||_||_||_|
  |  |  |  |  |  |  |  |  |
                           
 _  _  _  _  _  _  _  _  _ 
|_ |_ |_ |_ |_ |_ |_ |_ |_ 
 _| _| _| _| _| _| _| _| _|
                           
 _  _  _  _  _  _  _  _  _ 
|_ |_ |_ |_ |_ |_ |_ |_ |_ 
|_||_||_||_||_||_||_||_||_|
                           
 _  _  _  _  _  _  _  _  _ 
  |  |  |  |  |  |  |  |  |
  |  |  |  |  |  |  |  |  |
                           
 _  _  _  _  _  _  _  _  _ 
|_||_||_||_||_||_||_||_||_|
|_||_||_||_||_||_||_||_||_|
                           
 _  _  _  _  _  _  _  _  _ 
|_||_||_||_||_||_||_||_||_|
 _| _| _| _| _| _| _| _| _|
                           
 _  _  _  _  _  _  _  _  _ 
|_||_||_||_||_||_||_||_||_|
{_| _| _| _| _| _| _| _| _|
                           
    _  _     _  _  _  _  _ 
  | _| _||_||_ |_   ||_||_|
  ||_  _|  | _||_|  ||_| _|
                           
";
            Parser = new LineParser(filecontents);
            Parser.Parse();
        }

        [Test]
        public void ZeroLineOutput()
        {
            Assert.AreEqual("000000000", new DisplayLine(Parser.Lines[0]).ToString());
        }

        [Test]
        public void All1sIsAnErrorLine()
        {
           Assert.AreEqual("111111111 ERR", new DisplayLine(Parser.Lines[1]).ToString());
        }

        [Test]
        public void AllDigitsParsedOnLastLine()
        {
            Assert.AreEqual("123456789", new DisplayLine(Parser.Lines[11]).ToString());
        }

        [Test]
        public void InvalidDigitIsQuestionMarkAndIllRow()
        {
            Assert.AreEqual("?99999999 ILL", new DisplayLine(Parser.Lines[10]).ToString());
        }


    }
}

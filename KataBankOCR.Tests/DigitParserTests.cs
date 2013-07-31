using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace KataBankOCR.Tests
{
    [TestFixture]
    public class DigitParserTests
    {
        public string File;

        [SetUp]
        public void Before()
        {
            File = @" _  _  _  _  _  _  _  _  _ 
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
                           
    _  _     _  _  _  _  _ 
  | _| _||_||_ |_   ||_||_|
  ||_  _|  | _||_|  ||_| _|
                           
";

        }

        [Test]
        public void ZeroLine()
        {
            var parser = new LineParser(File);
            parser.Parse();
            Assert.AreEqual(new List<int> { 0, 0, 0, 0, 0, 0, 0, 0, 0 }, parser.Lines[0]);
        }

        [Test]
        public void OnesLine()
        {
            var parser = new LineParser(File);
            parser.Parse();
            Assert.AreEqual(new List<int> { 1, 1, 1, 1, 1, 1, 1, 1, 1 }, parser.Lines[1]);
        }

        [Test]
        public void TwosLine()
        {
            var parser = new LineParser(File);
            parser.Parse();
            Assert.AreEqual(new List<int> { 2, 2, 2, 2, 2, 2, 2, 2, 2 }, parser.Lines[2]);
        }
        [Test]
        public void ThreesLine()
        {
            var parser = new LineParser(File);
            parser.Parse();
            Assert.AreEqual(new List<int> { 3, 3, 3, 3, 3, 3, 3, 3, 3 }, parser.Lines[3]);
        }
        [Test]
        public void FoursLine()
        {
            var parser = new LineParser(File);
            parser.Parse();
            Assert.AreEqual(new List<int> { 4, 4, 4, 4, 4, 4, 4, 4, 4 }, parser.Lines[4]);
        }

        [Test]
        public void FivesLine()
        {
            var parser = new LineParser(File);
            parser.Parse();
            Assert.AreEqual(new List<int> { 5, 5, 5, 5, 5, 5, 5, 5, 5 }, parser.Lines[5]);
        }

        [Test]
        public void SixLine()
        {
            var parser = new LineParser(File);
            parser.Parse();
            Assert.AreEqual(new List<int> { 6, 6, 6, 6, 6, 6, 6, 6, 6 }, parser.Lines[6]);
        }

        [Test]
        public void AllDigits()
        {
            var parser = new LineParser(File);
            parser.Parse();
            Assert.AreEqual(new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 }, parser.Lines.Last());
        }

        [Test]
        public void OnesFailChecksum()
        {
            Assert.False(CheckSumValidator.Valid(new List<int> { 1, 1, 1, 1, 1, 1, 1, 1, 1 }));
        }

        [Test]
        public void ChecksOut()
        {
            Assert.True(CheckSumValidator.Valid(new List<int> { 3, 4, 5, 8, 8, 2, 8, 6, 5 }));
        }

        [Test]
        public void OutputFile()
        {
            var parser = new LineParser(File);
            parser.Parse();

            Assert.AreEqual("000000000", new DisplayLine(parser.Lines[0]).ToString());
            Assert.AreEqual("111111111 ERR", new DisplayLine(parser.Lines[1]).ToString());
            Assert.AreEqual("123456789", new DisplayLine(parser.Lines[10]).ToString());
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
        public void CountLines()
        {
           var parser = new LineParser(File);
           parser.Parse();
           Assert.AreEqual(10, parser.LineCount);
        }

        [Test]
        public void ParseZeroLine()
        {
            
        }

    }

    public class LineParser
    {
        private int _lineCount;
        public string Filecontents { get; set; }

        public LineParser(string filecontents)
        {
            Filecontents = filecontents;
        }

        public void Parse()
        {
            var lines = Filecontents.Split('\n');
            _lineCount = lines.Length / 4;
        }

        public int LineCount {
            get { return _lineCount; }
        }

    }
}

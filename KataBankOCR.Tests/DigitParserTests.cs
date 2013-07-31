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
        [Test]
        public void CountLines()
        {
            var file = @"
 _  _  _  _  _  _  _  _  _ 
| || || || || || || || || |
|_||_||_||_||_||_||_||_||_|
                                                      
  |  |  |  |  |  |  |  |  |
  |  |  |  |  |  |  |  |  |
                            _  _  _  _  _  _  _  _  _ 
 _| _| _| _| _| _| _| _| _|
|_ |_ |_ |_ |_ |_ |_ |_ |_ 
                           "


        }

    }
}

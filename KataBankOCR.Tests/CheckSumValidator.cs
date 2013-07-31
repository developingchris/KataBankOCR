using System.Collections.Generic;

namespace KataBankOCR.Tests
{
    public class CheckSumValidator
    {
        public static bool Valid(List<int> digits)
        {
            var sum = digits[8] + (2 * digits[7]) + (3 * digits[6]) + (4 * digits[5]) + (5 * digits[4]) + (6 * digits[3]) + (7 * digits[2]) + (8 * digits[1]) + (9 * digits[0]);

            return sum % 11 == 0;
        }
    }
}
using System.Collections.Generic;

namespace KataBankOCR.Tests
{
    public class LineParser
    {
        public string Filecontents { get; set; }

        public LineParser(string filecontents)
        {
            Filecontents = filecontents;
        }

        public void Parse()
        {
            Lines = new List<List<int>>();
            var lines = Filecontents.Split('\r');

            int step = 3;
            int online = 0;
            int limit = lines.Length / 4;
            while (online < limit)
            {
                var i = online * 4;
                var top_line = lines[i].TrimStart('\n');
                var middle_line = lines[i + 1].TrimStart('\n');
                var bottom_line = lines[i + 2].TrimStart('\n');
                int dig = 0;
                var digits = new List<int>();
                while (dig < 9)
                {
                    int index = dig * step;
                    var d = GetDigit(top_line.Substring(index, step), middle_line.Substring(index, step), bottom_line.Substring(index, step));
                    digits.Add(d);

                    dig += 1;
                }
                Lines.Add(digits);
                online += 1;
            }
        }

        public int GetDigit(string top, string middle, string bottom)
        {
            int output = -1;
            switch (top)
            {
                case "   ":
                    switch (middle)
                    {
                        case "  |":
                            output = 1;
                            break;
                        case "|_|":
                            output = 4;
                            break;
                    }
                    break;
                case " _ ":
                    switch (middle)
                    {
                        case "| |":
                            output = 0;
                            break;
                        case " _|":
                            switch (bottom)
                            {
                                case "|_ ":
                                    output = 2;
                                    break;
                                case " _|":
                                    output = 3;
                                    break;

                            }
                            break;
                        case "|_ ":
                            switch (bottom)
                            {
                                case " _|":
                                    output = 5;
                                    break;
                                case "|_|":
                                    output = 6;
                                    break;
                            }
                            break;
                        case "  |":
                            output = 7;
                            break;
                        case "|_|":
                            switch (bottom)
                            {
                                case "|_|":
                                    output = 8;
                                    break;
                                case " _|":
                                    output = 9;
                                    break;

                            }
                            break;
                    }
                    break;
            }
            return output;
        }

        public List<List<int>> Lines { get; set; }

    }
}
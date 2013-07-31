using System.Collections.Generic;
using System.Text;

namespace KataBankOCR.Tests
{
    public class DisplayLine
    {
        private readonly List<int> _line;

        public DisplayLine(List<int> line)
        {
            _line = line;
        }


        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            bool err = !CheckSumValidator.Valid(_line);
            bool ill = false;
            _line.ForEach(x =>
                {
                    if (x == -1)
                    {
                        ill = true;
                        sb.Append("?");
                    }
                    else
                    {
                        sb.Append(x.ToString());
                    }
                });
            if (ill)
            {
                sb.Append(" ILL");
            }
            else if (err)
            {
                sb.Append(" ERR");
            }
            return sb.ToString();
        }

    }
}
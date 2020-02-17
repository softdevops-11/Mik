using System;
using System.Text;

namespace RangeComplex
{
    internal class Range
    {
        public double From { get; set; }

        public double To { get; set; }

        public Range(double from, double to)
        {
            From = from;
            To = to;
        }

        public double GetLength()
        {
            return To - From;
        }

        public bool IsInside(double number)
        {
            return number >= From && number <= To;
        }

        public Range Intersection(Range range)
        {
            if (To > range.From && From < range.To)
            {
                To = Math.Min(To, range.To);
                From = Math.Max(From, range.From);

                return this;
            }

            To = From;

            return this;
        }

        public Range Union(Range range)
        {
            if (range.To >= From && range.From <= To)
            {
                From = Math.Min(From, range.From);
                To = Math.Max(To, range.To);
                range.From = From;
                range.To = To;
            }

            return this;
        }

        public Range Difference(Range range)
        {
            if (range.To > From && range.From < To)
            {
                if (range.From > From && range.To < To)
                {
                    double temp = To;
                    To = range.From;
                    range.From = range.To;
                    range.To = temp;
                }
                else if (range.From > From || range.To < To)
                {
                    if (range.From > From)
                    {
                        To = range.From;
                        range.From = From;
                        range.To = To;
                    }
                    else
                    {
                        From = range.To;
                        range.From = From;
                        range.To = To;
                    }
                }
            }
            else
            {
                range.From = From;
                range.To = To;
            }

            return this;
        }

        public override string ToString()
        {
            StringBuilder rangeString = new StringBuilder();
            rangeString.AppendFormat("({0}; {1})", From, To);

            return rangeString.ToString();
        }
    }
}

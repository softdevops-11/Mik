using System;
using System.Text;

namespace ComplexRange
{
    public class Range
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

        public Range Intersect(Range range)
        {
            if (To > range.From && From < range.To)
            {
                return new Range(Math.Max(From, range.From), Math.Min(To, range.To));
            }

            return null;
        }

        public Range[] Unite(Range range)
        {
            if (range.To >= From && range.From <= To)
            {
                Range[] rangeOneUnion = new Range[1];
                rangeOneUnion[0] = new Range(Math.Min(From, range.From), Math.Max(To, range.To));

                return rangeOneUnion;
            }

            Range[] rangeTwoUnion = new Range[2];
            rangeTwoUnion[0] = new Range(From, To);
            rangeTwoUnion[1] = new Range(range.From, range.To);

            return rangeTwoUnion;
        }

        public Range[] Subtract(Range range)
        {
            if (range.To > From && range.From < To)
            {
                if (range.From > From && range.To < To)
                {
                    Range[] rangeTwoDifference = new Range[2];
                    rangeTwoDifference[0] = new Range(From, range.From);
                    rangeTwoDifference[1] = new Range(range.To, To);

                    return rangeTwoDifference;
                }
                else if (range.From > From || range.To < To)
                {
                    Range[] rangeOneDifference = new Range[1];
                    if (range.From > From)
                    {
                        rangeOneDifference[0] = new Range(From, range.From);

                        return rangeOneDifference;
                    }
                    else
                    {
                        rangeOneDifference[0] = new Range(range.To, To);

                        return rangeOneDifference;
                    }
                }
            }
            else
            {
                Range[] rangeOneDifference = new Range[1];
                rangeOneDifference[0] = new Range(From, To);

                return rangeOneDifference;
            }

            return null;
        }

        public override string ToString()
        {
            return string.Format("({0}; {1})", From, To);
        }
    }
}


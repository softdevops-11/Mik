namespace RangeMain
{
    internal class Range
    {
        public double From { get; private set; }

        public double To { get; private set; }

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

        public static Range RangesIntersection(Range intervalOne, Range intervalTwo)
        {
            double intersectionFrom = 0;
            double intersectionTo = 0;

            if (intervalTwo.To >= intervalOne.From && intervalTwo.From <= intervalOne.To)
            {
                if (intervalOne.From >= intervalTwo.From)
                {
                    intersectionFrom = intervalOne.From;
                }
                else
                {
                    intersectionFrom = intervalTwo.From;
                }

                if (intervalOne.To <= intervalTwo.To)
                {
                    intersectionTo = intervalOne.To;
                }
                else
                {
                    intersectionTo = intervalTwo.To;
                }

                return new Range(intersectionFrom, intersectionTo);
            }

            return null;
        }

        public static Range[] RangesUnion(Range intervalOne, Range intervalTwo)
        {
            double[] unionFrom = new double[2];
            double[] unionTo = new double[2];
            Range[] rangesUnion = new Range[2];

            if (intervalTwo.To >= intervalOne.From && intervalTwo.From <= intervalOne.To)
            {
                if (intervalOne.From >= intervalTwo.From)
                {
                    unionFrom[0] = intervalTwo.From;
                }
                else
                {
                    unionFrom[0] = intervalOne.From;
                }

                if (intervalOne.To <= intervalTwo.To)
                {
                    unionTo[0] = intervalTwo.To;
                }
                else
                {
                    unionTo[0] = intervalOne.To;
                }

                rangesUnion[0] = new Range(unionFrom[0], unionTo[0]);

                return rangesUnion;
            }
            unionFrom[0] = intervalOne.From;
            unionTo[0] = intervalOne.To;
            unionFrom[1] = intervalTwo.From;
            unionTo[1] = intervalTwo.To;

            rangesUnion[0] = new Range(unionFrom[0], unionTo[0]);
            rangesUnion[1] = new Range(unionFrom[1], unionTo[1]);

            return rangesUnion;
        }

        public static Range[] RangesDifference(Range intervalOne, Range intervalTwo)
        {
            double[] differenceFrom = new double[2];
            double[] differenceTo = new double[2];

            Range[] rangesDifference = new Range[2];

            if (intervalTwo.To >= intervalOne.From && intervalTwo.From <= intervalOne.To)
            {
                if (intervalTwo.From > intervalOne.From && intervalTwo.To < intervalOne.To)
                {
                    differenceFrom[0] = intervalOne.From;
                    differenceTo[0] = intervalTwo.From;
                    differenceFrom[1] = intervalTwo.To;
                    differenceTo[1] = intervalOne.To;

                    rangesDifference[0] = new Range(differenceFrom[0], differenceTo[0]);
                    rangesDifference[1] = new Range(differenceFrom[1], differenceTo[1]);
                }
                else if (intervalTwo.From > intervalOne.From || intervalTwo.To < intervalOne.To)
                {
                    if (intervalTwo.From > intervalOne.From)
                    {
                        differenceFrom[0] = intervalOne.From;
                        differenceTo[0] = intervalTwo.From;
                        rangesDifference[0] = new Range(differenceFrom[0], differenceTo[0]);
                    }
                    else
                    {
                        differenceFrom[0] = intervalTwo.To;
                        differenceTo[0] = intervalOne.To;
                        rangesDifference[0] = new Range(differenceFrom[0], differenceTo[0]);
                    }
                }
            }
            else if (!(intervalTwo.To >= intervalOne.From && intervalTwo.From <= intervalOne.To))
            {
                differenceFrom[0] = intervalOne.From;
                differenceTo[0] = intervalOne.To;
                rangesDifference[0] = new Range(differenceFrom[0], differenceTo[0]);
            }

            return rangesDifference;
        }

    }
}

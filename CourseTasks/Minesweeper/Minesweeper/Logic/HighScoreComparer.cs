using System.Collections.Generic;

namespace Minesweeper.Logic
{
    class HighScoreComparer : IComparer<HightScores>
    {
        public int Compare(HightScores hs1, HightScores hs2)
        {
            return hs1.Time.CompareTo(hs2.Time);
        }
    }
}

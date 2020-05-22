using System.Collections.Generic;

namespace Minesweeper.Logic
{
    class HighScoreComparer : IComparer<HighScores>
    {
        public int Compare(HighScores hs1, HighScores hs2)
        {
            return hs1.Time.CompareTo(hs2.Time);
        }
    }
}

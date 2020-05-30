namespace Minesweeper.Logic
{
    public class HighScores
    {
        private readonly int time;
        private readonly string date;

        public HighScores(int time, string date)
        {
            this.time = time;
            this.date = date;
        }

        public override string ToString()
        {
            return string.Format("Время:{0}  Текущее время:{1}", time, date);
        }

        public int GetTime()
        {
            return time;
        }
    }
}


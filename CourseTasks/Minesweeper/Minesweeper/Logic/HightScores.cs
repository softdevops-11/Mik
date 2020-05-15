namespace Minesweeper.Logic
{
    public class HightScores
    {
        public int Time { get; }
        public string Date { get; }

        public HightScores(int time, string date)
        {
            Time = time;
            Date = date;
        }

        public override string ToString()
        {
            return string.Format("Время:{0}  Текущее время:{1}", Time, Date);
        }
    }
}


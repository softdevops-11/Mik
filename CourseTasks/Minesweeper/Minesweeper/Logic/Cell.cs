namespace Minesweeper.Logic
{
    class Cell
    {
        public enum Status
        {
            Close,
            Open,
            Flaged
        }

        public enum Mean
        {
            Bomb,
            Zero,
            OneBomb,
            TwoBomb,
            ThreeBomb,
            FourBomb,
            FiveBomb,
            SixBomb,
            SevenBomb,
            EightBomb
        }

        private Status currentCellStatus;
        private Mean currentCellMean;

        public Cell()
        {
            currentCellStatus = Status.Close;
            currentCellMean = Mean.Zero;
        }

        public Status GetStatus()
        {
            return currentCellStatus;
        }

        public Mean GetMean()
        {
            return currentCellMean;
        }

        public void SetMean(Mean mean)
        {
            currentCellMean = mean;
        }

        public void SetStatus(Status status)
        {
            currentCellStatus = status;
        }
    }
}

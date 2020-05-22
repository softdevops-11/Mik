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

        public Status CurrentCellStatus { get; set; }
        public Mean CurrentCellMean { get; set; }

        public Cell()
        {
            CurrentCellStatus = Cell.Status.Close;
            CurrentCellMean = Cell.Mean.Zero;
        }
    }
}

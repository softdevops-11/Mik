using System;

namespace Minesweeper.Logic
{
    class Field
    {
        public enum GameStatus
        {
            Play,
            Win,
            Lose
        }

        public int ColumsCount { get; }
        public int RowsCount { get; }
        public int MinesCount { get; }
        public Cell[,] Cells { get; }
        private GameStatus currentGameStatus;
        public bool firstTurn;

        public Field(int columsCount, int rowsCount, int minesCount)
        {
            MinesCount = minesCount;
            ColumsCount = columsCount;
            RowsCount = rowsCount;
            firstTurn = false;
            currentGameStatus = GameStatus.Play;

            Cells = new Cell[ColumsCount, RowsCount];

            for (int i = 0; i < ColumsCount; i++)
            {
                for (int j = 0; j < RowsCount; j++)
                {
                    Cells[i, j] = new Cell();
                }
            }

            Random randomNumber = new Random();

            for (int i = 0; i < MinesCount; i++)
            {
                int randomColum = randomNumber.Next(ColumsCount);
                int randomRow = randomNumber.Next(RowsCount);

                if (Cells[randomColum, randomRow].CurrentCellMean == Cell.Mean.Bomb)
                {
                    i--;
                }

                Cells[randomColum, randomRow].CurrentCellMean = Cell.Mean.Bomb;

            }

            for (int i = 0; i < ColumsCount; i++)
            {
                for (int j = 0; j < RowsCount; j++)
                {
                    if (Cells[i, j].CurrentCellMean == Cell.Mean.Bomb)
                    {
                        continue;
                    }

                    int nearbyMinesCount = 1;

                    for (int p = i - 1; p <= i + 1; p++)
                    {
                        for (int k = j - 1; k <= j + 1; k++)
                        {
                            if (p >= 0 && k >= 0 && p < ColumsCount && k < RowsCount && !(p == i && k == j) && Cells[p, k].CurrentCellMean == Cell.Mean.Bomb)
                            {
                                nearbyMinesCount++;
                            }
                        }
                    }

                    Cells[i, j].CurrentCellMean = (Cell.Mean)nearbyMinesCount;
                }
            }
        }

        private void OpenAllField()
        {
            foreach (Cell cell in Cells)
            {
                if (cell.CurrentCellStatus != Cell.Status.Open && cell.CurrentCellMean != Cell.Mean.Bomb)
                {
                    return;
                }
            }

            currentGameStatus = GameStatus.Win;
        }

        public void OpenCell(int columNumber, int rowNumber)
        {
            if (Cells[columNumber, rowNumber].CurrentCellStatus == Cell.Status.Close)
            {
                Cells[columNumber, rowNumber].CurrentCellStatus = Cell.Status.Open;

                if (Cells[columNumber, rowNumber].CurrentCellMean == Cell.Mean.Bomb)
                {
                    currentGameStatus = GameStatus.Lose;
                    return;
                }

                if (Cells[columNumber, rowNumber].CurrentCellMean == Cell.Mean.Zero)
                {
                    for (int i = 0; i < ColumsCount; i++)
                    {
                        for (int j = 0; j < RowsCount; j++)
                        {
                            if (Math.Abs(columNumber - i) <= 1 && Math.Abs(rowNumber - j) <= 1 && Cells[i, j].CurrentCellStatus == Cell.Status.Close)
                            {
                                OpenCell(i, j);
                            }
                        }
                    }
                }
            }

            OpenAllField();
        }

        public GameStatus GetStatusGame()
        {
            return currentGameStatus;
        }

        public void RebuildField()
        {
            firstTurn = false;
            currentGameStatus = Field.GameStatus.Play;

            for (int i = 0; i < ColumsCount; i++)
            {
                for (int j = 0; j < RowsCount; j++)
                {
                    Cells[i, j].CurrentCellStatus = Cell.Status.Close;
                    Cells[i, j].CurrentCellMean = Cell.Mean.Zero;
                }
            }

            Random randomNumber = new Random();

            for (int i = 0; i < MinesCount; i++)
            {
                int randomColum = randomNumber.Next(ColumsCount);
                int randomRow = randomNumber.Next(RowsCount);

                if (Cells[randomColum, randomRow].CurrentCellMean == Cell.Mean.Bomb)
                {
                    i--;
                }

                Cells[randomColum, randomRow].CurrentCellMean = Cell.Mean.Bomb;

            }

            for (int i = 0; i < ColumsCount; i++)
            {
                for (int j = 0; j < RowsCount; j++)
                {
                    if (Cells[i, j].CurrentCellMean == Cell.Mean.Bomb)
                    {
                        continue;
                    }

                    int nearbyMinesCount = 1;

                    for (int p = i - 1; p <= i + 1; p++)
                    {
                        for (int k = j - 1; k <= j + 1; k++)
                        {
                            if (p >= 0 && k >= 0 && p < ColumsCount && k < RowsCount && !(p == i && k == j) && Cells[p, k].CurrentCellMean == Cell.Mean.Bomb)
                            {
                                nearbyMinesCount++;
                            }
                        }
                    }

                    Cells[i, j].CurrentCellMean = (Cell.Mean)nearbyMinesCount;
                }
            }
        }
    }
}

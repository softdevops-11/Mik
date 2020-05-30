using System;

namespace Minesweeper.Logic
{
    class Field
    {
        private readonly int columnsCount;
        private readonly int rowsCount;
        private readonly int minesCount ;
        private readonly Cell[,] cells;
        private GameStatus currentGameStatus;
        private bool firstTurn;

        public Field(int columnsCount, int rowsCount, int minesCount)
        {
            this.minesCount = minesCount;
            this.columnsCount = columnsCount;
            this.rowsCount = rowsCount;
            firstTurn = false;
            currentGameStatus = GameStatus.Play;

            cells = new Cell[this.columnsCount, this.rowsCount];

            for (var i = 0; i < this.columnsCount; i++)
            {
                for (var j = 0; j < this.rowsCount; j++)
                {
                    cells[i, j] = new Cell();
                }
            }

            var randomNumber = new Random();

            for (var i = 0; i < this.minesCount; i++)
            {
                var randomColum = randomNumber.Next(this.columnsCount);
                var randomRow = randomNumber.Next(this.rowsCount);

                if (cells[randomColum, randomRow].GetMean() == Cell.Mean.Bomb)
                {
                    i--;
                }

                cells[randomColum, randomRow].SetMean(Cell.Mean.Bomb);
            }

            for (var i = 0; i < this.columnsCount; i++)
            {
                for (var j = 0; j < this.rowsCount; j++)
                {
                    if (cells[i, j].GetMean() == Cell.Mean.Bomb)
                    {
                        continue;
                    }

                    var nearbyMinesCount = 1;

                    for (var p = i - 1; p <= i + 1; p++)
                    {
                        for (var k = j - 1; k <= j + 1; k++)
                        {
                            if (p >= 0 && k >= 0 && p < this.columnsCount && k < this.rowsCount && !(p == i && k == j) && cells[p, k].GetMean() == Cell.Mean.Bomb)
                            {
                                nearbyMinesCount++;
                            }
                        }
                    }

                    cells[i, j].SetMean((Cell.Mean)nearbyMinesCount);
                }
            }
        }

        private void OpenAllField()
        {
            foreach (var cell in cells)
            {
                if (cell.GetStatus() != Cell.Status.Open && cell.GetMean() != Cell.Mean.Bomb)
                {
                    return;
                }
            }

            currentGameStatus = GameStatus.Win;
        }

        public void OpenCell(int columNumber, int rowNumber)
        {
            if (cells[columNumber, rowNumber].GetStatus() == Cell.Status.Close)
            {
                cells[columNumber, rowNumber].SetStatus(Cell.Status.Open);

                if (cells[columNumber, rowNumber].GetMean() == Cell.Mean.Bomb)
                {
                    currentGameStatus = GameStatus.Lose;
                    return;
                }

                if (cells[columNumber, rowNumber].GetMean() == Cell.Mean.Zero)
                {
                    for (var i = 0; i < columnsCount; i++)
                    {
                        for (var j = 0; j < rowsCount; j++)
                        {
                            if (Math.Abs(columNumber - i) <= 1 && Math.Abs(rowNumber - j) <= 1 && cells[i, j].GetStatus() == Cell.Status.Close)
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
            currentGameStatus = GameStatus.Play;

            for (var i = 0; i < columnsCount; i++)
            {
                for (var j = 0; j < rowsCount; j++)
                {
                    cells[i, j].SetStatus(Cell.Status.Close);
                    cells[i, j].SetMean(Cell.Mean.Zero);
                }
            }

            var randomNumber = new Random();

            for (var i = 0; i < minesCount; i++)
            {
                var randomColum = randomNumber.Next(columnsCount);
                var randomRow = randomNumber.Next(rowsCount);

                if (cells[randomColum, randomRow].GetMean() == Cell.Mean.Bomb)
                {
                    i--;
                }

                cells[randomColum, randomRow].SetMean(Cell.Mean.Bomb);
            }

            for (var i = 0; i < columnsCount; i++)
            {
                for (var j = 0; j < rowsCount; j++)
                {
                    if (cells[i, j].GetMean() == Cell.Mean.Bomb)
                    {
                        continue;
                    }

                    var nearbyMinesCount = 1;

                    for (var p = i - 1; p <= i + 1; p++)
                    {
                        for (var k = j - 1; k <= j + 1; k++)
                        {
                            if (p >= 0 && k >= 0 && p < columnsCount && k < rowsCount && !(p == i && k == j) && cells[p, k].GetMean() == Cell.Mean.Bomb)
                            {
                                nearbyMinesCount++;
                            }
                        }
                    }

                    cells[i, j].SetMean((Cell.Mean)nearbyMinesCount);
                }
            }
        }

        public int GetColumnsCount()
        {
            return columnsCount;
        }

        public int GetRowsCount()
        {
            return rowsCount;
        }

        public int GetMinesCount()
        {
            return minesCount;
        }

        public bool GetFirstTurn()
        {
            return firstTurn;
        }

        public void SetFirstTurn(bool isTurn)
        {
            firstTurn= isTurn;
        }

        public Cell GetCell(int i,int j)
        {
            return cells[i,j];
        }
    }
}

using System;

namespace Minesweeper.Logic
{
    internal class Field
    {
        public int ColumnsCount { get; }
        public int RowsCount { get; }
        public int MinesCount { get; }
        public int[,] Cells { get; }
        private int statusGame;

        public Field(int columsCount, int rowsCount, int minesCount)
        {
            MinesCount = minesCount;
            ColumnsCount = columsCount;
            RowsCount = rowsCount;

            Cells = new int[ColumnsCount, RowsCount];

            for (int i = 0; i < ColumnsCount; i++)
            {
                for (int j = 0; j < RowsCount; j++)
                {
                    Cells[i, j] = 1;
                }
            }

            Random randomNumber = new Random();

            for (int i = 0; i < MinesCount; i++)
            {
                int randomNumberColum = randomNumber.Next(ColumnsCount);
                int randomNumberRow = randomNumber.Next(RowsCount);

                if (Cells[randomNumberColum, randomNumberRow] == 0)
                {
                    i--;
                }

                Cells[randomNumberColum, randomNumberRow] = 0;

            }

            for (int i = 0; i < ColumnsCount; i++)
            {
                for (int j = 0; j < RowsCount; j++)
                {
                    if (Cells[i, j] != 0)
                    {
                        int countNeabyMine = 1;

                        if (i - 1 >= 0 && Cells[i - 1, j] == 0)
                        {
                            countNeabyMine++;
                        }

                        if (i + 1 < ColumnsCount && Cells[i + 1, j] == 0)
                        {
                            countNeabyMine++;
                        }

                        if (j - 1 >= 0 && Cells[i, j - 1] == 0)
                        {
                            countNeabyMine++;
                        }

                        if (j + 1 < RowsCount && Cells[i, j + 1] == 0)
                        {
                            countNeabyMine++;
                        }

                        if (i - 1 >= 0 && j - 1 >= 0 && Cells[i - 1, j - 1] == 0)
                        {
                            countNeabyMine++;
                        }

                        if (i + 1 < ColumnsCount && j - 1 >= 0 && Cells[i + 1, j - 1] == 0)
                        {
                            countNeabyMine++;
                        }

                        if (i - 1 >= 0 && j + 1 < RowsCount && Cells[i - 1, j + 1] == 0)
                        {
                            countNeabyMine++;
                        }

                        if (i + 1 < ColumnsCount && j + 1 < RowsCount && Cells[i + 1, j + 1] == 0)
                        {
                            countNeabyMine++;
                        }

                        Cells[i, j] = countNeabyMine;
                    }
                }
            }
        }

        private void OpenAllField()
        {
            foreach (int cell in Cells)
            {
                if (cell > 0)
                {
                    return;
                }
            }

            statusGame = 2;
        }

        public void OpenCell(int columNumber, int rowNumber)
        {
            if (Cells[columNumber, rowNumber] == 0)
            {
                statusGame = 1;
                return;
            }

            if (Cells[columNumber, rowNumber] > 0)
            {
                Cells[columNumber, rowNumber] = -Cells[columNumber, rowNumber];

                if (Cells[columNumber, rowNumber] == -1)
                {
                    for (int i = 0; i < ColumnsCount; i++)
                    {
                        for (int j = 0; j < RowsCount; j++)
                        {
                            if (Math.Abs(columNumber - i) <= 1 && Math.Abs(rowNumber - j) <= 1 && Cells[i, j] > 0)
                            {
                                OpenCell(i, j);
                            }
                        }
                    }
                }
            }

            OpenAllField();
        }

        public int GetStatusGame()
        {
            return statusGame;
        }
    }
}

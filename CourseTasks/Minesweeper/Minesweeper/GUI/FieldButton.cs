using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Minesweeper.Logic;

namespace Minesweeper.GUI
{
    class FieldButton : Button
    {
        private readonly int i;
        private readonly int j;
        private Field field;
        private TableLayoutPanel table;
        private static readonly Dictionary<Cell.Mean, Bitmap> dictionary = new Dictionary<Cell.Mean, Bitmap>()
        {
            { Cell.Mean.Bomb, Properties.Resources.bomb},
            { Cell.Mean.Zero, Properties.Resources.zero},
            { Cell.Mean.OneBomb, Properties.Resources.num1},
            { Cell.Mean.TwoBomb, Properties.Resources.num2},
            { Cell.Mean.ThreeBomb, Properties.Resources.num3},
            { Cell.Mean.FourBomb, Properties.Resources.num4},
            { Cell.Mean.FiveBomb, Properties.Resources.num5},
            { Cell.Mean.SixBomb, Properties.Resources.num6},
            { Cell.Mean.SevenBomb, Properties.Resources.num7},
            { Cell.Mean.EightBomb, Properties.Resources.num8},
        };

        public FieldButton(TableLayoutPanel table, Field field, int i, int j)
        {
            this.table = table;
            this.field = field;
            this.i = i;
            this.j = j;
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            MinesweeperForm.GetTimer().Enabled = true;
            if (MinesweeperForm.GetTimer().Enabled)
            {
                MinesweeperForm.GetTimer().Start();
            }

            if (e.Button == MouseButtons.Right)
            {
                if (field.GetCell(i, j).GetStatus() == Cell.Status.Flaged)
                {
                    field.GetCell(i, j).SetStatus(Cell.Status.Close);
                    BackgroundImage = Properties.Resources.closed;
                }
                else if (field.GetCell(i, j).GetStatus() == Cell.Status.Close)
                {
                    field.GetCell(i, j).SetStatus(Cell.Status.Flaged);
                    BackgroundImage = Properties.Resources.flaged;
                }
            }
            else
            {
                if (field.GetCell(i, j).GetStatus() == Cell.Status.Open)
                {
                    var countFlagedCells = 0;

                    for (var p = i - 1; p <= i + 1; p++)
                    {
                        for (var k = j - 1; k <= j + 1; k++)
                        {
                            if (p >= 0 && k >= 0 && p < field.GetColumnsCount() && k < field.GetRowsCount() && !(p == i && k == j) && field.GetCell(p, k).GetStatus() == Cell.Status.Flaged)
                            {
                                countFlagedCells++;
                            }
                        }
                    }

                    if ((int)field.GetCell(i, j).GetMean() - 1 == countFlagedCells)
                    {
                        for (var p = i - 1; p <= i + 1; p++)
                        {
                            for (var k = j - 1; k <= j + 1; k++)
                            {
                                if (p >= 0 && k >= 0 && p < field.GetColumnsCount() && k < field.GetRowsCount() && !(p == i && k == j) && field.GetCell(p, k).GetStatus() == Cell.Status.Close)
                                {
                                    field.OpenCell(p, k);
                                }
                            }
                        }

                        var m = 0;
                        var n = 0;

                        foreach (FieldButton b in table.Controls)
                        {
                            if (b.field.GetCell(m, n).GetStatus() == Cell.Status.Open)
                            {
                                b.BackgroundImage = dictionary[b.field.GetCell(m, n).GetMean()];
                            }

                            n++;

                            if (n >= field.GetRowsCount())
                            {
                                m++;
                                n = 0;
                            }
                        }
                    }
                }
                else if (field.GetCell(i, j).GetStatus() == Cell.Status.Close)
                {
                    field.OpenCell(i, j);

                    if (field.GetCell(i, j).GetStatus() == Cell.Status.Open)
                    {
                        if (field.GetCell(i, j).GetMean() == Cell.Mean.Zero)
                        {
                            var p = 0;
                            var k = 0;

                            foreach (FieldButton b in table.Controls)
                            {
                                if (b.field.GetCell(p, k).GetStatus() == Cell.Status.Open)
                                {
                                    b.BackgroundImage = dictionary[b.field.GetCell(p, k).GetMean()];
                                }

                                k++;

                                if (k >= field.GetRowsCount())
                                {
                                    p++;
                                    k = 0;
                                }
                            }
                        }
                        else
                        {
                            BackgroundImage = dictionary[field.GetCell(i, j).GetMean()];
                        }
                    }
                }

                if (field.GetStatusGame() == GameStatus.Lose)
                {
                    if (!field.GetFirstTurn())
                    {
                        field.RebuildField();
                        OnMouseDown(e);
                    }
                    else
                    {
                        if (field.GetCell(i, j).GetMean() == Cell.Mean.Bomb)
                        {
                            BackgroundImage = Properties.Resources.bombed;
                        }

                        foreach (FieldButton b in table.Controls)
                        {
                            b.Enabled = false;
                        }

                        MinesweeperForm.GetTimer().Stop();
                        MinesweeperForm.GetTimer().Enabled = false;
                        MessageBox.Show("Вы проиграли.", "Поражение");
                    }
                }
                else if (field.GetStatusGame() == GameStatus.Win)
                {
                    foreach (FieldButton b in table.Controls)
                    {
                        b.Enabled = false;
                    }

                    MinesweeperForm.GetTimer().Stop();
                    MinesweeperForm.GetTimer().Enabled = false;
                    MinesweeperForm.GetHighScores().Add(new HighScores(MinesweeperForm.GetStartTime(), MinesweeperForm.GetDate()));
                    MessageBox.Show("Вы выиграли!", "Победа");
                }

                if (!field.GetFirstTurn())
                {
                    field.SetFirstTurn(true);
                }
            }
        }
    }
}

using System.Windows.Forms;
using System.Drawing;
using Minesweeper.Logic;

namespace Minesweeper.GUI
{
    class FieldButton : Button
    {
        public int i;
        public int j;
        public Field field;
        public TableLayoutPanel table;

        public FieldButton(TableLayoutPanel table, Field field, int i, int j)
        {
            this.table = table;
            this.field = field;
            this.i = i;
            this.j = j;
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            MinesweeperForm.timer.Enabled = true;
            if (MinesweeperForm.timer.Enabled)
            {
                MinesweeperForm.timer.Start();
            }

            if (e.Button == MouseButtons.Right)
            {
                if (field.Cells[i, j].CurrentCellStatus == Cell.Status.Flaged)
                {
                    field.Cells[i, j].CurrentCellStatus = Cell.Status.Close;
                    BackgroundImage = Properties.Resources.closed;
                }
                else if (field.Cells[i, j].CurrentCellStatus == Cell.Status.Close)
                {
                    field.Cells[i, j].CurrentCellStatus = Cell.Status.Flaged;
                    BackgroundImage = Properties.Resources.flaged;
                }
            }
            else
            {
                field.OpenCell(i, j);

                if (field.Cells[i, j].CurrentCellStatus == Cell.Status.Open)
                {
                    if (field.Cells[i, j].CurrentCellMean == Cell.Mean.Zero)
                    {
                        int p = 0;
                        int k = 0;

                        foreach (FieldButton b in table.Controls)
                        {
                            if (b.field.Cells[p, k].CurrentCellMean == Cell.Mean.Zero && b.field.Cells[p, k].CurrentCellStatus == Cell.Status.Open)
                            {
                                b.BackgroundImage = Properties.Resources.zero;
                            }
                            else if (b.field.Cells[p, k].CurrentCellMean == Cell.Mean.OneBomb && b.field.Cells[p, k].CurrentCellStatus == Cell.Status.Open)
                            {
                                b.BackgroundImage = Properties.Resources.num1;
                            }
                            else if (b.field.Cells[p, k].CurrentCellMean == Cell.Mean.TwoBomb && b.field.Cells[p, k].CurrentCellStatus == Cell.Status.Open)
                            {
                                b.BackgroundImage = Properties.Resources.num2;
                            }
                            else if (b.field.Cells[p, k].CurrentCellMean == Cell.Mean.ThreeBomb && b.field.Cells[p, k].CurrentCellStatus == Cell.Status.Open)
                            {
                                b.BackgroundImage = Properties.Resources.num3;
                            }
                            else if (b.field.Cells[p, k].CurrentCellMean == Cell.Mean.FourBomb && b.field.Cells[p, k].CurrentCellStatus == Cell.Status.Open)
                            {
                                b.BackgroundImage = Properties.Resources.num4;
                            }
                            else if (b.field.Cells[p, k].CurrentCellMean == Cell.Mean.FiveBomb && b.field.Cells[p, k].CurrentCellStatus == Cell.Status.Open)
                            {
                                b.BackgroundImage = Properties.Resources.num5;
                            }
                            else if (b.field.Cells[p, k].CurrentCellMean == Cell.Mean.SixBomb && b.field.Cells[p, k].CurrentCellStatus == Cell.Status.Open)
                            {
                                b.BackgroundImage = Properties.Resources.num6;
                            }
                            else if (b.field.Cells[p, k].CurrentCellMean == Cell.Mean.SevenBomb && b.field.Cells[p, k].CurrentCellStatus == Cell.Status.Open)
                            {
                                b.BackgroundImage = Properties.Resources.num7;
                            }
                            else if (b.field.Cells[p, k].CurrentCellMean == Cell.Mean.EightBomb && b.field.Cells[p, k].CurrentCellStatus == Cell.Status.Open)
                            {
                                b.BackgroundImage = Properties.Resources.num8;
                            }

                            k++;

                            if (k >= field.RowsCount)
                            {
                                p++;
                                k = 0;
                            }
                        }
                    }
                    else if (field.Cells[i, j].CurrentCellMean == Cell.Mean.OneBomb)
                    {
                        BackgroundImage = Properties.Resources.num1;
                    }
                    else if (field.Cells[i, j].CurrentCellMean == Cell.Mean.TwoBomb)
                    {
                        BackgroundImage = Properties.Resources.num2;
                    }
                    else if (field.Cells[i, j].CurrentCellMean == Cell.Mean.ThreeBomb)
                    {
                        BackgroundImage = Properties.Resources.num3;
                    }
                    else if (field.Cells[i, j].CurrentCellMean == Cell.Mean.FourBomb)
                    {
                        BackgroundImage = Properties.Resources.num4;
                    }
                    else if (field.Cells[i, j].CurrentCellMean == Cell.Mean.FiveBomb)
                    {
                        BackgroundImage = Properties.Resources.num5;
                    }
                    else if (field.Cells[i, j].CurrentCellMean == Cell.Mean.SixBomb)
                    {
                        BackgroundImage = Properties.Resources.num6;
                    }
                    else if (field.Cells[i, j].CurrentCellMean == Cell.Mean.SevenBomb)
                    {
                        BackgroundImage = Properties.Resources.num7;
                    }
                    else if (field.Cells[i, j].CurrentCellMean == Cell.Mean.EightBomb)
                    {
                        BackgroundImage = Properties.Resources.num8;
                    }
                }

                if (field.GetStatusGame() == Field.GameStatus.Lose)
                {
                    if (field.firstTurn == false)
                    {
                        field.RebuildField();
                        OnMouseDown(e);
                    }
                    else
                    {
                        if (field.Cells[i, j].CurrentCellMean == Cell.Mean.Bomb)
                        {
                            BackgroundImage = Properties.Resources.bombed;
                        }

                        foreach (FieldButton b in table.Controls)
                        {
                            b.Enabled = false;
                        }

                        MinesweeperForm.timer.Stop();
                        MinesweeperForm.timer.Enabled = false;
                        MessageBox.Show("Вы проиграли.", "Поражение");
                    }
                }
                else if (field.GetStatusGame() == Field.GameStatus.Win)
                {
                    foreach (FieldButton b in table.Controls)
                    {
                        b.Enabled = false;
                    }

                    MinesweeperForm.timer.Stop();
                    MinesweeperForm.timer.Enabled = false;
                    MinesweeperForm.hs.Add(new HighScores(MinesweeperForm.startTime, MinesweeperForm.date));
                    MessageBox.Show("Вы выиграли!", "Победа");
                }

                if (field.firstTurn == false)
                {
                    field.firstTurn = true;
                }
            }
        }
    }
}

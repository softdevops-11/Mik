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
                if (field.Cells[i, j] >= 0)
                {
                    BackgroundImage = ((Image)(Properties.Resources.flaged));
                }
            }
            else
            {
                field.OpenCell(i, j);

                if (field.Cells[i, j] < 0)
                {
                    if (field.Cells[i, j] == -1)
                    {
                        int p = 0;
                        int k = 0;

                        foreach (object o in table.Controls)
                        {
                            if ((o as FieldButton).field.Cells[p, k] == -1)
                            {
                                (o as FieldButton).BackgroundImage = ((Image)(Properties.Resources.zero));
                            }

                            if ((o as FieldButton).field.Cells[p, k] == -2)
                            {
                                (o as FieldButton).BackgroundImage = ((Image)(Properties.Resources.num1));
                            }

                            if ((o as FieldButton).field.Cells[p, k] == -3)
                            {
                                (o as FieldButton).BackgroundImage = ((Image)(Properties.Resources.num2));
                            }
                            if ((o as FieldButton).field.Cells[p, k] == -4)
                            {
                                (o as FieldButton).BackgroundImage = ((Image)(Properties.Resources.num3));
                            }

                            if ((o as FieldButton).field.Cells[p, k] == -5)
                            {
                                (o as FieldButton).BackgroundImage = ((Image)(Properties.Resources.num4));
                            }
                            if ((o as FieldButton).field.Cells[p, k] == -6)
                            {
                                (o as FieldButton).BackgroundImage = ((Image)(Properties.Resources.num5));
                            }

                            if ((o as FieldButton).field.Cells[p, k] == -7)
                            {
                                (o as FieldButton).BackgroundImage = ((Image)(Properties.Resources.num6));
                            }
                            if ((o as FieldButton).field.Cells[p, k] == -8)
                            {
                                (o as FieldButton).BackgroundImage = ((Image)(Properties.Resources.num7));
                            }

                            if ((o as FieldButton).field.Cells[p, k] == -9)
                            {
                                (o as FieldButton).BackgroundImage = ((Image)(Properties.Resources.num8));
                            }

                            k++;

                            if (k >= field.RowsCount)
                            {
                                p++;
                                k = 0;
                            }
                        }
                    }
                    if (field.Cells[i, j] == -2)
                    {
                        BackgroundImage = ((Image)(Properties.Resources.num1));
                    }
                    if (field.Cells[i, j] == -3)
                    {
                        BackgroundImage = ((Image)(Properties.Resources.num2));
                    }
                    if (field.Cells[i, j] == -4)
                    {
                        BackgroundImage = ((Image)(Properties.Resources.num3));
                    }
                    if (field.Cells[i, j] == -5)
                    {
                        BackgroundImage = ((Image)(Properties.Resources.num4));
                    }
                    if (field.Cells[i, j] == -6)
                    {
                        BackgroundImage = ((Image)(Properties.Resources.num5));
                    }
                    if (field.Cells[i, j] == -7)
                    {
                        BackgroundImage = ((Image)(Properties.Resources.num6));
                    }
                    if (field.Cells[i, j] == -8)
                    {
                        BackgroundImage = ((Image)(Properties.Resources.num7));
                    }
                    if (field.Cells[i, j] == -9)
                    {
                        BackgroundImage = ((Image)(Properties.Resources.num8));
                    }
                }

                if (field.GetStatusGame() == 1)
                {
                    if (field.Cells[i, j] == 0)
                    {
                        BackgroundImage = ((Image)(Properties.Resources.bombed));
                    }

                    foreach (object o in table.Controls)
                    {
                        (o as FieldButton).Enabled = false;
                    }

                    MinesweeperForm.timer.Stop();
                    MinesweeperForm.timer.Enabled = false;
                    MessageBox.Show("Вы проиграли.");
                }

                if (field.GetStatusGame() == 2)
                {
                    foreach (object o in table.Controls)
                    {
                        (o as FieldButton).Enabled = false;
                    }

                    MinesweeperForm.timer.Stop();
                    MinesweeperForm.timer.Enabled = false;
                    MinesweeperForm.hs.Add(new HightScores(MinesweeperForm.startTime, MinesweeperForm.date));
                    MessageBox.Show("Вы выиграли!");
                }
            }
        }
    }
}

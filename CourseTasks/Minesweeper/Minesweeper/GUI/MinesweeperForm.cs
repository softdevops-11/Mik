using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Minesweeper.Logic;


namespace Minesweeper.GUI
{
    public partial class MinesweeperForm : Form
    {
        private HightScoresForm hightScoresForm;
        public static List<HightScores> hs = new List<HightScores>();
        public int columsCount = 9;
        public int rowsCount = 9;
        public int minesCount = 10;
        public TableLayoutPanel table;
        private Field field;
        public static Timer timer;
        public static int startTime;
        public static string date;


        public MinesweeperForm()
        {
            InitializeComponent();
            timer = new Timer();
            timer.Tick += new EventHandler(Timer_Tick);
            timer.Interval = 1000;
            NewGames();
        }

        public void NewGames()
        {
            MinesweeperForm.timer.Stop();
            MinesweeperForm.timer.Enabled = false;
            labelTime.Text = string.Format("Время:");
            startTime = 0;
            field = new Field(columsCount, rowsCount, minesCount);
            table = new TableLayoutPanel
            {
                Parent = this,
                Location = new Point(0, 27),
                Size = new Size(20 * field.ColumnsCount, 20 * field.RowsCount),
                ColumnCount = field.ColumnsCount,
                RowCount = field.RowsCount,
                Margin = new Padding(1)
            };

            for (int i = 0; i < field.ColumnsCount; ++i)
            {
                for (int j = 0; j < field.RowsCount; ++j)
                {
                    FieldButton button = new FieldButton(table, field, i, j)
                    {
                        Margin = new Padding(1),
                        Width = 18,
                        Height = 18,
                        Location = new Point(j * 20, i * 20),
                        FlatStyle = FlatStyle.Flat,
                        BackgroundImage = ((Image)(Properties.Resources.closed)),
                        BackgroundImageLayout = ImageLayout.Zoom,
                        ForeColor = SystemColors.Control
                    };
                    table.Controls.Add(button, i, j);
                }
            }

            Size = new Size(20 * field.ColumnsCount + 17, 20 * field.RowsCount + 85);
            labelTime.Location = new Point(1, Height - 55);
        }

        private void About_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Игра сапер.", "О программе");
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Options_Click(object sender, EventArgs e)
        {
            OptionsForm optionsForm = new OptionsForm(this);
            optionsForm.Show();
        }

        private void NewGame_Click(object sender, EventArgs e)
        {
            table.Parent = null;
            NewGames();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            startTime++;
            date = DateTime.Now.ToString("HH:mm:ss");
            labelTime.Text = string.Format("Время:{0}  Текущее время:{1}", startTime, DateTime.Now.ToString("HH:mm:ss"));
        }

        private void HightScores_Click(object sender, EventArgs e)
        {
            hightScoresForm = new HightScoresForm(this);
            hs.Sort(new HighScoreComparer());

            foreach (HightScores h in hs)
            {
                hightScoresForm.hightScoresBox.Items.Add(h);
            }

            hightScoresForm.Show();
        }
    }
}

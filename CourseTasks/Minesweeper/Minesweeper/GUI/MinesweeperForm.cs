using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Minesweeper.Logic;


namespace Minesweeper.GUI
{
    public partial class MinesweeperForm : Form
    {
        private HighScoresForm highScoresForm;
        public static List<HighScores> hs = new List<HighScores>();
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
                Size = new Size(25 * field.ColumsCount, 25 * field.RowsCount),
                ColumnCount = field.ColumsCount,
                RowCount = field.RowsCount,
                Margin = new Padding(1)
            };

            for (int i = 0; i < field.ColumsCount; ++i)
            {
                for (int j = 0; j < field.RowsCount; ++j)
                {
                    FieldButton button = new FieldButton(table, field, i, j)
                    {
                        Margin = new Padding(1),
                        Width = 23,
                        Height = 23,
                        Location = new Point(j * 25, i * 25),
                        FlatStyle = FlatStyle.Flat,
                        BackgroundImage = Properties.Resources.closed,
                        BackgroundImageLayout = ImageLayout.Zoom,
                        ForeColor = SystemColors.Control
                    };
                    table.Controls.Add(button, i, j);
                }
            }

            Size = new Size(25 * field.ColumsCount + 17, 25 * field.RowsCount + 85);
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
            optionsForm.ShowDialog();
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

        private void HighScores_Click(object sender, EventArgs e)
        {
            highScoresForm = new HighScoresForm(this);
            hs.Sort(new HighScoreComparer());

            foreach (HighScores h in hs)
            {
                highScoresForm.highScoresBox.Items.Add(h);
            }

            highScoresForm.ShowDialog();
        }
    }
}

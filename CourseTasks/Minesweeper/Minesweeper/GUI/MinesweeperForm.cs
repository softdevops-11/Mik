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
        private static List<HighScores> highScores = new List<HighScores>();
        private int columnsCount = 9;
        private int rowsCount = 9;
        private int minesCount = 10;
        private TableLayoutPanel table;
        private Field field;
        private static Timer timer;
        private static int startTime;
        private static string date;

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
            timer.Stop();
            timer.Enabled = false;
            labelTime.Text = string.Format("Время:");
            startTime = 0;
            field = new Field(columnsCount, rowsCount, minesCount);
            table = new TableLayoutPanel
            {
                Parent = this,
                Location = new Point(0, 27),
                Size = new Size(25 * field.GetColumnsCount(), 25 * field.GetRowsCount()),
                ColumnCount = field.GetColumnsCount(),
                RowCount = field.GetRowsCount(),
                Margin = new Padding(1)
            };

            for (var i = 0; i < field.GetColumnsCount(); ++i)
            {
                for (var j = 0; j < field.GetRowsCount(); ++j)
                {
                    var button = new FieldButton(table, field, i, j)
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

            Size = new Size(25 * field.GetColumnsCount() + 17, 25 * field.GetRowsCount() + 85);
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
            highScores.Sort(new HighScoreComparer());

            foreach (var h in highScores)
            {
                highScoresForm.highScoresBox.Items.Add(h);
            }

            highScoresForm.ShowDialog();
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

        public void SetColumnsCount(int columnsCount)
        {
            this.columnsCount= columnsCount;
        }

        public void SetRowsCount(int rowsCount)
        {
            this.rowsCount = rowsCount;
        }

        public void SetMinesCount(int minesCount)
        {
            this.minesCount = minesCount;
        }

        public static Timer GetTimer()
        {
            return timer;
        }

        public static string GetDate()
        {
            return date;
        }

        public static int GetStartTime()
        {
            return startTime;
        }

        public TableLayoutPanel GetTable()
        {
            return table;
        }

        public static List<HighScores> GetHighScores()
        {
            return highScores;
        }
    }
}

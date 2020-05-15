using System;
using System.Windows.Forms;

namespace Minesweeper.GUI
{
    public partial class OptionsForm : Form
    {
        MinesweeperForm minesweeper;

        public OptionsForm()
        {
            InitializeComponent();
        }

        public OptionsForm(MinesweeperForm minesweeper)
        {
            InitializeComponent();
            this.minesweeper = minesweeper;
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            bool notError = true;

            bool isNumber = int.TryParse(textBoxColums.Text, out int columsCount);

            if (isNumber)
            {
                minesweeper.columsCount = columsCount;
            }
            else
            {
                MessageBox.Show("Преобразование невозможно. Введено не число.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                notError = false;
            }

            isNumber = int.TryParse(textBoxRows.Text, out int rowsCount);

            if (isNumber)
            {
                minesweeper.rowsCount = rowsCount;
            }
            else
            {
                MessageBox.Show("Преобразование невозможно. Введено не число.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                notError = false;
            }

            isNumber = int.TryParse(textBoxMines.Text, out int minesCount);

            if (isNumber)
            {
                minesweeper.minesCount = minesCount;
            }
            else
            {
                MessageBox.Show("Преобразование невозможно. Введено не число.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                notError = false;
            }

            if (notError)
            {
                minesweeper.table.Parent = null;
                minesweeper.NewGames();
                Close();
            }
        }
    }
}

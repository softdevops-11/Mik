using System;
using System.Windows.Forms;

namespace Minesweeper.GUI
{
    public partial class OptionsForm : Form
    {
        private double percentPossibleMinesCount = 0.3;
        private int minColumsCount = 9;
        private int maxColumsCount = 30;
        private int minRowsCount = 9;
        private int maxRowsCount = 30;
        private int minMinesCount = 0;
        private int maxMinesCount = 99;
        private MinesweeperForm minesweeper;

        public OptionsForm()
        {
            InitializeComponent();
        }

        public OptionsForm(MinesweeperForm minesweeper)
        {
            InitializeComponent();
            this.minesweeper = minesweeper;
        }

        private void ButtonOk_Click(object sender, EventArgs e)
        {
            bool notError = true;

            bool isNumber = int.TryParse(textBoxColums.Text, out var columsCount);

            if (isNumber)
            {
                if (columsCount < minColumsCount || columsCount > maxColumsCount)
                {
                    MessageBox.Show("Неверный размер поля", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    notError = false;
                }
                else
                {
                    minesweeper.SetColumnsCount(columsCount);
                }
            }
            else
            {
                MessageBox.Show("Преобразование невозможно. Введено не число.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                notError = false;
            }

            isNumber = int.TryParse(textBoxRows.Text, out var rowsCount);

            if (isNumber)
            {
                if ((rowsCount < minRowsCount || rowsCount > maxRowsCount) && notError)
                {
                    MessageBox.Show("Неверный размер поля", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    notError = false;
                }
                else
                {
                    minesweeper.SetRowsCount(rowsCount);
                }
            }
            else
            {
                MessageBox.Show("Преобразование невозможно. Введено не число.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                notError = false;
            }

            isNumber = int.TryParse(textBoxMines.Text, out var minesCount);

            if (isNumber)
            {
                if ((minesCount < minMinesCount || minesCount > maxMinesCount || minesCount > (int)(rowsCount * columsCount * percentPossibleMinesCount)) && notError)
                {
                    MessageBox.Show("Слишком большое количество мин или не в пределах интервала", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    notError = false;
                }
                else
                {
                    minesweeper.SetMinesCount(minesCount);
                }
            }
            else
            {
                MessageBox.Show("Преобразование невозможно. Введено не число.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                notError = false;
            }

            if (notError)
            {
                minesweeper.GetTable().Parent = null;
                minesweeper.NewGames();
                Close();
            }
        }
    }
}

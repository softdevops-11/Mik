using System.Windows.Forms;

namespace Minesweeper.GUI
{
    public partial class HighScoresForm : Form
    {
        MinesweeperForm minesweeper;

        public HighScoresForm()
        {
            InitializeComponent();
        }

        public HighScoresForm(MinesweeperForm minesweeper)
        {
            InitializeComponent();
            this.minesweeper = minesweeper;
        }
    }
}

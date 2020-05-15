using System.Windows.Forms;

namespace Minesweeper.GUI
{
    public partial class HightScoresForm : Form
    {
        MinesweeperForm minesweeper;

        public HightScoresForm()
        {
            InitializeComponent();
        }

        public HightScoresForm(MinesweeperForm minesweeper)
        {
            InitializeComponent();
            this.minesweeper = minesweeper;
        }
    }
}

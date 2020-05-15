using System;
using System.Windows.Forms;
using Minesweeper.GUI;

namespace Minesweeper
{
    static class MinesweeperProgram
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MinesweeperForm());
        }
    }
}

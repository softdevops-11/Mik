using System;
using System.Windows.Forms;

namespace Temperature
{
    static class TemperatureProgram
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new TemperatureForm());
        }
    }
}

using System;
using System.Windows.Forms;

namespace Temperature
{
    internal static class TemperatureProgram
    {
        public static double ConvertToKelvin(double initialTemperature, int index)
        {
            switch (index)
            {
                case 0:
                    return initialTemperature + 273.15;
                case 1:
                    return initialTemperature;
                case 2:
                    return (initialTemperature - 32) * 5 / 9 + 273.15;
            }

            return 0;
        }

        public static double ConvertToFahrenheit(double initialTemperature, int index)
        {
            switch (index)
            {
                case 0:
                    return (initialTemperature * 9 / 5) + 32;
                case 1:
                    return (initialTemperature - 273.15) * 9 / 5 + 32;
                case 2:
                    return initialTemperature;
            }

            return 0;
        }

        public static double ConvertToCelsius(double initialTemperature, int index)
        {
            switch (index)
            {
                case 0:
                    return initialTemperature;
                case 1:
                    return initialTemperature - 273.15;
                case 2:
                    return (initialTemperature - 32) * 5 / 9;
            }

            return 0;
        }

        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new TemperatureForm());
        }
    }
}

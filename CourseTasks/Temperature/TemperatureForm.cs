using System;
using System.Windows.Forms;

namespace Temperature
{
    public partial class TemperatureForm : Form
    {
        public TemperatureForm()
        {
            InitializeComponent();
        }

        private void TemperatureForm_Load(object sender, EventArgs e)
        {
            inputComboBox.SelectedIndex = 0;
            outputComboBox.SelectedIndex = 0;
        }

        private void convertButton_Click(object sender, EventArgs e)
        {
            double number;
            bool isNumber = double.TryParse(inputTextBox.Text, out number);

            if (isNumber)
            {
                switch (outputComboBox.SelectedIndex)
                {
                    case 0:
                        outputTextBox.Text = Convert.ToString(TemperatureProgram.ConvertToCelsius(number, inputComboBox.SelectedIndex));
                        break;
                    case 1:
                        outputTextBox.Text = Convert.ToString(TemperatureProgram.ConvertToKelvin(number, inputComboBox.SelectedIndex));
                        break;
                    case 2:
                        outputTextBox.Text = Convert.ToString(TemperatureProgram.ConvertToFahrenheit(number, inputComboBox.SelectedIndex));
                        break;
                }
            }
            else
            {
                MessageBox.Show("Преобразование невозможно. Введено не число.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

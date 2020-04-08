using System;
using System.Windows.Forms;
using Temperature.ConversationScales;

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
            bool isNumber = double.TryParse(inputTextBox.Text, out double temperature);

            if (isNumber)
            {
                double temperatureInCelsius = 0;

                switch (inputComboBox.SelectedIndex)
                {
                    case 0:
                        temperatureInCelsius = new CelsiusScales().GetConversationToCelsius(temperature);
                        break;
                    case 1:
                        temperatureInCelsius = new KelvinScales().GetConversationToCelsius(temperature);
                        break;
                    case 2:
                        temperatureInCelsius = new FahrenheitScales().GetConversationToCelsius(temperature);
                        break;
                }

                switch (outputComboBox.SelectedIndex)
                {
                    case 0:
                        outputTextBox.Text = Convert.ToString(new CelsiusScales().GetConversationToScale(temperatureInCelsius));
                        break;
                    case 1:
                        outputTextBox.Text = Convert.ToString(new KelvinScales().GetConversationToScale(temperatureInCelsius));
                        break;
                    case 2:
                        outputTextBox.Text = Convert.ToString(new FahrenheitScales().GetConversationToScale(temperatureInCelsius));
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

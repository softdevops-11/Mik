using System;
using System.Windows.Forms;
using System.Collections.Generic;
using Temperature.ConversionScales;

namespace Temperature
{
    public partial class TemperatureForm : Form
    {
        private List<IScale> scaleList = new List<IScale> { new CelsiusScale(), new KelvinScale(), new FahrenheitScale() };

        public TemperatureForm()
        {
            InitializeComponent();

            foreach (IScale o in scaleList)
            {
                outputComboBox.Items.Add(o.Name);
                inputComboBox.Items.Add(o.Name);
            }
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
                double temperatureInCelsius = scaleList[inputComboBox.SelectedIndex].ConvertToCelsius(temperature);
                outputTextBox.Text = Convert.ToString(scaleList[outputComboBox.SelectedIndex].ConvertToScale(temperatureInCelsius));
            }
            else
            {
                MessageBox.Show("Преобразование невозможно. Введено не число.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

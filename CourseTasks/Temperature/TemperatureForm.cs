using System;
using System.Collections;
using System.Windows.Forms;
using System.Collections.Generic;
using Temperature.ConversionScales;

namespace Temperature
{
    public partial class TemperatureForm : Form
    {
        public List<IScale> scaleList = new List<IScale>() { new CelsiusScales(), new KelvinScales(), new FahrenheitScales() };

        public TemperatureForm()
        {
            InitializeComponent();

            foreach (IScale o in scaleList)
            {
                outputComboBox.Items.Add(o.NameScale);
                inputComboBox.Items.Add(o.NameScale);
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

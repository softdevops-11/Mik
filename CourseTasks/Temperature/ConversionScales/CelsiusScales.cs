namespace Temperature.ConversionScales
{
    public class CelsiusScales : IScale
    {
        public string NameScale
        {
            get
            {
                return "Градус Цельсия";
            }
        }

        public double ConvertToScale(double initialTemperatureInCelsius)
        {
            return initialTemperatureInCelsius;
        }

        public double ConvertToCelsius(double initialTemperature)
        {
            return initialTemperature;
        }
    }
}

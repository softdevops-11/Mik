namespace Temperature.ConversionScales
{
    public class KelvinScales : IScale
    {
        public string NameScale
        {
            get
            {
                return "Кельвин";
            }
        }

        public double ConvertToScale(double initialTemperatureInCelsius)
        {
            return initialTemperatureInCelsius + 273.15;
        }

        public double ConvertToCelsius(double initialTemperature)
        {
            return initialTemperature - 273.15;
        }
    }
}

namespace Temperature.ConversionScales
{
    public class KelvinScale : IScale
    {
        public string Name => "Кельвин";

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

namespace Temperature.ConversionScales
{
    public class CelsiusScale : IScale
    {
        public string Name => "Градус Цельсия";

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

namespace Temperature.ConversionScales
{
    public class FahrenheitScale : IScale
    {
        public string Name => "Градус Фаренгейта";

        public double ConvertToScale(double initialTemperatureInCelsius)
        {
            return initialTemperatureInCelsius * 9 / 5 + 32;
        }

        public double ConvertToCelsius(double initialTemperature)
        {
            return (initialTemperature - 32) * 5 / 9;
        }
    }
}
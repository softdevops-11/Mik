namespace Temperature.ConversionScales
{
    public class FahrenheitScales : IScale
    {
        public string NameScale
        {
            get
            {
                return "Градус Фаренгейта";
            }
        }

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
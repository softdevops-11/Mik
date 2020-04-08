namespace Temperature.ConversationScales
{
    public class FahrenheitScales : IScales
    {
        public double GetConversationToScale(double initialTemperatureInCelsius)
        {
            return initialTemperatureInCelsius * 9 / 5 + 32;
        }

        public double GetConversationToCelsius(double initialTemperature)
        {
            return (initialTemperature - 32) * 5 / 9;
        }
    }
}
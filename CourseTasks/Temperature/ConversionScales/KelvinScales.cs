namespace Temperature.ConversationScales
{
    public class KelvinScales : IScales
    {
        public double GetConversationToScale(double initialTemperatureInCelsius)
        {
            return initialTemperatureInCelsius + 273.15;
        }

        public double GetConversationToCelsius(double initialTemperature)
        {
            return initialTemperature - 273.15;
        }
    }
}

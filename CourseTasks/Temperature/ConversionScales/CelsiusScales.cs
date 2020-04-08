namespace Temperature.ConversationScales
{
    public class CelsiusScales : IScales
    {
        public double GetConversationToScale(double initialTemperatureInCelsius)
        {
            return initialTemperatureInCelsius;
        }

        public double GetConversationToCelsius(double initialTemperature)
        {
            return initialTemperature;
        }
    }
}

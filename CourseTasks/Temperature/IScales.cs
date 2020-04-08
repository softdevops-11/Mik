namespace Temperature
{
    public interface IScales
    {
        double GetConversationToCelsius(double initialTemperature);
        double GetConversationToScale(double initialTemperatureInCelsius);
    }
}


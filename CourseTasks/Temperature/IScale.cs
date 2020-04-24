namespace Temperature
{
    public interface IScale
    {
        string Name { get; }

        double ConvertToCelsius(double initialTemperature);

        double ConvertToScale(double initialTemperatureInCelsius);
    }
}


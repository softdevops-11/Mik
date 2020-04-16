namespace Temperature
{
    public interface IScale
    {
        string NameScale { get; }

        double ConvertToCelsius(double initialTemperature);

        double ConvertToScale(double initialTemperatureInCelsius);
    }
}


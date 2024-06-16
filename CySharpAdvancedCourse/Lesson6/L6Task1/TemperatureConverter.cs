namespace L6Task1
{
    public class TemperatureConverter
    {
        public float CelsiusToFahrenheit(float celsius)
        {
            return celsius * 1.8F + 32;
        }
        
        public float FahrenheitToCelsius(float fahrenheit)
        {
            return (fahrenheit - 32) / 1.8F;
        }
    }
}
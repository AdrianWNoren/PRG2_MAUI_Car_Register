namespace PRG_MAUI_Car_Register
{
    public class Car : Vehicle
    {
        public Car() : base(Vehicle.Type.Bil)
        {
        }

        // VehicleType ärvs nu från basklassen, ingen override behövs
        // Om du vill ha specifik logik kan du override:a andra metoder
    }
}
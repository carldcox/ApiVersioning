namespace WebApi.Models
{
    public class Vehicle
    {
        public Vehicle()
        {
        }

        public Vehicle(long id, BodyType bodyType, string modelName)
        {
            Id = id;
            BodyType = bodyType;
            ModelName = modelName;
        }

        public long Id { get; set; }
        public BodyType BodyType { get; set; }
        public string ModelName { get; set; }
    }

    public enum BodyType
    {
        Coupe,
        Sedan,
        Truck,
        Suv
    }
}
using Data.Vehicle;
using MediatR;

namespace Models.CQRS.Vehicle.Commands
{
    public class AddVehicleCommand : IRequest<Data.Vehicle.Vehicle>
    {
        public string ModelName { get; set; }
        public BodyType Type { get; set; }

        public AddVehicleCommand(
            string modelName,
            BodyType type)
        {
            ModelName = modelName;
            Type = type;
        }
    }
}
using MediatR;
using Models.Domain;

namespace Services.CQRS.Vehicle.Commands
{
    public class AddVehicleCommand : IRequest<Models.Domain.Vehicle>
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
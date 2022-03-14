using MediatR;

namespace Services.CQRS.Vehicle.Queries
{
    public class GetVehicleByIdQuery : IRequest<Models.Domain.Vehicle>
    {
        public readonly int VehicleId;

        public GetVehicleByIdQuery(int vehicleId)
        {
            VehicleId = vehicleId;
        }   
    }
}
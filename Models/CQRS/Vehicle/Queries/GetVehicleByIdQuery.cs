using MediatR;

namespace Models.CQRS.Vehicle.Queries
{
    public class GetVehicleByIdQuery : IRequest<Data.Vehicle.Vehicle>
    {
        public readonly int VehicleId;

        public GetVehicleByIdQuery(int vehicleId)
        {
            VehicleId = vehicleId;
        }   
    }
}
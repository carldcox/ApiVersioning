using System.Collections.Generic;
using MediatR;

namespace Models.CQRS.Vehicle.Queries
{
    public class GetAllVehiclesQuery : IRequest<IEnumerable<Data.Vehicle.Vehicle>>
    { }
}
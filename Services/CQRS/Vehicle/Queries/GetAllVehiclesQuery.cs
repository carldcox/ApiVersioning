using System.Collections.Generic;
using MediatR;

namespace Services.CQRS.Vehicle.Queries
{
    public class GetAllVehiclesQuery : IRequest<IEnumerable<Models.Domain.Vehicle>>
    { }
}
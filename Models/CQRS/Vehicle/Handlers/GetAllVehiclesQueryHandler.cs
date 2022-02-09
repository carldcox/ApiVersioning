using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Data;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Models.CQRS.Vehicle.Queries;

namespace Models.CQRS.Vehicle.Handlers
{
    public class GetAllVehiclesQueryHandler : IRequestHandler<GetAllVehiclesQuery, IEnumerable<Data.Vehicle.Vehicle>>
    {
        private readonly MemoryDbContext _context;

        public GetAllVehiclesQueryHandler(MemoryDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Data.Vehicle.Vehicle>> Handle(GetAllVehiclesQuery request, CancellationToken cancellationToken)
        {
            return await _context.Vehicles.ToListAsync(cancellationToken);
        }
    }
}
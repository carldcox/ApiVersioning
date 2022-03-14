using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Data;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Services.CQRS.Vehicle.Queries;

namespace Services.CQRS.Vehicle.Handlers
{
    public class GetAllVehiclesQueryHandler : IRequestHandler<GetAllVehiclesQuery, IEnumerable<Models.Domain.Vehicle>>
    {
        private readonly MemoryDbContext _context;

        public GetAllVehiclesQueryHandler(MemoryDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Models.Domain.Vehicle>> Handle(GetAllVehiclesQuery request, CancellationToken cancellationToken)
        {
            return await _context.Vehicles.ToListAsync(cancellationToken);
        }
    }
}
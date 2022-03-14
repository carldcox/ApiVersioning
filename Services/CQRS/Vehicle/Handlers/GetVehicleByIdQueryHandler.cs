using System.Threading;
using System.Threading.Tasks;
using Data;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Services.CQRS.Vehicle.Queries;

namespace Services.CQRS.Vehicle.Handlers
{
    public class GetVehicleByIdQueryHandler : IRequestHandler<GetVehicleByIdQuery, Models.Domain.Vehicle>
    {
        private readonly MemoryDbContext _context;

        public GetVehicleByIdQueryHandler(MemoryDbContext context)
        {
            _context = context;
        }
        
        public async Task<Models.Domain.Vehicle> Handle(GetVehicleByIdQuery request, CancellationToken cancellationToken)
        {
            return await _context.Vehicles.FirstOrDefaultAsync(v => v.Id == request.VehicleId, cancellationToken);
        }
    }
}
using System.Threading;
using System.Threading.Tasks;
using Data;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Models.CQRS.Vehicle.Queries;

namespace Models.CQRS.Vehicle.Handlers
{
    public class GetVehicleByIdQueryHandler : IRequestHandler<GetVehicleByIdQuery, Data.Vehicle.Vehicle>
    {
        private readonly MemoryDbContext _context;

        public GetVehicleByIdQueryHandler(MemoryDbContext context)
        {
            _context = context;
        }
        
        public async Task<Data.Vehicle.Vehicle> Handle(GetVehicleByIdQuery request, CancellationToken cancellationToken)
        {
            return await _context.Vehicles.FirstOrDefaultAsync(v => v.Id == request.VehicleId, cancellationToken);
        }
    }
}
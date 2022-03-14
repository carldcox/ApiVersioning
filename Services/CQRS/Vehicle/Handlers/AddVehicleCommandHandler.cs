using System.Threading;
using System.Threading.Tasks;
using Data;
using MediatR;
using Services.CQRS.Vehicle.Commands;

namespace Services.CQRS.Vehicle.Handlers
{
    public class AddVehicleCommandHandler : IRequestHandler<AddVehicleCommand, Models.Domain.Vehicle>
    {
        private readonly MemoryDbContext _context;

        public AddVehicleCommandHandler(MemoryDbContext context)
        {
            _context = context;
        }
        public async Task<Models.Domain.Vehicle> Handle(AddVehicleCommand request, CancellationToken cancellationToken)
        {
            if (request == null) return null;
            
            var vehicle = new Models.Domain.Vehicle { BodyType = request.Type, ModelName = request.ModelName };
            
            var result = await _context.Set<Models.Domain.Vehicle>().AddAsync(vehicle, cancellationToken);

            await _context.SaveChangesAsync(cancellationToken);

            return result.Entity;
        }
    }
}
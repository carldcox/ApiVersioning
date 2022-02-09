using System.Threading;
using System.Threading.Tasks;
using Data;
using MediatR;
using Models.CQRS.Vehicle.Commands;

namespace Models.CQRS.Vehicle.Handlers
{
    public class AddVehicleCommandHandler : IRequestHandler<AddVehicleCommand, Data.Vehicle.Vehicle>
    {
        private readonly MemoryDbContext _context;

        public AddVehicleCommandHandler(MemoryDbContext context)
        {
            _context = context;
        }
        public async Task<Data.Vehicle.Vehicle> Handle(AddVehicleCommand request, CancellationToken cancellationToken)
        {
            if (request == null) return null;
            
            var vehicle = new Data.Vehicle.Vehicle { BodyType = request.Type, ModelName = request.ModelName };
            
            var result = await _context.Set<Data.Vehicle.Vehicle>().AddAsync(vehicle, cancellationToken);

            await _context.SaveChangesAsync(cancellationToken);

            return result.Entity;
        }
    }
}
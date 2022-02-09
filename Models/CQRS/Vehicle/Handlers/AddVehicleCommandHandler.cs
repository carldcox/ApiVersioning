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
        public Task<Data.Vehicle.Vehicle> Handle(AddVehicleCommand request, CancellationToken cancellationToken)
        {
            if (request == null) return null;
            
            
        }
    }
}
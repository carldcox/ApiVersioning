using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Models.CQRS.Vehicle.Commands;

namespace Models.CQRS.Vehicle.Handlers
{
    public class AddVehicleCommandHandler : IRequestHandler<AddVehicleCommand, Domain.Vehicle>
    {
        public Task<Domain.Vehicle> Handle(AddVehicleCommand request, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}
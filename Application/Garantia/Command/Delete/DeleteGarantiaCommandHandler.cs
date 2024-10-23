using Application.SeedOfWork;
 using Domain.Entities.Garantia;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Garantia.Command.Delete
{
    internal class DeleteGarantiaCommandHandler : IRequestHandler<DeleteGarantiaCommand>
    {


        private readonly IUnitOfWork _unitOfWork;
        private readonly IGarantia _garantia;
        public DeleteGarantiaCommandHandler(IUnitOfWork unitOfWork, IGarantia garantia)
        {
            _unitOfWork = unitOfWork;
            _garantia = garantia;
        }
        public async Task Handle(DeleteGarantiaCommand request, CancellationToken cancellationToken)
        {
            var garantia  = await _garantia.GetById(request.Id);
            if(garantia == null)
            {
                throw new Exception("GARANTIA NOT FOUND");
            }
            _garantia.Delete(garantia);

            await _unitOfWork.CompletedAsync(cancellationToken);
        }
    }
}

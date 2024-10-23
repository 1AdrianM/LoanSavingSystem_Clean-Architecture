using Application.SeedOfWork;
using Domain.Entities.Garantia;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Garantia.Query.GetAll
{
    public class GetAllGarantiaQueryHandler : IRequestHandler<GetAllGarantiaQuery, List<GarantiaResponse>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IGarantia _garantia;

        public GetAllGarantiaQueryHandler(IUnitOfWork unitOfWork, IGarantia garantia)
        {
            _unitOfWork = unitOfWork;
            _garantia = garantia;
        }
        async Task<List<GarantiaResponse>> IRequestHandler<GetAllGarantiaQuery, List<GarantiaResponse>>.Handle(GetAllGarantiaQuery request, CancellationToken cancellationToken)
        {
           var list=  await _garantia.GetAllGarantia();

            return list.Select(p => new GarantiaResponse(
                p.GarantiaId,
                p.TipoGarantia,
                p.Valor, 
                p.Ubicacion))
                 .ToList();
        }
    }
}

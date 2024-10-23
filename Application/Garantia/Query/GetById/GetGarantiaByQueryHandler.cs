using Application.SeedOfWork;
using Domain.Entities.Garantia;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Garantia.Query.GetById

{
    internal class GetGarantiaByQueryHandler : IRequestHandler<GetGarantiaByQuery, GarantiaIdResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IGarantia _garantia;

    public GetGarantiaByQueryHandler(IUnitOfWork unitOfWork, IGarantia garantia)
    {
        _unitOfWork = unitOfWork;
        _garantia = garantia;

    }
    public async Task<GarantiaIdResponse> Handle(GetGarantiaByQuery request, CancellationToken cancellationToken)
    {
        var garantia = await _garantia.GetById(request.Id);
        if (garantia == null) {
            throw new Exception();
        }
        var garantiaObj = new GarantiaIdResponse(garantia.GarantiaId, garantia.TipoGarantia, garantia.Valor, garantia.Ubicacion);
        return garantiaObj;
    }
} 
}

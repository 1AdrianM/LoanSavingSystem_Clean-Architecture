using Application.SeedOfWork;
using Domain.Entities.Prestatario;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Prestatario.Query
{
    internal class GetAllPrestatarioQueryHandler : IRequestHandler<GetAllPrestatarioQuery, List<PrestatarioResponse>>
    {
        private readonly IPrestatario _prestatario;
         public GetAllPrestatarioQueryHandler(IPrestatario prestatario) {
            _prestatario = prestatario;
        }
        public async Task<List<PrestatarioResponse>> Handle(GetAllPrestatarioQuery request, CancellationToken cancellationToken)
        {
            var prestatarioList =  await _prestatario.GetAllPrestatarios();
            return prestatarioList.Select(p => new PrestatarioResponse(p.PrestatarioId, p.ClientId, p.EstadoPrestatario,p.CantidadPrestamos)).ToList();
        }
    }
}

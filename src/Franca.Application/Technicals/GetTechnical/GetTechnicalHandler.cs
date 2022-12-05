using Franca.Domain;
using Franca.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Franca.Application.Technicals.GetTechnical
{
    public class GetTechnicalHandler : IRequestHandler<GetTechnicalQuery, GetTechnicalDTO>
    {
        private readonly IRepository repository;

        private readonly IMapObject mapObject;

        public GetTechnicalHandler(IRepository repository, IMapObject mapObject)
        {
            this.repository = repository;
            this.mapObject = mapObject;
        }

        public async Task<GetTechnicalDTO> Handle(GetTechnicalQuery request, CancellationToken cancellationToken)
        {
            var tecnico = await this.repository.Get<Tecnico>(x => x.Id.ToString() == request.Id);
            return mapObject.Map<Tecnico, GetTechnicalDTO>(tecnico);
        }
    }
}

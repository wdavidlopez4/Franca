using Franca.Domain;
using Franca.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Franca.Application.Technicals.GetAllTechnicals
{
    public class GetAllTechnicalsHandler : IRequestHandler<GetAllTechnicalsQuery, List<GetAllTechnicalsDTO>>
    {
        private readonly IRepository repository;

        private readonly IMapObject mapObject;

        public GetAllTechnicalsHandler(IRepository repository, IMapObject mapObject)
        {
            this.repository = repository;
            this.mapObject = mapObject;
        }

        public async Task<List<GetAllTechnicalsDTO>> Handle(GetAllTechnicalsQuery request, CancellationToken cancellationToken)
        {
            List<Tecnico> tecnicos;
            tecnicos = await this.repository.GetAll<Tecnico>(nameof(Sucursal));

            return this.mapObject.Map<List<Tecnico>, List<GetAllTechnicalsDTO>>(tecnicos);
        }
    }
}

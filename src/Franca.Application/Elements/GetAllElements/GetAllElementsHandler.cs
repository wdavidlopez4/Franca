using Franca.Domain;
using Franca.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Franca.Application.Elements.GetAllElements
{
    public class GetAllElementsHandler : IRequestHandler<GetAllElementsQuery, List<GetAllElementsDTO>>
    {
        private readonly IRepository repository;

        private readonly IMapObject mapObject;

        public GetAllElementsHandler(IRepository repository, IMapObject mapObject)
        {
            this.repository = repository;
            this.mapObject = mapObject;
        }

        public async Task<List<GetAllElementsDTO>> Handle(GetAllElementsQuery request, CancellationToken cancellationToken)
        {
            var elements = await this.repository.GetAll<Elemento>();
            return this.mapObject.Map<List<Elemento>, List<GetAllElementsDTO>>(elements);
        }
    }
}

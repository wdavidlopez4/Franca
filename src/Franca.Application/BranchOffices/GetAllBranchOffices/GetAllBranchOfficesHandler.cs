using Franca.Domain;
using Franca.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Franca.Application.BranchOffices.GetAllBranchOffices
{
    public class GetAllBranchOfficesHandler : IRequestHandler<GetAllBranchOfficesQuery, List<GetAllBranchOfficesDTO>>
    {
        private readonly IRepository repository;

        private readonly IMapObject mapObject;

        public GetAllBranchOfficesHandler(IRepository repository, IMapObject mapObject)
        {
            this.repository = repository;
            this.mapObject = mapObject;
        }

        public async Task<List<GetAllBranchOfficesDTO>> Handle(GetAllBranchOfficesQuery request, CancellationToken cancellationToken)
        {
            var sucursales = await this.repository.GetAll<Sucursal>();
            return this.mapObject.Map<List<Sucursal>, List<GetAllBranchOfficesDTO>>(sucursales);
        }
    }
}

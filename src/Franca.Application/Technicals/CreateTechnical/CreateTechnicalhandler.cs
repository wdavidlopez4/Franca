using Franca.Domain;
using Franca.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Franca.Application.Technicals.CreateTechnical
{
    public class CreateTechnicalhandler : IRequestHandler<CreateTechnicalCommand, int>
    {
        private readonly IRepository repository;

        public CreateTechnicalhandler(IRepository repository)
        {
            this.repository = repository;
        }

        public async Task<int> Handle(CreateTechnicalCommand request, CancellationToken cancellationToken)
        {
            Tecnico tecnico;
            List<TecnicoElemento> elementos; 

            if (request.ElementosIds.Count < 1)
                throw new Exception("no cumple con el minimo de elementos para añadir");

            if (request.ElementosIds.Count > 10)
                throw new Exception("no cumple con el maximo de elementos para añadir");

            tecnico = Tecnico.Build(request.Name, request.Salary, Guid.Parse(request.SucursalId));
            tecnico.AddElementosCount(request.ElementosIds.Count);

            elementos = new();
            for (int i = 0; i < request.ElementosIds.Count; i++)
            {
                if (! this.repository.Exists<Elemento>(x => x.Id.ToString() == request.ElementosIds[i]))
                    throw new Exception("elemento no existe");

                elementos.Add(TecnicoElemento.Bulid(tecnico.Id, Guid.Parse(request.ElementosIds[i])));
            }

            await this.repository.Save(tecnico);
            await this.repository.Save(elementos);
            await this.repository.Commit();

            return 0;
        }
    }
}

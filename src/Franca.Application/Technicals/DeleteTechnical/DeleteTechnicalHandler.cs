using Franca.Domain;
using Franca.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Franca.Application.Technicals.DeleteTechnical
{
    public class DeleteTechnicalHandler : IRequestHandler<DeleteTechnicalCommand, int>
    {
        private readonly IRepository repository;

        public DeleteTechnicalHandler(IRepository repository)
        {
            this.repository = repository;
        }

        public async Task<int> Handle(DeleteTechnicalCommand request, 
            CancellationToken cancellationToken)
        {
            Tecnico tecnico;
            List<TecnicoElemento> tecnicoElementos;

            if (!this.repository.Exists<Tecnico>(x => x.Id.ToString() == request.Id))
                throw new Exception("el tecnico no existe");

            tecnico = await this.repository.Get<Tecnico>(x => x.Id.ToString() == request.Id);
            tecnico.Remove();

            tecnicoElementos = await this.repository.GetAll<TecnicoElemento>(
                nested: nameof(Elemento),
                expression: x => x.TecnicoId.ToString() == request.Id);

            for (int i = 0; i < tecnicoElementos.Count; i++)
            {
                tecnicoElementos[i].Elemento.Remove();
                this.repository.Update(tecnicoElementos[i].Elemento);
            }

            this.repository.Update(tecnico);
            await this.repository.Commit();

            return 0;
        }
    }
}

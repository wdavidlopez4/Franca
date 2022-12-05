using Franca.Domain;
using Franca.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Franca.Application.Elements.AddElement
{
    public class AddElementHandler : IRequestHandler<AddElementCommand, int>
    {
        private readonly IRepository repository;

        public AddElementHandler(IRepository repository)
        {
            this.repository = repository;
        }

        public async Task<int> Handle(AddElementCommand request, 
            CancellationToken cancellationToken)
        {
            Tecnico tecnico;
            Elemento elemento;
            TecnicoElemento tecnicoElemento;

            if (! this.repository.Exists<Tecnico>(x => x.Id.ToString() == request.TecnicoId))
                throw new Exception("no existe el tecnico");

            tecnico = await this.repository.Get<Tecnico>(
                x => x.Id.ToString() == request.TecnicoId);

            if (tecnico.ElementosCount >= 10)
                throw new Exception("limite de eleemntos superado");

            tecnico.AddElementosCount(1);
            this.repository.Update(tecnico);

            elemento = await this.repository.Get<Elemento>(
                x => x.Id.ToString() == request.ElementoId);

            tecnicoElemento = TecnicoElemento.Bulid(tecnico.Id, elemento.Id);

            await this.repository.Save(elemento);
            await this.repository.Save(tecnicoElemento);

            await this.repository.Commit();

            return 0;
        }
    }
}

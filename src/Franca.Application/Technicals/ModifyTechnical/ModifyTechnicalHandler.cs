using Franca.Domain;
using Franca.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Franca.Application.Technicals.ModifyTechnical
{
    public class ModifyTechnicalHandler : IRequestHandler<ModifyTechnicalCommand, int>
    {
        private readonly IRepository repository;

        public ModifyTechnicalHandler(IRepository repository)
        {
            this.repository = repository;
        }

        public async Task<int> Handle(ModifyTechnicalCommand request, CancellationToken cancellationToken)
        {
            Tecnico tecnico;

            if (!this.repository.Exists<Tecnico>(x => x.Id.ToString() == request.Id))
                throw new Exception("tecnico no existe");

            tecnico = await this.repository.Get<Tecnico>(x => x.Id.ToString() == request.Id);
            tecnico.ChangeMainAttributes(request.Name, request.Salary);

            this.repository.Update(tecnico);
            await this.repository.Commit();

            return 0;
        }
    }
}

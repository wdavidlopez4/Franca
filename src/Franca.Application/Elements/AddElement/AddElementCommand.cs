using Franca.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Franca.Application.Elements.AddElement
{
    public class AddElementCommand : IRequest<int>
    {
        public string TecnicoId { get; set; }

        public string ElementoId { get; set; }
    }
}

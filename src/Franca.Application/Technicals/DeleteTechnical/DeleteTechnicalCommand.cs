using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Franca.Application.Technicals.DeleteTechnical
{
    public class DeleteTechnicalCommand : IRequest<int>
    {
        public string Id { get; set; }
    }
}

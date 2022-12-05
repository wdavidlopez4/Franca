using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Franca.Application.Technicals.GetTechnical
{
    public class GetTechnicalQuery : IRequest<GetTechnicalDTO>
    {
        public string Id { get; set; }
    }
}

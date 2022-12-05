using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Franca.Application.Technicals.CreateTechnical
{
    public class CreateTechnicalCommand : IRequest<int>
    {
        public string Name { get; set; }

        public double Salary { get; set; }

        public string SucursalId { get; set; }

        public List<string> ElementosIds { get; set; }
    }
}

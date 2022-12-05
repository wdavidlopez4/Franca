using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Franca.Application.Technicals.ModifyTechnical
{
    public class ModifyTechnicalCommand : IRequest<int>
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public double Salary { get; set; }
    }
}

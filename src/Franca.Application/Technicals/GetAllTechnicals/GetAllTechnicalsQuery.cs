using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Franca.Application.Technicals.GetAllTechnicals
{
    public class GetAllTechnicalsQuery : IRequest<List<GetAllTechnicalsDTO>>
    {
        //traer todos con detalle
    }
}

using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Franca.Application.Elements.GetAllElements
{
    public class GetAllElementsQuery : IRequest<List<GetAllElementsDTO>>
    {
        //get all elements
    }
}

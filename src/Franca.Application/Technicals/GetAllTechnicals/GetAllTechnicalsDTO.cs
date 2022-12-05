using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Franca.Application.Technicals.GetAllTechnicals
{
    public class GetAllTechnicalsDTO
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public double Salary { get; set; }

        public SucursalDTO Sucursal { get; set; }

        public class SucursalDTO
        {
            public string Name { get; set; }
        }
    }
}

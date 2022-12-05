using AutoMapper;
using Franca.Application.BranchOffices.GetAllBranchOffices;
using Franca.Application.Elements.GetAllElements;
using Franca.Application.Technicals.GetAllTechnicals;
using Franca.Application.Technicals.GetTechnical;
using Franca.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Franca.Application.Technicals.GetAllTechnicals.GetAllTechnicalsDTO;

namespace Franca.Infrastructure.MapObjects
{
    public class Profiles : Profile
    {
        public Profiles()
        {
            this.CreateMap<Sucursal, GetAllBranchOfficesDTO>();
            this.CreateMap<Elemento, GetAllElementsDTO>();
            this.CreateMap<Tecnico, GetAllTechnicalsDTO>();
            this.CreateMap<Sucursal, SucursalDTO>();
            this.CreateMap<Tecnico, GetTechnicalDTO>();
        }
    }
}

using Franca.Application.BranchOffices.GetAllBranchOffices;
using Franca.Application.Elements.AddElement;
using Franca.Application.Elements.GetAllElements;
using Franca.Application.Technicals.CreateTechnical;
using Franca.Application.Technicals.DeleteTechnical;
using Franca.Application.Technicals.GetAllTechnicals;
using Franca.Application.Technicals.GetTechnical;
using Franca.Application.Technicals.ModifyTechnical;
using Franca.Web.App.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Franca.Web.App.Controllers
{
    public class TecnicoController : Controller
    {
        private readonly IMediator mediator;

        public TecnicoController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public async Task<IActionResult> Index()
        {
            var dto = await mediator.Send(new GetAllTechnicalsQuery());
            return View(dto);
        }

        public async Task<IActionResult> CrearTecnico()
        {
            ViewData["GetAllElementsDTO"] = await mediator.Send(new GetAllElementsQuery());
            ViewData["GetAllBranchOfficesDTO"] = await mediator.Send(new GetAllBranchOfficesQuery());
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CrearTecnico(CreateTechnicalCommand command)
        {
            await mediator.Send(command);
            return RedirectToAction("Index", "Tecnico");
        }

        public async Task<IActionResult> ModificarTecnico(string idTecnico)
        {
            ViewData["GetTechnicalDTO"] = await mediator.Send(
                new GetTechnicalQuery
                {
                    Id = idTecnico
                });

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ModificarTecnico(ModifyTechnicalCommand command)
        {
            await mediator.Send(command);
            return RedirectToAction("Index", "Tecnico");
        }

        [HttpPost]
        public async Task<IActionResult> EliminarTecnico(GetAllTechnicalsDTO dto)
        {
            var technicalDTO = await mediator.Send(
                new DeleteTechnicalCommand
                {
                    Id = dto.Id
                });

            return RedirectToAction("Index", "Tecnico");
        }

        public async Task<IActionResult> AddElementoATecnico(GetAllTechnicalsDTO dto)
        {
            var technicalDTO = await mediator.Send(
                new AddElementCommand
                {
                    TecnicoId = dto.Id
                });

            return RedirectToAction("Index", "Tecnico");
        }

    }
}

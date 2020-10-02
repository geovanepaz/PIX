using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Pix.Application.Services;
using Pix.Application.ViewModels.BadRequest;
using Pix.Application.ViewModels.Cliente;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace API.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/cliente")]
    [Authorize]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteAppService appService;

        public ClienteController(IClienteAppService appService)
        {
            this.appService = appService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<ClienteResponse>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> ObterTodosAsync()
        {
            var clientes = await appService.ObterTodosAsync();

            if (clientes == null || clientes.Count() == 0)
            { 
                return NotFound();
            }

            return Ok(clientes);
        }
    }
}

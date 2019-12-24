using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Vega.Application.Makes.Queries.GetMakes;

namespace Vega.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MakesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public MakesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetMakes()
        {
            return Ok(await _mediator.Send(new GetMakesQuery()).ConfigureAwait(false));
        }
    }
}
using System;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Vega.Application.Common.Models;
using Vega.Application.Makes.Commands.CreateMake;
using Vega.Application.Makes.Queries.GetMake;
using Vega.Application.Makes.Queries.GetMakes;
using Vega.Application.Models.Queries.GetModels;

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

        /// <summary>
        /// Retrieves list of makes
        /// </summary>
        /// <returns>All makes</returns>
        /// <response code="200">Returned list of makes</response>
        /// <response code="500">Returned in case of internal server error</response>
        [HttpGet]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetMakes()
        {
            return Ok(await _mediator.Send(new GetMakesQuery()).ConfigureAwait(false));
        }

        /// <summary>
        /// Retrieves list of makes
        /// </summary>
        /// <returns>All makes</returns>
        /// <response code="200">Returned list of makes</response>
        /// <response code="500">Returned in case of internal server error</response>
        [HttpGet("{id}")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetMake(Guid id)
        {
            return Ok(await _mediator.Send(new GetMakeQuery(id)).ConfigureAwait(false));
        }

        /// <summary>
        /// Creates new make
        /// </summary>
        /// <returns>Created make</returns>
        /// <response code="201">Returned in case of success</response>
        /// <response code="400">Returned in case of validation errors</response>
        /// <response code="500">Returned in case of internal server error</response>
        [HttpPost]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateMake(CreateMakeCommand request)
        {
            var make = await _mediator.Send(request).ConfigureAwait(false);
            return CreatedAtAction(nameof(GetMake), "makes", new { id = make.Id }, make);
        }

        #region Make Models

        /// <summary>
        /// Retrieves make models
        /// </summary>
        /// <param name="id">Make ID</param>
        /// <returns>All models associated with make</returns>
        /// <response code="200">Returned list of models</response>
        /// <response code="500">Returned in case of internal server error</response>
        [HttpGet("{id}/models")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetMakeModels(Guid id)
        {
            return Ok(await _mediator.Send(new GetModelsQuery(id)).ConfigureAwait(false));
        }

        #endregion Make Models
    }
}
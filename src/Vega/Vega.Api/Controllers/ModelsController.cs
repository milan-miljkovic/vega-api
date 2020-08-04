using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vega.Application.Models.Commands;
using Vega.Application.Models.Queries.GetModel;

namespace Vega.Api.Controllers
{
    [Route("api/[controller]")]
    public class ModelsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ModelsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Creates new model
        /// </summary>
        /// <returns>Created model</returns>
        /// <response code="201">Returned in case of success</response>
        /// <response code="400">Returned in case of validation errors</response>
        /// <response code="500">Returned in case of internal server error</response>
        [HttpPost]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateModel([FromBody] CreateModelCommand request)
        {
            var model = await _mediator.Send(request).ConfigureAwait(false);
            return CreatedAtAction(nameof(GetModel), "models", new { id = model.Id }, model);
        }

        /// <summary>
        /// Retrieves model by ID
        /// </summary>
        /// <returns>Model</returns>
        /// <response code="200">Returned model based on ID</response>
        /// <response code="500">Returned in case of internal server error</response>
        [HttpGet("{id}")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetModel(Guid id)
        {
            return Ok(await _mediator.Send(new GetModelQuery(id)).ConfigureAwait(false));
        }
    }
}

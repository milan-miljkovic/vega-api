using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Vega.Application.Common.Models;
using Vega.Domain;
using Vega.Persistance;

namespace Vega.Application.Models.Commands
{
    class CreateModelCommandHandler : IRequestHandler<CreateModelCommand, ModelDTO>
    {
        private readonly VegaDbContext _context;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public CreateModelCommandHandler(VegaDbContext context, IMediator mediator, IMapper mapper)
        {
            _context = context;
            _mediator = mediator;
            _mapper = mapper;
        }

        public async Task<ModelDTO> Handle(CreateModelCommand request, CancellationToken cancellationToken)
        {
            var model = _mapper.Map<Model>(request);
            _context.Models.Add(model);
            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);

            return _mapper.Map<ModelDTO>(model);
        }
    }
}

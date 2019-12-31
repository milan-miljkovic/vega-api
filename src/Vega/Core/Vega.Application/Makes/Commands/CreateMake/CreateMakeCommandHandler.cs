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

namespace Vega.Application.Makes.Commands.CreateMake
{
    public class CreateMakeCommandHandler : IRequestHandler<CreateMakeCommand, MakeDTO>
    {
        private readonly VegaDbContext _context;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public CreateMakeCommandHandler(VegaDbContext context, IMediator mediator, IMapper mapper)
        {
            _context = context;
            _mediator = mediator;
            _mapper = mapper;
        }

        public async Task<MakeDTO> Handle(CreateMakeCommand request, CancellationToken cancellationToken)
        {
            var make = _mapper.Map<Make>(request);
            _context.Makes.Add(make);
            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);

            return _mapper.Map<MakeDTO>(make);
        }
    }
}

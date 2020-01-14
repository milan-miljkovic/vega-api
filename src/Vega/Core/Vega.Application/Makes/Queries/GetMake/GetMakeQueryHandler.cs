using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Vega.Application.Common.Exceptions;
using Vega.Application.Common.Models;
using Vega.Domain;
using Vega.Persistance;

namespace Vega.Application.Makes.Queries.GetMake
{
    public class GetMakeQueryHandler : IRequestHandler<GetMakeQuery, MakeDTO>
    {
        private readonly VegaDbContext _context;
        private readonly IMapper _mapper;

        public GetMakeQueryHandler(VegaDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<MakeDTO> Handle(GetMakeQuery request, CancellationToken cancellationToken)
        {
            var make = await _context.Makes.Include(m => m.Models)
                .FirstOrDefaultAsync(m => m.Id == request.Id, cancellationToken)
                .ConfigureAwait(false);

            if (make == null)
            {
                throw new NotFoundException(nameof(Make), request.Id);
            }

            return _mapper.Map<MakeDTO>(make);
        }
    }
}

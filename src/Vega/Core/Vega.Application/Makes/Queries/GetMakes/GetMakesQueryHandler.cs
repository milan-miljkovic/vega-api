using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Vega.Application.Common.Models;
using Vega.Persistance;

namespace Vega.Application.Makes.Queries.GetMakes
{
    public class GetMakesQueryHandler : IRequestHandler<GetMakesQuery, MakesListDTO>
    {
        private readonly VegaDbContext _context;
        private readonly IMapper _mapper;

        public GetMakesQueryHandler(VegaDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<MakesListDTO> Handle(GetMakesQuery request, CancellationToken cancellationToken)
        {
            var makes = await _context.Makes.ProjectTo<MakeDTO>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken).ConfigureAwait(false);

            return new MakesListDTO(makes);
        }
    }
}

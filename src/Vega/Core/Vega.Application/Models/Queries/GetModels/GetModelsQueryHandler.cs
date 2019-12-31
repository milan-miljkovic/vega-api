using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Vega.Application.Common.Models;
using Vega.Persistance;

namespace Vega.Application.Models.Queries.GetModels
{
    public class GetModelsQueryHandler : IRequestHandler<GetModelsQuery, ModelsListDTO>
    {
        private readonly VegaDbContext _context;
        private readonly IMapper _mapper;

        public GetModelsQueryHandler(VegaDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ModelsListDTO> Handle(GetModelsQuery request, CancellationToken cancellationToken)
        {
            return new ModelsListDTO(await _context.Models
                .Where(m => m.MakeId == request.MakeId)
                .ProjectTo<ModelDTO>(_mapper.ConfigurationProvider)
                .ToListAsync()
                .ConfigureAwait(false));
        }
    }
}

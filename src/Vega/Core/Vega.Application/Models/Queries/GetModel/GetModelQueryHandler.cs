using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Vega.Application.Common.Exceptions;
using Vega.Application.Common.Models;
using Vega.Domain;
using Vega.Persistance;

namespace Vega.Application.Models.Queries.GetModel
{
    public class GetModelQueryHandler : IRequestHandler<GetModelQuery, ModelDTO>
    {
        private readonly VegaDbContext _context;
        private readonly IMapper _mapper;

        public GetModelQueryHandler(VegaDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ModelDTO> Handle(GetModelQuery request, CancellationToken cancellationToken)
        {
            var model = await _context.Models.FindAsync(new object[] { request.Id }, cancellationToken);

            if (model == null)
            {
                throw new NotFoundException(nameof(Model), request.Id);
            }

            return _mapper.Map<ModelDTO>(model);
        }
    }
}

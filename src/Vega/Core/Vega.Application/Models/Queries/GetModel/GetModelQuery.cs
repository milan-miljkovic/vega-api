using MediatR;
using System;
using Vega.Application.Common.Models;

namespace Vega.Application.Models.Queries.GetModel
{
    public class GetModelQuery : IRequest<ModelDTO>
    {
        public Guid Id { get; private set; }

        public GetModelQuery(Guid id)
        {
            Id = id;
        }
    }
}

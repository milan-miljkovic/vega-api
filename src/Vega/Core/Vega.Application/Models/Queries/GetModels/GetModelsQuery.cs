using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Vega.Application.Models.Queries.GetModels
{
    public class GetModelsQuery : IRequest<ModelsListDTO>
    {
        public Guid MakeId { get; private set; }

        public GetModelsQuery(Guid makeId)
        {
            MakeId = makeId;
        }
    }
}

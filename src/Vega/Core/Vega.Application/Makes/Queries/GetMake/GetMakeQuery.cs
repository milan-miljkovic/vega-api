using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using Vega.Application.Common.Models;

namespace Vega.Application.Makes.Queries.GetMake
{
    public class GetMakeQuery : IRequest<MakeDTO>
    {
        public Guid Id { get; private set; }

        public GetMakeQuery(Guid id)
        {
            Id = id;
        }
    }
}

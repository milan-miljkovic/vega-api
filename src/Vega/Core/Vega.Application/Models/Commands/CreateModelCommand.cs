using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using Vega.Application.Common.Models;

namespace Vega.Application.Models.Commands
{
    public class CreateModelCommand : IRequest<ModelDTO>
    {
        public string Name { get; set; }
        public string MakeId { get; set; }
    }
}

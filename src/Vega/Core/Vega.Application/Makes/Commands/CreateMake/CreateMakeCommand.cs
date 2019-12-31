using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using Vega.Application.Common.Models;

namespace Vega.Application.Makes.Commands.CreateMake
{
    public class CreateMakeCommand : IRequest<MakeDTO>
    {
        public string Name { get; set; }
    }
}

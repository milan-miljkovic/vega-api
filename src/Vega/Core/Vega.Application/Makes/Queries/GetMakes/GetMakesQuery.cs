using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Vega.Application.Makes.Queries.GetMakes
{
    public class GetMakesQuery : IRequest<MakesListDTO>
    {
    }
}

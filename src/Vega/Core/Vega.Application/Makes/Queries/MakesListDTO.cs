using System;
using System.Collections.Generic;
using System.Text;
using Vega.Application.Common.Models;

namespace Vega.Application.Makes.Queries
{
    public class MakesListDTO
    {
        public List<MakeDTO> Makes { get; private set; }

        public MakesListDTO(List<MakeDTO> makes)
        {
            Makes = makes;
        }
    }
}

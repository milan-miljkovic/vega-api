using System;
using System.Collections.Generic;
using System.Text;
using Vega.Application.Common.Models;

namespace Vega.Application.Models
{
    public class ModelsListDTO
    {
        public List<ModelDTO> Models { get; private set; }

        public ModelsListDTO(List<ModelDTO> models)
        {
            Models = models;
        }
    }
}

using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using Vega.Application.Common.Models;
using Vega.Domain;

namespace Vega.Application.Common.Mappings
{
    public class ModelProfile : Profile
    {
        public ModelProfile()
        {
            CreateMap<Model, ModelDTO>();
        }
    }
}

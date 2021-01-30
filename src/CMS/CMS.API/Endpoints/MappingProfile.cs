using AutoMapper;

using CMS.API.Endpoints.Categories;
using CMS.Core.Entities;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMS.API.Endpoints
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Category, CategoryDto>();
        }
    }
}

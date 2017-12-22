using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmprestaGame.API.AutoMapper
{
    public class AutoMapperConfig
    {
        public static void RegisterMappings()

        {
            Mapper.Initialize(x =>
            {
                x.AddProfile<ViewModelToDomainMappingProfile>();
                x.AddProfile<DomainToViewModelMappingProfile>();
            });

        }
    }
}
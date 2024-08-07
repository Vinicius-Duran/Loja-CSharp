﻿using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Persistencias.Repositorios
{
    public class AutoMapperConfiguration
    {
        public MapperConfiguration Configure()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });

            return config;
        }
    }
}

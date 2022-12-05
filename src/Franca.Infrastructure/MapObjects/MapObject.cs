﻿using AutoMapper;
using Franca.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Franca.Infrastructure.MapObjects
{
    public class MapObject : IMapObject
    {
        private readonly IMapper mapper;

        public MapObject(IMapper mapper)
        {
            this.mapper = mapper;
        }

        public TDestination Map<TSource, TDestination>(TSource source)
        {
            try
            {
                return mapper.Map<TSource, TDestination>(source);
            }
            catch (Exception e)
            {

                throw new Exception($"Error de mapeo: {e.Message}");
            }
        }
    }
}

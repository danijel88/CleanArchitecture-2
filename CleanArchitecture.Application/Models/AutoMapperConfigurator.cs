using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using AutoMapper;
using CleanArchitecture.Application.CrossCuttingConcerns.Mapping;

namespace CleanArchitecture.Application.Models
{
    public static class AutoMapperConfigurator
    {
        public static IMapper Mapper()
        {
            MapperConfiguration configuration = MapperConfiguration();

            Mapper mapper = new Mapper(configuration);

            return mapper;
        }

        private static MapperConfiguration MapperConfiguration()
        {
            // Load all Assemblies
            Assembly target = Assembly.GetCallingAssembly();
            Func<AssemblyName, bool> loadAllFilter = x => true;

            List<Assembly> assembliesToLoad =
                target.GetReferencedAssemblies().Where(loadAllFilter).Select(Assembly.Load).ToList();

            assembliesToLoad.Add(target);

            Type[] types = assembliesToLoad.SelectMany(a => a.GetExportedTypes()).ToArray();

            MapperConfiguration configuration = new MapperConfiguration(cfg =>
            {
                Load(cfg, types); // cfg create map
            });

            return configuration;
        }

        private static void Load(IMapperConfigurationExpression cfg, Type[] types)
        {
            LoadIMapFromMappings(cfg, types);
            LoadIMapToMappings(cfg, types);
        }

        private static void LoadIMapToMappings(IMapperConfigurationExpression cfg, Type[] types)
        {
            var maps = (from t in types
                from i in t.GetInterfaces()
                where i.IsGenericType && (i.GetGenericTypeDefinition() == typeof(IMapTo<>)) && !t.IsAbstract
                select new { Destination = i.GetGenericArguments()[0], Source = t }).ToArray();

            foreach (var map in maps)
            {
                cfg.CreateMap(map.Source, map.Destination);
            }
        }

        private static void LoadIMapFromMappings(IMapperConfigurationExpression cfg, Type[] types)
        {
            var maps = (from t in types
                from i in t.GetInterfaces()
                where i.IsGenericType && (i.GetGenericTypeDefinition() == typeof(IMapFrom<>)) && !t.IsAbstract
                select new { Source = i.GetGenericArguments()[0], Destination = t }).ToArray();

            foreach (var map in maps)
            {
                cfg.CreateMap(map.Source, map.Destination);
            }
        }
    }
}
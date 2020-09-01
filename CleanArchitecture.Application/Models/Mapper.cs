using AutoMapper;

namespace CleanArchitecture.Application.Models
{
    public static class Mapper
    {
        public static IMapper Mapper()
        {
            MapperConfiguration configuration = AutoMapperConfigurator.MapperConfiguration();

            Mapper mapper = new Mapper(configuration);

            return mapper;
        }
    }
}
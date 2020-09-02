using AutoMapper;

namespace CleanArchitecture.Application.CrossCuttingConcerns.Mapping
{
    public static class AutoMapping
    {
        public static IMapper Mapper()
        {
            MapperConfiguration configuration = AutoMapperConfigurator.MapperConfiguration();

            Mapper autoMapping = new Mapper(configuration);

            return autoMapping;
        }
    }
}

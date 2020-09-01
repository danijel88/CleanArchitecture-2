using AutoMapper;

namespace CleanArchitecture.Application.CrossCuttingConcerns.Mapping
{
    public interface IHaveCustomMappings
    {
        void CreateMappings(IMapperConfigurationExpression configuration);
    }
}
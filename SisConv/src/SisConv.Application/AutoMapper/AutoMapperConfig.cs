using AutoMapper;

namespace SisConv.Application.AutoMapper
{
    public class AutoMapperConfig
    {
        public static void RegisterMapping()
        {
            Mapper.Initialize(x =>
            {
                x.AddProfile<DomaintoviewModelMappingProfile>();
               
            });

            Mapper.AssertConfigurationIsValid();
        }
    }
}
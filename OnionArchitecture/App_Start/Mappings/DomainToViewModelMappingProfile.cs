using AutoMapper;
using OnionArchitecture.Core.DomainModels;
using OnionArchitecture.Dtos;

namespace OnionArchitecture.Mappings
{
    public class DomainToViewModelMappingProfile:Profile
    {
        public override string ProfileName => "DomainToViewModelMappings";

        protected override void Configure()
        {
            Mapper.CreateMap<Student, StudentDto>();
       
        }
    }
}
using AutoMapper;
using OnionArchitecture.Core.DomainModels;
using OnionArchitecture.Dtos;

namespace OnionArchitecture.Mappings
{
    public class ViewModelToDomainMappingProfile:Profile
    {
        public override string ProfileName => "ViewModelToDomainMappings";

        protected override void Configure()
        {
            Mapper.CreateMap<StudentDto, Student>()
                .ForMember(s => s.FirstName, map => map.MapFrom(vm => vm.FirstName))
                .ForMember(s => s.LastName, map => map.MapFrom(vm => vm.LastName))
                .ForMember(s => s.MiddleName, map => map.MapFrom(vm => vm.MiddleName))
                .ForMember(s => s.EnrollmentDate, map => map.MapFrom(vm => vm.EnrollmentDate));

        }
    }
}
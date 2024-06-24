using AutoMapper;
using GraduationProjectApi.Dtos.Hospital;
using GraduationProjectApi.Dtos.Note;
using GraduationProjectApi.Dtos.Person;
using GraduationProjectApi.Dtos.Pharmacy;
using GraduationProjectApi.Models;

namespace GraduationProjectApi.Helper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //<source , destination>

            // Person Class
            CreateMap<Person, PeopleDetailsDto>();

            CreateMap<CreatePersonDto, Person>()
                .ForMember(src => src.Image, opt => opt.Ignore());

            // Hospital Class
            CreateMap<Hospital, HospitalDetalilsDto>();

            CreateMap<HospitalDto, Hospital>();

            // Pharmacy Class
            CreateMap<PharmacyDto, Pharmacy>();

            // Note Class
            CreateMap<Note, NoteDetailsDto>();

            CreateMap<NoteDto, Note>();

        }
    }
}

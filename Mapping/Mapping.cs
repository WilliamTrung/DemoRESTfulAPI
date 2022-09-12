using AutoMapper;
using Mapping.DTO;
using Models;

namespace Mapping
{
    public class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Person, PersonDTO>().ReverseMap();
        }
       
    }
}
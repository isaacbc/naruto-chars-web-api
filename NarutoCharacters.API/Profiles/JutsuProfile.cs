using AutoMapper;

namespace NarutoCharacters.API.Profiles
{
    public class JutsuProfile : Profile
    {
        public JutsuProfile()
        {
            CreateMap<Entities.Jutsu, Models.JutsuDto>(); //FOR RETURN/SHOW JUTSU
            CreateMap<Models.JutsuForCreationDto, Entities.Jutsu>(); //FOR CREATE JUTSU
            CreateMap<Models.JutsuForUpdateDto,  Entities.Jutsu>();
        }
    }
}

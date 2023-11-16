using AutoMapper;

namespace NarutoCharacters.API.Profiles
{
    public class NinjaProfile : Profile
    {
        public NinjaProfile() {
            CreateMap<Entities.Ninja, Models.NinjaDto>(); //FOR RETURN/SHOW NINJA
            CreateMap<Entities.Ninja, Models.NinjaWithoutJutsusDto>(); //FOR RETURN/SHOW NINJA
            CreateMap<Models.NinjaForCreationDto, Entities.Ninja>();
            CreateMap<Models.NinjaForUpdateDto, Entities.Ninja>();
        }
    }
}

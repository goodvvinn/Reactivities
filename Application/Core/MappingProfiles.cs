namespace Application.Core
{
    using AutoMapper;
    using Domain;
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Activity, Activity>();
        }
    }
}

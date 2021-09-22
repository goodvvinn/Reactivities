namespace Application.Core
{
    using System.Linq;
    using Application.Activities;
    using AutoMapper;
    using Domain;
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Activity, Activity>();
            CreateMap<Activity, ActivityDto>()
            .ForMember(h => h.HostUsername, o => o.MapFrom(s => s.Attendees.FirstOrDefault(x => x.IsHost).AppUser.UserName));
            CreateMap<ActivityAttendee, Profiles.Profile>()
            .ForMember(h => h.DisplayName, o => o.MapFrom(s => s.AppUser.DisplayName))
            .ForMember(h => h.Username, o => o.MapFrom(s => s.AppUser.UserName))
            .ForMember(h => h.Bio, o => o.MapFrom(s => s.AppUser.Bio));
        }
    }
}

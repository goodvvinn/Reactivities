namespace Application.Core
{
    using System.Linq;
    using Application.Activities;
    using Application.Comments;
    using AutoMapper;
    using Domain;
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Activity, Activity>();

            CreateMap<Activity, ActivityDto>()
            .ForMember(h => h.HostUsername, o => o.MapFrom(s => s.Attendees.FirstOrDefault(x => x.IsHost).AppUser.UserName));

            CreateMap<ActivityAttendee, AttendeeDto>()
            .ForMember(h => h.DisplayName, o => o.MapFrom(s => s.AppUser.DisplayName))
            .ForMember(h => h.Username, o => o.MapFrom(s => s.AppUser.UserName))
            .ForMember(h => h.Bio, o => o.MapFrom(s => s.AppUser.Bio))
            .ForMember(h => h.Image, o => o.MapFrom(s => s.AppUser.Photos.FirstOrDefault(x => x.IsMain).Url));

            CreateMap<AppUser, Profiles.Profile>()
            .ForMember(h => h.Image, o => o.MapFrom(s => s.Photos.FirstOrDefault(x => x.IsMain).Url));

            CreateMap<Comment, CommentDto>()
            .ForMember(h => h.DisplayName, o => o.MapFrom(s => s.Author.DisplayName))
            .ForMember(h => h.Username, o => o.MapFrom(s => s.Author.UserName))
            .ForMember(h => h.Image, o => o.MapFrom(s => s.Author.Photos.FirstOrDefault(x => x.IsMain).Url));
        }
    }
}

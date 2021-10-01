namespace Application.Core
{
    using System.Linq;
    using Application.Activities;
    using Application.Comments;
    using Application.Profiles;
    using Domain;
    public class MappingProfiles : AutoMapper.Profile
    {
        public MappingProfiles()
        {
            string currentUsername = null;
            CreateMap<Activity, Activity>();

            CreateMap<Activity, ActivityDto>()
            .ForMember(h => h.HostUsername, o => o.MapFrom(s => s.Attendees.FirstOrDefault(x => x.IsHost).AppUser.UserName));

            CreateMap<ActivityAttendee, AttendeeDto>()
            .ForMember(h => h.DisplayName, o => o.MapFrom(s => s.AppUser.DisplayName))
            .ForMember(h => h.Username, o => o.MapFrom(s => s.AppUser.UserName))
            .ForMember(h => h.Bio, o => o.MapFrom(s => s.AppUser.Bio))
            .ForMember(h => h.Image, o => o.MapFrom(s => s.AppUser.Photos.FirstOrDefault(x => x.IsMain).Url))
            .ForMember(f => f.FollowersCount, o => o.MapFrom(s => s.AppUser.Followers.Count))
            .ForMember(f => f.FollowingCount, o => o.MapFrom(s => s.AppUser.Followings.Count))
            .ForMember(m => m.Following, o => o.MapFrom(s => s.AppUser.Followers.Any(a => a.Observer.UserName == currentUsername)));

            CreateMap<AppUser, Profiles.Profile>()
            .ForMember(h => h.Image, o => o.MapFrom(s => s.Photos.FirstOrDefault(x => x.IsMain).Url))
            .ForMember(f => f.FollowersCount, o => o.MapFrom(s => s.Followers.Count))
            .ForMember(f => f.FollowingCount, o => o.MapFrom(s => s.Followings.Count))
            .ForMember(m => m.Following, o => o.MapFrom(s => s.Followers.Any(a => a.Observer.UserName == currentUsername)));

            CreateMap<Comment, CommentDto>()
            .ForMember(h => h.DisplayName, o => o.MapFrom(s => s.Author.DisplayName))
            .ForMember(h => h.Username, o => o.MapFrom(s => s.Author.UserName))
            .ForMember(h => h.Image, o => o.MapFrom(s => s.Author.Photos.FirstOrDefault(x => x.IsMain).Url));

            CreateMap<ActivityAttendee, UserActivityDto>()
            .ForMember(d => d.Id, o => o.MapFrom(s => s.Activity.Id))
            .ForMember(d => d.Date, o => o.MapFrom(s => s.Activity.Date))
            .ForMember(d => d.Title, o => o.MapFrom(s => s.Activity.Title))
            .ForMember(d => d.Category, o => o.MapFrom(s => s.Activity.Category))
            .ForMember(d => d.HostUsername, o => o.MapFrom(s => s.Activity.Attendees.FirstOrDefault(h => h.IsHost).AppUser.UserName));
        }
    }
}

namespace Persistence
{
    using Domain;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    public class DataContext : IdentityDbContext<AppUser>
    {
        public DataContext(DbContextOptions options)
        : base(options)
        {
        }

        public DbSet<Activity> Activities { get; set; }
        public DbSet<ActivityAttendee> ActivitiyAttendees { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<ActivityAttendee>(x => x.HasKey(aa => new { aa.AppUserId, aa.ActivityId }));
            
            builder.Entity<ActivityAttendee>()
            .HasOne(h => h.AppUser)
            .WithMany(w => w.Activities)
            .HasForeignKey(aa => aa.AppUserId);

            builder.Entity<ActivityAttendee>()
            .HasOne(h => h.Activity)
            .WithMany(w => w.Attendees)
            .HasForeignKey(aa => aa.ActivityId);
        }
    }
}

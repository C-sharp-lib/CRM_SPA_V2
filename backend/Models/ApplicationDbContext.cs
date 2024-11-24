using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace backend.Models
{
    public class ApplicationDbContext(DbContextOptions options) : IdentityDbContext<AppUser, AppRole, string, 
        IdentityUserClaim<string>, AppUserRole, IdentityUserLogin<string>, IdentityRoleClaim<string>, IdentityUserToken<string>>(options)
    {
        public DbSet<Contacts> Contacts { get; set; }
        public DbSet<Customers> Customers { get; set; }
        public DbSet<CustomerActivities> CustomerActivities { get; set; }
        public DbSet<CustomerRelationships> CustomerRelationships { get; set; }
        public DbSet<CustomerSegments> CustomerSegments { get; set; }
        public DbSet<Jobs> Jobs { get; set; }
        public DbSet<Leads> Leads { get; set; }
        public DbSet<LeadHistory> LeadHistory { get; set; }
        public DbSet<LeadActivities> LeadActivities { get; set; }
        public DbSet<Notes> Notes { get; set; }
        public DbSet<Orders> Orders { get; set; }
        public DbSet<OrderItems> OrderItems { get; set; }
        public DbSet<Products> Products { get; set; }
        public DbSet<Tasks> Tasks { get; set; }
        public DbSet<TaskAttachments> TaskAttachments { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<AppUser>()
                .HasMany(ur => ur.UserRoles)
                .WithOne(ur => ur.User)
                .HasForeignKey(ur => ur.UserId)
                .IsRequired();
            modelBuilder.Entity<AppUser>()
                .HasMany(c => c.Customers)
                .WithOne(c => c.CreatedByUser)
                .HasForeignKey(c => c.CreatedBy);
            modelBuilder.Entity<AppUser>()
                .HasMany(j => j.Jobs)
                .WithOne(j => j.CreatedByUser)
                .HasForeignKey(j => j.CreatedBy);
            modelBuilder.Entity<AppUser>()
                .HasMany(t => t.Tasks)
                .WithOne(t => t.CreatedByUser)
                .HasForeignKey(t => t.CreatedBy);
            modelBuilder.Entity<AppRole>()
               .HasMany(ur => ur.UserRoles)
               .WithOne(ur => ur.Role)
               .HasForeignKey(ur => ur.RoleId)
               .IsRequired();
            modelBuilder.Entity<Customers>()
                .HasKey(c => c.CustomerId);
            modelBuilder.Entity<Contacts>()
                .HasKey(c => c.ContactId);
            modelBuilder.Entity<CustomerActivities>()
                .HasKey(c => new { c.ActivityId, c.CustomerId });
            modelBuilder.Entity<CustomerRelationships>()
                .HasKey(c => new { c.RelationshipId, c.CustomerId, c.RelatedCustomerId });
            modelBuilder.Entity<CustomerSegments>()
                .HasKey(c => new { c.SegmentId, c.CustomerId });
            modelBuilder.Entity<Jobs>()
                .HasKey(j => new { j.JobId, j.AssignedTo, j.CustomerId, j.LastUpdatedBy, j.CreatedBy });
            modelBuilder.Entity<Leads>()
                .HasKey(l => new { l.LeadId, l.CustomerId, l.UpdatedBy, l.AssignedTo });
            modelBuilder.Entity<LeadActivities>()
                .HasKey(l => new { l.LeadId, l.LeadActivitiesId, l.CreatedBy });
            modelBuilder.Entity<LeadHistory>()
                .HasKey(l => new { l.LeadId, l.LeadHistoryId, l.UpdatedBy });
            modelBuilder.Entity<Notes>()
                .HasKey(n => new { n.UserId, n.NoteId });
            modelBuilder.Entity<Orders>()
                .HasKey(o => new {o.OrderId, o.CustomerId, o.UserId, o.LastUpdatedBy });
            modelBuilder.Entity<OrderItems>()
                .HasKey(o => new { o.OrderId, o.OrderItemId, o.ProductId });
            modelBuilder.Entity<Products>()
                .HasKey(p => new { p.ProductId });
            modelBuilder.Entity<Tasks>()
                .HasKey(t => new {t.TaskId, t.CreatedBy, t.UpdatedBy, t.AssignedTo});
            modelBuilder.Entity<TaskAttachments>()
                .HasKey(t => new { t.TaskId, t.TaskAttachmentId, t.UploadedBy});
        }
    }
}

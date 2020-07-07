using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Diagnostics;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using VocabHero.Data.Tables;

namespace VocabHero.Data
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        //Extended properties
        public string DisplayName { get; set; }
        public ICollection<UserFlashCard> UserFlashCards { get; set; }


        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            userIdentity.AddClaim(new Claim("DisplayName", this.DisplayName.ToString()));

            return userIdentity;
        }

        

        public string GetUserID()
        {
            ApplicationUser user = new ApplicationUser();
            string userId = user.Id;
            return userId;

        }

        public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
        {
            public ApplicationDbContext()
                : base("DefaultConnection", throwIfV1Schema: false)
            {
            }

            public static ApplicationDbContext Create()
            {
                return new ApplicationDbContext();
            }

            public DbSet<FlashCard> FlashCards { get; set; }
            public DbSet<UserFlashCard> UserFlashCards { get; set; }
            public DbSet<FlashCardUserAttempt> FlashCardUserAttempts { get; set; }


            protected override void OnModelCreating(DbModelBuilder modelBuilder)
            {
                modelBuilder
                .Conventions
                .Remove<PluralizingTableNameConvention>();

                modelBuilder
                    .Configurations
                    .Add(new IdentityUserLoginConfiguration())
                    .Add(new IdentityUserRoleConfiguration());


                
    //ARE THESE IN THE WRONG PLACE?
                modelBuilder.Entity<FlashCard>()
                    .HasMany(c => c.UserFlashCards)
                    .WithRequired(u => u.FlashCard)
                    .HasForeignKey(k => k.FlashCardId)
                    .WillCascadeOnDelete(false);

                modelBuilder.Entity<ApplicationUser>()
                    .HasMany(c => c.UserFlashCards)
                    .WithRequired(u => u.AppUser)
                    .HasForeignKey(k => k.UserID)
                    .WillCascadeOnDelete(false);
               
                modelBuilder.Entity<UserFlashCard>()
                    .HasRequired(u => u.AppUser)
                    .WithMany(c => c.UserFlashCards)
                    .HasForeignKey(k => k.UserID)
                    .WillCascadeOnDelete(false);

                modelBuilder.Entity<UserFlashCard>()
                    .HasRequired(f => f.FlashCard)
                    .WithMany(c => c.UserFlashCards)
                    .HasForeignKey(k => k.FlashCardId)
                    .WillCascadeOnDelete(false);

                modelBuilder.Entity<FlashCardUserAttempt>()
                    .HasRequired(u => u.UserFlashCard)
                    .WithMany(a => a.UserAttempts)
                    .HasForeignKey(k => k.UserCardId)
                    .WillCascadeOnDelete(false);

            }
        }

        public class IdentityUserLoginConfiguration : EntityTypeConfiguration<IdentityUserLogin>
        {
            public IdentityUserLoginConfiguration()
            {
                HasKey(iul => iul.UserId);
            }
        }

        public class IdentityUserRoleConfiguration : EntityTypeConfiguration<IdentityUserRole>
        {
            public IdentityUserRoleConfiguration()
            {
                HasKey(iur => iur.UserId);
            }
        }

    }


}
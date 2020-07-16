using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Diagnostics;
using System.Dynamic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Xml.XPath;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using VocabHero.Data.Tables;

namespace VocabHero.Data
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        //Extended properties
        
       
        public ICollection<UserFlashCard> UserFlashCards { get; set; }
        public ICollection<FlashCardUserAttempt> FlashCardUserAttempts { get; set; }


       

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            

            return userIdentity;
        }


        //public int GetTotalXP()
        //{
        //    ApplicationUser user = new ApplicationUser();

        //    List<FlashCardUserAttempt> userAttempts = user.FlashCardUserAttempts.ToList();
        //    int totalXP = 0;
        //    foreach (var item in userAttempts)
        //    {
        //        totalXP += item.XPGained;
        //    }
        //    return totalXP;

        //}

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
               

                modelBuilder.Entity<ApplicationUser>()
                    .HasMany(c => c.UserFlashCards)
                    .WithRequired(u => u.ApplicationUser)
                    .HasForeignKey(k => k.UserId)
                    .WillCascadeOnDelete(false);
               
                modelBuilder.Entity<UserFlashCard>()
                    .HasRequired(u => u.ApplicationUser)
                    .WithMany(c => c.UserFlashCards)
                    .HasForeignKey(k => k.UserId)
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
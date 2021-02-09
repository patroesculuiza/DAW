
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
namespace lab6.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        /*
        public virtual Room Room { get; set; }
        public virtual ICollection<Utility> Utilities { get; set; }
*/
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
        
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
            //Database.SetInitializer<ApplicationDbContext>(new Initp());

        }

        public DbSet<Room> Rooms { get; set; }
       // public DbSet<Furniture> Furnitures{ get; set; }
        //public DbSet<Utility> Utilities { get; set; }
        //public DbSet<Rezervation> Rezervations{ get; set; }

        /*
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //sau Room 
            modelBuilder.Entity<Rezervation>()
                .HasRequired(f => f.Persone)
                .WithMany()
                .WillCascadeOnDelete(false);
        }
        */
       // public DbSet<Room> Rooms { get; set; }
        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext(); ;

        }
    }
    
   
    
}
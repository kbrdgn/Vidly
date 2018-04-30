using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Vidly2.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        [Required]
        [RegularExpression(@"^(\d{4})$", ErrorMessage =
            "Lütfen TC kimlik numaranızın son 4 hanesini doğru bir şekilde girdiğinizden emin olunuz.")]
        public string TcSon4Hane { get; set; }

        [Required] [StringLength(50)] public string Telefon { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<Models.ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }

        public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
        {
            public DbSet<Musteri> Musteriler { get; set; } // Represents the Customer table in the database.
            public DbSet<Film> Filmler { get; set; }
            public DbSet<UyelikTuru> UyelikTurleri { get; set; }
            public DbSet<Tur> Turler { get; set; }

            public ApplicationDbContext()
                : base("DefaultConnection", throwIfV1Schema: false)
            {
            }

            public static ApplicationDbContext Create()
            {
                return new ApplicationDbContext();
            }
        }
    }
}
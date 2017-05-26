using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ClinicaVeterinaria.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class VetsDB : IdentityDbContext<ApplicationUser>
    {
        //contrutor, para referenciar a BD
        public VetsDB()
            : base("LocalizacaoDaBD", throwIfV1Schema: false)
        {
        }

        static VetsDB()
        {
            // Set the database intializer which is run once during application start
            // This seeds the database with admin user credentials and admin role
            Database.SetInitializer<VetsDB>(new ApplicationDbInitializer());
        }

        public static VetsDB Create()
        {
            return new VetsDB();
        }

        //#######################################################################
        //######################Inserir aqui as tabelas##########################

        //representar as tabelas a criar na Base de Dados
        public virtual DbSet<Donos> Donos { get; set; }

        public virtual DbSet<Animais> Animais { get; set; }

        public virtual DbSet<Veterinarios> Veterinarios { get; set; }

        public virtual DbSet<Consultas> Consultas { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder) {
            // não podemos usar a chave seguinte, nesta geração de tabelas
            // por causa das tabelas do Identity (gestão de utilizadores)
            // modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            base.OnModelCreating(modelBuilder);
        }
    }
}
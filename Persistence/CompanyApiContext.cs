using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using CompanyApi.Models;

namespace CompanyApi.Persistence
{
    public class CompanyApiContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public CompanyApiContext() : base("name=CompanyApiContext")
        {
            this.Configuration.LazyLoadingEnabled = false;
        }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            /*modelBuilder.Entity<Company>()
                .HasMany(c => c.Contacts)
                .WithMany(i => i.Companies)
                .Map(t => t.MapLeftKey("CompanyId")
                    .MapRightKey("ContactId")
                    .ToTable("CompanyContact"));*/

            modelBuilder.Entity<Person>()
                .Map<Employee>(m => m.Requires("Discriminator").HasValue("EMP"))
                .Map<Freelance>(m => m.Requires("Discriminator").HasValue("FRE"));

            base.OnModelCreating(modelBuilder);
        }



        public System.Data.Entity.DbSet<Company> Companies { get; set; }

        public System.Data.Entity.DbSet<Employee> Employees { get; set; }
        
        public System.Data.Entity.DbSet<Freelance> Freelances { get; set; }

        public System.Data.Entity.DbSet<Address> Addresses { get; set; }

        public System.Data.Entity.DbSet<Person> People { get; set; }
    }
}

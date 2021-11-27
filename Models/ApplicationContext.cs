using Microsoft.EntityFrameworkCore;

namespace Rocket_Elevators_REST_API.Models
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
        }

        public DbSet<Battery> batteries { get; set; }
        public DbSet<Column> columns { get; set; }
        public DbSet<Elevator> elevators { get; set; }
        public DbSet<Building> buildings { get; set; }
        public DbSet<Lead> leads { get; set; }
        public DbSet<Customer> customers { get; set; }
        public DbSet<Address> addresses {get; set;}

    }
    public class PostgreApplicationContext : DbContext {
        public PostgreApplicationContext(DbContextOptions<PostgreApplicationContext> options)
            : base(options)
            {}
        public DbSet<FactIntervention> fact_interventions {get; set;}

    }
}
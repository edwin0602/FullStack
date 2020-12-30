using Microsoft.EntityFrameworkCore;
using RestBackend.Core.Models.Business;
using RestBackend.Data.Configurations;
using System.Threading.Tasks;

namespace RestBackend.Data
{
    public class RestBackendDbContext : DbContext
    {
        public DbSet<Vehicle> Vehicles { get; set; }

        public DbSet<VehicleBrand> VehicleBrands { get; set; }

        public DbSet<VehicleType> VehicleTypes { get; set; }

        public RestBackendDbContext(DbContextOptions<RestBackendDbContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder
                .ApplyConfiguration(new VehicleConfiguration())
                .ApplyConfiguration(new VehicleBrandConfiguration())
                .ApplyConfiguration(new VehicleTypeConfiguration());

            DataSeed(builder);
        }

        private void DataSeed(ModelBuilder builder)
        {
            #region [ Default VehicleBrand ]

            builder.Entity<VehicleBrand>().HasData(
               new VehicleBrand
               {
                   Name = "BMW",
                   Id = 1
               },
               new VehicleBrand
               {
                   Name = "Mazda",
                   Id = 2
               },
               new VehicleBrand
               {
                   Name = "Audi",
                   Id = 3
               },
               new VehicleBrand
               {
                   Name = "Tesla",
                   Id = 4
               }
           );

            #endregion

            #region [ Default VehicleType ]

            builder.Entity<VehicleType>().HasData(
               new VehicleType
               {
                   Name = "Bicicleta",
                   Description = "Ciclo de dos ruedas.",
                   Id = 1
               },
               new VehicleType
               {
                   Name = "Automóvil",
                   Description = "Automóvil especialmente concebido y construido para el transporte de personas.",
                   Id = 2
               },
               new VehicleType
               {
                   Name = "Autobus",
                   Description = "Automóvil para el transporte de más de 9 personas incluido el conductor, cuya masa máxima autorizada no exceda de 3.500 kg.",
                   Id = 3
               }
           );

            #endregion
        }

        public async Task<int> SaveChangesAsync()
        {
            return await base.SaveChangesAsync();
        }
    }
}

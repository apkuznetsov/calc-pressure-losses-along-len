using calc_pressure_losses_along_len.Dtos;
using System.Data.Entity;

namespace calc_pressure_losses_along_len.Db
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext() : base("DefaultConnection") { }

        public DbSet<EquivalentPipeRoughness> Roughness { get; set; }

        public DbSet<KinematicViscosityCoefficients> Coefficients { get; set; }
    }
}

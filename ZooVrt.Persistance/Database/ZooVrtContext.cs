using Microsoft.EntityFrameworkCore;
using ZooVrt.Domain.Entities;

namespace ZooVrt.Persistance.Database
{
    public class ZooVrtContext: DbContext
    {
        public ZooVrtContext() { }
        public ZooVrtContext(DbContextOptions<ZooVrtContext> contextOptions) : base(contextOptions) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }

        public DbSet<Lokacija> Lokacije { get; set; }
        public DbSet<TipStanista> TipoviStanista { get; set; }
        public DbSet<Domain.Entities.ZooVrt> ZooVrt { get; set; }
    }
}

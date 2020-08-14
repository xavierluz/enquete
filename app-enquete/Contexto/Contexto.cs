using app_enquete.Domain;
using app_enquete.Maps;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;

namespace app_enquete.contexto
{
    public class Contexto : DbContext
    {
        public DbSet<Poll> Polls { get; set; }
        private Contexto([NotNullAttribute] DbContextOptions<Contexto> options) : base(options)
        {
        }

        internal static Contexto Create(DbContextOptions<Contexto> options)
        {
            return new Contexto(options);
        }
        public override void Dispose()
        {
            base.Dispose();
        }

        public override ValueTask DisposeAsync()
        {
            return base.DisposeAsync();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            EnqueteMap.Create(modelBuilder);
        }


    }
}

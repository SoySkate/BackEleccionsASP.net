
using BackEleccionsM.Models;
using Microsoft.EntityFrameworkCore;

namespace BackEndEleccions.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options):base(options) 
        {
        
        }

        public DbSet<Municipi> Municipis { get; set; }
        public DbSet<PartitPolitic> PartitsPolitics { get; set; }
        public DbSet<Candidat> Candidats { get; set; }
        public DbSet<TaulaElectoral> TaulesElectorals { get; set; }
        public DbSet<ResultatsTaula> ResultatsTaules { get; set; }
        public DbSet<VotsPerPartit> VotsPerPartit { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Relación entre TaulaElectoral y ResultatsTaula
            modelBuilder.Entity<TaulaElectoral>()
                .HasOne(te => te.ResultatsTaula) // TaulaElectoral tiene uno ResultatsTaula
                .WithOne() // ResultatsTaula tiene una TaulaElectoral
                .HasForeignKey<ResultatsTaula>(r => r.TaulaElectoralId) // La clave foránea está en ResultatsTaula
                .OnDelete(DeleteBehavior.Cascade);

            // Relación entre Municipi y PartitPolitic
            modelBuilder.Entity<Municipi>()
                .HasMany(m => m.LlistaPartits) // Un Municipi tiene muchos PartitPolitic
                .WithOne() // Un PartitPolitic pertenece a un Municipi
                .OnDelete(DeleteBehavior.Cascade);

            // Relación entre Municipi y TaulaElectoral
            modelBuilder.Entity<Municipi>()
                .HasMany(m => m.TaulesElectorals) // Un Municipi tiene muchas TaulaElectoral
                .WithOne(t=> t.Municipi)        // Una TaulaElectoral pertenece a un Municipi
                .HasForeignKey(m=>m.MunicipiId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<PartitPolitic>()
                .HasMany(p=>p.Vots)
                .WithOne(v=>v.Partit)
                .HasForeignKey(v=>v.PartitId)
                 .OnDelete(DeleteBehavior.Cascade);
            // Relación entre PartitPolitic y Candidat
            modelBuilder.Entity<PartitPolitic>()
                .HasMany(p => p.Candidats) // Un PartitPolitic tiene muchos Candidats
                .WithOne(c=>c.PartitPolitic) // Un Candidat pertenece a un PartitPolitic
                .HasForeignKey(p => p.PartitPoliticId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<PartitPolitic>()
                .HasOne(p=>p.Municipi)
                .WithMany(p=>p.LlistaPartits)
                .HasForeignKey(m=>m.MunicipiId)
               .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<TaulaElectoral>()
              .HasOne(p => p.Municipi)
              .WithMany(p => p.TaulesElectorals)
              .HasForeignKey(m => m.MunicipiId)
              .OnDelete(DeleteBehavior.Cascade);
            // Relación entre ResultatsTaula y VotsPerPartit
            modelBuilder.Entity<ResultatsTaula>()
                .HasMany(r => r.VotsPartit) // ResultatsTaula tiene muchos VotsPerPartit
                .WithOne(v => v.ResultatsTaula) // VotsPerPertit pertenece a un ResultatsTaula
                .HasForeignKey(v => v.ResultatsTaulaId) // Establecemos la clave foránea
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<VotsPerPartit>()
              .HasOne(v => v.Partit)
              .WithMany(r => r.Vots)
              .HasForeignKey(v=>v.PartitId)
              .OnDelete(DeleteBehavior.Restrict);

        }
    }
}

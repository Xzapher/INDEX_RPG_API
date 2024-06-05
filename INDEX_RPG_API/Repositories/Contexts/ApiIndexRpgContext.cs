using INDEX_RPG_API.Repositories.Models;
using Microsoft.EntityFrameworkCore;

namespace INDEX_RPG_API.Models
{
    public partial class ApiIndexRpgContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public ApiIndexRpgContext(DbContextOptions<ApiIndexRpgContext> options, IConfiguration configuration)
            : base(options)
        {
            _configuration = configuration;
        }

        public virtual DbSet<CharacterStat> CharacterStats { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(_configuration.GetConnectionString("connection"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CharacterStat>(entity =>
            {
                entity.ToTable("Character_Stats");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");
                entity.Property(e => e.Damage).HasColumnName("damage");
                entity.Property(e => e.Health).HasColumnName("health");
                entity.Property(e => e.Mana).HasColumnName("mana");
                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("name");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

using Microsoft.EntityFrameworkCore;
using Tabu.Entities;

namespace Tabu.DAL
{
    public class TabuDbContext : DbContext

    {
        public TabuDbContext(DbContextOptions options) : base(options) 
        { 
        }
        public DbSet<Language> Languages { get; set; }
        public DbSet<Word> Wordss { get; set; }
        public DbSet<BannedWord> BannedWords { get; set; }
        public DbSet<Game> Games { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Language>(b =>
            {
                b.HasKey(x => x.Code);
                b.HasIndex(x => x.Name)
                .IsUnique();
                b.Property(x => x.Code)
                .IsFixedLength(true)
                .HasMaxLength(2);
                b.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(32);
                b.Property(x => x.Icon)
                .HasMaxLength(400);
                b.HasData(new Language
                {
                    Code = "az",
                    Name = "Azərbaycan",
                    Icon = "https://upload.wikimedia.org/wikipedia/commons/thumb/d/dd/Flag_of_Azerbaijan.svg/1200px-Flag_of_Azerbaijan.svg.png"
                });
            });
            modelBuilder.Entity<Word>(b =>
            {
                b.Property(x => x.Text)
                .IsRequired()
                .HasMaxLength(32);
                b.HasOne(x => x.Language)
                .WithMany(x => x.Words)
                .HasForeignKey(x => x.LanguageCode);
                b.HasMany(x => x.BannedWords)
                .WithOne(x => x.Word)
                .HasForeignKey(x => x.WordId);
            });
            base.OnModelCreating(modelBuilder);
        }

    }
}

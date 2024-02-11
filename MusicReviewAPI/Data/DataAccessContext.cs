using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MusicReviewAPI.Models;

namespace MusicReviewAPI.Data;

public class DataAccessContext : IdentityDbContext<User>
{
    public DataAccessContext(DbContextOptions<DataAccessContext> options) : base(options)
    {
        
    }
    
    public DbSet<Musician> Musicians { get; set; }
    public DbSet<Album> Albums { get; set; }
    public DbSet<Genre> Genres { get; set; }
    public DbSet<Band> Bands { get; set; }
    public DbSet<MusicianBand> MusicianBand { get; set; }
    public DbSet<Review> Reviews { get; set; }
    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<MusicianBand>()
            .HasKey(mb => new { mb.BandId, mb.MusicianId});
        modelBuilder.Entity<MusicianBand>()
            .HasOne(b => b.Musician)
            .WithMany(mb => mb.MusicianBands)
            .HasForeignKey(p => p.MusicianId);
        modelBuilder.Entity<MusicianBand>()
            .HasOne(b => b.Band)
            .WithMany(mb => mb.MusicianBands)
            .HasForeignKey(b => b.BandId);
    }
}
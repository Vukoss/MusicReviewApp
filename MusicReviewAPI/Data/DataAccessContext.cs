using Microsoft.AspNetCore.Identity;
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
    public DbSet<Review> Reviews { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Track> Tracks { get; set; }

    public DbSet<AlbumGenre> AlbumGenre { get; set; }
    public DbSet<BandGenre> BandGenre { get; set; }
    public DbSet<MusicianGenre> MusicianGenre { get; set; }
    public DbSet<MusicianBand> MusicianBand { get; set; }

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

        modelBuilder.Entity<AlbumGenre>()
            .HasKey(ag => new { ag.AlbumId, ag.GenreId });
        modelBuilder.Entity<AlbumGenre>()
            .HasOne(a => a.Album)
            .WithMany(ag => ag.AlbumGenres)
            .HasForeignKey(a => a.AlbumId);
        modelBuilder.Entity<AlbumGenre>()
            .HasOne(g => g.Genre)
            .WithMany(ag => ag.AlbumGenres)
            .HasForeignKey(g => g.GenreId);

        modelBuilder.Entity<BandGenre>()
            .HasKey(bg => new { bg.BandId, bg.GenreId });
        modelBuilder.Entity<BandGenre>()
            .HasOne(b => b.Band)
            .WithMany(bg => bg.BandGenres)
            .HasForeignKey(b => b.BandId);
        modelBuilder.Entity<BandGenre>()
            .HasOne(g => g.Genre)
            .WithMany(bg => bg.BandGenres)
            .HasForeignKey(g => g.GenreId);

        modelBuilder.Entity<MusicianGenre>()
            .HasKey(mg => new { mg.MusicianId, mg.GenreId });
        modelBuilder.Entity<MusicianGenre>()
            .HasOne(m => m.Musician)
            .WithMany(mg => mg.MusicianGenres)
            .HasForeignKey(m => m.MusicianId);
        modelBuilder.Entity<MusicianGenre>()
            .HasOne(g => g.Genre)
            .WithMany(mg => mg.MusicianGenres)
            .HasForeignKey(g => g.GenreId);

        const string defaultAdminUserName = "admin@admin.pl";
        const string defaultAdminPassword = "Admin.123";
        const string adminRoleName = "Administrator";

        var adminUser = new User
        {
            UserName = defaultAdminUserName,
            NormalizedUserName = defaultAdminUserName.ToUpper(),
            Email = defaultAdminUserName,
            NormalizedEmail = defaultAdminUserName.ToUpper(),
            EmailConfirmed = true
        };

        var adminRole = new IdentityRole
        {
            Name = adminRoleName,
            NormalizedName = adminRoleName.ToUpper()
        };

        modelBuilder.Entity<IdentityRole>().HasData(adminRole);

        var passwordHasher = new PasswordHasher<User>();

        adminUser.PasswordHash = passwordHasher.HashPassword(adminUser, defaultAdminPassword);

        modelBuilder.Entity<User>().HasData(adminUser);

        modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
        {
            RoleId = adminRole.Id,
            UserId = adminUser.Id
        });

        modelBuilder.Entity<Track>().HasData(
            new Track { Id = 1, TrackName = "Track_1_A1", AlbumId = 1 },
            new Track { Id = 2, TrackName = "Track_2_A1", AlbumId = 1 },
            new Track { Id = 3, TrackName = "Track_3_A1", AlbumId = 1 },
            new Track { Id = 4, TrackName = "Track_1_A2", AlbumId = 2 },
            new Track { Id = 5, TrackName = "Track_2_A2", AlbumId = 2 },
            new Track { Id = 6, TrackName = "Track_3_A2", AlbumId = 2 },
            new Track { Id = 7, TrackName = "Track_1_A3", AlbumId = 3 },
            new Track { Id = 8, TrackName = "Track_2_A3", AlbumId = 3 },
            new Track { Id = 9, TrackName = "Track_3_A3", AlbumId = 3 }
            );

        modelBuilder.Entity<Musician>().HasData(
            new Musician { Id = 1, FirstName = "John", LastName = "Travolta", Nickname = "Johnny" },
            new Musician { Id = 2, FirstName = "Winston", LastName = "Schmidt", Nickname = "Schmidt" },
            new Musician { Id = 3, FirstName = "Winston", LastName = "Bishop", Nickname = "Bishop" },
            new Musician { Id = 4, FirstName = "Jessica", LastName = "Day", Nickname = "Day" },
            new Musician { Id = 5, FirstName = "Nick", LastName = "Miller", Nickname = "Miller" },
            new Musician { Id = 6, FirstName = "Monicka", LastName = "Geller", Nickname = "Geller" },
            new Musician { Id = 7, FirstName = "Chandler", LastName = "Bing", Nickname = "Bing" },
            new Musician { Id = 8, FirstName = "Jack", LastName = "Geller", Nickname = "Geller" },
            new Musician { Id = 9, FirstName = "Will", LastName = "Smith", Nickname = "Smith" },
            new Musician { Id = 10, FirstName = "Leonardo", LastName = "DiCaprio", Nickname = "DiCaprio" }
            );

        modelBuilder.Entity<Album>().HasData(
            new Album { Id = 1, Name = "Album_1", Country = "Poland", Duration = 11.11, Label = "Kayah", BandId = 1 },
            new Album { Id = 2, Name = "Album_2", Country = "Poland", Duration = 11.11, Label = "Kayah", BandId = 1 },
            new Album { Id = 3, Name = "Album_3", Country = "Poland", Duration = 11.11, Label = "Kayah", BandId = 1 },
            new Album { Id = 4, Name = "Album_4", Country = "Poland", Duration = 11.11, Label = "Kayah", BandId = 2 },
            new Album { Id = 5, Name = "Album_5", Country = "Poland", Duration = 11.11, Label = "Kayah", BandId = 2 },
            new Album { Id = 6, Name = "Album_6", Country = "Poland", Duration = 11.11, Label = "Kayah", BandId = 2 },
            new Album { Id = 7, Name = "Album_7", Country = "Poland", Duration = 11.11, Label = "Kayah", BandId = 3 },
            new Album { Id = 8, Name = "Album_8", Country = "Poland", Duration = 11.11, Label = "Kayah", BandId = 3 },
            new Album { Id = 9, Name = "Album_9", Country = "Poland", Duration = 11.11, Label = "Kayah", BandId = 3 }
            );

        modelBuilder.Entity<Band>().HasData(
            new Band { Id = 1, Name = "Band_1", Country = "Poland", StartDate = DateTime.UtcNow},
            new Band { Id = 2, Name = "Band_2", Country = "Poland", StartDate = DateTime.UtcNow },
            new Band { Id = 3, Name = "Band_2", Country = "Poland", StartDate = DateTime.UtcNow }
            );

        modelBuilder.Entity<Review>().HasData(
            new Review { Id = 1, Text = "Best", Rating = 5, AlbumId = 1, UserId = adminUser.Id },
            new Review { Id = 2, Text = "Great", Rating = 4, AlbumId = 1, UserId = adminUser.Id },
            new Review { Id = 3, Text = "Good", Rating = 3, AlbumId = 1, UserId = adminUser.Id },
            new Review { Id = 4, Text = "Best", Rating = 5, AlbumId = 2, UserId = adminUser.Id },
            new Review { Id = 5, Text = "Great", Rating = 4, AlbumId = 2, UserId = adminUser.Id },
            new Review { Id = 6, Text = "Good", Rating = 3, AlbumId = 2, UserId = adminUser.Id },
            new Review { Id = 7, Text = "Best", Rating = 5, AlbumId = 3, UserId = adminUser.Id },
            new Review { Id = 8, Text = "Great", Rating = 4, AlbumId = 3, UserId = adminUser.Id },
            new Review { Id = 9, Text = "Good", Rating = 3, AlbumId = 3, UserId = adminUser.Id },

            new Review { Id = 10, Text = "Best", Rating = 5, BandId = 1, UserId = adminUser.Id },
            new Review { Id = 11, Text = "Great", Rating = 4, BandId = 1, UserId = adminUser.Id },
            new Review { Id = 12, Text = "Good", Rating = 3, BandId = 1, UserId = adminUser.Id },
            new Review { Id = 13, Text = "Best", Rating = 5, BandId = 2, UserId = adminUser.Id },
            new Review { Id = 14, Text = "Great", Rating = 4, BandId = 2, UserId = adminUser.Id },
            new Review { Id = 15, Text = "Good", Rating = 3, BandId = 2, UserId = adminUser.Id },
            new Review { Id = 16, Text = "Best", Rating = 5, BandId = 3, UserId = adminUser.Id },
            new Review { Id = 17, Text = "Great", Rating = 4, BandId = 3, UserId = adminUser.Id },
            new Review { Id = 18, Text = "Good", Rating = 3, BandId = 3, UserId = adminUser.Id },

            new Review { Id = 19, Text = "Best", Rating = 5, MusicianId = 1, UserId = adminUser.Id },
            new Review { Id = 20, Text = "Great", Rating = 4, MusicianId = 1, UserId = adminUser.Id },
            new Review { Id = 21, Text = "Good", Rating = 3, MusicianId = 1, UserId = adminUser.Id },
            new Review { Id = 22, Text = "Best", Rating = 5, MusicianId = 2, UserId = adminUser.Id },
            new Review { Id = 23, Text = "Great", Rating = 4, MusicianId = 2, UserId = adminUser.Id },
            new Review { Id = 24, Text = "Good", Rating = 3, MusicianId = 2, UserId = adminUser.Id },
            new Review { Id = 25, Text = "Best", Rating = 5, MusicianId = 3, UserId = adminUser.Id },
            new Review { Id = 26, Text = "Great", Rating = 4, MusicianId = 3, UserId = adminUser.Id },
            new Review { Id = 27, Text = "Good", Rating = 3, MusicianId = 3, UserId = adminUser.Id }
            );

        modelBuilder.Entity<Genre>().HasData(
            new Genre { Id = 1, GenreName = "Rock" },
            new Genre { Id = 2, GenreName = "Indie" },
            new Genre { Id = 3, GenreName = "Jazz" },
            new Genre { Id = 4, GenreName = "Smooth Jazz" },
            new Genre { Id = 5, GenreName = "Electronic" },
            new Genre { Id = 6, GenreName = "Pop" },
            new Genre { Id = 7, GenreName = "Indie Pop" },
            new Genre { Id = 8, GenreName = "Classic" },
            new Genre { Id = 9, GenreName = "Metal" }
            );

        modelBuilder.Entity<AlbumGenre>().HasData(
            new AlbumGenre { AlbumId = 1, GenreId = 1 },
            new AlbumGenre { AlbumId = 2, GenreId = 2 },
            new AlbumGenre { AlbumId = 3, GenreId = 3 },
            new AlbumGenre { AlbumId = 4, GenreId = 4 },
            new AlbumGenre { AlbumId = 5, GenreId = 5 },
            new AlbumGenre { AlbumId = 6, GenreId = 6 },
            new AlbumGenre { AlbumId = 7, GenreId = 7 },
            new AlbumGenre { AlbumId = 8, GenreId = 8 },
            new AlbumGenre { AlbumId = 9, GenreId = 9 }
            );

        modelBuilder.Entity<BandGenre>().HasData(
            new BandGenre { BandId = 1, GenreId = 1 },
            new BandGenre { BandId = 1, GenreId = 2 },
            new BandGenre { BandId = 1, GenreId = 3 },
            new BandGenre { BandId = 2, GenreId = 4 },
            new BandGenre { BandId = 2, GenreId = 5 },
            new BandGenre { BandId = 2, GenreId = 6 },
            new BandGenre { BandId = 3, GenreId = 7 },
            new BandGenre { BandId = 3, GenreId = 8 },
            new BandGenre { BandId = 3, GenreId = 9 }
            );

        modelBuilder.Entity<MusicianGenre>().HasData(
            new MusicianGenre { MusicianId = 1, GenreId = 1 },
            new MusicianGenre { MusicianId = 2, GenreId = 2 },
            new MusicianGenre { MusicianId = 3, GenreId = 3 },
            new MusicianGenre { MusicianId = 4, GenreId = 4 },
            new MusicianGenre { MusicianId = 5, GenreId = 5 },
            new MusicianGenre { MusicianId = 6, GenreId = 6 },
            new MusicianGenre { MusicianId = 7, GenreId = 7 },
            new MusicianGenre { MusicianId = 8, GenreId = 8 },
            new MusicianGenre { MusicianId = 9, GenreId = 9 },
            new MusicianGenre { MusicianId = 10, GenreId = 9}
            );

        modelBuilder.Entity<MusicianBand>().HasData(
            new MusicianBand { BandId = 1, MusicianId = 1 },
            new MusicianBand { BandId = 1, MusicianId = 2 },
            new MusicianBand { BandId = 1, MusicianId = 3 },
            new MusicianBand { BandId = 1, MusicianId = 4 },
            new MusicianBand { BandId = 2, MusicianId = 5 },
            new MusicianBand { BandId = 2, MusicianId = 6 },
            new MusicianBand { BandId = 2, MusicianId = 7 },
            new MusicianBand { BandId = 2, MusicianId = 8 },
            new MusicianBand { BandId = 3, MusicianId = 9 },
            new MusicianBand { BandId = 3, MusicianId = 10 }
            );
    }
}
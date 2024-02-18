using System.ComponentModel.DataAnnotations;

namespace MusicReviewAPI.Models;

public class Genre
{
    public int Id { get; set; }
    public string GenreName { get; set; }
    public ICollection<AlbumGenre>? AlbumGenres { get; set; }
    public ICollection<BandGenre>? BandGenres { get; set; }
    public ICollection<MusicianGenre>? MusicianGenres { get; set; }
    public ICollection<Track>? Tracks { get; set; }
}
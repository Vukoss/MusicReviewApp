using System.ComponentModel.DataAnnotations;

namespace MusicReviewAPI.Models;

public class Genre
{
    public int Id { get; set; }
    public string GenreName { get; set; }
    public ICollection<Album>? Albums { get; set; }
    public ICollection<Band>? Bands { get; set; }
    public ICollection<Musician>? Musicians { get; set; }
    public ICollection<Track>? Tracks { get; set; }
}
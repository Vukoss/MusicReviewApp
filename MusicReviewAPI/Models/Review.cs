using System.ComponentModel.DataAnnotations;

namespace MusicReviewAPI.Models;

public class Review
{
    public int Id { get; set; }
    public string Text { get; set; }
    public int Rating { get; set; }

    public string UserId { get; set; }
    public User User { get; set; }

    public int? AlbumId { get; set; }
    public Album? Album { get; set; }

    public int? TrackId{ get; set; }
    public Track? Track { get; set; }

    public int? BandId { get; set; }
    public Band? Band { get; set; }

    public int? MusicianId { get; set; }
    public Musician? Musician { get; set; }
}
namespace MusicReviewAPI.Models;

public class Album
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string? Country { get; set; }
    public string? Label { get; set; }
    public double? Duration { get; set; }
    public Band Band { get; set; }
    public int BandId { get; set; }
    public ICollection<Track> Tracks { get; set; }
    public ICollection<Review>? Reviews { get; set; }
    public ICollection<Genre>? Genres { get; set; }
}
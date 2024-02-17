namespace MusicReviewAPI.Models;

public class Track
{
	public int Id { get; set; }
	public string TrackName { get; set; }
	public int AlbumId { get; set; }
	public Album Album { get; set; }
	public ICollection<Genre>? Genres { get; set; }
	public ICollection<Review>? Reviews { get; set; }
}


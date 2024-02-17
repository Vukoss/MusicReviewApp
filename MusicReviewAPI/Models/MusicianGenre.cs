using System;
namespace MusicReviewAPI.Models
{
	public class MusicianGenre
	{
		public int MusicianId { get; set; }
		public int GenreId { get; set; }
		public Musician Musician { get; set; }
		public Genre Genre { get; set; }
	}
}


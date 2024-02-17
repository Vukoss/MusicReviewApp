using System;
namespace MusicReviewAPI.Models
{
	public class BandGenre
	{
        public int BandId { get; set; }
        public int GenreId { get; set; }
        public Band Band { get; set; }
        public Genre Genre { get; set; }
    }
}


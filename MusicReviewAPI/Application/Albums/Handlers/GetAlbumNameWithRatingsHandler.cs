using MediatR;
using Microsoft.EntityFrameworkCore;
using MusicReviewAPI.Application.Albums.Queries;
using MusicReviewAPI.Data;
using MusicReviewAPI.Models.DTOs;

namespace MusicReviewAPI.Application.Albums.Handlers
{
    public class GetAlbumNameWithRatingsHandler : IRequestHandler<GetAlbumNameWithRatingsQuery, AlbumWithRatingsDTO>
    {
        private readonly DataAccessContext _db;

        public GetAlbumNameWithRatingsHandler(DataAccessContext db)
        {
            _db = db;
        }

        public async Task<AlbumWithRatingsDTO> Handle(GetAlbumNameWithRatingsQuery request, CancellationToken cancellationToken)
        {
            var album = await _db.Albums.Include(a => a.Reviews).FirstOrDefaultAsync(a => a.Id == request.AlbumId);

            var ratings = new List<int>();

            if (album.Reviews != null)
            {
                ratings.AddRange(album.Reviews.Select(a => a.Rating));
            }

            var albumWithRatings = new AlbumWithRatingsDTO()
            {
                AlbumName = album.Name,
                Ratings = ratings
            };

            return albumWithRatings;
        }
    }
}


using MediatR;
using Microsoft.EntityFrameworkCore;
using MusicReviewAPI.Application.Albums.Queries;
using MusicReviewAPI.Data;

namespace MusicReviewAPI.Application.Albums.Handlers
{
	public class AlbumExistsHandler : IRequestHandler<AlbumExistsQuery, bool>
	{
        private readonly DataAccessContext _db;

        public AlbumExistsHandler(DataAccessContext db)
		{
            _db = db;
        }

        public async Task<bool> Handle(AlbumExistsQuery request, CancellationToken cancellationToken)
        {
            var result = await _db.Albums.AnyAsync(a => a.Id == request.AlbumId);
            return result;
        }
    }
}


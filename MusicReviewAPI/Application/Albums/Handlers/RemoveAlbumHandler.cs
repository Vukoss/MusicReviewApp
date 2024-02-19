using System;
using AutoMapper;
using MediatR;
using MusicReviewAPI.Application.Albums.Commands;
using MusicReviewAPI.Application.Albums.Queries;
using MusicReviewAPI.Data;
using MusicReviewAPI.Models;

namespace MusicReviewAPI.Application.Albums.Handlers
{
	public class RemoveAlbumHandler : IRequestHandler<RemoveAlbumCommand>
	{
        private readonly DataAccessContext _db;

        public RemoveAlbumHandler(DataAccessContext db)
        {
            _db = db;
        }

        public async Task Handle(RemoveAlbumCommand request, CancellationToken cancellationToken)
        {
            var album = _db.Albums.FirstOrDefault(a => a.Id == request.AlbumId);
            _db.Albums.Remove(album);
            await _db.SaveChangesAsync();
        }
    }
}


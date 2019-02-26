using Musi_Tech_.Data;
using Musi_Tech_.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Musi_Tech_.Services
{
    public class PlaylistService
    {
        private readonly Guid _userId;

        public PlaylistService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreatePlaylist(PlaylistCreate model)
        {
            var entity =
                new Playlist()
                {
                    OwnerID = _userId,
                    SongTitle = model.SongTitle,
                    Artist = model.Artist,
                    Genre = model.Genre
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Songs.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<PlaylistListItem> GetSongs()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Songs
                        .Where(e => e.OwnerID == _userId)
                        .Select(
                            e =>
                                new PlaylistListItem
                                {
                                    SongID = e.SongID,
                                    SongTitle = e.SongTitle,
                                    Artist = e.Artist,
                                    Genre = e.Genre
                                }
                        );

                return query.ToArray();
            }
        }

        public PlaylistDetail GetPlaylistById(int playlistID)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Songs
                        .Single(e => e.SongID == playlistID && e.OwnerID == _userId);
                return
                    new PlaylistDetail
                    {
                        SongID = entity.SongID,
                        SongTitle = entity.SongTitle,
                        Artist = entity.Artist,
                        Genre = entity.Genre,                     
                    };
            }
        }

        public bool UpdatePlaylist(PlaylistEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Songs
                        .Single(e => e.SongID == model.SongID && e.OwnerID == _userId);

                entity.SongTitle = model.SongTitle;
                entity.Artist = model.Artist;
                entity.Genre = model.Genre;
                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeletePlaylist(int songId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Songs
                        .Single(e => e.SongID == songId && e.OwnerID == _userId);

                ctx.Songs.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}

using System;

namespace RhythmsGonnaGetYou
{
    public class Song
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int TrackNumber { get; set; }
        public DateTime Duration { get; set; }
        public int AlbumId { get; set; }

        public Album TheAlbumAssociatedToTheSongObject { get; set; }
    }
}

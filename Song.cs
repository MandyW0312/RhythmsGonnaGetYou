using System;

namespace RhythmsGonnaGetYou
{
    class Song
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int TrackNumber { get; set; }
        public DateTime Duration { get; set; }
        public int AlbumId { get; set; }
    }
}

using System.Collections.Generic;

namespace RhythmsGonnaGetYou
{
    public class Position
    {
        public int Id { get; set; }
        public int BandId { get; set; }
        public Band TheAssociatedBand { get; set; }
        public int MusicianId { get; set; }
        public Musician TheAssociatedMusician { get; set; }
        public string BandPosition { get; set; }

    }
}

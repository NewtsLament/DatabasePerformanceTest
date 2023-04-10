using System;
using System.Collections.Generic;

namespace DatabasePerformanceTest.Models;

public partial class Song
{
    public string TrackId { get; set; } = null!;

    public DateTime? TimeStamp { get; set; }

    public string Artist { get; set; } = null!;

    public string Title { get; set; } = null!;

    public virtual ICollection<Similar> SimilarSimilarToTracks { get; } = new List<Similar>();

    public virtual ICollection<Similar> SimilarTracks { get; } = new List<Similar>();

    public virtual ICollection<SongsTag> SongsTags { get; } = new List<SongsTag>();
}

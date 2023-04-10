using System;
using System.Collections.Generic;

namespace DatabasePerformanceTest.Models;

public partial class Tag
{
    public int TagId { get; set; }

    public string? Title { get; set; }

    public virtual ICollection<SongsTag> SongsTags { get; } = new List<SongsTag>();
}

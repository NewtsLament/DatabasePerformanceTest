using System;
using System.Collections.Generic;

namespace DatabasePerformanceTest.Models;

public partial class Similar
{
    public string TrackId { get; set; } = null!;

    public string SimilarToTrackId { get; set; } = null!;

    public float Similarity { get; set; }

    public virtual Song SimilarToTrack { get; set; } = null!;

    public virtual Song Track { get; set; } = null!;
}

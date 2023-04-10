using System;
using System.Collections.Generic;

namespace DatabasePerformanceTest.Models;

public partial class SongsTag
{
    public string TrackId { get; set; } = null!;

    public int TagId { get; set; }

    public sbyte Weight { get; set; }

    public virtual Tag Tag { get; set; } = null!;

    public virtual Song Track { get; set; } = null!;
}

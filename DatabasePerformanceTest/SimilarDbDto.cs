using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabasePerformanceTest
{
    [PrimaryKey(nameof(SongTrackId),nameof(SimilarToTrackId))]
    internal class SimilarDbDto
    {
        [ForeignKey(nameof(SongDbDto.TrackId))]
        public string SongTrackId { get; set; }
        [ForeignKey(nameof(SongDbDto.TrackId))]
        public string SimilarToTrackId { get; set; }
        public SongDbDto SimilarTo { get; set; }
        public float Similarity { get; set; }
    }
}

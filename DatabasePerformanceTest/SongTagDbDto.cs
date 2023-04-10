using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabasePerformanceTest
{
    [PrimaryKey(nameof(TrackId), nameof(TagId))]
    internal class SongTagDbDto
    {
        [ForeignKey(nameof(SongDbDto))]
        public int TrackId { get; set; }
        public SongDbDto Song { get; set; }
        [ForeignKey(nameof(TagDbDto))]
        public int TagId { get; set; }
        public TagDbDto Tag { get; set; }
        public byte Weight { get; set; }
    }
}

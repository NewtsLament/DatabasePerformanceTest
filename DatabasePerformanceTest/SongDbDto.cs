using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabasePerformanceTest
{
    internal class SongDbDto
    {
        [Key]
        public string TrackId { get; set; }
        public string Title { get; set; }
        public string Artist { get; set; }
        public DateTime TimeStamp { get; set; }
        [ForeignKey(nameof(SimilarDbDto.SimilarToTrackId))]
        public ICollection<SimilarDbDto> Similars { get; set; }
        [ForeignKey(nameof(SongTagDbDto))]
        public ICollection<SongTagDbDto> SongTags { get; set; }
    }
}

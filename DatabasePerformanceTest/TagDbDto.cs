using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabasePerformanceTest
{
    internal class TagDbDto
    {
        [Key]
        public int TagId { get; set; }
        public string Title { get; set; }
        public ICollection<SongTagDbDto> SongTags { get; set; }
    }
}

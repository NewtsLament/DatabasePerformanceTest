using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabasePerformanceTest
{
    internal class SongsDbContext : DbContext
    {
        public DbSet<SongDbDto> Songs { get; set; }
        public DbSet<SimilarDbDto> Similars { get; set; }
        public DbSet<SongTagDbDto> SongTags { get; set; }
        public DbSet<TagDbDto> Tags { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(
                optionsBuilder.UseMySql(@"Server=localhost;Port=3306;user=forger;password=turpentine;database=lastfm.mariadb", ServerVersion.Create(new Version(10, 11, 2), Pomelo.EntityFrameworkCore.MySql.Infrastructure.ServerType.MariaDb))
                );
        }
    }
}

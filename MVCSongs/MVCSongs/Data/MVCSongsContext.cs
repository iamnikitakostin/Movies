using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MVCSongs.Models;

namespace MVCSongs.Data
{
    public class MVCSongsContext : DbContext
    {
        public MVCSongsContext (DbContextOptions<MVCSongsContext> options)
            : base(options)
        {
        }

        public DbSet<MVCSongs.Models.Song> Song { get; set; } = default!;
    }
}

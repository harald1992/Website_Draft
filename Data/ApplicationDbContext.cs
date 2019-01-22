using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Data.EntityModels;

namespace Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
        {
        }

        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<MusicTrack> MusicTracks{ get; set; }
        public virtual DbSet<WebshopItem> WebshopItems { get; set; }

    }
}

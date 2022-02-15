using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace AliyunSpotPriceHistoryQuery
{
    public class PricingContext : DbContext
    {
        public DbSet<SpotPrice> SpotPrices { get; set; }

        public string DbPath { get; }

        public PricingContext()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = System.IO.Path.Join(path, "pricing.db");
        }

        // The following configures EF to create a Sqlite database file in the
        // special "local" folder for your platform.
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite($"Data Source={DbPath}");
    }

    public class SpotPrice
    {
        public int Id { get; set; }
        public float PriceValue { get; set; }
        public float OriginPrice { get; set; }
        public string IoOptimized { get; set; }
        public string ZoneId { get; set; }
        public string NetworkType { get; set; }
        public string InstanceType { get; set; }
        public string Timestamp { get; set; }
    }

    // public class Post
    // {
    //     public int PostId { get; set; }
    //     public string Title { get; set; }
    //     public string Content { get; set; }

    //     public int BlogId { get; set; }
    //     public Blog Blog { get; set; }
    // }
}
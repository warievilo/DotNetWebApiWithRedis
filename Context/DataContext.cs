using System.Collections.Generic;
using DotNetWebApiWithRedis.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace DotNetWebApiWithRedis.Context
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base (options) { }

        public DbSet<Actor> Actor { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Actor>()
                .HasKey(a => new { a.Id });
            
            builder.Entity<Actor>()
                .HasData(new List<Actor>(){
                    new Actor(1, "Bradley Cooper", "male", new DateTime(1975, 01, 05)),
                    new Actor(2, "Brie Larson", "female", new DateTime(1989, 10, 01)),
                    new Actor(3, "Chris Hemsworth", "male", new DateTime(1983, 08, 11)),
                    new Actor(4, "Chris Evans", "male", new DateTime(1981, 06, 13)),
                    new Actor(5, "Chris Pratt", "male", new DateTime(1979, 06, 21)),
                    new Actor(6, "Leonardo DiCaprio", "male", new DateTime(1974, 11, 11)),
                    new Actor(7, "Kate Winslet", "female", new DateTime(1975, 10, 05)),
                    new Actor(8, "Zoë Saldaña", "female", new DateTime(1978, 06, 19)),  
            });           
        }        
    }
}
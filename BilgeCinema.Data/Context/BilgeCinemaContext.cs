using BilgeCinema.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BilgeCinema.Data.Context
{
    public class BilgeCinemaContext : DbContext
    {
        public BilgeCinemaContext(DbContextOptions<BilgeCinemaContext> options) : base (options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<MovieEntity>().HasQueryFilter(x => x.IsDeleted == false);

            // TODO: bu üstteki kod olmadan da istek atmayı dene.

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<MovieEntity> Movies => Set<MovieEntity>();
    }
}

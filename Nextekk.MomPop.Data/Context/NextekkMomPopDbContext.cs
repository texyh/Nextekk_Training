using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Nextekk.MomPop.Core.Models.Entities;

namespace Nextekk.MomPop.Data.Context
{
    public class NextekkMomPopDbContext : DbContext
    {
        public NextekkMomPopDbContext(DbContextOptions<NextekkMomPopDbContext> options) : base(options)
        {
            
        }

        public DbSet<ProductEntity> Products { get; set; }

        public DbSet<OrderItemEntity> OrderItems { get; set; }

        public DbSet<OrderEntity> Orders { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<OrderItemEntity>()
                .HasOne(x => x.Product).WithMany();

            builder.Entity<OrderEntity>().HasMany(x => x.OrderItems).WithOne().HasForeignKey(x => x.OrderId);
        }
        
    }
}

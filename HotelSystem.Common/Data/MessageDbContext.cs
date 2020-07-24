using HotelSystem.Common.Data.Configuration;
using HotelSystem.Common.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace HotelSystem.Common.Data
{
    public abstract class MessageDbContext : DbContext
    {
        protected MessageDbContext(DbContextOptions options)
            :base(options)
        {

        }

        public DbSet<Message> Messages { get; set; }

        protected abstract Assembly ConfigurationsAssembly { get; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new MessageConfiguration());

            builder.ApplyConfigurationsFromAssembly(this.ConfigurationsAssembly);

            base.OnModelCreating(builder);
        }
    }
}

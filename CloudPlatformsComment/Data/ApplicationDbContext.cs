using CloudPlatformsComment.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CloudPlatformsComment.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, int>
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Comment> Comments { get; set; }

        public DbSet<CloudPlatform> CloudPlatforms { get; set; }

        public DbSet<CloudPlatformListView> CloudPlatformList { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            //builder.Ignore<CloudPlatformListView>();
            //builder.Entity<CloudPlatformListView>()
            //    .ToTable("v_cloudplatform");

        }
    }
}

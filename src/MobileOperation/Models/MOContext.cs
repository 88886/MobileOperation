using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using CodeComb.AspNet.Upload.Models;

namespace MobileOperation.Models
{
    public class MOContext : IdentityDbContext<User>, IFileUploadDbContext
    {
        public DbSet<Flow> Flows { get; set; }

        public DbSet<FlowExecutor> FlowExecutors { get; set; }

        public DbSet<File> Files { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.SetupBlob();

            builder.Entity<User>(e =>
            {
                e.HasIndex(x => x.PhoneNumber);
                e.HasIndex(x => x.Position);
                e.HasIndex(x => x.PositionLevel);
                e.HasIndex(x => x.Department);
            });

            builder.Entity<Flow>(e =>
            {
                e.HasIndex(x => x.SpecificTime);
                e.HasIndex(x => x.AlarmTimeSpan);
                e.HasIndex(x => x.Type);
            });

            builder.Entity<FlowExecutor>(e =>
            {
                e.HasKey(x => new { x.FlowId, x.UserId });
                e.HasIndex(x => x.Status);
                e.HasIndex(x => x.ExecutedTime);
                e.HasIndex(x => x.ExecutingTime);
                e.HasIndex(x => x.ReadTime);
            });
        }
    }
}

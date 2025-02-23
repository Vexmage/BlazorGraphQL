using BlazorGraphQL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore.Migrations;
using System.Data.Common;

namespace BlazorGraphQL.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Book> Books { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite("Data Source=books.db");
        public DbSet<EfmigrationsLock> EfmigrationsLocks { get; set; } // Ensure it's properly mapped


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EfmigrationsLock>(entity =>
            {
                entity.ToTable("__EFMigrationsLock");
                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            base.OnModelCreating(modelBuilder);
        }
    }

    // Move this OUTSIDE AppDbContext
    public class DisableMigrationLockInterceptor : DbCommandInterceptor
    {
        public override InterceptionResult<int> NonQueryExecuting(
            DbCommand command,
            CommandEventData eventData,
            InterceptionResult<int> result)
        {
            if (command.CommandText.Contains("__EFMigrationsLock"))
            {
                return InterceptionResult<int>.SuppressWithResult(1); // Suppress execution
            }
            return base.NonQueryExecuting(command, eventData, result);
        }
    }
}

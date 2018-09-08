using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DotNetCore2.WebJob.TemplateProject.Data
{

    public partial class MyDbContext : DbContext
    {
        public MyDbContext()
        {
        }

        // Insert list of DbSets here - these can be auto-genreated by the dotnet core database first
        // code generation tools: https://docs.microsoft.com/en-us/ef/core/get-started/aspnetcore/existing-db

        public MyDbContext(DbContextOptions<MyDbContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}
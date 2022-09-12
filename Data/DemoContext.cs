using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Models;

namespace Data
{
    public partial class DemoContext : DbContext
    {
        private string _connectionString;
        public DbSet<Person> People { get; set; }
        public DemoContext()
        {
           //_connectionString = "Server=WILLIAMTRUNG\\MYSQL;Database=Demo;Trusted_Connection=True;";
        }
        public DemoContext(string _connectionString)
        {
            this._connectionString = _connectionString;
        }
        public DemoContext(DbContextOptions<DemoContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(_connectionString);
                //optionsBuilder.UseSqlServer("Server=WILLIAMTRUNG\\MYSQL;Database=Demo;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

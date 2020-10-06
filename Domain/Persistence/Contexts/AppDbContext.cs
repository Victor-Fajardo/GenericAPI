using GenericAPI.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GenericAPI.Domain.Persistence.Contexts
{
    public class AppDbContext : DbContext
    {
        //Creating a class object for each class
        public DbSet<ExampleClass> ExampleClasses { get; set; }

        //Setting AppDbContext to use default configuration
        public AppDbContext (DbContextOptions<AppDbContext> options): base(options)
        {}

        //Defining tables to be created
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            //Defining the table name (must be in plural)
            builder.Entity<ExampleClass>().ToTable("ExampleClasses");
            //Setting a table Key
            builder.Entity<ExampleClass>().HasKey(p => p.Id);
            //Setting the attributes properties
            builder.Entity<ExampleClass>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<ExampleClass>().Property(p => p.Data).IsRequired().HasMaxLength(20);
            //Addiong prexisting data
            builder.Entity<ExampleClass>().HasData
                (
                new ExampleClass { Id = 1, Data = "Data goes here" },
                new ExampleClass { Id = 2, Data = "Data goes here" }
                );
        }
    }
}

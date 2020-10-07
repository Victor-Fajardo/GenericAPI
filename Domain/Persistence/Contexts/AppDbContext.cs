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
        public DbSet<ExampleSubClass> ExampleSubClasses { get; set; }

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
            //Listing ExampleSubClass
            builder.Entity<ExampleClass>().HasMany(p => p.ExampleSubClasses)
                                          .WithOne(p => p.ExampleClass)
                                          .HasForeignKey(p => p.ExampleClassId);
            //Addiong prexisting data
            builder.Entity<ExampleClass>().HasData
                (
                new ExampleClass { Id = 1, Data = "Data goes here" },
                new ExampleClass { Id = 2, Data = "Data goes here" }
                );

            //Doing the same for the other class
            //Defining the table name (must be in plural)
            builder.Entity<ExampleSubClass>().ToTable("ExampleSubClasses");
            //Setting a table Key
            builder.Entity<ExampleSubClass>().HasKey(p => p.Id);
            //Setting the attributes properties
            builder.Entity<ExampleSubClass>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<ExampleSubClass>().Property(p => p.Data).IsRequired().HasMaxLength(20);
            //Addiong prexisting data
            builder.Entity<ExampleSubClass>().HasData
                (
                new ExampleSubClass { Id = 1, Data = "SubData goes here", ExampleClassId = 1 },
                new ExampleSubClass { Id = 2, Data = "SubData goes here", ExampleClassId = 1 }
                );
        }
    }
}

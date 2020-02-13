using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PeopleApi.Model
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
        public DbSet<Person> PersonList { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Person>().HasData(
                new Person
                {
                    Id = 1,
                    Name = "Luke",
                    DateOfBirth = DateTime.Parse("1/12/1900"),
                    Gender = Gender.Male,
                    HairColor = HairColor.Blonde,
                    Height = 1.80m,
                    Weight = 95.6m,
                },
                new Person
                {
                    Id = 2,
                    Name = "Tom",
                    DateOfBirth = DateTime.Parse("1/12/1900"),
                    Gender = Gender.Male,
                    HairColor = HairColor.Brunette,
                    Height = 1.80m,
                    Weight = 95.6m,
                },
                new Person
                {
                    Id = 3,
                    Name = "Mary",
                    DateOfBirth = DateTime.Parse("1/12/1900"),
                    Gender = Gender.Female,
                    HairColor = HairColor.Ginger,
                    Height = 1.80m,
                    Weight = 95.6m,
                }
        );
        }
    }
}

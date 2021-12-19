using LexiconWebApp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LexiconWebApp.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<PersonModel> People { get; set; }


        public DbSet<CountryModel> Countries { get; set; }
        public DbSet<CityModel> Cities { get; set; }

        public DbSet<LanguageModel> Languages { get; set; }
        public DbSet<PersonLanguageModel> Person_Language { get; set; }
        public  DbSet<ApplicationUser> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<PersonLanguageModel>().HasKey(p_l => new { p_l.PersonId, p_l.LanguageId });

            modelBuilder.Entity<PersonLanguageModel>().HasOne(p => p.Person).WithMany(p_l => p_l.Person_Language)
                .HasForeignKey(pi => pi.PersonId);

            modelBuilder.Entity<PersonLanguageModel>().HasOne(l => l.Language).WithMany(p_l => p_l.Person_Language)
                .HasForeignKey(li => li.LanguageId);


            // seeding countries
            modelBuilder.Entity<CountryModel>().HasData(
                new CountryModel { CountryId = 1, CountryName = "Germany" });
            modelBuilder.Entity<CountryModel>().HasData(
                new CountryModel { CountryId = 2, CountryName = "Italy" });
            modelBuilder.Entity<CountryModel>().HasData(
                new CountryModel { CountryId = 3, CountryName = "Sweden" });
            modelBuilder.Entity<CountryModel>().HasData(
                new CountryModel { CountryId = 4, CountryName = "Norway" });

            // seeding Cities

            modelBuilder.Entity<CityModel>().HasData(
                new CityModel { CityId = 1, CityName = "Roma", CountryId = 2 });
            modelBuilder.Entity<CityModel>().HasData(
                new CityModel { CityId = 2, CityName = "Berlin", CountryId = 1 });
            modelBuilder.Entity<CityModel>().HasData(
                new CityModel { CityId = 3, CityName = "Hanover", CountryId = 1 });
            modelBuilder.Entity<CityModel>().HasData(
                new CityModel { CityId = 4, CityName = "Gothenburg", CountryId = 3 });
            modelBuilder.Entity<CityModel>().HasData(
                new CityModel { CityId = 5, CityName = "Stockholm", CountryId = 3 });
            modelBuilder.Entity<CityModel>().HasData(
                new CityModel { CityId = 6, CityName = "Oslo", CountryId = 4 });


            // seeding Language

            modelBuilder.Entity<LanguageModel>().HasData(
                new LanguageModel { LanguageId = 1, LanguageName = "German" });
            modelBuilder.Entity<LanguageModel>().HasData(
                new LanguageModel { LanguageId = 2, LanguageName = "Swedish" });
            modelBuilder.Entity<LanguageModel>().HasData(
                new LanguageModel { LanguageId = 3, LanguageName = "Norwegian" });
            modelBuilder.Entity<LanguageModel>().HasData(
                new LanguageModel { LanguageId = 4, LanguageName = "italian" });

            // seeding Person
            modelBuilder.Entity<PersonModel>().HasData(
                new PersonModel { PersonId = 1, FullName = "Johan Strom", PhoneNumber = "+46-73225588", CityId = 5 });
            modelBuilder.Entity<PersonModel>().HasData(
                new PersonModel { PersonId = 2, FullName = "Masoud Ozel", PhoneNumber = "+49-55883211", CityId = 2 });
            modelBuilder.Entity<PersonModel>().HasData(
                new PersonModel { PersonId = 3, FullName = "Angela Mark", PhoneNumber = "+49-55880011", CityId = 5 });
            modelBuilder.Entity<PersonModel>().HasData(
                new PersonModel { PersonId = 4, FullName = "Anna Maria", PhoneNumber = "+46-732001874", CityId = 4 });
            modelBuilder.Entity<PersonModel>().HasData(
                new PersonModel { PersonId = 5, FullName = "Samanta Hanson", PhoneNumber = "+46-73201177", CityId = 4 });
            modelBuilder.Entity<PersonModel>().HasData(
                new PersonModel { PersonId = 6, FullName = "Sandro Mazzola", PhoneNumber = "+39-73225588", CityId = 1 });
            modelBuilder.Entity<PersonModel>().HasData(
                new PersonModel { PersonId = 7, FullName = "Marco Tardeli ", PhoneNumber = "+39-73225588", CityId = 1 });
            modelBuilder.Entity<PersonModel>().HasData(
                new PersonModel { PersonId = 8, FullName = "Rita Nord", PhoneNumber = "+47-73225008", CityId = 6 });
            modelBuilder.Entity<PersonModel>().HasData(
                new PersonModel { PersonId = 9, FullName = "Michel Moler", PhoneNumber = "+49-73225008", CityId = 3 });



            // Seeding Person_Language
            modelBuilder.Entity<PersonLanguageModel>().HasData(
                new PersonLanguageModel { PersonId = 1, LanguageId = 2 });
            modelBuilder.Entity<PersonLanguageModel>().HasData(
                new PersonLanguageModel { PersonId = 1, LanguageId = 1 });
            modelBuilder.Entity<PersonLanguageModel>().HasData(
                new PersonLanguageModel { PersonId = 1, LanguageId = 3 });
            modelBuilder.Entity<PersonLanguageModel>().HasData(
                new PersonLanguageModel { PersonId = 2, LanguageId = 1 });
            modelBuilder.Entity<PersonLanguageModel>().HasData(
                new PersonLanguageModel { PersonId = 3, LanguageId = 1 });
            modelBuilder.Entity<PersonLanguageModel>().HasData(
                new PersonLanguageModel { PersonId = 4, LanguageId = 2 });
            modelBuilder.Entity<PersonLanguageModel>().HasData(
                new PersonLanguageModel { PersonId = 5, LanguageId = 2 });
            modelBuilder.Entity<PersonLanguageModel>().HasData(
                new PersonLanguageModel { PersonId = 6, LanguageId = 4 });
            modelBuilder.Entity<PersonLanguageModel>().HasData(
                new PersonLanguageModel { PersonId = 7, LanguageId = 4 });
            modelBuilder.Entity<PersonLanguageModel>().HasData(
                new PersonLanguageModel { PersonId = 7, LanguageId = 3 });
            modelBuilder.Entity<PersonLanguageModel>().HasData(
                new PersonLanguageModel { PersonId = 8, LanguageId = 3 });
            modelBuilder.Entity<PersonLanguageModel>().HasData(
                new PersonLanguageModel { PersonId = 9, LanguageId = 1 });
            modelBuilder.Entity<PersonLanguageModel>().HasData(
                new PersonLanguageModel { PersonId = 9, LanguageId = 4 });


            string roleId = Guid.NewGuid().ToString();
            string userId = Guid.NewGuid().ToString();
            string userRoleId = Guid.NewGuid().ToString();


            modelBuilder.Entity<IdentityRole>().HasData(
                new IdentityRole 
                { Id = roleId, 
                    Name = "Admin", 
                    NormalizedName = "ADMIN" });

            modelBuilder.Entity<IdentityRole>().HasData(
                  new IdentityRole
                  {
                      Id = userId,
                      Name = "User",
                      NormalizedName = "USER"
                  });

            PasswordHasher<ApplicationUser> hasher = new PasswordHasher<ApplicationUser>();

            modelBuilder.Entity<ApplicationUser>().HasData(new ApplicationUser
            {
                Id = userId,
                Email = "admin@admin.com",
                NormalizedEmail = "ADMIM@ADMIN.COM",
                UserName = "admin",
                NormalizedUserName = "ADMIN",
                PasswordHash = hasher.HashPassword(null, "pass"),
                FirstName = "First",
                LastName = "Last"
            });

            modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = roleId,
                UserId = userId
            });

        }


    }
}

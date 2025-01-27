using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Project.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Dal.BogusHandling
{
    public static class UserAndRoleSeed
    {
        public static void SeedUsersAndRoles(ModelBuilder modelBuilder)
        {
            IdentityRole<int> appRole = new()
            {
                Id = 1,
                Name = "Admin",
                NormalizedName = "ADMIN",
                ConcurrencyStamp = Guid.NewGuid().ToString()
            };

            modelBuilder.Entity<IdentityRole<int>>().HasData(appRole);


            //Normalde sifreleme islemlerei gibi yapilar Identity kutuphanesi sayesinde otomatik olarak gelmektedir. Ama biz bu seviyede hardcoded veriler ekledigimiz icin o kutuphane aslinda calismayacaktir. Biz bu kutuphaneyi taklit edecegiz.

            PasswordHasher<AppUser> passwordHasher = new PasswordHasher<AppUser>();
            AppUser appUser = new()
            {
                Id = 1,
                UserName = "hkn123",
                Email = "hakan@email.com",
                NormalizedEmail = "HAKAN@EMAIL.COM",
                NormalizedUserName = "HKN123",
                EmailConfirmed = true,
                SecurityStamp = Guid.NewGuid().ToString(),
                PasswordHash = passwordHasher.HashPassword(null, "hkn123")
            };
            modelBuilder.Entity<AppUser>().HasData(appUser);

            IdentityUserRole<int> appUserRole = new()
            {
                RoleId = 1,
                UserId = 1
            };

            modelBuilder.Entity<IdentityUserRole<int>>().HasData(appUserRole);

        }


    }
}

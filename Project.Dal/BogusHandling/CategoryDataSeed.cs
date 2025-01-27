using Microsoft.EntityFrameworkCore;
using Project.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bogus;
using Bogus.DataSets;

namespace Project.Dal.BogusHandling
{

    public static class CategoryDataSeed
    {
        public static void SeedCategories(ModelBuilder modelBuilder)
        {
            //Bu seviyede Dal'da oldugumuz icin rahatca Domain entity ile calisabiliriz
            List<Category> categories = new();


            //Eger saf durumda Database'e hardcoded bir veri eklemesi yapacaksak Identity sistemi devreye girmez. O yuzden Id'lerin degeri elle vermek zorunda kaliriz.
            for (int i = 1; i < 11; i++)
            {
                Category c = new()
                {
                    Id = i,
                    CategoryName = new Commerce("tr").Categories(1)[0],
                    Description = new Lorem("tr").Sentence(10)
                };

                categories.Add(c);
            }

            modelBuilder.Entity<Category>().HasData(categories);
        }
    }
}

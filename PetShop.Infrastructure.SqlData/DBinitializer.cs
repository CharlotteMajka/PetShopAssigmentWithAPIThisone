using PetShop.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShop.Infrastructure.SqlData
{
    public class DBinitializer
    {
        public static void seedDB(PetShopAppContext ctx)
        {
            ctx.Database.EnsureDeleted();
            ctx.Database.EnsureCreated(); 
        

            var pet1 = new Pet
            {

                Name = "doggy",
                Dob = System.DateTime.Now.AddYears(-2),
                Price = 1000




            };


            var pet2 = new Pet
            {

                Name = "Bo",
                Dob = System.DateTime.Now.AddYears(-3),
                Price = 1500


            };

            var pet3 = new Pet
            {

                Name = "HAns",
                Dob = System.DateTime.Now.AddYears(-6),
                Price = 400.00


            };

            var pet4 = new Pet
            {

                Name = "bird",
                Dob = System.DateTime.Now.AddYears(-2),
                Price = 100.00


            };
            var pet5 = new Pet
            {

                Name = "penny",
                Dob = System.DateTime.Now.AddYears(-2),
                Price = 200.00


            };
            var pet6 = new Pet
            {

                Name = "kim",
                Dob = System.DateTime.Now.AddYears(-7),
                Price = 300.00

            };


            ctx.pets.Add(pet1);
            ctx.pets.Add(pet2);
            ctx.pets.Add(pet3);
            ctx.pets.Add(pet4);
            ctx.pets.Add(pet5);
            ctx.pets.Add(pet6);

            ctx.SaveChanges(); 
        }

    }
}

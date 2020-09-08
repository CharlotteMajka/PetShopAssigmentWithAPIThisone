using PetShop.Core.DomainServices;
using PetShop.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShop.Infrastructure.Data
{
    public class MockData
    {
        IPetRepository petRepo;
        IOwnerRepository ownerRepo;

        public MockData(IPetRepository repo, IOwnerRepository repo2)
        {
            petRepo = repo;
            ownerRepo = repo2;

        }

        public  void InitData()
        {
            var owner1 = new Owner
            {
                Address = "Vintervej 1",
                Email = "vinter@gmail.com",
                FirstName = "Lasse",
                LastName = "Hanse",
                PhoneNr = "20103120"
                //Pets. //= pet1


            };
            var owner2 = new Owner
            {
                Address = "Hassegade 5",
                Email = "Hasse@gmail.com",
                FirstName = "Gurli",
                LastName = "Larsen",
                PhoneNr = "12345678"


            };
            var owner3 = new Owner
            {
                Address = "OwnerVej 9",
                Email = "Owner@Yahoo.dk",
                FirstName = "Åge",
                LastName = "Karlsen",
                PhoneNr = "87654321"


            };

            ownerRepo.CreateOwner(owner1);
            ownerRepo.CreateOwner(owner2);
            ownerRepo.CreateOwner(owner3);

            var pet1 = new Pet
            {

                Name = "doggy",
                Dob = System.DateTime.Now.AddYears(-2),
                Price = 1000,
                Type = "dog",
                PreviousOwner = owner1

                


            };


            var pet2 = new Pet
            {

                Name = "Bo",
                Dob = System.DateTime.Now.AddYears(-3),
                Price = 1500,
                Type = "Bird",
                PreviousOwner = ownerRepo.GetOwnerByID(1)


            };

            var pet3 = new Pet
            {

                Name = "HAns",
                Dob = System.DateTime.Now.AddYears(-6),
                Price = 400.00,
                Type = "dog",
                PreviousOwner = ownerRepo.GetOwnerByID(2)


            };

            var pet4 = new Pet
            {

                Name = "bird",
                Dob = System.DateTime.Now.AddYears(-2),
                Price = 100.00,
                Type = "bird",
                PreviousOwner = ownerRepo.GetOwnerByID(2)


            };
            var pet5 = new Pet
            {

                Name = "penny",
                Dob = System.DateTime.Now.AddYears(-2),
                Price = 200.00,
                Type = "Horse",
                PreviousOwner = ownerRepo.GetOwnerByID(3)


            };
            var pet6 = new Pet
            {

                Name = "kim",
                Dob = System.DateTime.Now.AddYears(-7),
                Price = 300.00,
                Type = "pig",
                PreviousOwner = ownerRepo.GetOwnerByID(3)

            };





            petRepo.CreatePet(pet1);
            petRepo.CreatePet(pet2);
            petRepo.CreatePet(pet3);
            petRepo.CreatePet(pet4);
            petRepo.CreatePet(pet5);
            petRepo.CreatePet(pet6);
        }







    }
}

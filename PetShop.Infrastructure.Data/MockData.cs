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
        IPetTypeRerpository petTyperepo;

        public MockData(IPetRepository repo, IOwnerRepository repo2, IPetTypeRerpository repo3)
        {
            petRepo = repo;
            ownerRepo = repo2;
            petTyperepo = repo3;

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

            var petType1 = new PetType()
            {
                Pettype = "Dog"

            };
            var pettype2 = new PetType()
            {
                Pettype = "Cat"
            };
            var pettype3 = new PetType()
            {
                Pettype = "Horse"
            };
            var pettype4 = new PetType()
            {
                Pettype = "Bird"
            };
            var pettype5 = new PetType()
            {
                Pettype = "Pig"
            };

         

            var pet1 = new Pet
            {

                Name = "doggy",
                Dob = System.DateTime.Now.AddYears(-2),
                Price = 1000,
                Type = petType1,
                PreviousOwner = owner1

                


            };


            var pet2 = new Pet
            {

                Name = "Bo",
                Dob = System.DateTime.Now.AddYears(-3),
                Price = 1500,
                Type = pettype4,
                PreviousOwner = ownerRepo.GetOwnerByID(1)


            };

            var pet3 = new Pet
            {

                Name = "HAns",
                Dob = System.DateTime.Now.AddYears(-6),
                Price = 400.00,
                Type = petType1,
                PreviousOwner = ownerRepo.GetOwnerByID(2)


            };

            var pet4 = new Pet
            {

                Name = "bird",
                Dob = System.DateTime.Now.AddYears(-2),
                Price = 100.00,
                Type = pettype3,
                PreviousOwner = ownerRepo.GetOwnerByID(2)


            };
            var pet5 = new Pet
            {

                Name = "penny",
                Dob = System.DateTime.Now.AddYears(-2),
                Price = 200.00,
                Type = pettype5,
                PreviousOwner = ownerRepo.GetOwnerByID(3)


            };
            var pet6 = new Pet
            {

                Name = "kim",
                Dob = System.DateTime.Now.AddYears(-7),
                Price = 300.00,
                Type = pettype5,
                PreviousOwner = ownerRepo.GetOwnerByID(3)

            };



            owner1.SetOnePet(pet1);
            owner1.SetOnePet(pet2);

            petTyperepo.addPetType(petType1);
            petTyperepo.addPetType(pettype2);
            petTyperepo.addPetType(pettype3);
            petTyperepo.addPetType(pettype4);
            petTyperepo.addPetType(pettype5);

           

            petRepo.CreatePet(pet1);
            petRepo.CreatePet(pet2);
            petRepo.CreatePet(pet3);
            petRepo.CreatePet(pet4);
            petRepo.CreatePet(pet5);
            petRepo.CreatePet(pet6);

            petType1.addPetToType(pet1);
            petType1.addPetToType(pet3);
            pettype3.addPetToType(pet4);
            pettype4.addPetToType(pet2);
            pettype5.addPetToType(pet5);
            pettype5.addPetToType(pet6);
        
            
           
        }







    }
}

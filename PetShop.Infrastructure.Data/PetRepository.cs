using PetShop.Core.DomainServices;
using PetShop.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PetShop.Infrastructure.Data
{
    public class PetRepository : IPetRepository
    {
        static int id = 1;
        static List<Pet> listPets = new List<Pet>();

       

        public List<Pet> ReadPets()
        {
            return (List<Pet>)listPets;
        }


        public Pet CreatePet(Pet pet1)
        {
            pet1.Id = id++;
            listPets.Add(pet1);
            return pet1;
        }



        public void DeletePet(Pet petToDelete)
        {

            listPets.Remove(petToDelete);

        }

        public Pet GetPetByID(int id)
        {
         
            var result = listPets.Where(p => p.Id == id).FirstOrDefault();

            return result;
        }

        public Pet UpdatePet(Pet pet)
        {

            Pet petThatNeedsUpdate = GetPetByID(pet.Id);

            petThatNeedsUpdate.Name = pet.Name;
            petThatNeedsUpdate.PreviousOwner = pet.PreviousOwner;
            petThatNeedsUpdate.Price = pet.Price;
            petThatNeedsUpdate.SoldDate = pet.SoldDate;
            petThatNeedsUpdate.Type = pet.Type;
            petThatNeedsUpdate.Color = pet.Color;
            petThatNeedsUpdate.Dob = pet.Dob;

            return petThatNeedsUpdate;
            
        }
    }
}

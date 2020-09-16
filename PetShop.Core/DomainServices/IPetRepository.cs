using PetShop.Core.Entities;
using PetShop.Core.Filters;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShop.Core.DomainServices
{
   public  interface IPetRepository
    {

        //public List<Pet> ReadPets();
        
        
        //Create
        Pet CreatePet(Pet TheNewPet);
        //Delete
        void DeletePet(Pet petToDelete);
        //Read
        Pet GetPetByID(int id);
        FilteredList<Pet> ReadAll(Filter filter);
        //update
        Pet UpdatePet(Pet pet);
    }
}

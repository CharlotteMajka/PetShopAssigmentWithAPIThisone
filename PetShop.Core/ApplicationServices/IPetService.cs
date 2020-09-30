using PetShop.Core.Entities;
using PetShop.Core.Filters;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PetShop.Core.ApplicationServices
{
    public interface IPetService
    {

        //public List<Pet> getPets();

        //create 
        Pet AddNewPet(Pet TheNewPet);

        //Delete
        Pet DeletePet(int id);

        //Update
        Pet UpdatePet(int idToupdate, Pet petToUpdate);

        Pet GetPetById(int id);

        FilteredList<Pet> GetAllPets(Filter filter);
    }
}

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
        Pet AddNewPet(string name, string type, DateTime dob, string color, Owner previousOwner, double price);

        //Delete
        Pet DeletePet(int id);

        //Update
        Pet UpdatePet(int idToupdate, Pet petToUpdate);

        //Read
        //IEnumerable<Pet> SortPetsByPrice();
        //IEnumerable<Pet> Get5ChepestPets();    
        //IEnumerable<Pet> SearchPetByType(string stringToLookFore);
        Pet GetPetById(int id);

        FilteredList<Pet> GetAllPets(Filter filter);
    }
}

using Microsoft.EntityFrameworkCore;
using PetShop.Core.DomainServices;
using PetShop.Core.Entities;
using PetShop.Core.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PetShop.Infrastructure.SqlData.Repositories
{
    public class PetRepositoryDb : IPetRepository
    {
        readonly PetShopAppContext _petContext;

        public PetRepositoryDb(PetShopAppContext ctx)
        {
            _petContext = ctx;
        }

        public Pet CreatePet(Pet TheNewPet)
        {
            if (TheNewPet.Type != null) 
            {
                _petContext.Attach(TheNewPet.Type).State = EntityState.Unchanged;    
            }
            var pet =_petContext.pets.Add(TheNewPet);
            _petContext.SaveChanges();

            return pet.Entity;
        }

        public void DeletePet(Pet petToDelete)
        {
            _petContext.Remove(petToDelete);
            _petContext.SaveChanges(); 
        
        }

        public Pet GetPetByID(int id)
        {
           return _petContext.pets.AsNoTracking().FirstOrDefault(p => p.Id == id);
        }

        public FilteredList<Pet> ReadAll(Filter filter)
        {
            //Create a Filtered List
            var filteredList = new FilteredList<Pet>();

            filteredList.TotalCount = _petContext.pets.Count();
            filteredList.FilterUsed = filter;

            filteredList.List = _petContext.pets.ToList();

            //Else just return the full list and get the count from the list (to save a SQL call)
            /*filteredList.List = _petContext.pets
                .Select(p => new Pet { Id = p.Id, Name = p.Name }).ToList();    */               
         
            return filteredList;
        }

        public Pet UpdatePet(int id, Pet pet)
        {
            var petUpdated = _petContext.Update(pet);
            _petContext.SaveChanges();
            return petUpdated.Entity;
        }
    }
}

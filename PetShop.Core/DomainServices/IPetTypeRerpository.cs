using PetShop.Core.Entities;
using PetShop.Core.Filters;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShop.Core.DomainServices
{
    public interface IPetTypeRerpository
    {

        //read
        public FilteredList<PetType> ReadAllTypes(Filter filter);

        public PetType GetPetTypeById(int id);

        //Create
        public PetType addPetType(PetType pettype);

        //Delete
        public void DeletePetType(PetType petTypeToDelete);

        //Update
        public PetType updatePet(int id, PetType pettype);

        public void AddPetToPetType(Pet petToAdd, PetType pettype);

    }
}

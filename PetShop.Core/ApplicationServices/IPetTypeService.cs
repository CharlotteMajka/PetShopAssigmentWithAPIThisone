using PetShop.Core.Entities;
using PetShop.Core.Filters;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShop.Core.ApplicationServices
{
    public interface IPetTypeService
    {

        //read
        public FilteredList<PetType> ReadAllTypes(Filter filter);

        public PetType GetPetTypeById(int id);

        //Create
        public PetType addPetType(PetType pettype);

        //Delete
        public PetType DeletePetType(int id);

        //Update
        public PetType updatePet(int id, PetType pertype);

    }
}

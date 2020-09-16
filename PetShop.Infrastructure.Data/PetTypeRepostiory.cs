using System;
using PetShop.Core.DomainServices;
using PetShop.Core.Entities;
using PetShop.Core.Filters;
using System.Collections.Generic;
using System.Text;

namespace PetShop.Infrastructure.Data
{
    public class PetTypeRepostiory : IPetTypeRerpository
    {
        static int id = 1;
        static List<PetType> ListpetTypes = new List<PetType>(); 
        public PetType addPetType(PetType pettype)
        {
            pettype.id = id++;

            ListpetTypes.Add(pettype);
            return pettype;

        }

        public PetType DeletePetType(int id)
        {
            throw new NotImplementedException();
        }

        public PetType GetPetTypeById(int id)
        {
            throw new NotImplementedException();
        }

        public FilteredList<PetType> ReadAllTypes(Filter filter)
        {
            throw new NotImplementedException();
        }

        public PetType updatePet(int id, PetType pettype)
        {
            throw new NotImplementedException();
        }
    }
}

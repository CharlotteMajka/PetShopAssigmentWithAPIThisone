using PetShop.Core.ApplicationServices;
using PetShop.Core.DomainServices;
using PetShop.Core.Entities;
using PetShop.Core.Filters;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShop.Core.ApplicationServiceImple
{
    public class PetTypeService : IPetTypeService
    {
        private IPetTypeRerpository petTypeRepo;
        public PetTypeService(IPetTypeRerpository petRepo)
        {
            petTypeRepo = petRepo;
        }

        public PetType addPetType(PetType pettype)
        {
            var pettypenew = new PetType()
            {
                Pettype = pettype.Pettype

            };
            return petTypeRepo.addPetType(pettypenew);
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

        public PetType updatePet(int id, PetType pertype)
        {
            throw new NotImplementedException();
        }
    }
}

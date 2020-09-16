using PetShop.Core.ApplicationServices;
using PetShop.Core.DomainServices;
using PetShop.Core.Entities;
using PetShop.Core.Filters;
using System;
using System.Collections.Generic;
using System.IO;
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
            return petTypeRepo.GetPetTypeById(id);
        }

        public FilteredList<PetType> ReadAllTypes(Filter filter)
        {
            return petTypeRepo.ReadAllTypes(filter);
        }

        public PetType updatePet(int id, PetType pettype)
        {
            if ( id < 0)
            {
                throw new InvalidDataException("id must be above 0");

            }

            return petTypeRepo.updatePet(id, pettype);

        }
    }
}

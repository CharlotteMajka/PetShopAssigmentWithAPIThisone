using PetShop.Core.DomainServices;
using PetShop.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShop.Infrastructure.MSSQL.Data
{
    class PetSQLRepository : IPetRepository
    {
        public Pet CreatePet(Pet TheNewPet)
        {
            throw new NotImplementedException();
        }
         
        public void DeletePet(Pet petToDelete)
        {
            throw new NotImplementedException();
        }

        public Pet GetPetByID(int id)
        {
            throw new NotImplementedException();
        }

        public List<Pet> ReadPets()
        {
            throw new NotImplementedException();
        }

        public Pet UpdatePet(Pet pet)
        {
            throw new NotImplementedException();
        }
    }
}

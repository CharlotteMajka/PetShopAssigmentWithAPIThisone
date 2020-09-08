using PetShop.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShop.Core.DomainServices
{
    public interface IOwnerRepository
    {

        public List<Owner> ReadOwners();
        Owner CreateOwner(Owner TheNewOwner);

        void DeleteOwner(Owner OwnerToDelete);
        Owner GetOwnerByID(int id);
        Owner UpdateOwner(Owner owner);
    }
}

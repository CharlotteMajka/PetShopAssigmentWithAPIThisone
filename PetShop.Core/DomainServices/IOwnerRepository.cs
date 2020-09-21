using PetShop.Core.Entities;
using PetShop.Core.Filters;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShop.Core.DomainServices
{
    public interface IOwnerRepository
    {

        //public List<Owner> ReadOwners();

        FilteredList<Owner> ReadOwners(Filter filter);

        Owner CreateOwner(Owner TheNewOwner);

        void DeleteOwner(Owner OwnerToDelete);
        Owner GetOwnerByID(int id);
        Owner UpdateOwner(int id, Owner owner);
    }
}

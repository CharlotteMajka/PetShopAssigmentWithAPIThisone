using System;
using System.Collections.Generic;
using System.Text;
using PetShop.Core.DomainServices;
using PetShop.Core.Entities;
using PetShop.Core.Filters;

namespace PetShop.Infrastructure.SqlData.Repositories
{
   public class OwnerRepositoryDb: IOwnerRepository
    {
        readonly PetShopAppContext _petContext;

        public OwnerRepositoryDb(PetShopAppContext ctx)
        {
            _petContext = ctx;
        }

        public FilteredList<Owner> ReadOwners(Filter filter)
        {
            throw new NotImplementedException();
        }

        public Owner CreateOwner(Owner TheNewOwner)
        {
            throw new NotImplementedException();
        }

        public void DeleteOwner(Owner OwnerToDelete)
        {
            throw new NotImplementedException();
        }

        public Owner GetOwnerByID(int id)
        {
            throw new NotImplementedException();
        }

        public Owner UpdateOwner(int id, Owner owner)
        {
            throw new NotImplementedException();
        }
    }
}

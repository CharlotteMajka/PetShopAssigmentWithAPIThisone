using PetShop.Core.ApplicationServices;
using PetShop.Core.DomainServices;
using PetShop.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShop.Core.ApplicationServiceImple
{
    public class OwnerService : IOwnerService
    { 
        IOwnerRepository ownerrepo;

        public OwnerService(IOwnerRepository repo)
    {
            ownerrepo = repo;
    } 
    
        public Owner AddNewOwner(Owner newOwner)
        {
            throw new NotImplementedException();
        }

        public Owner DeleteOwner(int id)
        {
            throw new NotImplementedException();
        }

        public Owner GetOwnerById(int id)
        {
            return ownerrepo.GetOwnerByID(id);
        }

        public List<Owner> ReadOwners()
        {
            throw new NotImplementedException();
        }

        public Owner UpdateOwner(int idToupdate, Owner OwnerToUpdate)
        {
            throw new NotImplementedException();
        }
    }
}

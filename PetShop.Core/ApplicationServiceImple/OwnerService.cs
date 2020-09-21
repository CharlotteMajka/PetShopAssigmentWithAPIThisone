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
    public class OwnerService : IOwnerService
    { 
        IOwnerRepository ownerrepo;

        public OwnerService(IOwnerRepository repo)
    {
            ownerrepo = repo;
    } 
    
        public Owner AddNewOwner(Owner newOwner)
        {
            return ownerrepo.CreateOwner(newOwner);
        }

        public Owner DeleteOwner(int id)
        {
            if (id < 0)
            {
                throw new InvalidDataException("ID can't be under zero");
            }
            var OwnerToDelete = ownerrepo.GetOwnerByID(id);
            if (OwnerToDelete == null)
            {
                throw new InvalidDataException("Owner Can't be 'NULL'");
            }
            else
            {   ownerrepo.DeleteOwner(OwnerToDelete);
                return OwnerToDelete;
            }
        }

        public Owner GetOwnerById(int id)
        { //var owner = ownerrepo.GetOwnerByID(id);
            if (id <= 0)
            {
                throw new InvalidDataException("ID can't bu 0 or under!");
            }
            if (ownerrepo.GetOwnerByID(id) == null )
            {
                throw new ArgumentNullException("Owner could not be found");
            }
            return ownerrepo.GetOwnerByID(id);
        }

        public FilteredList<Owner> ReadOwners(Filter filter)
        {
            if (!string.IsNullOrEmpty(filter.SearchText) && string.IsNullOrEmpty(filter.SearchField))
            {
                filter.SearchField = "FirstName";
            }

            return ownerrepo.ReadOwners(filter);
        }

        /*public List<Owner> ReadOwners()
        {
            return ownerrepo.ReadOwners();
        }*/

        public Owner UpdateOwner(int idToupdate, Owner OwnerToUpdate)
        {
            if (idToupdate <= 0)
            {
                throw new InvalidDataException("ID must be above 0");
            }
           
            else if (ownerrepo.GetOwnerByID(idToupdate) == null)
            {

                throw new ArgumentNullException("The Owner could not be found");
            }
            else
            {

                return ownerrepo.UpdateOwner(idToupdate, OwnerToUpdate);

            }
        }
    }
}

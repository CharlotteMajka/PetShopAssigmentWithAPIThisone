using PetShop.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShop.Core.ApplicationServices
{
   public interface IOwnerService
    {


        public List<Owner> ReadOwners();

        Owner AddNewOwner(Owner newOwner);

        Owner DeleteOwner(int id);

        Owner UpdateOwner(int idToupdate, Owner OwnerToUpdate);

        Owner GetOwnerById(int id);



    }
}

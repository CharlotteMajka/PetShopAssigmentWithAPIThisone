﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PetShop.Core.DomainServices;
using PetShop.Core.Entities;

namespace PetShop.Infrastructure.Data
{
    public class OwnerRepostiory : IOwnerRepository
    {

        static int id = 0;
        static List<Owner> listOwners = new List<Owner>();
        public Owner CreateOwner(Owner TheNewOwner)
        {
            TheNewOwner.id = ++id;
            listOwners.Add(TheNewOwner);
            return TheNewOwner;
        }

        public void DeleteOwner(Owner OwnerToDelete)
        {
            listOwners.Remove(OwnerToDelete);
        }

        public Owner GetOwnerByID(int id)
        {

            var result = listOwners.Where(p => p.id == id).FirstOrDefault();

            return result;
        }

        public List<Owner> ReadOwners()
        {
            return listOwners;
        }

        public Owner UpdateOwner(Owner owner)
        {

            var OwnerFromMock = GetOwnerByID(owner.id);

            OwnerFromMock.FirstName = owner.FirstName;
            OwnerFromMock.LastName = owner.LastName;
            OwnerFromMock.PhoneNr = owner.PhoneNr;
            OwnerFromMock.Email = owner.Email;
            OwnerFromMock.Address = owner.Address;

            return OwnerFromMock;



        }
    }
}

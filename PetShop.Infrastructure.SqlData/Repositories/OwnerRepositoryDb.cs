using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
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
            var FiltertList = new FilteredList<Owner>();

            FiltertList.TotalCount = _petContext.Owners.Count();
            FiltertList.FilterUsed = filter;

            FiltertList.List = _petContext.Owners.ToList();

            return FiltertList;

        }
        public Owner GetOwnerByID(int id)
        {
            return _petContext.Owners
                .AsNoTracking()
                .FirstOrDefault(o => o.id == id);
        }
        public Owner CreateOwner(Owner TheNewOwner)
        {
         
            var Owner = _petContext.Owners.Add(TheNewOwner);
            _petContext.SaveChanges();

            return Owner.Entity;
        }

        public void DeleteOwner(Owner OwnerToDelete)
        {
            throw new NotImplementedException();
        }

       

        public Owner UpdateOwner(int id, Owner owner)
        {
            throw new NotImplementedException();
        }
    }
}

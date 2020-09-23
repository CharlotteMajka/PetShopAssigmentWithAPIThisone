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
    public class PetTypeRepositoryDb: IPetTypeRerpository
    {
        readonly PetShopAppContext _petContext;

        public PetTypeRepositoryDb(PetShopAppContext ctx)
        {
            _petContext = ctx;
        }

        public FilteredList<PetType> ReadAllTypes(Filter filter)
        {
            var FiltertPetTyps = new FilteredList<PetType>();

            FiltertPetTyps.TotalCount = _petContext.PetTypes.Count();
            FiltertPetTyps.FilterUsed = filter;

            FiltertPetTyps.List = _petContext.PetTypes.ToList();

            return FiltertPetTyps;

        }

        public PetType GetPetTypeById(int id)
        {
            return _petContext.PetTypes.AsNoTracking().FirstOrDefault(p => p.id == id);
        }

        public PetType addPetType(PetType pettype)
        {
            var newPettype = _petContext.PetTypes.Add(pettype);
            _petContext.SaveChanges();

            return newPettype.Entity;
            
        }

        public void DeletePetType(PetType petTypeToDelete)
        {
            throw new NotImplementedException();
        }

        public PetType updatePet(int id, PetType pettype)
        {
            throw new NotImplementedException();
        }

        public void AddPetToPetType(Pet petToAdd, PetType pettype)
        {
            throw new NotImplementedException();
        }
    }
}

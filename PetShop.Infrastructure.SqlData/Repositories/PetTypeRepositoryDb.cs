﻿using System;
using System.Collections.Generic;
using System.Text;
using PetShop.Core.DomainServices;
using PetShop.Core.Entities;
using PetShop.Core.Filters;

namespace PetShop.Infrastructure.SqlData.Repositories
{
    public class PetTypeRepositoryDb: IPetTypeRerpository
    {
        private IPetTypeRerpository _pettypeRepo;

        public PetTypeRepositoryDb(IPetTypeRerpository pettypeRepo)
        {
            _pettypeRepo = pettypeRepo;
        }

        public FilteredList<PetType> ReadAllTypes(Filter filter)
        {
            throw new NotImplementedException();
        }

        public PetType GetPetTypeById(int id)
        {
            throw new NotImplementedException();
        }

        public PetType addPetType(PetType pettype)
        {
            throw new NotImplementedException();
        }

        public void DeletePetType(int id)
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
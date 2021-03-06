﻿using PetShop.Core.DomainServices;
using PetShop.Core.Entities;
using PetShop.Core.Filters;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PetShop.Infrastructure.Data
{
    public class PetRepository : IPetRepository
    {
        static int id = 1;
        static List<Pet> listPets = new List<Pet>();

       

        /*public List<Pet> ReadPets()
        {
            return (List<Pet>)listPets;
        }
        */
        


        public Pet CreatePet(Pet pet1)
        {
            pet1.Id = id++;
            listPets.Add(pet1);

            /*if(!pet1.Type.Equals(null))
            {
                var pettype = pet1.Type;
                pettype.addPetToType(pet1);
            }*/
            return pet1;
        }



        public void DeletePet(Pet petToDelete)
        {

            listPets.Remove(petToDelete);

        }

        public Pet GetPetByID(int id)
        {

            var result = listPets
                .FirstOrDefault(p => p.Id == id);
                //Where(p => p.Id == id).FirstOrDefault();

            return result;
        }

        public Pet UpdatePet(int id, Pet pet)
        {

            Pet petThatNeedsUpdate = GetPetByID(id);

            petThatNeedsUpdate.Name = pet.Name;
            petThatNeedsUpdate.PreviousOwner = pet.PreviousOwner;
            petThatNeedsUpdate.Price = pet.Price;
            petThatNeedsUpdate.SoldDate = pet.SoldDate;
            petThatNeedsUpdate.Color = pet.Color;
            petThatNeedsUpdate.Dob = pet.Dob;


          
        

            return petThatNeedsUpdate;
            
        }

        public FilteredList<Pet> ReadAll(Filter filter)
        {
            var filteredList = new FilteredList<Pet>();

            filteredList.TotalCount = listPets.Count;
            filteredList.FilterUsed = filter;


            IEnumerable<Pet> filtering = listPets;

            if (!string.IsNullOrEmpty(filter.SearchText))
            {
                switch (filter.SearchField)
                {

                    case "Name":
                        filtering = filtering.Where(p => p.Name.ToLower().Contains(filter.SearchText.ToLower()));
                        break;
                    case "Color":
                        filtering = filtering.Where(p => p.Color.Contains(filter.SearchText));
                        break;



                }


            }

            if (!string.IsNullOrEmpty(filter.OrderDirection) && !string.IsNullOrEmpty(filter.OrderProperty))
            {
                var prop = typeof(Pet).GetProperty(filter.OrderProperty);

                filtering = "ASC".Equals(filter.OrderDirection) ?
                    filtering.OrderBy(p => prop.GetValue(p, null)) :
                    filtering.OrderByDescending(p => prop.GetValue(p, null));

            }

            filteredList.List = filtering.ToList();

            filteredList.ShowingCount = filtering.Count();

            return filteredList;

        }
    }
}

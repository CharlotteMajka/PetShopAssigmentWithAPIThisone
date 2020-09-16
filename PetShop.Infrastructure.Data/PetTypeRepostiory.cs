using System;
using PetShop.Core.DomainServices;
using PetShop.Core.Entities;
using PetShop.Core.Filters;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace PetShop.Infrastructure.Data
{
    public class PetTypeRepostiory : IPetTypeRerpository
    {
        static int id = 1;
        static List<PetType> ListpetTypes = new List<PetType>(); 
        public PetType addPetType(PetType pettype)
        {
            pettype.id = id++;

            ListpetTypes.Add(pettype);
            return pettype;

        }

        public void DeletePetType(int id)
        {

          ListpetTypes.Remove(GetPetTypeById(id));
        }

        public PetType GetPetTypeById(int id)
        {
            return ListpetTypes.Where(pt => pt.id == id).FirstOrDefault();
        }

        public FilteredList<PetType> ReadAllTypes(Filter filter)
        {
            var filteredList = new FilteredList<PetType>();

            filteredList.TotalCount = ListpetTypes.Count;
            filteredList.FilterUsed = filter;


            IEnumerable<PetType> filtering = ListpetTypes;

            if (!string.IsNullOrEmpty(filter.SearchText))
            {
                //switch (filter.SearchField)
                //{

                    
                        filtering = filtering.Where(p => p.Pettype.ToLower().Contains(filter.SearchText.ToLower()));
                        //break;


                //}

            }

            if (!string.IsNullOrEmpty(filter.OrderDirection) && !string.IsNullOrEmpty(filter.OrderProperty))
            {
                var prop = typeof(PetType).GetProperty(filter.OrderProperty);

                filtering = "ASC".Equals(filter.OrderDirection) ?
                    filtering.OrderBy(p => prop.GetValue(p, null)) :
                    filtering.OrderByDescending(p => prop.GetValue(p, null));

            }

            filteredList.List = filtering.ToList();

            filteredList.ShowingCount = filtering.Count();

            return filteredList;
        }

        public PetType updatePet(int id, PetType pettype)
        {
            var pettypetoupdate = GetPetTypeById(pettype.id);

            pettypetoupdate.Pettype = pettype.Pettype;

            return pettypetoupdate;
        }
    }
}

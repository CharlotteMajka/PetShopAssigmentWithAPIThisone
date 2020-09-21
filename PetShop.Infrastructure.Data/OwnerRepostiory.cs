using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PetShop.Core.DomainServices;
using PetShop.Core.Entities;
using PetShop.Core.Filters;

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

        public FilteredList<Owner> ReadOwners(Filter filter)
        {
            var filteredList = new FilteredList<Owner>();

            filteredList.TotalCount = listOwners.Count;
            filteredList.FilterUsed = filter;


            IEnumerable<Owner> filtering = listOwners;

            if (!string.IsNullOrEmpty(filter.SearchText))
            {
                switch (filter.SearchField)
                {

                    case "FirstName":
                        filtering = filtering.Where(o => o.FirstName.ToLower().Contains(filter.SearchText.ToLower()));
                        break;
                    case "LastName":
                        filtering = filtering.Where(o => o.LastName.Contains(filter.SearchText));
                        break;



                }


            }

            if (!string.IsNullOrEmpty(filter.OrderDirection) && !string.IsNullOrEmpty(filter.OrderProperty))
            {
                var prop = typeof(Owner).GetProperty(filter.OrderProperty);

                filtering = "ASC".Equals(filter.OrderDirection) ?
                    filtering.OrderBy(o => prop.GetValue(o, null)) :
                    filtering.OrderByDescending(o => prop.GetValue(o, null));

            }

            filteredList.List = filtering.ToList();

            filteredList.ShowingCount = filtering.Count();

            return filteredList;

        }

        /*public List<Owner> ReadOwners()
        {
            return listOwners;
        }*/

        public Owner UpdateOwner(int id, Owner owner)
        {

            var OwnerFromMock = GetOwnerByID(id);

            OwnerFromMock.FirstName = owner.FirstName;
            OwnerFromMock.LastName = owner.LastName;
            OwnerFromMock.PhoneNr = owner.PhoneNr;
            OwnerFromMock.Email = owner.Email;
            OwnerFromMock.Address = owner.Address;

            return OwnerFromMock;



        }
    }
}

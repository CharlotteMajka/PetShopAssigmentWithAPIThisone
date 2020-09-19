using PetShop.Core.ApplicationServices;
using PetShop.Core.DomainServices;
using PetShop.Core.Entities;
using PetShop.Core.Filters;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace PetShop.Core.ApplicationServiceImple
{
   public class PetService : IPetService
    {
        private IPetRepository petRepository;


        public PetService(IPetRepository _petRepository)
        {
            petRepository = _petRepository;
           
        }

        public Pet AddNewPet(string name, PetType pettype ,DateTime dob, string color, Owner previousOwner, double price)
        {
         

            Pet TheNewPet = new Pet()
            {
                Name = name,
                Type = pettype,
                Dob = dob,
                Color = color,
                PreviousOwner = previousOwner,
                Price = price
            };
            return petRepository.CreatePet(TheNewPet);
        }

        public Pet DeletePet(int id)
        {   
            if(id <= 0)
            {
                throw new InvalidDataException("ID can not be 0 or lower");
            }

            var pet = petRepository.GetPetByID(id);
            if( pet == null)
            {
                throw new ArgumentNullException("Pet Could not be found");
            }
             petRepository.DeletePet(pet);
            return pet; 
        }

       /* public List<Pet> getPets()
        {   
            return petRepository.ReadPets();
        }*/

        

        public Pet UpdatePet(int idToupdate, Pet petToUpdate)
        {
            if (idToupdate <= 0)
            {
                throw new InvalidDataException("ID must be above 0");
            }
            /*else // why this? vi har ikke et id ud over det der står i url, der er ikke nogen id i body...   
            if (idToupdate != petToUpdate.Id)
            {
                throw new InvalidDataException("Something is wrong with the ID? check if it is correct");
            }*/
            else if (petRepository.GetPetByID(idToupdate) == null )
            {

                throw new ArgumentNullException("The pet could not be found");
            }
            else
            {

                return petRepository.UpdatePet(petToUpdate);
                
            }
        }

       /* public IEnumerable<Pet> SortPetsByPrice()
        {
           var SortPetsByPrice = petRepository.ReadPets().OrderByDescending(s => s.Price);

            return SortPetsByPrice.ToList();


        }*/


        /*public IEnumerable<Pet> Get5ChepestPets()
        {
            var Get5ChepestPets = petRepository.ReadPets().OrderBy(s => s.Price);
            
            return Get5ChepestPets;


        }*/

        /*public IEnumerable<Pet> SearchPetByType(string stringToLookFore)
        {

            return petRepository.ReadPets().FindAll(s => s.Type.ToLower().Contains(stringToLookFore.ToLower()));
        }*/

        public Pet GetPetById(int id)
        {   
            if (id < 0)
            {
                throw new InvalidDataException("ID must be above 0");
            
            }
            else if (petRepository.GetPetByID(id) == null)
            {
                throw new ArgumentNullException("There is no pet with the id " + id + "... ");
            }

            return petRepository.GetPetByID(id);
        }

        public FilteredList<Pet> GetAllPets(Filter filter)
        {
            if (!string.IsNullOrEmpty(filter.SearchText) && string.IsNullOrEmpty(filter.SearchField))
            {
                filter.SearchField = "Name";
            }

            return petRepository.ReadAll(filter);
        }
    }
}

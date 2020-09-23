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
        private IPetTypeRerpository petTypeRepo;

        public PetService(IPetRepository _petRepository, IPetTypeRerpository _pettyperepo)
        {
            petRepository = _petRepository;
            petTypeRepo = _pettyperepo;
           
        }

        public Pet AddNewPet(Pet TheNewPet)//(string name, PetType pettype ,DateTime dob, string color, Owner previousOwner, double price, DateTime solddate)
        {
            if (TheNewPet.Name.Length <= 2)
            {
                throw new InvalidDataException("Name must be longer than 2 letters");
            }
            //Pet TheNewPet1 = new Pet(TheNewPet);
            /*{

                Name = name,
                //Type = pettype,
                Dob = dob,
                Color = color,
                PreviousOwner = previousOwner,
                Price = price,
                SoldDate = solddate
            };*/
            //if(TheNewPet.Type != null)
            //{
                var pettypeFromDb = petTypeRepo.GetPetTypeById(TheNewPet.Type.id);
                TheNewPet.Type = pettypeFromDb;
            //}
           
            
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



        

        public Pet UpdatePet(int idToupdate, Pet petToUpdate)
        {   
            

            if (idToupdate <= 0)
            {
                throw new InvalidDataException("ID must be above 0");
            }
            Pet fetchedPetFromDB = petRepository.GetPetByID(idToupdate);
             if (fetchedPetFromDB == null)
            {

                throw new ArgumentNullException("The pet could not be found");
            }


            if (!petToUpdate.SoldDate.Equals(DateTime.MinValue) && petToUpdate.SoldDate < fetchedPetFromDB.Dob)
            {
                throw new InvalidDataException("the pet can't be sold before it is born!");
            }
            if (petToUpdate.Dob > DateTime.Now)
            {
                throw new InvalidDataException("The Pet can't have a DoB in the future!");
            } 
            if(petToUpdate.Price < 0)
            {
                throw new InvalidDataException("Pet can't have a negativ price");
            }
            else
            {

                return petRepository.UpdatePet(idToupdate, petToUpdate);

            }
        }

   

        public Pet GetPetById(int id)
        {
            if (id < 0)
            {
                throw new InvalidDataException("ID must be above 0");

            }

            var tjekpet = petRepository.GetPetByID(id);
            if (tjekpet == null)
            {
                throw new ArgumentNullException("There is no pet with the id " + id + "... ");
            }

            return tjekpet;
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

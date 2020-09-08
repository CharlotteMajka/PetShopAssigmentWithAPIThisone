using System;
using System.Collections.Generic;
using System.Text;

namespace PetShop.Core.Entities
{
    public class Owner
    {
        public int id { get; set; }
        public String FirstName { get; set; }

        public String LastName { get; set; }

        public String Address { get; set; }

        public String PhoneNr { get; set; }
        public String Email { get; set; }

        public List<Pet> Pets = new List<Pet>();

        public List<Pet> GetPets()
        {
            return Pets;

        } 


        public void SetOnePet(Pet pet)
        {
            Pets.Add(pet);
        }

    }

}

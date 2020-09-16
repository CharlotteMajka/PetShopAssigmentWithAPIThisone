using System;
using System.Collections.Generic;
using System.Text;

namespace PetShop.Core.Entities
{
    public class PetType
    {
        public int id { get; set; }
        public String Pettype { get; set; }

        public List<Pet> Pets = new List<Pet>();

        public void addPetToType(Pet pet)
        {
            Pets.Add(pet);
        }
       
        public List<Pet> GetPetsForType()
        {
            return Pets;
        }

    }
}

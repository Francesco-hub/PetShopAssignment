using CompulsoryPetshop.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace CompulsoryPetshop.Core.ApplicationService
{
    public interface IPetService
    {
        public List<Pet> GetAllPets();
        public Pet CreateNewPet(Pet pet);

        public Pet DeletePet(int id);

        public Pet UpdatePet(int id, Pet updatedPet);

        public Pet ReadPetById(int id);

        public List<Pet> GetAllPetsByPrice();
    }
}

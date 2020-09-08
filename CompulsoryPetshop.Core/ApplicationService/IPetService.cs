using CompulsoryPetshop.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace CompulsoryPetshop.Core.ApplicationService
{
    public interface IPetService
    {
        public List<Pet> GetAllPets();
        public void CreateNewPet(Pet pet);

        public void DeletePet(int id);

        public void UpdatePet(Pet previousPet, Pet updatedPet);

        public Pet ReadPetById(int id);

        public List<Pet> GetAllPetsByPrice();
    }
}

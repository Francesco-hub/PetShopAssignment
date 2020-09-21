using CompulsoryPetshop.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace CompulsoryPetshop.Core.DomainService
{
    public interface IPetRepository
    {
        public List<Pet> GetAllPets();
        public Pet CreateNewPet(Pet pet);

        public Pet DeletePet(int id);

        public Pet UpdatePet(int id, Pet updatedPet);

        public Pet ReadPetById(int id);

        public List<Pet> GetAllPetsByPrice();

    }
}



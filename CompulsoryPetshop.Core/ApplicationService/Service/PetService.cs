using CompulsoryPetshop.Core.DomainService;
using CompulsoryPetshop.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace CompulsoryPetshop.Core.ApplicationService.Service
{
    public class PetService : IPetService
    {
        private IPetRepository _petRepo;

        public PetService(IPetRepository petRepository)
        {
            _petRepo = petRepository;
        }

        public void CreateNewPet(Pet pet)
        {
            _petRepo.CreateNewPet(pet);
        }

        public void DeletePet(int id)
        {
            _petRepo.DeletePet(id);
        }

        public List<Pet> GetAllPets()
        {
           return _petRepo.GetAllPets();
        }

        public List<Pet> GetAllPetsByPrice()
        {
            return _petRepo.GetAllPetsByPrice();
        }

        public Pet ReadPetById(int id)
        {
            return _petRepo.ReadPetById(id);
        }

        public void UpdatePet(Pet previousPet, Pet updatedPet)
        {
            _petRepo.UpdatePet(previousPet, updatedPet);
        }
    }
}

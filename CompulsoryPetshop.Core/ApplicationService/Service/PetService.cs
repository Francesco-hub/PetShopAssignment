using CompulsoryPetshop.Core.DomainService;
using CompulsoryPetshop.Core.Entities;
using CompulsoryPetshop.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace CompulsoryPetshop.Core.ApplicationService.Service
{
    public class PetService : IPetService
    {
        private IPetRepository _petRepo;
        private List<Pet> servicePetLst;

        public PetService(IPetRepository petRepository)
        {
            _petRepo = petRepository;
        }

        public Pet CreateNewPet(Pet pet)
        {
           if (pet.Name == null || pet.Price == 0 )
            {
                throw new Exception("Missing or Wrong Pet information");
            }
           if (pet.PrevOwner.Name==null || pet.PrevOwner.Age == 0)
            {
                throw new Exception("Missing or Wrong Pet information");
            }
           return _petRepo.CreateNewPet(pet);

        }

        public Pet DeletePet(int id)
        {
            servicePetLst = _petRepo.GetAllPets();
            if (id == 0)
            {
                throw new Exception("Invalid ID");
            }
            Pet petForOwnerID = _petRepo.ReadPetById(id); 
           return _petRepo.DeletePet(id);
        }

        public List<Pet> GetAllPets()
        {
            servicePetLst = _petRepo.GetAllPets();
            if (servicePetLst.Count == 0)
            {
                throw new Exception("The List is empty");
            }
                return _petRepo.GetAllPets();
           
        }

        public List<Pet> GetAllPetsByPrice()
        {
            servicePetLst = _petRepo.GetAllPets();
            if (servicePetLst.Count == 0)
            {
                throw new Exception("List is Empty");
            }

            return _petRepo.GetAllPetsByPrice();
        }

        public Pet ReadPetById(int id)
        {
            servicePetLst = _petRepo.GetAllPets();
            if (servicePetLst.Count == 0)
            {
                throw new Exception("List is Empty");
            }
            if (id == 0 || id > servicePetLst.Count)
            {
                throw new Exception("Invalid ID");
            }
            return _petRepo.ReadPetById(id);
        }

        public Pet UpdatePet(int id, Pet updatedPet)
        {
            if (id == 0 || id > servicePetLst.Count)
            {
                throw new Exception("Invalid ID");
            }
            if (updatedPet.Name == null || updatedPet.Price == 0)
            {
                throw new Exception("Missing or Wrong Pet information");
            }
            if(updatedPet.PrevOwner.Age==0 || updatedPet.PrevOwner.Name == null || updatedPet.PrevOwner.OwnerID==0)
            {
                throw new Exception("Missing or Wrong Owner information");
            }
            Owner owner = new Owner()
            {OwnerID = updatedPet.PrevOwner.OwnerID,
            Name = updatedPet.PrevOwner.Name,
            Age = updatedPet.PrevOwner.Age
            };
            return  _petRepo.UpdatePet(id, updatedPet);
        }
    }
}

using CompulsoryPetshop.Core.DomainService;
using CompulsoryPetshop.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CompulsoryPetshop.Core.ApplicationService.Service
{
    public class PetTypeService : IPetTypeService
    {
        private IPettypeRepository _petTypeRepo;

        public PetTypeService(IPettypeRepository pettypeRepository)
        {
            _petTypeRepo = pettypeRepository;
        }
        public PetType Createtype(PetType petType)
        {
            return _petTypeRepo.Createtype(petType);
        }

        public PetType DeletePetType(int deletedPetTypeId)
        {
            return _petTypeRepo.DeletePetType(deletedPetTypeId);
        }

        public List<PetType> getAllPetTypes()
        {
            return _petTypeRepo.getAllPetTypes();
        }

        public PetType getPetTypeByFilter()
        {
            return _petTypeRepo.getPetTypeByFilter();
        }

        public PetType getTypeById(int id)
        {
            return _petTypeRepo.getTypeById(id);
        }

        public PetType UpdatePetType(int UpdatePetTypeId, PetType petType)
        {
            return _petTypeRepo.UpdatePetType(UpdatePetTypeId, petType);

        }
    }
}

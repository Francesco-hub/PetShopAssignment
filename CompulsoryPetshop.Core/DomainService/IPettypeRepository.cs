using CompulsoryPetshop.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CompulsoryPetshop.Core.DomainService
{
    public interface IPettypeRepository
    {
        public List<PetType> getAllPetTypes();

        public PetType getTypeById(int id);

        public PetType Createtype(PetType petType);

        public PetType UpdatePetType(int UpdatePetTypeId, PetType petType);

        public PetType DeletePetType(int deletedPetTypeId);

        public PetType getPetTypeByFilter();
    }
}

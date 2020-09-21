using CompulsoryPetshop.Core.DomainService;
using CompulsoryPetshop.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infrastructure.Data
{
    public class PetTypeRepository : IPettypeRepository
    {
        private static List<PetType> _petTypeList = new List<PetType>();
        public static int onlyInitDataOnce = 0;
        public void InitData()
        {
            if (onlyInitDataOnce == 0)
            {
                _petTypeList.Add(new PetType()
                {
                    PetTypeId = 1,
                    PetTypeName = "dog"
                });

                _petTypeList.Add(new PetType()
                {
                    PetTypeId = 2,
                    PetTypeName = "other"
                });
            }
            onlyInitDataOnce++;
        }
                public PetType Createtype(PetType petType)
        {
            InitData();
            petType.PetTypeId = _petTypeList.Count() + 1;
            _petTypeList.Add(petType);
            return petType;
        }

        public PetType DeletePetType(int deletedPetTypeId)
        {
            InitData();
            foreach (PetType petType in _petTypeList)
            {
                if (petType.PetTypeId == deletedPetTypeId)
                {
                    _petTypeList.Remove(petType);
                    return petType;
                }
            }
            return null;
        }

        public List<PetType> getAllPetTypes()
        {
            InitData();
            return _petTypeList;
        }

        public PetType getPetTypeByFilter()
        {
            throw new NotImplementedException();
        }

        public PetType getTypeById(int id)
        {
            InitData();
            foreach (PetType petType in _petTypeList)
            {
                if (petType.PetTypeId == id)
                {
                    return petType;
                }
            }
            return null;
        }

        public PetType UpdatePetType(int UpdatePetTypeId, PetType petType)
        {
            InitData();
            foreach (PetType foundPetType in _petTypeList)
            {
                if (foundPetType.PetTypeId == UpdatePetTypeId)
                {
                    foundPetType.PetTypeName = petType.PetTypeName;
                }
            }
            return petType;
        }
    }
}

using CompulsoryPetshop.Core.DomainService;
using CompulsoryPetshop.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CompulsoryPetshop.Core.ApplicationService.Service
{
    public class OwnerService : IOwnerService
    {

        private IOwnerRepository _ownerRepo;

        public OwnerService (IOwnerRepository ownerRepository)
        {
            _ownerRepo = ownerRepository;
        }
        public Owner CreateOwner(Owner newOwner)
        {
            if (newOwner.Name.Equals(null) || newOwner.Age < 0)
            {
                throw new Exception("Missing or wrong Owner information");
            }
            return _ownerRepo.CreateOwner(newOwner);
        }

        public Owner DeleteOwner(int deletedOwnerId)
        {
            if (deletedOwnerId <= 0)
            {
                throw new Exception("Invalid Id");
            }
            return _ownerRepo.DeleteOwner(deletedOwnerId);
        }

        public List<Owner> getAllOwners()
        {
            return _ownerRepo.getAllOwners();
        }

        public Owner getOwnerByFilter()
        {
            return _ownerRepo.getOwnerByFilter();
        }

        public Owner getOwnerById(int id)
        {
            if (id <= 0)
            {
                throw new Exception("Invalid Id");
            }
            return _ownerRepo.getOwnerById(id);
        }

        public Owner UpdateOwner(int UpdateOwnerId, Owner Updateowner)
        {
            if (UpdateOwnerId <= 0)
            {
                throw new Exception("Invalid Id");
            }
            if (Updateowner.Name.Equals(null) || Updateowner.Age < 0)
            {
                throw new Exception("Missing or wrong Owner information");
            }
            return _ownerRepo.UpdateOwner(UpdateOwnerId,Updateowner);
        }
    }
}

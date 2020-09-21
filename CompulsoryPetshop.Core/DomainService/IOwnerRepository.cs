using CompulsoryPetshop.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CompulsoryPetshop.Core.DomainService
{
    public interface IOwnerRepository
    {
        public List<Owner> getAllOwners();

        public Owner getOwnerById(int id);

        public Owner CreateOwner(Owner newOwner);

        public Owner UpdateOwner(int UpdateOwnerId, Owner Updateowner);

        public Owner DeleteOwner(int deletedOwnerId);

        public Owner getOwnerByFilter();
    }
}

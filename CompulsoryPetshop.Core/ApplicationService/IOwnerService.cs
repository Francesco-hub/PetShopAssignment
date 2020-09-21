using CompulsoryPetshop.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CompulsoryPetshop.Core.ApplicationService
{
    public interface IOwnerService
    {
        public List<Owner> getAllOwners();

        public Owner getOwnerById(int id);

        public Owner CreateOwner(Owner newOwner);

        public Owner UpdateOwner(int UpdateOwnerId, Owner Updateowner);

        public Owner DeleteOwner(int deletedOwnerId);

        public Owner getOwnerByFilter();
    }
}

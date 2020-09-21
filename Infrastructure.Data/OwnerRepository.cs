using CompulsoryPetshop.Core.DomainService;
using CompulsoryPetshop.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infrastructure.Data
{
    public class OwnerRepository : IOwnerRepository
    {
        private static List<Owner> _ownerList = new List<Owner>();
        public static int onlyInitDataOnce = 0;



        public void InitData()
        {
            if (onlyInitDataOnce == 0)
            {
                _ownerList.Add(new Owner()
                {
                    OwnerID = 1,
                    Name = "Carl",
                    Age = 12
                }); ;

                _ownerList.Add(new Owner()
                {
                    OwnerID = 2,
                    Name = "Neymar",
                    Age = 29
                });

                _ownerList.Add(new Owner()
                {
                    OwnerID = 3,
                    Name = "Gandalf",
                    Age = 999
                });

                _ownerList.Add(new Owner()
                {
                    OwnerID = 4,
                    Name = "Harry Potter",
                    Age = 12
                });

                
                onlyInitDataOnce++;
            }
        }
        public Owner CreateOwner(Owner newOwner)
        {
            InitData();
            newOwner.OwnerID = _ownerList.Count() + 1;
            _ownerList.Add(newOwner);
            return newOwner;
        }

        public Owner DeleteOwner(int deletedOwnerId)
        {
            InitData();
            foreach (Owner owner in _ownerList)
            {
                if (owner.OwnerID == deletedOwnerId)
                {
                    _ownerList.Remove(owner);
                    return owner;
                }
            }
            return null;
        }

        public List<Owner> getAllOwners()
        {
            InitData();
            return _ownerList;
        }

        public Owner getOwnerByFilter()
        {
            InitData();
            throw new NotImplementedException();
        }

        public Owner getOwnerById(int id)
        {
            InitData();
            foreach (Owner owner in _ownerList)
            {
                if (owner.OwnerID == id)
                {
                    return owner;
                }
            }
            return null;
        }

        public Owner UpdateOwner(int UpdateOwnerId, Owner Updateowner)
        {
            InitData();
            foreach (Owner owner in _ownerList)
            {
                if (owner.OwnerID == UpdateOwnerId)
                {
                    owner.Name = Updateowner.Name;
                    owner.Age = Updateowner.Age;
                }
            }
            return Updateowner;
        }
    }
}

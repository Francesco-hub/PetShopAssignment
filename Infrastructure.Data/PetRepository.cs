using CompulsoryPetshop.Core.DomainService;
using CompulsoryPetshop.Core.Entities;
using CompulsoryPetshop.UI;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructure.Data
{
    public class PetRepository : IPetRepository
    {
        private static List<Pet> _petList = new List<Pet>();
        public static int onlyInitDataOnce = 0;

        public void InitData()
        {
            if (onlyInitDataOnce == 0) {
            _petList.Add(new Pet()
            {
                PetId = 1,
                Name = "Groot",
                Type = "tree",
                Price = 34,
                BirthDate = new DateTime(2014, 07, 31),
                PrevOwner = new Owner()
                    {OwnerID = 1,
                    Name = "Starlord",
                    Age = 27
                    },
                Color = "brown"
            });

                _petList.Add(new Pet()
                {
                    PetId = 2,
                    Name = "Venom",
                    Type = "Symbiote",
                    Price = 14,
                    BirthDate = new DateTime(2018, 10, 11),
                    PrevOwner = new Owner()
                    {
                        OwnerID = 2,
                        Name = "Eddie Brock",
                        Age = 30
                    },
                    Color = "black"
                }); 
                _petList.Add(new Pet()
                {
                    PetId = 3,
                    Name = "Rex",
                    Type = "dog",
                    Price = 31,
                    BirthDate = new DateTime(1994, 11, 10),
                    PrevOwner = new Owner()
                    { OwnerID = 3,
                        Name = "Tv Show",
                        Age = 50,
                    },
                    Color = "brown"
                }) ;

            _petList.Add(new Pet()
            {
                PetId = 4,
                Name = "Jaws",
                Type = "shark",
                Price = 337,
                BirthDate = new DateTime(1975, 12, 26),
                PrevOwner = new Owner()
                {OwnerID = 4,
                Name = "Unknown",
                Age = 30
                },
                Color = "white"
            });

                _petList.Add(new Pet()
                {
                    PetId = 5,
                    Name = "Hedwig",
                    Type = "Snowy Owl",
                    Price = 42,
                    BirthDate = new DateTime(2001, 11, 23),
                    PrevOwner = new Owner()
                    {
                        OwnerID = 5,
                        Name = "Harry Potter",
                        Age = 10
                    },
                    Color = "white"
                }) ;

            _petList.Add(new Pet()
            {
                PetId = 6,
                Name = "Artax",
                Type = "horse",
                Price = 73,
                BirthDate = new DateTime(1984, 04, 06),
                PrevOwner = new Owner()
                {OwnerID = 6,
                Name = "Bastian Bux",
                Age = 14
                },
                Color = "white"
            });
                onlyInitDataOnce++;
            }
        }

        public List<Pet> GetAllPets()
        {
            InitData();
            return _petList;
            
        }

        public Pet CreateNewPet(Pet pet)
        {
            InitData();
            pet.PetId = _petList.Count() + 1;
            _petList.Add(pet);
            
            return pet;
        }

        public Pet DeletePet(int id)
        {
            InitData();
            foreach (Pet pet in _petList)
            {
                if (pet.PetId == id)
                {
                    _petList.Remove(pet);
                    return pet;
                }
            }
            return null;
            
        }

        public Pet UpdatePet(int id, Pet updatedPet)
        {
            InitData();
            foreach (Pet pet in _petList)
            {
                if (pet.PetId == id)
                {
                    pet.Name = updatedPet.Name;
                    pet.Color = updatedPet.Color;
                    pet.Type = updatedPet.Type;
                    pet.BirthDate = updatedPet.BirthDate;
                    pet.PrevOwner = updatedPet.PrevOwner;
                    pet.SoldDate = updatedPet.SoldDate;
                }
            }
            return updatedPet;
        }

        public Pet ReadPetById(int id)
        {
            InitData();
            foreach (Pet pet in _petList)
            {
                if (pet.PetId == id)
                {
                    return pet;
                }
            }
            return null;
        }

        public List<Pet> GetAllPetsByPrice()
        {
            InitData();
            List<Pet> sortedLst = _petList.OrderBy(o => o.Price).ToList();
            return sortedLst;
        }
    }
}

using CompulsoryPetshop.Core.DomainService;
using CompulsoryPetshop.UI;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructure.Data
{
    public class PetRepository : IPetRepository
    {
        private static List<Pet> _petList = new List<Pet>();


        public void InitData()
        {
            _petList.Add(new Pet()
            {
                PetId = 1,
                Name = "Groot",
                Type = "tree",
                Price = 34,
                BirthDate = new DateTime(2014, 07, 31),
                PrevOwner = "Starlord",
                Color = "brown"
            });

            _petList.Add(new Pet()
            {
                PetId = 2,
                Name = "Venom",
                Type = "Symbiote",
                Price = 14,
                BirthDate = new DateTime(2018, 10, 11),
                PrevOwner = "Eddie Brock",
                Color = "black"
            });

            _petList.Add(new Pet()
            {
                PetId = 3,
                Name = "Rex",
                Type = "dog",
                Price = 31,
                BirthDate = new DateTime(1994, 11, 10),
                PrevOwner = "Tv Show",
                Color = "brown"
            });

            _petList.Add(new Pet()
            {
                PetId = 4,
                Name = "Jaws",
                Type = "shark",
                Price = 337,
                BirthDate = new DateTime(1975, 12, 26),
                PrevOwner = "NONE",
                Color = "white"
            });

            _petList.Add(new Pet()
            {
                PetId = 5,
                Name = "Hedwig",
                Type = "Snowy Owl",
                Price = 42,
                BirthDate = new DateTime(2001, 11, 23),
                PrevOwner = "Harry Potter",
                Color = "white"
            });

            _petList.Add(new Pet()
            {
                PetId = 6,
                Name = "Artax",
                Type = "horse",
                Price = 73,
                BirthDate = new DateTime(1984, 04, 06),
                PrevOwner = "Bastian Bux",
                Color = "white"
            });

        }

        public List<Pet> GetAllPets()
        {
            return _petList;
        }

        public void CreateNewPet(Pet pet)
        {
            _petList.Add(pet);
        }

        public void DeletePet(int id)
        {
            foreach (Pet pet in _petList)
            {
                if (pet.PetId == id)
                {
                    _petList.Remove(pet);
                }
            }
            
        }

        public void UpdatePet(Pet previousPet, Pet updatedPet)
        {
            int id = previousPet.PetId;
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
        }

        public Pet ReadPetById(int id)
        {
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
            List<Pet> sortedLst = _petList.OrderBy(o => o.Price).ToList();
            return sortedLst;
        }
    }
}

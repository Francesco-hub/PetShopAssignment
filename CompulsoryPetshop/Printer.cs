using CompulsoryPetshop.Core.ApplicationService;
using CompulsoryPetshop.Core.ApplicationService.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CompulsoryPetshop.UI
{
    public class Printer : IPrinter
    {
        private IPetService _petService;
        public Printer(IPetService petService)
        {
            _petService = petService;
        }

        #region Options
        public int PrintMenuItems()
        {
            string[] menuItems =    {
                "Print all Pets",
                "Find pets by Type",
                "Create a new pet",
                "Delete a pet",
                "Update a pet",
                "Print all pets sorted by price",
                "Print the 5 cheapest pets",
                "Exit"
            };

            Console.WriteLine("Enter your selection: \n");

            for (int i = 0; i < menuItems.Length; i++)
            {
                Console.WriteLine($"{i + 1}: {menuItems[i]}");
            }
            Console.WriteLine("");

            int selection;
            while (!int.TryParse(Console.ReadLine(), out selection)
                || selection < 1 || selection > 8)
            {
                Console.WriteLine("Please, select a valid number (1-8)");
            }
            return selection;
        }
        #endregion

        #region Print by price
        public void PrintByPrice(List<Pet> OrderedPetList)
        {
            foreach (var pet in OrderedPetList)
            {
                Console.WriteLine($" NAME:{pet.Name}\tTYPE:{pet.Type}\tPRICE:{pet.Price}\t");
                Console.WriteLine(" ");
            }
            #endregion


        }

        public void End()
        {
            Console.WriteLine("Program terminated correctly");
        }

        public Pet NewPetInfo()
        {
            Pet pet = new Pet();
            Console.WriteLine("Insert name: ");
            pet.Name = Console.ReadLine();
            Console.WriteLine("Insert type: ");
            pet.Type = Console.ReadLine();
            Console.WriteLine("Insert price: ");
            pet.Price = Double.Parse(Console.ReadLine());
            Console.WriteLine("Insert birth date:");
            pet.BirthDate = CheckDate(Console.ReadLine());
            Console.WriteLine("Insert sold date: ");
            pet.SoldDate = CheckDate(Console.ReadLine());
            Console.WriteLine("Insert color: ");
            pet.Color = Console.ReadLine();
            Console.WriteLine("Insert previous owner: ");
            pet.PrevOwner = Console.ReadLine();
            

            return pet;
        }


        public void PrintPetByType(List<Pet> petLst)
        {
            Console.WriteLine("Insert the type of pet");
            string type = Console.ReadLine();
            foreach (Pet pet in petLst)
            {
                if (pet.Type.Equals(type))
                {
                    Console.WriteLine($" NAME:{pet.Name}\tTYPE:{pet.Type}\tPRICE:{pet.Price}\t");
                    Console.WriteLine(" ");
                }
            }

        }

        public void PrintListOfPets(List<Pet> petLst)
        { 
            foreach (var pet in petLst)
            {
                Console.WriteLine($"NAME:{pet.Name}\tTYPE:{pet.Type}\tPRICE:{pet.Price}\tBIRTHDATE:\t{pet.BirthDate}\tCOLOR:{pet.Color}\tOWNER:{pet.PrevOwner}\t");
                Console.WriteLine(" ");
            }
        }
        DateTime CheckDate(String s)
        {
            DateTime Checker;
            while (!DateTime.TryParse(s, out Checker))
            {
                Console.WriteLine("Insert a valid date: ");
                s = Console.ReadLine();
            }
            return Checker;
        }

        public Pet UpdatePet()
        {
            Pet newpet = NewPetInfo();
           return newpet;
        }

        public int getId()
        {
            Console.WriteLine("Insert an Id for the Pet");
            return int.Parse(Console.ReadLine());
        }

        public void PrintFiveCheapestPets(List<Pet> petLst)
        {
            int counter = 0;
            foreach (var pet in petLst)
            {
                counter++;
                Console.WriteLine($" NAME:{pet.Name}\tTYPE:{pet.Type}\tPRICE:{pet.Price}\t");
                Console.WriteLine(" ");
                if (counter == 5)
                {
                    break;
                }
            }
        }
    }
}
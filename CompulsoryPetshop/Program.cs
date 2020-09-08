using CompulsoryPetshop.Core.ApplicationService;
using CompulsoryPetshop.Core.ApplicationService.Service;
using CompulsoryPetshop.Core.DomainService;
using Infrastructure.Data;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;

namespace CompulsoryPetshop.UI
{
    public class Program
    {
        public static List<Pet> PetLst;
        public static int id = 1;
        public static void Main(string[] args)
        {
            var petRepo = new PetRepository();
            petRepo.InitData();
            PetService _petService = new PetService(petRepo);
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddScoped<IPetRepository, PetRepository>();
            serviceCollection.AddScoped<IPetService, PetService>();
            serviceCollection.AddScoped<IPrinter, Printer>();
            PetLst = _petService.GetAllPets();

            var serviceProvider = serviceCollection.BuildServiceProvider();
            var printer = serviceProvider.GetRequiredService<IPrinter>();
            var selection = printer.PrintMenuItems();
               

            while (selection != 8)
            {
                switch (selection)
                {
                    case 1:
                        Console.Clear();
                        printer.PrintListOfPets(PetLst);
                        break;
                    case 2:
                        Console.Clear();
                        printer.PrintPetByType(PetLst);
                        
                        break;
                    case 3:
                        Console.Clear();
                        Pet newPet = printer.NewPetInfo();
                        newPet.PetId = PetLst.Count+1;
                        _petService.CreateNewPet(newPet);
                        break;
                    case 4:
                        Console.Clear();
                        var petId = printer.getId();
                        _petService.DeletePet(petId);
                        break;
                    case 5:
                        Console.Clear();
                        var Id = printer.getId();
                        var UpdatedPet = printer.UpdatePet();
                        Pet PreviousPet = new Pet();
                        foreach (Pet existingPets in PetLst)
                        {
                            if (Id == existingPets.PetId)
                            {
                                PreviousPet = existingPets;
                            }
                        }
                        _petService.UpdatePet(PreviousPet, UpdatedPet);
                        break;
                    case 6:
                        Console.Clear();
                        printer.PrintByPrice(_petService.GetAllPetsByPrice()); 
                        break;
                    case 7:
                        Console.Clear();

                        printer.PrintFiveCheapestPets(_petService.GetAllPetsByPrice()); 
                        break;
                    default:
                        Console.Clear();
                        break;
                }
                selection = printer.PrintMenuItems();
            }
            printer.End();
        }
    }
}

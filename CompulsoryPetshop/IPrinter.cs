using System;
using System.Collections.Generic;
using System.Text;

namespace CompulsoryPetshop.UI
{
    public interface IPrinter
    {
        int PrintMenuItems();
        public void PrintByPrice(List<Pet> petLst);

        public void PrintFiveCheapestPets(List<Pet> petLst);
        public void End();
        public void PrintListOfPets(List<Pet> petLst);
        public Pet NewPetInfo();
        public Pet UpdatePet();
        public void PrintPetByType(List<Pet> petLst);
        public int getId();

    }
}

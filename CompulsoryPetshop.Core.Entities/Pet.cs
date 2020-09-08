using System;

namespace CompulsoryPetshop.UI
{
    public class Pet
    {
        public int PetId  { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime SoldDate { get; set; }
        public string Color { get; set; }
        public string PrevOwner { get; set; }
        public double Price { get; set; }

       
    }
}

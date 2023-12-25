using AnimalClasses.enums;
namespace AnimalClasses.animal
{
    public abstract class Animal
    {
        public string? Country { get; set; }
        public bool HideFromOtherAnimals { get; set; }
        public string? Name { get; set; }
        private eClassificationAnimal Classification { get; set; }
        protected Animal(string country, bool hideFromOtherAnimals, string name, eClassificationAnimal classification)
        {
            this.Country = country;
            this.HideFromOtherAnimals = hideFromOtherAnimals;
            this.Name = name;
            this.Classification = classification;

        }
        protected Animal()
        {
            this.Country = "";
            this.HideFromOtherAnimals = false;
            this.Name = "";
            this.Classification = eClassificationAnimal.Omnivores;
        }
        public void Deconstruct(out string country, out bool hideFromOtherAnimals, out string name,
        out eClassificationAnimal classification)
        {
            country = Country;
            hideFromOtherAnimals = HideFromOtherAnimals;
            name = Name;
            classification = Classification;
        }
        public eClassificationAnimal GetClassificationAnimal
        {
            get { return Classification; }
            set { Classification = value; }

        }
        public abstract eFavoriteFood GetFavoriteFood();
        public abstract void SayHello();

    }
}
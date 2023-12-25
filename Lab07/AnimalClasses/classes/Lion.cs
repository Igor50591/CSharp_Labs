using AnimalClasses.enums;
using AnimalClasses.animal;
namespace AnimalClasses.classes
{
    [Comment("Comment attribute for class lion")]
    class Lion : Animal
    {
        public override eFavoriteFood GetFavoriteFood()
        {
            return eFavoriteFood.Meat;
        }

        public override void SayHello()
        {
            Console.WriteLine("RAAAR");
        }
    }
}
using AnimalClasses.enums;
using AnimalClasses.animal;
namespace AnimalClasses.classes
{
    [Comment("Comment attribute for class pig")]
    public class Pig : Animal
    {
        public override eFavoriteFood GetFavoriteFood()
        {
            return eFavoriteFood.Everything;
        }

        public override void SayHello()
        {
            Console.WriteLine("OOINK");
        }
    }
}

using AnimalClasses.enums;
using AnimalClasses.animal;
namespace AnimalClasses.classes
{
    [Comment("Comment attribute for class cow")]
    public class Cow : Animal
    {
        public override eFavoriteFood GetFavoriteFood()
        {
            return eFavoriteFood.Plants;
        }

        public override void SayHello()
        {
            Console.WriteLine("MUUU");
        }
    }
}
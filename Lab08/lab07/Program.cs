using System.Reflection;
using System.Xml;
using AnimalClasses;
using AnimalClasses.classes;
using AnimalClasses.animal;
using AnimalClasses.enums;
using System.Xml.Serialization;

public class Program
{
    public static void Main()
    {
        // create Animal example
        Animal Lion = new Lion();
        Lion.Country = "Russia";
        Lion.HideFromOtherAnimals = false;
        Lion.Name = "Lion1";
        Lion.GetClassificationAnimal = eClassificationAnimal.Carnivores;

        XmlSerializer xmlSerializer = new XmlSerializer(typeof(Lion));

        // get stream and serialize object
        using (FileStream fs = new FileStream("D:\\Study\\2 Course\\3 semestr\\C# 2023\\Code\\lab08\\Animal.xml", FileMode.OpenOrCreate))
        {
            xmlSerializer.Serialize(fs, Lion);
            Console.WriteLine("Serialized");
        }
        using (FileStream fs = new FileStream("D:\\Study\\2 Course\\3 semestr\\C# 2023\\Code\\lab08\\Animal.xml", FileMode.OpenOrCreate))
        {
            Animal? Lion1 = xmlSerializer.Deserialize(fs) as Lion;
            Console.WriteLine($"Country: {Lion1?.Country}\nHide from other animals: {Lion1?.HideFromOtherAnimals}\n" +
                              $"Name: {Lion1?.Name}\nClassification: {Lion1?.GetClassificationAnimal}");
        }
    }

 

}

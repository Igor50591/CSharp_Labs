namespace Task2
{
    public class Car : IEquatable<Car>
    {
        public Car(string name, string engine, uint maxSpeed)
        {
            Name = name;
            Engine = engine;
            MaxSpeed = maxSpeed;
        }
        public string Name { get; }
        public string Engine { get; }
        public uint MaxSpeed { get; }
        public override string ToString() => Name;
        public override bool Equals(object? obj) => this == obj as Car;
        public virtual bool Equals(Car? other) => this == other;
        protected virtual Type EqualityContract { get; } = typeof(Car);
        public static bool operator ==(Car? car1, Car? car2) =>
    car1?.Name == car2?.Name && car1?.Engine == car2?.Engine && car1?.MaxSpeed == car2?.MaxSpeed && car1?.EqualityContract == car2?.EqualityContract;
        public static bool operator !=(Car? car1, Car? car2) => !(car1 == car2);

        public override int GetHashCode() => Name.GetHashCode() ^ Engine.GetHashCode() ^ MaxSpeed.GetHashCode();
    }

    public class  CarsCatalog
    {
        private Car[] _cars;
        public CarsCatalog(params Car[] car) =>
        _cars = car.ToArray();
        public string this[string name]
        {
            get
            {
                foreach (var Car in _cars)
                {
                    if (Car.Name == name) return $"{Car.Name}, {Car.Engine}";
                }
                throw new Exception("Unknown name");
            }
        }
        public Car this[int index]
        {
            set
            {
                _cars[index] = value;
            }
        }
    }

  public class Program
    {
        public static void Main(string[] args)
        {
            Car c1 = new("Honda CR-V", "K24Z4", 190);
            Console.WriteLine($"c1 ToString: {c1.ToString()}");
            Car c2 = new("Honda CR-V", "K24Z4", 190);
            Car c3 = new("Citroen C4", "EP6C", 181);
            Console.WriteLine($"Equals c1 and c2: {Car.Equals(c1, c2)}");
            Console.WriteLine($"Equals c1 and c3: {Car.Equals(c1, c3)}");
            CarsCatalog catalog = new(new Car[] { c1, c2, c3 });
            Console.WriteLine(catalog["Citroen C4"]);
        }
    }
}

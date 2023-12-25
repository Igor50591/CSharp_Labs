namespace Task1
{   
    struct Vector
    {
        double x;
        double y;
        double z;
        private readonly double Length()
        {
            return Math.Pow((Math.Pow(x, 2) + Math.Pow(y, 2) + Math.Pow(z, 2)), 0.5);
        }

        public override string ToString() => $"( {x}, {y}, {z} )";
        public Vector(double x, double y, double z)
        {
            this.x = x; this.y = y; this.z = z;
        }
        public static Vector operator +(Vector v1, Vector v2)
        {   
            Vector vec = new(v1.x + v2.x, v1.y + v2.y, v1.z + v2.z);
            return vec;
        }
        public static Vector operator *(double k, Vector v1)
        {
            Vector vec = new(k*v1.x, k*v1.y, k*v1.z);
            return vec;
        }
        public static Vector operator *(Vector v1, double k) => k*v1;
        public static double operator *(Vector v1, Vector v2)
        {
            return (v1.x * v2.x + v1.y * v2.y + v1.z + v2.z);
        }
        public static bool operator <(Vector v1, Vector v2)
        {
            return v1.Length() < v2.Length();
        }
        public static bool operator >(Vector v1, Vector v2) => v1.Length() > v2.Length();

        public static bool operator ==(Vector v1, Vector v2) => v1.Length() == v2.Length();

        public static bool operator !=(Vector v1, Vector v2) => v1.Length != v2.Length;


    }
    class Program
    {
        static void Main(string[] args) {
            Vector v1 = new(10, 15, 10);
            Vector v2 = new(13, 16, 12);
            Vector v3 = v1 + v2;
            Console.WriteLine(v3);
            Vector v4 = 2 * v3;
            Console.WriteLine(v4);
            v4 = v4*0.5;
            Console.WriteLine(v4);
            double p12 = v1 * v2;
            Console.WriteLine(p12);
            Console.WriteLine(v1>v2);
            Console.WriteLine(v2<v3);
            Console.WriteLine(v3==v4);
            Console.WriteLine(v1 != v2);
            

        }
    }
}

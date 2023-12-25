namespace Task3
{
    public class Currency
    {
        public double Value { get; set; }
    }
    public class CurrencyUSD : Currency
    {
        public static double toEUR;
        public static double toRUB;
        public CurrencyUSD(double value) {
            Value = value;
                }
     
        public static explicit operator CurrencyUSD(CurrencyEUR val)
        {
            return new CurrencyUSD (val.Value*CurrencyEUR.toUSD);
        }
        public static implicit operator CurrencyUSD(CurrencyRUB val)
        {
            return new CurrencyUSD(val.Value * CurrencyRUB.toUSD);
        }
    }
    public class CurrencyEUR: Currency
    {
        public static double toUSD;
        public static double toRUB;
        public CurrencyEUR(double value)
        {
            Value = value;
        }
        public static explicit operator CurrencyEUR(CurrencyUSD val)
        {
            return new CurrencyEUR(val.Value * CurrencyUSD.toEUR);
        }
        public static implicit operator CurrencyEUR(CurrencyRUB val)
        {
            return new CurrencyEUR(val.Value * CurrencyRUB.toEUR);
        }
    }
    public class CurrencyRUB : Currency
    {
        public static double toEUR;
        public static double toUSD;
        public CurrencyRUB(double value)
        {
            Value = value;
        }
        public static explicit operator CurrencyRUB(CurrencyUSD val)
        {
            return new CurrencyRUB(val.Value * CurrencyUSD.toRUB);
        }
        public static implicit operator CurrencyRUB(CurrencyEUR val)
        {
            return new CurrencyRUB(val.Value * CurrencyEUR.toRUB);
        }
    }
    public class program
    {
        public static void Main()
        {
            Console.Write("Введите курс доллара относительно рубля: ");
            CurrencyUSD.toRUB = Convert.ToDouble(Console.ReadLine());
            Console.Write("Введите курс евро относительно рубля: ");
            CurrencyEUR.toRUB = Convert.ToDouble(Console.ReadLine());
            Console.Write("Введите курс доллара относительно евро: ");
            CurrencyUSD.toEUR = Convert.ToDouble(Console.ReadLine());
            CurrencyRUB.toUSD = 1 / CurrencyUSD.toRUB;
            CurrencyRUB.toEUR = 1 / CurrencyEUR.toRUB;
            CurrencyEUR.toUSD = 1 / CurrencyUSD.toEUR;
            //DEMO Convert rub to usd and eur
            CurrencyRUB rub1 = new(10000);
            Console.WriteLine($"rub1.value={rub1.Value}");
            CurrencyUSD usd1 = (CurrencyUSD)rub1; //explicit
            Console.WriteLine($"usd1.value={usd1.Value}");
            CurrencyEUR eur1 = rub1; //implicit
            Console.WriteLine($"eur1.value={eur1.Value}");
            //DEMO Convert usd to rub and eur
            CurrencyUSD usd2 = new(1000);
            Console.WriteLine($"usd2.value={usd2.Value}");
            CurrencyRUB rub2 = (CurrencyRUB)usd2;  //explicit
            Console.WriteLine($"rub2.value={rub2.Value}");
            CurrencyEUR eur2 = (CurrencyEUR) usd2;  //explicit
            Console.WriteLine($"eur2.value={eur2.Value}");
            //DEMO Convert eur to rub and usd
            CurrencyEUR eur3 = new(1000);
            Console.WriteLine($"eur3.value={eur3.Value}");
            CurrencyRUB rub3 = eur3; //implicit
            Console.WriteLine($"rub3.value={rub3.Value}");
            CurrencyUSD usd3 = (CurrencyUSD)eur3;  //explicit
            Console.WriteLine($"usd3.value={usd3.Value}");
        }
    }
}

using Newtonsoft.Json;
using System.Net;
using System.Threading.Tasks;
namespace Lab06
{
    public class Weather
    {
        public Coord coord;
        public string name;
        public WeatherNow[] weather;
        public Sys sys;
        public Temp main;
    }
    public class Coord
    {
        public double lon;
        public double lat;
    }

    public class Temp
    {
        public double temp;
    }
    public class WeatherNow
    {
        public string main;
        public string description;
    }
    public class Sys
    {
        public string country;
    }

   


    public class Program
    {
        static HttpClient httpClient = new HttpClient();
        public static async Task<Weather> ConnectAsync()
        {
           WebRequest request = WebRequest.Create($"https://api.openweathermap.org/data/2.5/weather?lat={lat}&lon={lon}&units=metric&appid=51fcf697cf5bfc9274cb2d9595034531");
           request.Method = "POST";
           WebResponse response = await request.GetResponseAsync();

            string answer = string.Empty;
            using (Stream s = response.GetResponseStream())
            {
                using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                {
                    answer = await reader.ReadToEndAsync();
                }
            }
            Weather response_global = JsonConvert.DeserializeObject<Weather>(answer);
            response.Close();
            return response_global; 
         }
        public static double lat;
        public static double lon;
        
        public static void Main()
        {
            Random rnd = new();
            Weather[] array = new Weather[50];
            byte count = 0;
            while (count != 50)
            {
                lat = (rnd.NextDouble() * (90 - (-90))) - 90;
                lon = (rnd.NextDouble() * (180 + 180)) - 180;
                Weather weather = ConnectAsync().Result;
                if (String.IsNullOrEmpty(weather.name) || String.IsNullOrEmpty(weather.sys.country)) continue;
                array[count] = weather;
                //Console.Write($"{weather.name}, {weather.sys.country} \t");
                count++;
            }
            var minTempCountry = array.MinBy(x => x.main.temp);
            Console.WriteLine($"\nCountry with min. temp: {minTempCountry.sys.country}");
            var maxTempCountry = array.MaxBy(x => x.main.temp);
            Console.WriteLine($"Country with max. temp: {maxTempCountry.sys.country}");
            var avgTemp = array.Average(x => x.main.temp);
            Console.WriteLine($"average temp:{avgTemp}");
            var Countries = from x in array
                                   group x by x.sys.country;
            var CountOfCountries = Countries.Count();
            Console.WriteLine($"Count of countries: {CountOfCountries}");
            var firstMatch = array.FirstOrDefault(w => w.weather[0].description == "clear sky" || w.weather[0].description ==
           "rain" || w.weather[0].description == "few clouds");
            Console.WriteLine($"The first found country and name of place with suitable description: " +
                              $"{firstMatch.sys.country}, {firstMatch.name} with {firstMatch.weather[0].description}");
        }
    }
 }
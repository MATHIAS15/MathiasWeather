using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Weather;

namespace Weather_Test
{
    class Program
    {
        static void Main(string[] args)
        {

            //Variablea a récupérer dans la BDD apres
            string url = "http://api.openweathermap.org/data/2.5/weather";
            string apiKey = "84af7992ace2dd1b19d32a209737949e";
            string lat = "44.8333";
            string lon = "-0.5667";
            string unite = "metric"; //Celcius
            string lang = "fr";

            HttpForecast weather = new HttpForecast(url, apiKey, lat, lon, unite, lang);
            try
            {
                weather.pullForecast();
                Console.WriteLine(weather.getFullWeather());
                // Sur le programme final :
                // await weather.pullForecastAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                //Indiquer à l'utilisateur une erreur
            }

            Console.ReadLine();
        }
    }
}

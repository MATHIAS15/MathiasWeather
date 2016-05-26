using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;

namespace Weather
{
    //Classe qui va chercher la météo
    public class HttpForecast
    {
        private string URL;
        private string APIKEY;
        private string LATITUDE;
        private string LONGITUDE;
        private string UNITE;
        private string LANG;
        private Forecast f;

        public HttpForecast(string p_url, string p_apikey, string p_lattitude, string p_longitude, string p_unite, string p_lang)
        {
            this.URL = p_url;
            this.APIKEY = p_apikey;
            this.LATITUDE = p_lattitude;
            this.LONGITUDE = p_longitude;
            this.UNITE = p_unite;
            this.LANG = p_lang;
        }

        public void pullForecast()
        {
            string json = new WebClient().DownloadString(this.URL + "?lat=" + this.LATITUDE + "&lon=" + this.LONGITUDE + "&units=" + this.UNITE + "&lang=" + this.LANG + "&appid=" + this.APIKEY);
            //Séréalisation du json pour obtenir un objet
            this.f = JsonConvert.DeserializeObject<Forecast>(json);
        }

        public async Task pullForecastAsync()
        {
            string json = new WebClient().DownloadString(this.URL + "?lat=" + this.LATITUDE + "&lon=" + this.LONGITUDE + "&units=" + this.UNITE + "&lang=" + this.LANG + "&appid=" + this.APIKEY);
            //Séréalisation du json pour obtenir un objet
            this.f = JsonConvert.DeserializeObject<Forecast>(json);
        }

        public string getFullWeather()
        {
            return this.getCity() +", "+ this.getDescription() + ". " + this.getTemperature() + ". "+this.getTempMaxMin()+ ". "+ this.getHumidity()+". "+this.getWind();
        }

        public string getCity()
        {
            return "A "+this.f.name;
        }

        public string getDescription()
        {
            return this.f.weather[0].description;
        }

        public string getTemperature()
        {
            return "Il fait actuellement "+ this.f.main.temp + " degrès";
        }

        public string getTempMaxMin()
        {
            return "Les températures iront de " + this.f.main.temp_min + " dégrès à " + this.f.main.temp_max + " degrès";
        }

        public string getHumidity()
        {
            return "Le taux d'humidité est de "+this.f.main.humidity +" pourcents";
        }

        public string getWind()
        {
            return "Le vent souffle à "+this.f.wind.speed +" mètres par seconde ";
        }
    }
}

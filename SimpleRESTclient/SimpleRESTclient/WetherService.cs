using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SimpleRESTclient
{
    class WetherService
    {

        public static async Task<WeatherInService> GetWeather(string path)
        {

            dynamic results = await DataService.GetDataFromService(path).ConfigureAwait(false);

            if (results["weather"] != null)
            {
                WeatherInService weather = new WeatherInService();
                weather.Id = (string)results["id"];
                weather.Temperature = (string)results["main"]["temp"] + " F";

                DateTime time = new System.DateTime(1970, 1, 1, 0, 0, 0, 0);
                DateTime sunrise = time.AddSeconds((double)results["sys"]["sunrise"]);
                weather.Date = sunrise.ToString() + " UTC";
                return weather;
            }
            else
            {
                return null;
            }
        }



        public class WeatherInService
        {
            // Because labels bind to these values, set them to an empty string to
            // ensure that the label appears on all platforms by default.
            public string Id { get; set; } = " ";
            public string Temperature { get; set; } = " ";
            public string Date { get; set; } = " ";

            public string getWetherString()
            {
                string retStr = " ";
                retStr += " Id :" + this.Id;
                retStr += " Temp :" + this.Temperature;
                retStr += " Date :" + this.Date;

                return retStr;
            }
        }
    }
}

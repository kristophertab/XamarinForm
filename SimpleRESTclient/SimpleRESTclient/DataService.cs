﻿using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace SimpleRESTclient
{
    public class DataService
    {
        public static string serviceUrl = "http://192.168.43.159:7135/api/temperatures";
        public static string minSufix = "/min";
        public static string maxSufix = "/max";
        public static string avrSufix = "/avg";
        public static string plotSufix = "/week";

        public static async Task<dynamic> GetDataFromService(string queryString)
        {
            HttpClient client = new HttpClient();
            var response = await client.GetAsync(queryString);

            dynamic data = null;
            if (response != null)
            {
                string json = response.Content.ReadAsStringAsync().Result;
                data = JsonConvert.DeserializeObject(json);
            }

            return data;
        }

        public static async Task<Weather> GetWeatherDataFromService(string queryString)
        {
            HttpClient client = new HttpClient();
            var response = await client.GetAsync(queryString);

            //string dev_data = "{\"id\":39844,\"temperature\":100.0,\"date\":\"2017 - 01 - 01T12: 46:09\"}";

            Weather data = null;
            if (response != null)
            {
                string json = response.Content.ReadAsStringAsync().Result;
                data = JsonConvert.DeserializeObject<Weather>(json);
            }

            return data;
        }

        public static async Task<List<Weather>> GetWeatherListFromService(string queryString)
        {
            HttpClient client = new HttpClient();
            var response = await client.GetAsync(queryString);

            //string dev_data = "[{\"id\":1,\"temperature\":74.67759,\"date\":null},{\"id\":2,\"temperature\":74.7920151,\"date\":null},{\"id\":3,\"temperature\":74.855484,\"date\":null},{\"id\":4,\"temperature\":75.76137,\"date\":null},{\"id\":5,\"temperature\":75.48369,\"date\":null},{\"id\":6,\"temperature\":75.29217,\"date\":null},{\"id\":7,\"temperature\":74.86363,\"date\":null},{\"id\":8,\"temperature\":74.88173,\"date\":null},{\"id\":9,\"temperature\":75.42991,\"date\":null},{\"id\":10,\"temperature\":75.56968,\"date\":null},{\"id\":11,\"temperature\":75.11188,\"date\":null},{\"id\":12,\"temperature\":74.23059,\"date\":null},{\"id\":13,\"temperature\":74.8671951,\"date\":null},{\"id\":14,\"temperature\":75.2824554,\"date\":null},{\"id\":15,\"temperature\":75.08726,\"date\":null},{\"id\":16,\"temperature\":74.91914,\"date\":null},{\"id\":17,\"temperature\":75.0432,\"date\":null},{\"id\":18,\"temperature\":75.618576,\"date\":null},{\"id\":19,\"temperature\":74.5906,\"date\":null},{\"id\":20,\"temperature\":75.21954,\"date\":null},{\"id\":21,\"temperature\":74.89144,\"date\":null},{\"id\":22,\"temperature\":74.96822,\"date\":null},{\"id\":23,\"temperature\":75.1072,\"date\":null},{\"id\":24,\"temperature\":75.045,\"date\":null},{\"id\":25,\"temperature\":75.38789,\"date\":null},{\"id\":26,\"temperature\":74.96557,\"date\":null},{\"id\":27,\"temperature\":74.7605,\"date\":null},{\"id\":28,\"temperature\":74.93596,\"date\":null},{\"id\":29,\"temperature\":74.507515,\"date\":null},{\"id\":30,\"temperature\":75.60325,\"date\":null},{\"id\":31,\"temperature\":75.12474,\"date\":null},{\"id\":32,\"temperature\":74.8364944,\"date\":null},{\"id\":33,\"temperature\":74.57091,\"date\":null},{\"id\":34,\"temperature\":75.20253,\"date\":null},{\"id\":35,\"temperature\":74.75013,\"date\":null},{\"id\":36,\"temperature\":75.27002,\"date\":null},{\"id\":37,\"temperature\":75.24355,\"date\":null},{\"id\":38,\"temperature\":75.05457,\"date\":null},{\"id\":39,\"temperature\":74.32671,\"date\":null},{\"id\":40,\"temperature\":75.431,\"date\":null},{\"id\":41,\"temperature\":75.01736,\"date\":null},{\"id\":42,\"temperature\":74.76663,\"date\":null},{\"id\":43,\"temperature\":75.22883,\"date\":null},{\"id\":44,\"temperature\":74.50418,\"date\":null},{\"id\":45,\"temperature\":75.10929,\"date\":null},{\"id\":46,\"temperature\":75.24053,\"date\":null},{\"id\":47,\"temperature\":75.28498,\"date\":null},{\"id\":48,\"temperature\":74.8608,\"date\":null},{\"id\":49,\"temperature\":74.84193,\"date\":null},{\"id\":50,\"temperature\":74.8532,\"date\":null},{\"id\":51,\"temperature\":75.0336456,\"date\":null},{\"id\":52,\"temperature\":75.23706,\"date\":null},{\"id\":53,\"temperature\":74.6377,\"date\":null}]";

            List<Weather> data = null;
            if (response != null)
            {
                string json = response.Content.ReadAsStringAsync().Result;
                data = JsonConvert.DeserializeObject<List<Weather>>(json);
            }

            return data;
        }

        public class Weather
        {
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
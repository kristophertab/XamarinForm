using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SimpleRESTclient
{
    public class RestService
    {
        public static string myRestUrl = "http://www.google.com";
        public static string projectUrl = "http://192.168.43.195:60869/api/user";
        private string resoultOfSomething = "nothing";
        private string resoultGet = "nothing";

        HttpClient client;

        public RestService()
        {
            client = new HttpClient();
            client.MaxResponseContentBufferSize = 256000;
        }

        public async void GetRest(String url)
        {

            var uri = new Uri(string.Format(url, string.Empty));
            try
            {
                var response = await client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    resoultGet = content.ToString();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("GetRest error", ex.Message);
            }
        }

        public string GetRestResoult()
        {
            return resoultGet;
        }


        public async void PostRest()
        {
            var uri = new Uri(string.Format(projectUrl, string.Empty));

            string jsonData = @"{""userId"" : 13, ""userName"" : ""noname"", ""email"" : ""asd@pl.asd"", ""password"" : ""asdasd""}";

            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            HttpResponseMessage response = null;
            response = await client.PostAsync(uri, content);

            // this result string should be something like: "{"token":"rgh2ghgdsfds"}"
            var result = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
            {
                Debug.WriteLine("PostRest error");
            } 
 
        }



























        public async void GetSomethingString()
        {
            var uri = new Uri(string.Format(projectUrl, string.Empty));

            try
            {
                var response = await client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    resoultOfSomething = content.ToString();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Unsuccessful GetSomething :(", ex.Message);
            }
        }
        public string getResoultOfSomething()
        {
            return resoultOfSomething;
        }

   
        
    }
}

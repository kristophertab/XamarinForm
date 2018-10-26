using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Newtonsoft.Json;
using Microcharts;
using SkiaSharp;
using static SimpleRESTclient.DataService;
using System.Globalization;

namespace SimpleRESTclient
{
    public partial class MainPage : ContentPage
    {
        private const int weeksInYear = 52;

        public MainPage()
        {
            InitializeComponent();

            fillServiceInfo();
            showMicrochartsExample();
        }
        public void fillServiceInfo()
        {
            //agh weather service data are in DataDevice
            this.pathEntry.Text = DataService.serviceUrl;
        }

        public void fillDefaultPathEntry()
        {
            //Sign up for a free API key at http://openweathermap.org/appid  
            string key = "8812761dc6a41a9f49d8e0290394c618";
            string queryString = "http://api.openweathermap.org/data/2.5/weather?id=3094802&appid=" + key + "&units=imperial";

            this.pathEntry.Text = queryString;
        }

        public void showMicrochartsExample()
        {
            List<Microcharts.Entry> tempWeekly = new List<Microcharts.Entry>();

            tempWeekly.Add(new Microcharts.Entry(0));

            var chart = new LineChart()
            {
                Entries = tempWeekly,
                LineMode = LineMode.Straight,
                LineSize = 6,
            };

            this.chartView.Chart = chart;
        }

        public void showWeatherMicrochart(List<Weather> data)
        {
            List<Microcharts.Entry> plotList = new List<Microcharts.Entry>();

            foreach(Weather samle in data)
            {
                float fTemp = float.Parse(samle.Temperature, CultureInfo.InvariantCulture.NumberFormat);
                plotList.Add(new Microcharts.Entry(fTemp));
            }

            var chart = new LineChart()
            {
                Entries = plotList,
                LineMode = LineMode.Spline,
                LineSize = 6,
            };

            this.chartView.Chart = chart;
        }

        private async Task btnAvr_ClickedAsync(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(pathEntry.Text))
            {
                string requestUrl = pathEntry.Text + DataService.avrSufix;
                Weather weather = await DataService.GetWeatherDataFromService(requestUrl);
                labelMax.Text = weather.getWetherString();
            }
            else
            {
                labelAvr.Text = "unexpected error, sorry";
            }
        }

        private async Task btnMax_ClickedAsync(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(pathEntry.Text))
            {
                string requestUrl = pathEntry.Text + DataService.maxSufix;
                Weather weather = await DataService.GetWeatherDataFromService(requestUrl);
                labelMax.Text = weather.getWetherString();
            }
            else
            {
                labelMax.Text = "unexpected error, sorry";
            }
        }

        private async Task btnMin_ClickedAsync(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(pathEntry.Text))
            {
                string requestUrl = pathEntry.Text + DataService.minSufix;
                Weather weather = await DataService.GetWeatherDataFromService(requestUrl);
                labelMax.Text = weather.getWetherString();
            }
            else
            {
                labelMin.Text = "unexpected error, sorry";
            }
        }

        private async Task btnChart_ClickedAsync(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(pathEntry.Text))
            {
                string requestUrl = pathEntry.Text + DataService.plotSufix;
                List<Weather> weatherList = await DataService.GetWeatherListFromService(requestUrl);
                showWeatherMicrochart(weatherList);
            }
        }
    }
}

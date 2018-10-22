using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Newtonsoft.Json;
using Microcharts;
using SkiaSharp;

namespace SimpleRESTclient
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            fillDefaultPathEntry();
            showMicrochartsExample();
            
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
            var entries = new[]
             {
                 new Microcharts.Entry(-4)
                 {
                     Label = "1"
                 },
                 new Microcharts.Entry(2)
                 {
                     Label = "2",
                 },
                 new Microcharts.Entry(5)
                 {
                     Label = "3"
                 },
                 new Microcharts.Entry(10)
                 {
                     Label = "4",
                 },
                 new Microcharts.Entry(15)
                 {
                     Label = "5"
                 },
                 new Microcharts.Entry(22)
                 {
                     Label = "6",
                 },
                 new Microcharts.Entry(25)
                 {
                     Label = "7"
                 },
                 new Microcharts.Entry(22)
                 {
                     Label = "8",
                 },
                 new Microcharts.Entry(15)
                 {
                     Label = "9"
                 },
                 new Microcharts.Entry(6)
                 {
                     Label = "10",
                 },
                 new Microcharts.Entry(0)
                 {
                     Label = "11"
                 },
                 new Microcharts.Entry(-3)
                 {
                     Label = "12",
                 },

            };

            var chart = new LineChart()
            {
                Entries = entries,
                LineMode = LineMode.Straight,
                LineSize = 8,
            };

            this.chartView.Chart = chart;
        }

        private async Task nextBtn_ClickedAsync(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(pathEntry.Text))
            {
                Weather weather = await WetherService.GetWeather(pathEntry.Text);
                outputLabel.Text = weather.getWetherString();
            }
            else
            {
                outputLabel.Text = "unexpected error, sorry";
            }
        }

        private void nextBtn_Clicked(object sender, EventArgs e)
        {

        }
    }
}
